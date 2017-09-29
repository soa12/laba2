using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Test
    {
        [DisplayName("Дата рождения")]
        [DataType(DataType.Date)]
        DateTime days { get; set; }
    }
}