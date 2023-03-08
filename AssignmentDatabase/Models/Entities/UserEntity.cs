using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDatabase.Models.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; }







        [Required]
        public int DepartmentId { get; set; }
        public DepartmentEntity Departments { get; set; } = null!;

        [Required]
        public int TicketId { get; set; }
        public TicketEntity Tickets { get; set; } = null!;

        [Required]
        public int CommentId { get; set; }
        public CommentEntity Comments { get; set; } = null!;
    }
}
