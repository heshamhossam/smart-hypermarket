using SmartHyperMarket.Common.Controllers;
using SmartHyperMarket.Common.Models;
//using SmartHyperMarket.Common.StubModels;
using SmartHyperMarket.StorageManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SmartHyperMarket.StorageManager.Controllers
{
    public class OrderController
    {
        private OrdersListingPage _orderListingPage;

        public Response openOrder(params Input[] inputs)
        {
            Response response = new Response();

            Input id = inputs.Where(input => input.Name == "id").ElementAt(0);
            Input confirmationCode = inputs.Where(input => input.Name == "confirmationCode").ElementAt(0);

            if (id == null || id.Value == "")
                response.Errors.Add(new Error("Order id can't be empty."));

            if (confirmationCode == null || confirmationCode.Value == "")
                response.Errors.Add(new Error("Confirmation Code can't be empty."));

            if (response.Errors.Count > 0)
                response.State = ResponseState.FAIL;
            else
            {
                //search order in the market
                Order order = Market.getInstance().Orders.Find((Order o) => (o.Id == id.Value && o.Confirmation_code == confirmationCode.Value));

                if (order != null)
                {
                    response.State = ResponseState.SUCCESS;
                    OrderDetailsWindow orderPopup = new OrderDetailsWindow(order);
                    orderPopup.Show();
                }
                else
                {
                    response.Errors.Add(new Error("Wrong Order ID/Confirmation Code Combination."));
                    response.State = ResponseState.FAIL;
                }
            }


            return response;
        }

        public Response showOrders(OrdersListingPage orderListingPage)
        {
            Response response = new Response();

            _orderListingPage = orderListingPage;

            List<Order> ordersWaiting = Market.getInstance().Orders.FindAll((Order order) => order.State == Order.WAITING);
            _orderListingPage.changeLinks(ordersWaiting);
            Thread T = new Thread(Refresh);
            T.Start();

            response.State = ResponseState.SUCCESS;
            return response;
        }

        private void Refresh()
        {
            while(true)
            {
                int timer = 3000;
                Thread.Sleep(timer);
                Market.getInstance().refreshOrders();
                List<Order> ordersWaiting = Market.getInstance().Orders.FindAll((Order order) => order.State == Order.WAITING);
                _orderListingPage.Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() => { _orderListingPage.changeLinks(ordersWaiting); }));

            }
        }

        internal Response updateOrderState(Order order, params Input[] inputs)
        {
            Response response = new Response();
            Input state = inputs.Where(input => input.Name == "state").ElementAt(0);

            if (state == null || state.Value == "")
                response.Errors.Add(new Error("Order state can't be empty."));

            if (!order.isAllowableState(state.Value))
                response.Errors.Add(new Error("Order state " + state.Value + " isn't acceptable."));

            if (response.Errors.Count > 0)
                response.State = ResponseState.FAIL;
            else
            {
                order.State = state.Value;
                bool orderUpdated = order.update();

                if (orderUpdated)
                    response.State = ResponseState.SUCCESS;
                else
                {
                    response.Errors.Add(new Error("Unknown Error Happened While Updating Order State."));
                    response.State = ResponseState.FAIL;
                }
            }

            return response;
        }
    }
}
