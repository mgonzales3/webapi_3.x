using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CSharp.models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CSharp.Services
{
    public class OrderService : IOrderService
    {
        private readonly DBRepository _config;

        public OrderService(DBRepository config)
        {
            this._config = config;
        }

        public List<UserOrders> AllOrders()
        {
            return GetOrders();
        }

        public bool CancelOrder (int orderid)
        {
            return this.Cancel(orderid);
        }

        private bool Cancel(int OrderID)
        {
            bool mret = false;
            string sql = "Update Orders (Status) VALUES(999)";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(_config.ConnectionString.ConnectionString))
            {
                SqlMapper.Execute(conn, sql);
                mret = true;
            }

            return mret;
        }

        bool IOrderService.Create()
        {
            bool mret = false;
            string sql = "INSERT INTO Orders (Status, Note) VALUES(0, 'waiting for next process')";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(_config.ConnectionString.ConnectionString))
            {
                SqlMapper.Execute(conn, sql);
                mret = true;
            }

            return mret;
        }

        private List<UserOrders> GetOrders()
        {
            List<UserOrders> mret;
            string sql = "SELECT * FROM Orders WHERE Status <> 999;";

            try
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(_config.ConnectionString.ConnectionString))
                {
                    mret = SqlMapper.Query<UserOrders>(conn, sql).AsList<UserOrders>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mret;
        }

        bool IOrderService.UpdateOrder(UserOrders userorder)
        {
            bool mret;
            string sql = "Update Orders(Status, Note) VALUES(" + userorder.Status + "," + userorder.Note + ") WHERE orderid =" + userorder.ID;
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(_config.ConnectionString.ConnectionString))
            {
                SqlMapper.Execute(conn, sql);
                mret = true;
            }

            return mret;
        }
    }
}
