// File: Models/Pinpad.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace BtnNewPinpad.Models
{
    public class Pinpad
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string ParentBranch { get; set; }

        [StringLength(20)]
        public string OutletCode { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        public DateTime? RegistrationDate { get; set; }

        [StringLength(50)]
        public string SerialNumber { get; set; }

        [StringLength(50)]
        public string TerminalId { get; set; }

        [StringLength(50)]
        public string PinpadStatus { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string IpLow { get; set; }

        [StringLength(50)]
        public string IpHigh { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
