using CodeCheater.Domain.Models.Baskets;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeCheater.Application.RequestValidation
{
    public class BasketInsertRequestViewModel
    {
        public string UserName { get; set; }
       
        public List<BasketCartEntry> BasketOrders { get; set; } = new List<BasketCartEntry>();
        
    }
}
