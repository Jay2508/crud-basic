using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOpreation.Entity.Model
{

    [Table("RegisterTbl")]
    public class RegisterTbl
    {
        [Key]
        public int RegId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
