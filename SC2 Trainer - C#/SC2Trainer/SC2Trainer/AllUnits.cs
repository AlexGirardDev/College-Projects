using System.Collections.Generic;

namespace SC2Trainer
{
    class AllUnits
    {
        public int TotalUnits { get; private set; }


//UNIT PRIORITY LIST
//0-Raven
//1-Ghost
//2-Battlecruiser
//3-Marine
//4-Reaper
//5-Siege Tank
//6-Viking
//7-Banshee
//8-Thor
//9-Medivac
//10-Hellion
//11-Marauder
//12-SCV
//13-Mule
        //
        //

//14-orbitalcommand
//15-commandcenter
//16-refinery
//17-barracks
//18-engineeringbay
//19-missileturret
//20-nunker
//21-sensor tower
//22-ghostacademy
//23-factory
//24-starport
//25-armory
//26-fusion core
//27-supplydepot 
//28-planetaryfortr



  ///////////////////
 //  TUnits   //
/////////////////// 

      private readonly Unit _cc = new Unit(15, "cc", 400, 0, 72500,0, false, new List<Unit>() );
        public Unit Cc { get { return _cc; } }


        private readonly Unit _barracks = new Unit(17, "barracks", 150, 0, 47125, 0, false, new List<Unit>());
        public Unit Barracks { get { return _barracks; } }


        private readonly Unit _supplydepot = new Unit(27, "supplydepot", 100, 21750, 0, false, 8, new List<Unit>());
        public Unit SupplyDepot { get { return _supplydepot; } }



  //////////////
 //  TUnits  //
//////////////

        //Format for creating a unit is 
        //String name, int mineralCost, int gasCost, int supplyCost, String builtFrom, int buildTime, List<Unit> requiredUnits


        //Marine
        readonly Unit _tScv = new Unit(12, "scv", 50, 0, 1, "cc", 12325, 0, false, new List<Unit> { new Unit(17, "cc", 400, 0, 0 , new List<Unit>()) });
        
        public Unit Scv { get { return _tScv; } }

       


        readonly Unit _tMarine = new Unit(3, "marine", 50, 0, 1, "barracks", 18125, 0, false, new List<Unit> { new Unit(17, "barracks", 150, 0, 0, new List<Unit>()) });
        public Unit Marine{get{return _tMarine;}}

        //Reaper
        readonly Unit _tReaper = new Unit(4, "reaper", 50, 50, 1, "barracks", 32625, 0, false, new List<Unit> { new Unit(17, "barracks", 150, 0, 0, new List<Unit>()) });
        public Unit Reaper { get { return _tReaper; } }



        //Marauder
        readonly Unit _tMarauder = new Unit(11, "marauder", 100, 25, 2, "barracks", 21750, 0, false, new List<Unit> { new Unit(17, "barracks", 150, 0, 0, new List<Unit>()) });

        public Unit Marauder { get { return _tMarauder; } }


        public AllUnits()
        {
            TotalUnits = 29;
        }

       




    
    }








    
}
