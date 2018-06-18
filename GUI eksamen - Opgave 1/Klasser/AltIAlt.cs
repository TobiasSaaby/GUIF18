using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_eksamen___Opgave_1
{
    class AltIAlt
    {
        public Bistader Bistaderne { get; set; }
        public AlleMider Miderne { get; set; }
        public AltIAlt()
        {
            Bistaderne = new Bistader();
            Miderne = new AlleMider();
        }

        Bistad currentBistad = null;

        public Bistad CurrentBistad
        {
            get { return currentBistad; }
            set
            {
                if (currentBistad != value)
                {
                    currentBistad = value;
                    Bistaderne.CurrentBistad = value;
                    Miderne.CurrentBistad = value;
                }
            }
        }

    }
}
