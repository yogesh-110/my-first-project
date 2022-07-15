using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "* Name can't be blank")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Age can't be blank")]
        public int Age { get; set; }

        [Required(ErrorMessage = "* Address can't be blank")]
        public string Address { get; set; }

        [Required(ErrorMessage = "* phoneno can't be blank")]
        public int Phone { get; set; }
    }
}
