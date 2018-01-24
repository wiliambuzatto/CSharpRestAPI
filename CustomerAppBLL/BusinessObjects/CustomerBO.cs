using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerAppBLL.BusinessObjects
{
    public class CustomerBO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        [MinLength(3, ErrorMessage = "Nome deve conter mais de 3 letras")]
        [MaxLength(20, ErrorMessage = "Nome deve conter no máximo 20 letras")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string Address { get; set; }

    }
}
