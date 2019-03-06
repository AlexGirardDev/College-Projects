using System;
using System.Collections.Generic;

namespace SC2Trainer
{
    class Unit 
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public int MineralCost { get; set; }
        public int GasCost { get; set; }
        public int SupplyCost { get; set; }
        public long BuildTime { get; set; }
        public String BuiltFrom { get; set; }
        public List<Unit> RequiredBuildings { get; set; }
        public bool Building { get; set; }
        public Unit Lol { get; set; }
        public int GrantsSupply { get; set; }
        public string ScvState { get; set; }



        public List<Unit> UnitQue { get; set; }
       // public int currentQueTime { get; set; }
       

        public long BuildTimeLeft { get; set; }
        public long LastUpdate { get; set; }

        public bool HasTechLab { get; set; }

        //Base specific values
    
        public bool G1Built { get; set; }
       
       
        public bool G2Built { get; set; }
        public int Location { get; set; }


        public int WorkerRally { get; set; }
        public int UnitRally { get; set; }
//An actual Unit
        public Unit(int index, String name, int mineralCost, int gasCost, int supplyCost, String builtFrom, long buildTimeLeft, long lastUpdate ,bool building, List<Unit> requiredBuildings)
        {
            Index = index;
            Name = name;
            MineralCost = mineralCost;
            GasCost = gasCost;
            SupplyCost = supplyCost;

            BuildTimeLeft = buildTimeLeft;
            LastUpdate = lastUpdate;
            Building = building;
            BuiltFrom = builtFrom;
            RequiredBuildings = requiredBuildings;

           


            
        }

        public Unit(int index, String name, int mineralCost, int gasCost, int supplyCost, String builtFrom, long buildTimeLeft, long lastUpdate, bool building, List<Unit> requiredBuildings, int location, string scvState)
        {
            Index = index;
            Name = name;
            MineralCost = mineralCost;
            GasCost = gasCost;
            SupplyCost = supplyCost;

            BuildTimeLeft = buildTimeLeft;
            LastUpdate = lastUpdate;
            Building = building;
            BuiltFrom = builtFrom;
            RequiredBuildings = requiredBuildings;
            Location = location;
            ScvState = scvState;





        }

    



        // T Structure(Rax)
        public Unit (int index, String rax, int mineralCost, int gasCost, long buildTimeleft , long lastUpdate , bool hasTechlab, List<Unit> unitQue)
        {
            Index = index;
            Name = rax;
            MineralCost = mineralCost;
            GasCost = gasCost;
            BuildTimeLeft = buildTimeleft;
            LastUpdate = lastUpdate;
            HasTechLab = hasTechlab;
            UnitQue = unitQue;
            



            
        }
        //Temp Unit
        public Unit(int index, String name, int mineralCost, long buildTimeleft, int grantsSupply, List<Unit> unitQue)
        {
            Index = index;
            Name = name;
            MineralCost = mineralCost;
            BuildTimeLeft = buildTimeleft;
            
           // Building = building;
            GrantsSupply = grantsSupply;
            UnitQue = unitQue;

        }


        //T Structure(suppyDepot)
        public Unit (int index, String supplydepot, int mineralCost, long buildTimeleft ,long lastUpdate , bool building,int grantsSupply, List<Unit> unitQue)
        {
            Index = index;
            Name = supplydepot;
            MineralCost = mineralCost;
            BuildTimeLeft = buildTimeleft;
            LastUpdate = lastUpdate;
            Building = building;
            GrantsSupply = grantsSupply;
            UnitQue = unitQue;

        }



        

        //T CC
        public Unit(int index, String cc, int mineralCost, int gasCost, long buildTimeleft,long lastUpdate, bool building, int grantsSupply, bool g1Built, bool g2Built, List<Unit> unitQue, int location, int unitRally, int workerRally, string scvState)
       {
           Index = index;
           Name = cc;
           MineralCost = mineralCost;
           GasCost = gasCost;
           BuildTimeLeft = buildTimeleft;
           LastUpdate = lastUpdate;
           Building = building;
           GrantsSupply = grantsSupply;
         
           G1Built = g1Built;
    
           G2Built = g2Built;
           UnitQue = unitQue;
            Location = location;
            UnitRally = unitRally;
            WorkerRally = workerRally;
            ScvState = scvState;


       }

   }
}
