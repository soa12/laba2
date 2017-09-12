using System;
using System.Collections.Generic;
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
        [MaxLength(100)]
        public string FIO { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        



    }
}
