using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GUI_eksamen___Opgave_2.Models
{
    public class HiveReport
    {
        [Key]
        public string id;
        public Beehive beehive;
        public int mites;
        public DateTime dateTime;
    }
}