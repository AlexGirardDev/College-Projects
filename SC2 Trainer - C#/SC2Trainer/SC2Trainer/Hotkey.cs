using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SC2Trainer
{
    class Hotkey
    {
        public List<string> letter { get; set; }
        public bool control { get; set; }
        public bool alt { get; set; } 
        public bool shift {get;set;}
        public Unit unit {get;set;}

        public Hotkey(List<string> letter ,bool control,bool alt, bool shift, Unit unit)
        {
            this.letter = letter;
            this.alt = alt;

            this.control = control;
            this.shift = shift;
            this.unit = unit;


            


        }







       

    }
}
