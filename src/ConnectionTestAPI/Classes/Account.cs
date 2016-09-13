using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectionTestAPI.Classes
{
    [Table("account")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Account(){}

        public Account(int setId, string setName)
        {
            Id = setId;
            Name = setName;
        }
    }
}
