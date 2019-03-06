using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SC2Trainer
{
    class Building
    {
        public int index { get; set; }
        public string name { get; set; }
        public int mineralCost { get; set; }
        public int gasCost { get; set; }
        public int buildTimeLeft { get; set; }
        public bool hasTechLab { get; set; }

        //Base specific values
        public int M1Workers { get; set; }
        public int G1Workers { get; set; }
        public bool G1Built { get; set; }
       
        public int G2Workers { get; set; }
        public bool G2Built { get; set; }
        
       
       public Building(int index,String name, int mineralCost, int gasCost, int buildTimeleft,bool hasTechlab)
        {
            this.index = index;
            this.name = name;
            this.mineralCost = mineralCost;
            this.gasCost = gasCost;
            this.buildTimeLeft = buildTimeleft;
            this.hasTechLab = hasTechLab;



            
        }
       public Building(int index, String name, int mineralCost, int gasCost, int buildTimeleft, bool hasTechlab, int m1Workers, int g1Workers,bool g1built, int gas2Workers,bool g2built)
       {
           this.index = index;
           this.name = name;
           this.mineralCost = mineralCost;
           this.gasCost = gasCost;
           this.buildTimeLeft = buildTimeleft;
           this.hasTechLab = hasTechLab;
           this.M1Workers = m1Workers;
           this.G1Workers = g1Workers;
           this.G1Built = g1built;
           this.G2Workers = G2Workers;
           this.G2Built = g2built;





       }



    }
}
