using System;
using NUnit.Framework;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;

namespace CSharpSpecFlow.StepDefinitions
{
    [Binding]
    public class CheckoutSteps
    {
        private BillDC bill;
        private List<OrderDC> orders = new();

        [Given(@"the order includes:")]
        public void GivenTheOrderIncludes(Table table)
        {
            foreach (var order in table.CreateSet<OrderDC>())
                orders.Add(order);
        }

        [Given(@"a customer cancels (.*) starter, (.*) main, and (.*) drink")]
        public void GivenACustomerCancelsStarterMainAndDrink(int starters, int mains, int drinks)
        {
            if (orders.Count > 0)
            {
                orders[0].Mains -= mains;
                orders[0].Drinks -= drinks;
                orders[0].Starters -= starters;
            }
            else
                throw new InvalidOperationException("Cannot cancel items from an empty order.");
        }

        [When(@"the checkout is requested")]
        public void WhenTheCheckoutIsRequested()
        {
            var response = ApiManager.Post("/api/checkout", orders);
            bill = JsonConvert.DeserializeObject<BillDC>(response);
        }

        [Then(@"the bill should consist of price (.*), service charge (.*) and total (.*)")]
        public void ThenTheBillShouldConsistOfPriceServiceChargeAndTotal(double price, double serviceCharge, double total)
        {
            Assert.That(bill.Price, Is.EqualTo(price));
            Assert.That(bill.Total, Is.EqualTo(total));
            Assert.That(bill.ServiceCharge, Is.EqualTo(serviceCharge));
        }
    }
}