using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTodos.Models
{
    public class Todos
    {
        [Key]
        public int TodoId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string TodoName { get; set; } = "";

        [Column(TypeName = "nvarchar(300)")]
        public string TodoDesc { get; set; } = "";

        // dd/mm/yyyy

        [Column(TypeName = "nvarchar(10)")]
        public string TodoCreateDate { get; set; } = "";

        [Column(TypeName = "nvarchar(10)")]
        public string TodoTargetDate { get; set; } = "";
    }
}
