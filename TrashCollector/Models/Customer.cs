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
        public string PickupDay { get; set; }
        public string FirstName { get; set; }
        public string LastDay { get; set; }
        public int ExtraPickupDate { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public double Balance { get; set; }
        public string SuspendedStart { get; set; }
        public string SuspendedEnd { get; set; }
        public bool PickupConfirm { get; set; }


    }
}