using CSharp.models;
using CSharp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public UserOrdersController(IOrderService svc)
        {
            _orderService = svc;
        }

        // GET: api/userorders/
        [HttpGet(Name="AllOrders")]
        public List<UserOrders> AllOrders()
        {   
            return _orderService.AllOrders();
        }

        // PUT: api/userorders/cancelorder/1
        [HttpPut("{orderid}",Name ="CancelOrder")]
        public bool CancelOrder(int orderid)
        {
            return _orderService.CancelOrder(orderid);
        }

        [HttpPost(Name = "createorder")]
        public bool CreateOrder()
        {
            return _orderService.Create();
        }

        [HttpPut("{userorder}", Name = "UpdateOrder")]
        public bool UpdateOrder(UserOrders userorder)
        {
            return _orderService.UpdateOrder(userorder);
        }
    }
}
