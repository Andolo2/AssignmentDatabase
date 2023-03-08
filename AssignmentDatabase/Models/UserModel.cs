using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDatabase.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreationTime { get; set; }
        public DateTime ModifiedDate { get; set; }



        public string TicketText { get; set; } = null!;

        public string Status { get; set; } = null!;



        public string Comment { get; set; } = null!;
    }
}
