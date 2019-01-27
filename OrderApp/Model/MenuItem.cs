using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Model
{
    public class MenuItem
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }


        public ICollection<OrderMenuItem> Orders { get; set; } = new List<OrderMenuItem>();

    }
}
