using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        public Customer()
        {

        }
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [DisplayName("Pickup Day (day of week)")]
        public string pickupDay { get; set; }

        [DisplayName("First Name")]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [DisplayName("Extra Pickup (day of month)")]
        public int extraPickupDate { get; set; }

        [DisplayName("Street Address")]
        public string streetAddress { get; set; }

        [DisplayName("City Name")]
        public string city { get; set; }

        [DisplayName("State Name (abbr)")]
        public string state { get; set; }

        [DisplayName("Zip Code")]
        public int zip { get; set; }

        [DisplayName("Account Balance (due)")]
        public double balance { get; set; }

        [DisplayName("Suspend Service - Start Date")]
        public string suspendedStart { get; set; }

        [DisplayName("Suspend Service - End Date")]
        public string suspendedEnd { get; set; }

        [DisplayName("Garbage Picked Up?")]
        public bool pickupConfirm { get; set; }
    }
}