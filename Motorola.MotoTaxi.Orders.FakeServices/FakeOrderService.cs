﻿using Motorola.MotoTaxi.Orders.DomainModels;
using Motorola.MotoTaxi.Orders.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Motorola.MotoTaxi.Orders.FakeServices
{
    public class FakeOrderService : IOrderService
    {
        private IList<Order> orders;

        public FakeOrderService()
        {
            orders = new List<Order>();
        }

        public void Add(Order entity)
        {
            orders.Add(entity);
        }

        public void Cancel(int id)
        {
            throw new NotImplementedException();
        }

        public void Complete(int id, Location destination)
        {
            throw new NotImplementedException();
        }

        public void Confirm(int id)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            return orders.SingleOrDefault(p => p.Id == id);
        }

        public void Start(int id, Location start)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entyity)
        {
            throw new NotImplementedException();
        }
    }
}
