using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDatabase.Models.Entities
{
    public class TicketEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Description { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime? CreationTime { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        [StringLength(50)]
      
        public string Status { get; set; } = null!;

        [StringLength(500)]
        public string TicketText { get; set; } = null!;

        public ICollection<UserEntity> Tickets = new HashSet<UserEntity>();
    }
}
