using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace WebShop.Core
{
    public class CustomerStatus : Entity<int>
    {
        public CustomerStatus()
        {
        }

        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
