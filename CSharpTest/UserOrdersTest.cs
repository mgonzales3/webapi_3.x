using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Services;

namespace CSharpTest
{
    [TestClass]
    public class UserOrdersTest
    {
        IWebHostBuilder _webHostBuilder;
        TestServer _server;
        HttpClient _client;
        readonly IOrderService _orderService;

        public UserOrdersTest(IOrderService svc)
        {
            _server = new TestServer(new WebHostBuilder()
           .UseStartup<CSharp.Startup>());
            _client = _server.CreateClient();
            _orderService = svc;
            
    }

        [TestMethod]
        public void AllOrdersTest()
        {
            var userorderController = new CSharp.Controllers.UserOrdersController(_orderService);
            var result = _orderService.AllOrders();

           

        }
    }
}
