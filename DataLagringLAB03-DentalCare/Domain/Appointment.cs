using System;

namespace DataLagringLAB03_DentalCare.Domain
{
    class Appointment
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }

}
