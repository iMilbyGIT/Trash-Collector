using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        
        [Key]
        public int Id { get; set; }
        public string pickupDay { get; set; }
        public string firstName { get; set; }
        public string lastDay { get; set; }
        public int extraPickupDate { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public double balance { get; set; }
        public string suspendedStart { get; set; }
        public string suspendedEnd { get; set; }
        public bool pickupConfirm { get; set; }


    }
}