using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdamS.OnlineStore.BusinessInterfaces;
using AdamS.OnlineStore.DomainModel;
using AdamS.OnlineStore.Models;
using AdamS.OnlineStore.RepositoryInterfaces;
using AdamS.OnlineStore.Models;

namespace AdamS.OnlineStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly INotificationProvider _notificationProvider;
        private readonly IOrderRepository _ordersRepository;
        private readonly ILogger _logger;

        public CustomerController(ICustomerRepository customerRepository, INotificationProvider notificationProvider, IOrderRepository ordersRepository, ILogger logger)
        {
            _customerRepository = customerRepository;
            _notificationProvider = notificationProvider;
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        public ActionResult Index()
        {
            var allCustomers = _customerRepository.Get();

            return View(allCustomers);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var customerHasOrders = _ordersRepository.Get(id).Count > 0;

                if (customerHasOrders)
                {
                    return Content("Unable to delete customer due to existing invoices.");
                }

                _customerRepository.Delete(id);

                var statusMessage = string.Format("Customer Deleted : {0}", id);

                _notificationProvider.Send("admin@mycompany.com", "Customer Deleted", statusMessage);

                _logger.Info(statusMessage);

                return Content(statusMessage);

            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error Deleting Customer Id: {0}", id);

                return Content("Unable to delete customer");
            }

        }

    }
}