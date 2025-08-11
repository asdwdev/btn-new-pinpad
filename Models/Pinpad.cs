namespace BtnNewPinpad.Models
{
    public class Pinpad
    {
        public int Id { get; set; }

        public required string Region { get; set; }          // Regional
        public required string ParentBranch { get; set; }    // Cabang Induk
        public required string OutletCode { get; set; }      // Kode Outlet
        public required string Location { get; set; }        // Location

        public required DateTime RegistrationDate { get; set; }  // Register
        public required DateTime UpdateDate { get; set; }        // Update Date

        public required string SerialNumber { get; set; }    // Serial Number
        public required string TerminalId { get; set; }      // TID (Terminal ID)

        public required string PinpadStatus { get; set; }    // Status Pinpad

        public required string CreatedBy { get; set; }       // Create By

        public required string IpLow { get; set; }           // IP Low
        public required string IpHigh { get; set; }          // IP High

        public DateTime? LastActivity { get; set; }   // Last Activity
    }
}
