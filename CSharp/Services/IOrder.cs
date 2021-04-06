using CSharp.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Services
{
    public interface IOrderService
    {

        //List all orders by customer endpoint
        List<UserOrders> AllOrders();

        //Create order endpoint
        bool Create();  

        //Update order endpoint
        bool UpdateOrder(UserOrders userorder);

        //Cancel order endpoint
        bool CancelOrder(int OrderID);
    }
}
