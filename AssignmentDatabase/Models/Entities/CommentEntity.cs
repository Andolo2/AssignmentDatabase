using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentDatabase.Models.Entities
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(500)]
        public string Comment { get; set; } = null!;
    }
}
