using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEntity
{
    public class UserModel  //DbSet<UesrMode>
    {
        [Key]
        //How to disable identity property
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }//pk

        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }

    }
}
