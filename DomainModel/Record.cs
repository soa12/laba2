using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class Record
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [MaxLength(50)]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(16)]
        public string PhoneNumber { get; set; }

        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        



    }
}
