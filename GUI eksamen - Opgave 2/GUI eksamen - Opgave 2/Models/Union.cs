using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GUI_eksamen___Opgave_2.Models
{
    public class Union
    {
        [Key]
        public string id;
        public List<Beehive> beehives;
        public string name;
    }
}