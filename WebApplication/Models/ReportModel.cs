using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using DomainModel;

namespace WebApplication.Models
{
    public class ReportModel : Record
    {
        [DisplayName("Исполняется")]
        public int age { get; set; }

        [DisplayName("Через дней")]
        public int inDays { get; set; }

        [DisplayName("Дней вперед")]
        public int days { get; set; }
    }
}