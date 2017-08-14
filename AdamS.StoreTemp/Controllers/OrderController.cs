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
    public class OrderController : Controller
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly INotificationProvider _notificationProvider;
        private readonly IOrderRepository _ordersRepository;
        private readonly ILogger _logger;

        public OrderController(ICustomerRepository customerRepository, INotificationProvider notificationProvider, IOrderRepository ordersRepository, ILogger logger)
        {
            _customerRepository = customerRepository;
            _notificationProvider = notificationProvider;
            _ordersRepository = ordersRepository;
            _logger = logger;
        }

        public ActionResult Index()
        {
            var allOrders = _ordersRepository.Get();

            return View(allOrders);
        }

        


    }
}
