using AdamS.OnlineStore.DataDependenciesWithDB;
using AdamS.OnlineStore.DomainModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdamS.OnlineStore.DataDependenciesWithDBTst
{

    [TestFixture]
    public class TestDataDependenciesWithDBTst
    {

        IEnumerable<Customer> _customers;

        IEnumerable<Order> _orders;
        [Test]
        public void CustomerRepositoryTest()
        {
            CustomerRepository cr = new CustomerRepository();
            _customers =cr.Get();

            Assert.AreEqual(5, _customers.Count());
            string brk = "";
        }

        [TestCase(3)]
        public void CustomerDelete(int id)
        {
            string msg = string.Empty;
            try
            {
                CustomerRepository _customerRepository = new CustomerRepository();
                OrderRepository _ordersRepository = new OrderRepository();
                var customerHasOrders = _ordersRepository.Get(id).Count > 0;

                if (customerHasOrders)
                {
                    msg = "Unable to delete customer due to existing invoices.";
                    Assert.Fail();
                }
                else
                {
                    _customerRepository.Delete(id);
                    msg = string.Format("Customer Deleted : {0}", id);
                }
                TestContext.Out.WriteLine("msg = " + msg);
            }
            catch (Exception ex)
            {
                string ss = string.Empty;
            }
        }

        [Test]
        public void OrderRepositoryTest()
        {
            OrderRepository or = new OrderRepository();
            _orders = or.Get();
            Assert.AreEqual(2, _orders.Count());
            string brk = "";
        }
    }
}
