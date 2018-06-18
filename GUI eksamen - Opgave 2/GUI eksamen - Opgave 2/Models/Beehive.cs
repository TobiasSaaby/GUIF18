using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GUI_eksamen___Opgave_2.Models
{
    public class Beehive
    {
        [Key]
        public string id;
        public string name;
        public List<HiveReport> hiveReports;
    }
}