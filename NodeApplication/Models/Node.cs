using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodeApplication.Models
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }
        [Required]
        public string NodeName { get; set; }
        public int? ParentNodeId { get; set; }
        [DisplayName("IsActive")]
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }

        
        
    }
}
