using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kriptoProTask
{
    [Table("kriptoProdb")]
    public class Model
    {
       
        [Key]
        public Guid ProcessID { get; set; } = Guid.NewGuid();
        public long Number { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
