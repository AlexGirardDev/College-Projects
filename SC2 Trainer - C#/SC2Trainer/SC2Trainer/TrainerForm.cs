using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace SC2Trainer
{
    public partial class TrainerForm : Form
    {
        ///////////////////
        //Game mode Ideas//
        //////////////////


        //////////////////////
        //Polish To Do list//
        ////////////////////

        //


        //////////////////////
        //Engine To Do List//
        ////////////////////

        //Design and Impliment "Current unit location"   
        //////Add building Rally
        //////Add intuative Unit moving but how?    
        //////Unit location required for buildings    
        //////Should i add building lifting?Does it even matter  
        //////

        //Fix Game income based on SCV Location

        //Fix Stop/Reset Button    

        //Design and impliment  entire hotkey system    

        // Add Inheritance in the Unit class for Buildigns


        /////////////////////
        //To do list in order
        /////////////////////


        //Add barracks and building units
        //What else do i need at this point before hotekys?

        //
        //
        //
        //
        //
        //


        /////////////////////////////
        //Known Bugs
        /////////////////////////////
        //SCV Building can be buggy
        // FIXED Base Picture boxes are buggy as fuck once you have more Command center
        //Add key validation
        //Figure out a new fucking way to do time
        //


        //These are dobles for better accuracy
        // ReSharper restore FieldCanBeMadeReadOnly.Local


        private readonly AllUnits _allUnits = new AllUnits(); //
        private readonly List<PictureBox> _abilPb = new List<PictureBox>();
        private readonly List<ProgressBar> _baseProgB = new List<ProgressBar>();


        // List<Unit> Units = new List<Unit>();


        private readonly List<List<Unit>> _controlG1 = new List<List<Unit>>();
        private readonly List<List<Unit>> _controlG10 = new List<List<Unit>>();
        private readonly List<List<Unit>> _controlG2 = new List<List<Unit>>();
        private readonly List<List<Unit>> _controlG3 = new List<List<Unit>>();
        private readonly List<List<Unit>> _controlG4 = new List<List<Unit>>();
        private readonly List<List<Unit>> _controlG5 = new List<List<Unit>>();
        private readonly List<List<Unit>> _controlG6 = new List<List<Unit>>();
        private readonly List<List<Unit>> _controlG7 = new List<List<Unit>>();
        private readonly List<List<Unit>> _controlG8 = new List<List<Unit>>();
        private readonly List<List<Unit>> _controlG9 = new List<List<Unit>>();
        private List<List<Unit>> _tempGetLocationUnitList = new List<List<Unit>>();
        private readonly List<PictureBox> _selectPb = new List<PictureBox>();
        // ReSharper disable FieldCanBeMadeReadOnly.Local
       // private Stopwatch _swTickStart = new Stopwatch();
        // ReSharper restore FieldCanBeMadeReadOnly.Local
        private int _currentLocationIndex;
        private int _currentCommandCardIndex;
        private Unit _tempBuildingForPlacing;
        private double _currentGas; //Current Gas
        private double _currentMin; //Current minerals
        private int _currentSelectionIndex;
        private int _currentSupp; //Current supply (?/200)
        private int _currentTSupp; //Current Max supply(50/?)
        private readonly List<List<Unit>> _currentUnits = new List<List<Unit>>();
        private long _elapsedTime = 40;
      // private long _testWatch.ElapsedMilliseconds;
        private double _gasUpdaterate; //Gas per game update
        private double _minUpdaterate; //Minerals per  game clear
        private readonly List<List<Unit>> _selectedUnits = new List<List<Unit>>();
        private int _startGas; //Starting Gas
        private int _startMin; //Starting minerals
        private readonly List<Button> _cmdLocation = new List<Button>();
        private const int RefreshDelay = 2;
        private readonly Timer _GameLoopTimer = new Timer { Interval = RefreshDelay };
        private readonly Stopwatch _testWatch = new Stopwatch();
        private long _tempElapsedTime;
        private long _test10Scvcount;
        private long _test10Scvstart;

    private long _testQueTimeLength ;
         
 

        public enum Locations
           


        {
            Rally,
            First,
            Second,
            Third,
            Forth,
            Fifth,
            Sixth,
            Seventh,
            Battle,
        }



        public TrainerForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }


        //Build T Units'
        private void BuildTscv()
        {
            if (_currentSelectionIndex != _allUnits.Cc.Index) return;
            int i = GetQueBuildingIndex();

            _currentUnits[_currentSelectionIndex][i].UnitQue.Add(new Unit(12, "scv", 50, 0, 1, "cc", 12325,0, false,
                                                                          new List<Unit>
                                                                              {
                                                                                  new Unit(17, "cc", 400, 0, 0, new List<Unit>())
                                                                              }, _currentUnits[_currentSelectionIndex][i].WorkerRally, _currentUnits[_currentSelectionIndex][i].ScvState));

        }


        private void BuildTMarine()
        {
            if (_currentSelectionIndex != _allUnits.Barracks.Index) return;
            int i = GetQueBuildingIndex();

            _currentUnits[_currentSelectionIndex][i].UnitQue.Add(new Unit(3, "marine", 50, 0, 1, "barracks", 18125,0, false, new List<Unit> { new Unit(17, "barracks", 150, 0, 0, new List<Unit>()) }));

        }

      
        //Build T Units
        /*
                private void BuildTcc(int m1Workers, int g1Workers, bool g1Built, int g2Workers, bool g2Built)
                {
                    _currentUnits[_allUnits.T_CC.index].Add(
                        new Unit(_allUnits.T_CC.index, _allUnits.T_CC.name,
                                 _allUnits.T_CC.mineralCost, _allUnits.T_CC.gasCost,
                                 _allUnits.T_CC.buildTimeLeft, false, false,
                                 m1Workers,
                                 g1Workers, g1Built,
                                 g2Workers, g2Built, new List<Unit>()));


                    adjustBuildValues(_allUnits.T_CC);
                }
        */

        private void BuildBuilding(Unit building,int location)
        {
            building.Building = true;
            building.Location = location;


            _currentUnits[building.Index].Add(building);

            if (_currentUnits[_allUnits.Cc.Index].Count <= 3&& building.Index == _allUnits.Cc.Index)
            {
                _baseProgB[_currentUnits[_allUnits.Cc.Index].Count - 1].Maximum = 72000 + 33;
                _baseProgB[_currentUnits[_allUnits.Cc.Index].Count - 1].Value = 72000;
            }


            AdjustBuildValues(_allUnits.Cc);
        }


        #region ControlGroups
        //Control groups
        private void BtnCtrl1Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                CopyUnitList(_selectedUnits, _controlG1);
            }
            else
            {
                CopyUnitList(_controlG1, _selectedUnits);
            }
            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void BtnCtrl2Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                CopyUnitList(_selectedUnits, _controlG2);
            }
            else
            {
                CopyUnitList(_controlG2, _selectedUnits);
            }
            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void BtnCtrl3Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                CopyUnitList(_selectedUnits, _controlG3);
            }
            else
            {
                CopyUnitList(_controlG3, _selectedUnits);
            }


            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void BtnCtrl4Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                CopyUnitList(_selectedUnits, _controlG4);
            }
            else
            {
                CopyUnitList(_controlG4, _selectedUnits);
            }
            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void BtnCtrl5Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                CopyUnitList(_selectedUnits, _controlG5);
            }
            else
            {
                CopyUnitList(_controlG5, _selectedUnits);
            }
            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void BtnCtrl6Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                CopyUnitList(_selectedUnits, _controlG6);
            }
            else
            {
                CopyUnitList(_controlG6, _selectedUnits);
            }
            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void BtnCtrl7Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                CopyUnitList(_selectedUnits, _controlG7);
            }
            else
            {
                CopyUnitList(_controlG7, _selectedUnits);
            }
            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void BtnCtrl8Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                CopyUnitList(_selectedUnits, _controlG8);
            }
            else
            {
                CopyUnitList(_controlG8, _selectedUnits);
            }
            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void BtnCtrl9Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                CopyUnitList(_selectedUnits, _controlG9);
            }
            else
            {
                CopyUnitList(_controlG9, _selectedUnits);
            }
            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void BtnCtrl0Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                CopyUnitList(_selectedUnits, _controlG10);
            }
            else
            {
                CopyUnitList(_controlG10, _selectedUnits);
            }
            UpdateUnitSelect();
            UpdateCommandCard();
        }
      
        #endregion

        ////////////////
        ////////////////
        //  Start up  //
        ////////////////  
        ////////////////  


        public void FillLists()
        {
            for (int i = 0; i < _allUnits.TotalUnits; i++)
            {
                _currentUnits.Add(new List<Unit>());
                _selectedUnits.Add(new List<Unit>());
                _tempGetLocationUnitList.Add(new List<Unit>());
                _controlG1.Add(new List<Unit>());
                _controlG2.Add(new List<Unit>());
                _controlG3.Add(new List<Unit>());
                _controlG4.Add(new List<Unit>());
                _controlG5.Add(new List<Unit>());
                _controlG6.Add(new List<Unit>());
                _controlG7.Add(new List<Unit>());
                _controlG8.Add(new List<Unit>());
                _controlG9.Add(new List<Unit>());
                _controlG10.Add(new List<Unit>());
            }

            for (int i = 0; i < _allUnits.TotalUnits; i++)
            {
                _currentUnits.Add(new List<Unit>());
                _selectedUnits.Add(new List<Unit>());
            }
            _baseProgB.Add(progressBar1);
            _baseProgB.Add(progressBar2);
            _baseProgB.Add(progressBar3);
        }

        private void AddPbUnits()
        {
            for (int i = 0; i < 24; ++i)
            {
                _selectPb.Add(Controls["pbUnit" + (i + 1).ToString(CultureInfo.InvariantCulture)] as PictureBox);
            }
        }

        private void AddPbAbil()
        {
            for (int i = 0; i < 15; ++i)
            {
                _abilPb.Add(Controls["pbAbil" + (i + 1)] as PictureBox);
            }
        }
        private void AddCmdLocation()
        {


            for (int i = 0; i < 9; i++)
            {
                _cmdLocation.Add(Controls["cmdLocation"+ i]as Button);
            }
        }

        // private void addPBabil()
        //{/
        //  for (int i = 0; i < 24; ++i)
        //{ selectPB.Add(this.Controls["pbAbil" + (i + 1).ToString()] as PictureBox); }
        //}


        //Game state Methods
        public long GetGameseconds() //Returns Current game time in Seconds(Minus the minutes)
        {
            return (_testWatch.ElapsedMilliseconds/725)%60;
            //725 is calculation from standard time to blizzard time
            //since every blizzard minute is 72.5% of a real minute
            //selectedUnits[index] {
        }

        public long GetGameminutes() //Rreturns current game time in Minutes
        {
            return (_testWatch.ElapsedMilliseconds/725)/60;
        }

        private void AdjustBuildValues(Unit unit)
        {
            _currentMin -= unit.MineralCost;
            _currentGas -= unit.GasCost;
            // currentSupp += unit.supplyCost;
            // updateValues();
        }

        public int GetQueBuildingIndex()
        {
            int lowestUnitQueCount = 5;
            long lowestTimeLeft = 1000;
            int lowestIndex = 0;
            // int firstBuildcheck = 0;
            int allEmptyCheck = 0;

            for (int i = 0; i < _selectedUnits[_currentSelectionIndex].Count; i++)
            {
                allEmptyCheck += _selectedUnits[_currentSelectionIndex][i].UnitQue.Count();
            }


            if (allEmptyCheck != 0)
            {
                for (int i = 0; i < _selectedUnits[_currentSelectionIndex].Count; i++)
                {
                    if (_selectedUnits[_currentSelectionIndex][i].UnitQue == null) continue;
                    if (_selectedUnits[_currentSelectionIndex][i].UnitQue.Count == 0)
                    {
                        if (!_selectedUnits[_currentSelectionIndex][i].Building && _selectedUnits[_currentSelectionIndex][i].BuildTimeLeft<=0)
                        { 
                        lowestIndex = i;
                        // ReSharper disable RedundantAssignment
                        lowestUnitQueCount = _selectedUnits[_currentSelectionIndex][i].UnitQue.Count();
                        // ReSharper restore RedundantAssignment
                            }

                        return lowestIndex;
                    }
                    if (_selectedUnits[_currentSelectionIndex][i].UnitQue.Count < lowestUnitQueCount)
                    {
                        lowestIndex = i;
                        lowestTimeLeft = _selectedUnits[_currentSelectionIndex][i].UnitQue[0].BuildTimeLeft;
                        lowestUnitQueCount = _selectedUnits[_currentSelectionIndex][i].UnitQue.Count();
                    }
                    else if (_selectedUnits[_currentSelectionIndex][i].UnitQue.Count == lowestUnitQueCount)
                    {
                        if (_selectedUnits[_currentSelectionIndex][lowestIndex].UnitQue[0].BuildTimeLeft <
                            lowestTimeLeft)
                        {
                            if (!_selectedUnits[_currentSelectionIndex][i].Building && _selectedUnits[_currentSelectionIndex][i].BuildTimeLeft <= 0)
                            {
                                lowestIndex = i;
                                lowestTimeLeft = _selectedUnits[_currentSelectionIndex][i].UnitQue[0].BuildTimeLeft;
                                lowestUnitQueCount = _selectedUnits[_currentSelectionIndex][i].UnitQue.Count();
                            }
                        }
                    }

                    //  lowestTimeLeft = selectedUnits[currentSelectionIndex][i].unitQue[0].buildTimeLeft;
                }
                return lowestIndex;
            }
            return 0;
        }

        private bool CheckUnitCost(Unit unit)
        {
            return unit.MineralCost < _currentMin && unit.GasCost < _currentGas;
        }

        //List Manipulation
        private void ClearUnitList(List<List<Unit>> unitList)
        {
            for (int i = 0; i < _allUnits.TotalUnits; i++)
            {
                unitList[i].Clear();
            }
        }

        private void CopyUnitList(List<List<Unit>> source, List<List<Unit>> dest)
        {
            for (int i = 0; i < _allUnits.TotalUnits; i++)
            {
                dest[i] = source[i].ToList();
            }
        }


        public void ClearSelectedUnitPb()
        {
            foreach (PictureBox t in _selectPb)
            {
                t.Image = null;
            }
        }

        public void ClearAbilPb()
        {
            foreach (PictureBox t in _abilPb)
            {
                t.Image = null;
            }
        }


        //Update Methods

        private void UpdateValues()
        {
            _minUpdaterate = (Convert.ToDouble(txtMpm.Text)/((60*0.725))/(1000.0/_elapsedTime));
            _gasUpdaterate = (Convert.ToDouble(txtGpm.Text)/((60*0.725))/(1000.0/_elapsedTime));
            //Start the game and set starting paramters
            if (_currentMin == 0)
            {
                _startMin = Convert.ToInt32(txtStartMin.Text); //Assign desrired starting minerals to startMin
                _currentMin = _startMin; //Set starting min to current minerals
            }


            if (_currentGas == 0)
            {
                _startGas = Convert.ToInt32(txtStartGas.Text); //Assign desrired starting Gas to startGas
                _currentGas = _startGas; //Set starting min to current Gas
            }


            lblMinerals.Text = Convert.ToInt32(_currentMin).ToString(CultureInfo.InvariantCulture);
            lblGas.Text = Convert.ToInt32(_currentGas).ToString(CultureInfo.InvariantCulture);
            lblSupply.Text = (_currentSupp.ToString(CultureInfo.InvariantCulture) + " / " +
                              _currentTSupp.ToString(CultureInfo.InvariantCulture));
        }


        private void UpdateSupply()
        {

            _currentSupp = 0;

            for (int i = 0; i < 13; i++)
            {
                
                _currentSupp += _currentUnits[i].Sum(tempunit => tempunit.SupplyCost);
               
            }


            for (int i = 0; i < _currentUnits[_allUnits.Cc.Index].Count; i++)
            {
                var cc = _currentUnits[_allUnits.Cc.Index][i];
                if (cc.UnitQue.Count != 0)
                {
                    if (cc.UnitQue[0].Building)
                    {
                        _currentSupp += cc.UnitQue[0].SupplyCost;
                    }
                }
            }


            _currentTSupp = 0;
            foreach (var supplyDepot in _currentUnits[_allUnits.SupplyDepot.Index])
            {

                if (!supplyDepot.Building && supplyDepot.BuildTimeLeft <=0)
                {
                    _currentTSupp += supplyDepot.GrantsSupply;
                }


            }

            foreach (var cc in _currentUnits[_allUnits.Cc.Index])
            {

                if (cc.Building && cc.BuildTimeLeft <= 0)
                {
                    _currentTSupp += cc.GrantsSupply;
                }


            }



           // _currentTSupp += _currentUnits[_allUnits.SupplyDepot.Index].Sum(supplyDepots => supplyDepots.GrantsSupply);
           _currentTSupp += _currentUnits[_allUnits.Cc.Index].Sum(supplyDepots => supplyDepots.GrantsSupply);
//


        }

        private void UpdateTime()
        {
            string min = GetGameminutes().ToString(CultureInfo.InvariantCulture);
            string sec = GetGameseconds().ToString(CultureInfo.InvariantCulture);
            string time = min + ":" + sec;


            lblTime.Text = time;
            lblRTime.Text = (_testWatch.ElapsedMilliseconds).ToString(CultureInfo.InvariantCulture);
        }

        private void UpdateUnitSelect()
        {
            UpdateTabIndex();
            ClearSelectedUnitPb();
            int currentPbIndex = 0;
            int overflowCount = 0;
            lstSupplyDepots.Items.Clear();
            //swTickStart.//

            for (int index = 0; index < _selectedUnits.Count; index++)
            {
                if (index < 14)
                {
                    for (int unit = 0; unit < _selectedUnits[index].Count && overflowCount < _selectPb.Count; unit++)
                    {
                        if (unit < _currentUnits[index].Count && _currentUnits[index].Count > unit - 1)
                        {
                            if (index == _currentSelectionIndex)
                            {
                                _selectPb[currentPbIndex].Image =
                                    Image.FromFile("T_" + _selectedUnits[index][unit].Name + "_1.jpg");
                                currentPbIndex++;
                                overflowCount++;
                            }
                            else
                            {
                                _selectPb[currentPbIndex].Image =
                                    Image.FromFile("T_" + _selectedUnits[index][unit].Name + "_0.jpg");
                                currentPbIndex++;
                                overflowCount++;
                            }
                        }

                        else
                        {
                            _selectPb[currentPbIndex].Image = null;
                            currentPbIndex++;
                            overflowCount++;
                        }
                    }
                }
        
                else
                {
                    for (int unit = 0; unit < _selectedUnits[index].Count && overflowCount < _selectPb.Count; unit++)
                    {
                        if (unit < _currentUnits[index].Count && _currentUnits[index].Count > unit - 1)
                        {
                            int queCount = _selectedUnits[index][unit].UnitQue.Count;
                            if (queCount >= 5)
                            {
                                queCount = 5;
                            }

                            if (!_selectedUnits[index][unit].Building)
                            {
                                if (index == _currentSelectionIndex)
                                {
                                    _selectPb[currentPbIndex].Image =
                                        Image.FromFile("T_" + _selectedUnits[index][unit].Name
                                                       + "_1_" + queCount + ".jpg");
                                   

                                    currentPbIndex++;
                                    overflowCount++;
                                }
                                else
                                {
                                    _selectPb[currentPbIndex].Image =
                                        Image.FromFile("T_" + _selectedUnits[index][unit].Name
                                                       + "_0_" + queCount + ".jpg");
                                    currentPbIndex++;
                                    overflowCount++;
                                }
                            }
                            else
                            {
                                if (index == _currentSelectionIndex)
                                {
                                    _selectPb[currentPbIndex].Image =
                                        Image.FromFile("T_" + _selectedUnits[index][unit].Name
                                                       + "_1_Building.jpg");

                                    currentPbIndex++;
                                    overflowCount++;
                                }
                                else
                                {
                                    _selectPb[currentPbIndex].Image =
                                        Image.FromFile("T_" + _selectedUnits[index][unit].Name
                                                       + "_0_Building.jpg");
                                    currentPbIndex++;
                                    overflowCount++;
                                }
                            }
                        }

                        else
                        {
                            _selectPb[currentPbIndex].Image = null;
                            currentPbIndex++;
                            overflowCount++;
                        }
                    }
                }

              //  if (_selectedUnits[_currentSelectionIndex].Count == 0 && pbUnit1.Image != null)
              //  {
               //     UpdateUnitSelect();
              //      UpdateCommandCard();
              //  }
            }
        }

        private void UpdateBaseIcons()
        {
            for (int i = 0; i < _cmdLocation.Count; i++)
            {
                var cmd = _cmdLocation[i];

                if ( i == _currentLocationIndex && cmd.BackColor!=Color.Red)
                {
                    cmd.BackColor = Color.Red;
                }

                if (i != _currentLocationIndex && cmd.BackColor != Color.Blue)
                {

                    cmd.BackColor = Color.Blue;
                    
                }
            }
        }

        private void UpdateTabIndex()
        {
            if (pbUnit1.Image != null)
            {
                for (int i = 0; _selectedUnits[_currentSelectionIndex].Count == 0 && i < _selectedUnits.Count*2; i++)
                     
                            if (_selectedUnits.Count - 1 == _currentSelectionIndex)
                            {
                                _currentSelectionIndex = 0;
                            }
                            else
                            {
                                _currentSelectionIndex++;
                            }
            }
        }

        
        private List<List<Unit>> GetLocationUnitList(int locationIndex)
        {
            ClearUnitList(_tempGetLocationUnitList);

            for (int i = 0; i < _currentUnits.Count; i++)
            {


                foreach (var tempunit in _currentUnits[i])
                {
                    if (tempunit.Location == locationIndex)
                    {
                        _tempGetLocationUnitList[i].Add(tempunit);
                    }
                }

            }
            return _tempGetLocationUnitList;


        }

        private void UpdateBase()
        {
            ClearUnitList(_tempGetLocationUnitList);

         _tempGetLocationUnitList = GetLocationUnitList( _currentLocationIndex);


            bool tempcheck = false;
            foreach (var cc in _currentUnits[_allUnits.Cc.Index])
            {
                if (cc.Location == _currentLocationIndex)
                {
                    pbBase0.Visible = true;
                    lblBase0MIcon.Visible = true;
                    lblBase0G1Icon.Visible = true;
                    lblBase0G2Icon.Visible = true;
                    lblBase0M.Visible = true;
                    lblBase0G1.Visible = true;

                    lblBase0G2.Visible = true;
                    progressBar1.Visible = true;


                    _tempGetLocationUnitList[_allUnits.Scv.Index].Count(r => r.ScvState.Equals("M"));

                    lblBase0M.Text =
                        _tempGetLocationUnitList[_allUnits.Scv.Index].Count(r => r.ScvState.Equals("M")).ToString(
                            CultureInfo.InvariantCulture);

                    lblBase0G1.Text =
                        _tempGetLocationUnitList[_allUnits.Scv.Index].Count(r => r.ScvState.Equals("G1")).ToString(
                            CultureInfo.InvariantCulture);

                    lblBase0G2.Text =
                        _tempGetLocationUnitList[_allUnits.Scv.Index].Count(r => r.ScvState.Equals("G2")).ToString(
                            CultureInfo.InvariantCulture);
                    tempcheck = true;


                }

                if (!tempcheck)
                {

                    pbBase0.Visible = false;
                    lblBase0MIcon.Visible = false;
                    lblBase0G1Icon.Visible = false;
                    lblBase0G2Icon.Visible = false;
                    progressBar1.Visible = false;
                    lblBase0M.Visible = false;
                    lblBase0G1.Visible = false;
                    lblBase0G2.Visible = false;
                }
            }

            //switch (_currentLocationIndex)
            //{
                    
            //    case 0:
            //        break;
            //    case 1:
            //        break;
            //    case 2:
            //        break;
            //    case 3:
            //        break;
            //    case 4:
            //        break;
            //    case 5:
            //        break;
            //    case 6:
            //        break;
            //    case 7:
            //        break;
            //    case 8:
            //        break;




            //}

                

             
            //if (_currentUnits[_allUnits.Cc.Index].Count != 0)
            //{
            //    if (_currentUnits[_allUnits.Cc.Index][0] != null)
            //    {
            //        pbBase0.Visible = true;
            //        lblBase0MIcon.Visible = true;
            //        lblBase0G1Icon.Visible = true;
            //        lblBase0G2Icon.Visible = true;
            //        lblBase0M.Visible = true;
            //        lblBase0G1.Visible = true;

            //        lblBase0G2.Visible = true;
            //        progressBar1.Visible = true;


            //        lblBase0M.Text =
            //            _currentUnits[_allUnits.Cc.Index][0].M1Workers.ToString(CultureInfo.InvariantCulture);
            //        lblBase0G1.Text =
            //            _currentUnits[_allUnits.Cc.Index][0].G1Workers.ToString(CultureInfo.InvariantCulture);
            //        lblBase0G2.Text =
            //            _currentUnits[_allUnits.Cc.Index][0].G2Workers.ToString(CultureInfo.InvariantCulture);
            //    }
            //    else
            //    {
            //        pbBase0.Visible = false;
            //        lblBase0MIcon.Visible = false;
            //        lblBase0G1Icon.Visible = false;
            //        lblBase0G2Icon.Visible = false;
            //        progressBar1.Visible = false;
            //        lblBase0M.Visible = false;
            //        lblBase0G1.Visible = false;
            //        lblBase0G2.Visible = false;

            //        //lblBase0M.Text = _currentUnits[_allUnits.T_CC.index][0].M1Workers.ToString();
            //        //lblBase0G1.Text = _currentUnits[_allUnits.T_CC.index][0].G1Workers.ToString();
            //        //lblBase0G2.Text = _currentUnits[_allUnits.T_CC.index][0].G2Workers.ToString();
            //    }
            //}

            //if (_currentUnits[_allUnits.Cc.Index].Count >= 2)
            //{
            //    if (_currentUnits[_allUnits.Cc.Index][1] != null)
            //    {
            //        //lblTest1.Text = Stopwatch.IsHighResolution.ToString();

            //        pbBase1.Visible = true;
            //        lblBase1MIcon.Visible = true;
            //        lblBase1G1Icon.Visible = true;
            //        lblBase1G2Icon.Visible = true;
            //        lblBase1M.Visible = true;
            //        lblBase1G1.Visible = true;
            //        lblBase1G2.Visible = true;

            //        lblBase1M.Text =
            //            _currentUnits[_allUnits.Cc.Index][1].M1Workers.ToString(CultureInfo.InvariantCulture);
            //        lblBase1G1.Text =
            //            _currentUnits[_allUnits.Cc.Index][1].G1Workers.ToString(CultureInfo.InvariantCulture);
            //        lblBase1G2.Text =
            //            _currentUnits[_allUnits.Cc.Index][1].G2Workers.ToString(CultureInfo.InvariantCulture);
            //    }
            //    else
            //    {
            //        pbBase1.Visible = false;
            //        lblBase1MIcon.Visible = false;
            //        lblBase1G1Icon.Visible = false;
            //        lblBase1G2Icon.Visible = false;
            //        lblBase1M.Visible = false;
            //        lblBase1G1.Visible = false;
            //        lblBase1G2.Visible = false;


            //        //lblBase1M.Text = _currentUnits[_allUnits.T_CC.index][1].M1Workers.ToString();
            //        //lblBase1G1.Text = _currentUnits[_allUnits.T_CC.index][1].G1Workers.ToString();
            //        //lblBase1G1.Text = _currentUnits[_allUnits.T_CC.index][1].G2Workers.ToString();
            //    }
            //}
            //if (_currentUnits[_allUnits.Cc.Index].Count >= 3)
            //{
            //    if (_currentUnits[_allUnits.Cc.Index][2] != null)
            //    {
            //        pbBase2.Visible = true;
            //        lblBase2MIcon.Visible = true;
            //        lblBase2G1Icon.Visible = true;
            //        lblBase2G2Icon.Visible = true;
            //        lblBase2M.Visible = true;
            //        lblBase2G1.Visible = true;
            //        lblBase2G2.Visible = true;

            //        lblBase2M.Text =
            //            _currentUnits[_allUnits.Cc.Index][2].M1Workers.ToString(CultureInfo.InvariantCulture);
            //        lblBase2G1.Text =
            //            _currentUnits[_allUnits.Cc.Index][2].G1Workers.ToString(CultureInfo.InvariantCulture);
            //        lblBase2G2.Text =
            //            _currentUnits[_allUnits.Cc.Index][2].G2Workers.ToString(CultureInfo.InvariantCulture);
            //    }
            //    else
            //    {
            //        pbBase2.Visible = false;
            //        lblBase2MIcon.Visible = false;
            //        lblBase2G1Icon.Visible = false;
            //        lblBase2G2Icon.Visible = false;
            //        lblBase2M.Visible = false;
            //        lblBase2G1.Visible = false;
            //        lblBase2G2.Visible = false;

            //        //lblBase2M.Text = _currentUnits[_allUnits.T_CC.index][2].M1Workers.ToString();
            //        //lblBase2G1.Text = _currentUnits[_allUnits.T_CC.index][2].G1Workers.ToString();
            //        //lblBase2G2.Text = _currentUnits[_allUnits.T_CC.index][2].G2Workers.ToString();
            //    }
            //}
        }
        private void UpdateBuildingConstruction()
        {
            lstSupplyDepots.Items.Clear();
            foreach (var supplyDepot in _currentUnits[_allUnits.SupplyDepot.Index])
            {
                if (supplyDepot.Building&& supplyDepot.BuildTimeLeft>0)
                {
                    supplyDepot.BuildTimeLeft -= _elapsedTime;
                    lstSupplyDepots.Items.Add("SD : " + supplyDepot.BuildTimeLeft);


                }

                if (supplyDepot.Building && supplyDepot.BuildTimeLeft <= 0)
                {
                    supplyDepot.Building = false;
                    supplyDepot.BuildTime = 0;


                }

                
            }


            for (int index = 0; index < _currentUnits[_allUnits.Cc.Index].Count; index++)
            {
                var cc = _currentUnits[_allUnits.Cc.Index][index];
                if (cc.Building && cc.BuildTimeLeft > 0)
                {
                    cc.BuildTimeLeft -= _elapsedTime;
                    lstSupplyDepots.Items.Add("CC : " + cc.BuildTimeLeft);
                }

                if (cc.Building && cc.BuildTimeLeft <= 0)
                {
                    cc.Building = false;
                    cc.BuildTime = 0;
                }
            }

            foreach (var cc in _currentUnits[_allUnits.Barracks.Index])
            {
                if (cc.Building && cc.BuildTimeLeft > 0)
                {
                    cc.BuildTimeLeft -= _elapsedTime;
                    lstSupplyDepots.Items.Add("rx : " + cc.BuildTimeLeft);


                }

                if (cc.Building && cc.BuildTimeLeft <= 0)
                {
                    cc.Building = false;
                    cc.BuildTime = 0;


                }


            }






        }
        private void UpdateCcQues()
        {


            for (int i = 0; i < _currentUnits[_allUnits.Cc.Index].Count(); i++)
            {



                if (_currentUnits[_allUnits.Cc.Index][i].UnitQue != null)
                {if (_currentUnits[_allUnits.Cc.Index][i].UnitQue.Count != 0)
                    {
                    
                    if (_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].BuildTimeLeft > 0 &&
                            !_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].Building &&
                            _currentTSupp - _currentSupp >=
                            _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].SupplyCost)
                        {
                            _currentSupp += _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].SupplyCost;
                            _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].Building = true;
                            if (_test10Scvcount == 0)
                            {
                                _test10Scvstart = _testWatch.ElapsedMilliseconds;


                            }


                                                if (_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].LastUpdate == 0)
                        {
                            _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].LastUpdate =
                                _testWatch.ElapsedMilliseconds;
                            if (i == 0)
                            {
                                _testQueTimeLength = _testWatch.ElapsedMilliseconds;
                            }
                        }
                        }


                    }
                }


                if (_currentUnits[_allUnits.Cc.Index][i].UnitQue != null)
                {
                    if (_currentUnits[_allUnits.Cc.Index][i].UnitQue.Count != 0)

                    {



 if
                        
                       (_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].BuildTimeLeft<= 
                            _testWatch.ElapsedMilliseconds -( _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].LastUpdate -5) &&
                            _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].BuildTimeLeft >= 0)
                        {
                            _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].BuildTimeLeft = 0;


                        }

                        if ((_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].Building)
                            && (_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].BuildTimeLeft>= 0))
                            /// the minus of elapsed time was due to increasing accuracy
                        {
                            


                            _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].BuildTimeLeft -=
                                _testWatch.ElapsedMilliseconds -
                                _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].LastUpdate;
                            _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].LastUpdate = _testWatch.ElapsedMilliseconds;
                        }


                    }


                }




                if (_currentUnits[_allUnits.Cc.Index][i].UnitQue != null)
                    {



                        if (_currentUnits[_allUnits.Cc.Index][i].UnitQue.Count != 0)
                        {


                            if (_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].Building
                                && _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].BuildTimeLeft <= _testWatch.ElapsedMilliseconds -
                                _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].LastUpdate +1)
                            {
                                _currentUnits[_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].Index].Add(
                                    _currentUnits[_allUnits.Cc.Index][i].UnitQue[0]);

                                long temp = _testWatch.ElapsedMilliseconds;
                                _currentUnits[_allUnits.Cc.Index][i].UnitQue.RemoveAt(0);
                                if (i == 0)
                                {
                                    lstErrors.Items.Add(_testWatch.ElapsedMilliseconds - _testQueTimeLength);
                                    _test10Scvcount++;
                                    if(_test10Scvcount ==5)
                                    {
                                        lstErrors.Items.Add("Fuck bitches " +
                                                            (_testWatch.ElapsedMilliseconds - _test10Scvstart));
                                        _test10Scvcount = 0;
                                    }
                                }


                                if (_currentUnits[_allUnits.Cc.Index][i].UnitQue.Count != 0)
                                {

                                    if (_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].BuildTimeLeft > 0 &&
                                            !_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].Building &&
                                            _currentTSupp - _currentSupp >=
                                            _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].SupplyCost)
                                    {
                                        _currentSupp += _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].SupplyCost;
                                        _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].Building = true;
                                        if (_test10Scvcount == 0)
                                        {
                                            _test10Scvstart = _testWatch.ElapsedMilliseconds;


                                        }
                                        if (_currentUnits[_allUnits.Cc.Index][i].UnitQue[0].LastUpdate == 0)
                                        {
                                            _currentUnits[_allUnits.Cc.Index][i].UnitQue[0].LastUpdate =
                                                _testWatch.ElapsedMilliseconds;
                                            if (i == 0)
                                            {
                                                _testQueTimeLength = _testWatch.ElapsedMilliseconds;
                                            }
                                        }
                                    }


                                }

                                UpdateUnitSelect();
                                UpdateCommandCard();
                                lstSpeedTest.Items.Add(_testWatch.ElapsedMilliseconds - temp);

                            }
                        }
                    }


                

            }
        }
        private void UpdateRaxQue()
            
        {
            
            for (int i = 0; i < _currentUnits[_allUnits.Barracks.Index].Count(); i++)
            {



                if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue != null)
                {
                    if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue.Count != 0)
                    {

                        if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft > 0 &&
                                !_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Building &&
                                _currentTSupp - _currentSupp >=
                                _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].SupplyCost)
                        {
                            _currentSupp += _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].SupplyCost;
                            _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Building = true;

                        }


                    }
                }


                if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue != null)
                {
                    if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue.Count != 0)
                    {



                        if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].LastUpdate == 0)
                        {
                            _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].LastUpdate =
                                _testWatch.ElapsedMilliseconds;
                            if (i == 0)
                            {
                                _testQueTimeLength = _testWatch.ElapsedMilliseconds;
                            }
                        }
                        else if

                      (_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft <=
                           _testWatch.ElapsedMilliseconds - (_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].LastUpdate - 4) &&
                           _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft >= 0)
                        {
                            _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft = 0;


                        }

                        if ((_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Building)
                            && (_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft >= 0))
                        /// the minus of elapsed time was due to increasing accuracy
                        {



                            _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft -=
                                _testWatch.ElapsedMilliseconds -
                                _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].LastUpdate;
                            _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].LastUpdate = _testWatch.ElapsedMilliseconds;
                        }


                    }


                }




                if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue != null)
                {



                    if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue.Count != 0)
                    {


                        if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Building
                            && _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft <= _testWatch.ElapsedMilliseconds -
                            _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].LastUpdate + 1)
                        {
                            _currentUnits[_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Index].Add(
                                _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0]);

                            long temp = _testWatch.ElapsedMilliseconds;
                            _currentUnits[_allUnits.Barracks.Index][i].UnitQue.RemoveAt(0);
                            if (i == 0)
                            {
                                lstErrors.Items.Add(_testWatch.ElapsedMilliseconds - _testQueTimeLength);
                            }


                            if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue.Count != 0)
                            {

                                if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft > 0 &&
                                        !_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Building &&
                                        _currentTSupp - _currentSupp >=
                                        _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].SupplyCost)
                                {
                                    _currentSupp += _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].SupplyCost;
                                    _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Building = true;

                                }


                            }

                            // UpdateUnitSelect();
                            //  UpdateCommandCard();
                            lstSpeedTest.Items.Add(_testWatch.ElapsedMilliseconds - temp);

                        }
                    }
                }




            }  


        }

    
        //private void UpdateQues()
        //{
        //    //Update CC Ques  
      

        //        //Update barracks ques
        //        lstSupplyDepots.Items.Clear();

        //        for (int i = 0; i < _currentUnits[_allUnits.Barracks.Index].Count(); i++)
        //        {
        //            lstSupplyDepots.Items.Add("rax " + i + _currentUnits[_allUnits.Barracks.Index][i].BuildTimeLeft);

        //            // if (_currentUnits[_allUnits.Barracks.Index][i].Building)
        //            // {
        //            //     _currentUnits[_allUnits.Barracks.Index][i].BuildTimeLeft -= _elapsedTime;
        //            // }


        //            // if (_currentUnits[_allUnits.Barracks.Index][i].BuildTimeLeft <= 0 &&
        //            //     _currentUnits[_allUnits.Barracks.Index][i].Building)
        //            // {
        //            //    _currentUnits[_allUnits.Barracks.Index][i].Building = false;
        //            //     _currentUnits[_allUnits.Barracks.Index][i].BuildTimeLeft = 0;
        //            // }


        //            if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue != null)
        //            {
        //                if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue.Count != 0)
        //                {
        //                    if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Building
        //                        && _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft <= 0)
        //                    {
        //                        _currentUnits[_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Index].Add(
        //                            _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0]);


        //                        _currentUnits[_allUnits.Barracks.Index][i].UnitQue.RemoveAt(0);
        //                        UpdateUnitSelect();
        //                        UpdateCommandCard();
        //                    }
        //                    else if ((_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Building)
        //                             && (_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft >= 0))
        //                    {
        //                        _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft -= _elapsedTime;
        //                    }

        //                    else if (_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].BuildTimeLeft > 0 &&
        //                             !_currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Building)
        //                    {
        //                        _currentUnits[_allUnits.Barracks.Index][i].UnitQue[0].Building = true;
        //                    }
        //                }
        //            }
        //        }






        //        //      UpdateUnitSelect();
            
        //}

        private void UpdateCommandCard()
        {
            ClearAbilPb();

            if (_currentSelectionIndex == _allUnits.Cc.Index)
            {
                if (_currentCommandCardIndex == 0)
                {
                    _abilPb[0].Image = Image.FromFile("T_cc_Abil_0_scv_F.jpg");
                }
            }

            if (_currentSelectionIndex == _allUnits.Scv.Index)
            {
                switch (_currentCommandCardIndex)
                {
                    case 0:
                        _abilPb[10].Image = Image.FromFile("T_scv_Abil_0_bs_F.jpg");
                        _abilPb[11].Image = Image.FromFile("T_scv_Abil_0_bas_F.jpg");
                        break;
                    case 1:
                        _abilPb[0].Image = Image.FromFile("T_scv_Abil_1_cc_F.jpg");
                        _abilPb[2].Image = Image.FromFile("T_scv_Abil_1_sd_F.jpg");
                        _abilPb[5].Image = Image.FromFile("T_scv_Abil_1_barracks_F.jpg");
                        break;
                }
            }

            if (_currentSelectionIndex != _allUnits.Barracks.Index) return;
            _abilPb[0].Image = Image.FromFile("T_barracks_Abil_0_marine_F.jpg");
        }


        

        //Old Select Next Index

        //////////////////////////
        // PAINT UNIT SELECTION //
        //////////////////////////  


        //private void updateTabIndex()
        //{

        //   // i/f( currentSelectionIndex <= selectedUnits.Count())
        //   // {
        //        for (; selectedUnits[currentSelectionIndex].Count == 0; )
        //        {

        //            if (currentSelectionIndex > selectedUnits.Count())
        //            {

        //                currentSelectionIndex = 0;
        //                // firstPriSelect = false;
        //                lblTestUnitsSelected.Text = _unitsSelected.ToString();

        //            }
        //            else
        //            {
        //                currentSelectionIndex++;
        //                lblTestUnitsSelected.Text = _unitsSelected.ToString();
        //            }


        //            if (currentSelectionIndex == selectedUnits.Count )
        //            {
        //                currentSelectionIndex = 0;
        //            }
        //      //  }


        //    }


        //    for (int index = 0; index < selectedUnits.Count ; index++)
        //    {


        //        if (selectedUnits[index].Count == 0 && !firstPriSelect)
        //        {
        //            currentSelectionIndex++;
        //            lblTestUnitsSelected.Text = _unitsSelected.ToString();

        //        }
        //        else
        //        {
        //           // _unitsSelected++;

        //            lblTestUnitsSelected.Text = _unitsSelected.ToString();
        //            firstPriSelect = true;
        //            //currentSelectionIndex = index;

        //        }


        //    }

        //    lblTestUnitsSelected.Text = _unitsSelected.ToString();
        //    if (currentSelectionIndex >= selectedUnits.Count())
        //    {

        //        currentSelectionIndex = 0;
        //       // firstPriSelect = false;
        //        lblTestUnitsSelected.Text = _unitsSelected.ToString();

        //    }
        //    if (selectedUnits[currentSelectionIndex].Count() == 0)
        //    {
        //        firstPriSelect = false;
        //        lblTestUnitsSelected.Text = _unitsSelected.ToString();
        //    }

        //}


        ////////////////
        //  FORM LOAD //
        //////////////// 
        private void Form1Load(object sender, EventArgs e)
        {
            _GameLoopTimer.Elapsed += GameLoopTimerTick;



            _currentTSupp = 200;

            //Process.GetCurrentProcess().ProcessorAffinity =
              //  new IntPtr(2); // Uses the second Core or Processor for the Test
          //  Process.GetCurrentProcess().PriorityClass =
                //ProcessPriorityClass.High; // Prevents "Normal" processes 
            // from interrupting Threads
            //Thread.CurrentThread.Priority =
              //  ThreadPriority.Highest;
            AddCmdLocation();
            AddPbUnits();
            AddPbAbil();

            //   addPBabil();
            FillLists();
            
            
        }

        private void CmdStartClick(object sender, EventArgs e)
        {
            //  DateTime dtStart = DateTime.Now;
            _GameLoopTimer.Enabled = true;

          
            _testWatch.Start();
            


         //   tmrUdate.Enabled = true; //Start the game timer

            // selectPB[1].Image = Image.FromFile("marine.jpg");
        }

        private void CmdStopClick(object sender, EventArgs e)
        {
          //  tmrUdate.Enabled = false; //Stop the game timer
            _GameLoopTimer.Enabled = false;
        }

        //Game Timer


        private void GameLoopTimerTick(object sender, ElapsedEventArgs e)
        {
            long temp = _testWatch.ElapsedMilliseconds;


            _elapsedTime = _testWatch.ElapsedMilliseconds - _tempElapsedTime;

      


            lblTestWatch.Text = _testWatch.ElapsedMilliseconds.ToString();
            if (Convert.ToInt32(lblTestTime.Text) <= _elapsedTime) 
            {
                lblTestTime.Text = _elapsedTime.ToString(CultureInfo.InvariantCulture);
            }

            //  lblTest1.Text = selectedUnits[0].Count.ToString();
            //   DateTime dtNow = DateTime.Now;

            //  lblTestTime.Text = dtNow.to


            if (_currentUnits[_allUnits.Cc.Index].Count != 0)
            {
                if (_currentUnits[_allUnits.Cc.Index][0].UnitQue.Count != 0)
                {
                    lblBase0QueTime.Text =
                        _currentUnits[_allUnits.Cc.Index][0].UnitQue[0].BuildTimeLeft.ToString(
                            CultureInfo.InvariantCulture);
                    lblBase0QueCount.Text =
                        _currentUnits[_allUnits.Cc.Index][0].UnitQue.Count.ToString(CultureInfo.InvariantCulture);
                }
            }
            if (_currentUnits[_allUnits.Cc.Index].Count >= 2)
            {
                if (_currentUnits[_allUnits.Cc.Index][1].UnitQue.Count != 0)
                {
                    lblBase1QueTime.Text =
                        _currentUnits[_allUnits.Cc.Index][1].UnitQue[0].BuildTimeLeft.ToString(
                            CultureInfo.InvariantCulture);
                    lblBase1QueCount.Text =
                        _currentUnits[_allUnits.Cc.Index][1].UnitQue.Count.ToString(CultureInfo.InvariantCulture);
                }
            }

            if (_currentUnits[_allUnits.Cc.Index].Count >= 3)
            {
                if (_currentUnits[_allUnits.Cc.Index][2].UnitQue.Count != 0)
                {
                    lblBase2QueTime.Text =
                        _currentUnits[_allUnits.Cc.Index][2].UnitQue[0].BuildTimeLeft.ToString(
                            CultureInfo.InvariantCulture);
                    lblBase2QueCount.Text =
                        _currentUnits[_allUnits.Cc.Index][2].UnitQue.Count.ToString(CultureInfo.InvariantCulture);
                }
            }


            //lblBase1QueTime.Text = currentUnits[allUnits.T_CC.index][1].currentQueTime.ToString();
            //lblBase2QueTime.Text = currentUnits[allUnits.T_CC.index][2].currentQueTime.ToString();


            //if (selectedUnits[currentSelectionIndex].Count == 0)
            //{
            //    updateTabIndex();

            //}


            //Add Refresh Delay
            //selectPB[0].Image = Image.FromFile("REAPER.jpg");
            // pbMiniMap.Image = Image.FromFile("10.png");

            _currentMin += _minUpdaterate;
            _currentGas += _gasUpdaterate;
            if (_currentMin > 37337)
            {
                _currentMin = 37337;
            }
            if (_currentGas > 37337)
            {
                _currentGas = 37337;
            }

            if (_elapsedTime == 0) return;

            UpdateValues();
            UpdateTime();
            // UpdateBase();
            //UpdateQues();
            UpdateSupply();
            UpdateBuildingConstruction();
            UpdateBaseIcons();
            
            UpdateCcQues();
            UpdateRaxQue();
           
            lblTestWatch.Text = _elapsedTime.ToString();

            _tempElapsedTime = _testWatch.ElapsedMilliseconds;
          //  lstSpeedTest.Items.Add(_testWatch.ElapsedMilliseconds - temp);


            // _testWatch.ElapsedMilliseconds += _elapsedTime;

        }

        //private void TmrUdateTick(object sender, EventArgs e)
        //{
        //    _elapsedTime = Convert.ToInt32(_swTickStart.ElapsedMilliseconds);
        //    _swTickStart.Reset();
        //    _swTickStart.Start();
        //    _testWatch.ElapsedMilliseconds += _elapsedTime;

        //    if (Convert.ToInt32(lblTestTime.Text) <= _elapsedTime)
        //    {
        //        lblTestTime.Text = _elapsedTime.ToString(CultureInfo.InvariantCulture);
        //    }

        //    //  lblTest1.Text = selectedUnits[0].Count.ToString();
        //    //   DateTime dtNow = DateTime.Now;

        //    //  lblTestTime.Text = dtNow.to


        //    if (_currentUnits[_allUnits.Cc.Index].Count != 0)
        //    {
        //        if (_currentUnits[_allUnits.Cc.Index][0].UnitQue.Count != 0)
        //        {
        //            lblBase0QueTime.Text =
        //                _currentUnits[_allUnits.Cc.Index][0].UnitQue[0].BuildTimeLeft.ToString(
        //                    CultureInfo.InvariantCulture);
        //            lblBase0QueCount.Text =
        //                _currentUnits[_allUnits.Cc.Index][0].UnitQue.Count.ToString(CultureInfo.InvariantCulture);
        //        }
        //    }
        //    if (_currentUnits[_allUnits.Cc.Index].Count >= 2)
        //    {
        //        if (_currentUnits[_allUnits.Cc.Index][1].UnitQue.Count != 0)
        //        {
        //            lblBase1QueTime.Text =
        //                _currentUnits[_allUnits.Cc.Index][1].UnitQue[0].BuildTimeLeft.ToString(
        //                    CultureInfo.InvariantCulture);
        //            lblBase1QueCount.Text =
        //                _currentUnits[_allUnits.Cc.Index][1].UnitQue.Count.ToString(CultureInfo.InvariantCulture);
        //        }
        //    }

        //    if (_currentUnits[_allUnits.Cc.Index].Count >= 3)
        //    {
        //        if (_currentUnits[_allUnits.Cc.Index][2].UnitQue.Count != 0)
        //        {
        //            lblBase2QueTime.Text =
        //                _currentUnits[_allUnits.Cc.Index][2].UnitQue[0].BuildTimeLeft.ToString(
        //                    CultureInfo.InvariantCulture);
        //            lblBase2QueCount.Text =
        //                _currentUnits[_allUnits.Cc.Index][2].UnitQue.Count.ToString(CultureInfo.InvariantCulture);
        //        }
        //    }


        //    //lblBase1QueTime.Text = currentUnits[allUnits.T_CC.index][1].currentQueTime.ToString();
        //    //lblBase2QueTime.Text = currentUnits[allUnits.T_CC.index][2].currentQueTime.ToString();


        //    //if (selectedUnits[currentSelectionIndex].Count == 0)
        //    //{
        //    //    updateTabIndex();

        //    //}


        //    //Add Refresh Delay
        //    //selectPB[0].Image = Image.FromFile("REAPER.jpg");
        //    // pbMiniMap.Image = Image.FromFile("10.png");

        //    _currentMin += _minUpdaterate;
        //    _currentGas += _gasUpdaterate;
        //    if (_currentMin > 37337)
        //    {
        //        _currentMin = 37337;
        //    }
        //    if (_currentGas > 37337)
        //    {
        //        _currentGas = 37337;
        //    }

        //    if (_elapsedTime == 0) return;

        //    UpdateValues();
        //    UpdateTime();
        //   // UpdateBase();
        //    UpdateQues();
        //    UpdateSupply();
        //    UpdateBuildingConstruction();
        //    UpdateBaseIcons();
        //}

   
       private void CmdSelectAllClick(object sender, EventArgs e)
        {
       
           ClearUnitList(_selectedUnits);
            CopyUnitList(_currentUnits, _selectedUnits);
            UpdateTabIndex(); 
           UpdateUnitSelect();

            UpdateCommandCard();
           
       }


        private void CmdSelectClearClick(object sender, EventArgs e)
        {
            ClearUnitList(_selectedUnits);
            _currentSelectionIndex = 0;
            UpdateUnitSelect();
            UpdateCommandCard();
        }


        private void PbUnit3MouseClick(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
            }
        }


        private void Button2Click1(object sender, EventArgs e)
        {
           _currentUnits[_allUnits.Barracks.Index].Add(new Unit(17, "barracks", 150, 0, 0,0, false,new List<Unit>()));
           UpdateUnitSelect();
           UpdateCommandCard(); 
        }


        private void CmdUploadHotkeyClick(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void BtnScvClick(object sender, EventArgs e)
        {
            _currentUnits[_allUnits.Scv.Index].Add(new Unit(12, "scv", 50, 0, 1, "cc", 12325,0, false, new List<Unit> { new Unit(17, "cc", 400, 0, 0, new List<Unit>()) },_currentLocationIndex,"M"));


            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void CmdTabClick(object sender, EventArgs e)
        {
            _currentSelectionIndex++;

            UpdateTabIndex();
            _currentCommandCardIndex = 0;

            UpdateUnitSelect();
            UpdateCommandCard();
        }

        private void PbGasIconClick(object sender, EventArgs e)
        {
        }

        private void LblMineralsClick(object sender, EventArgs e)
        {
        }

        private void PbBase1Click(object sender, EventArgs e)
        {
        }

        private void Button1Click(object sender, EventArgs e)
        {
            _currentUnits[_allUnits.Cc.Index].Add( new Unit(_allUnits.Cc.Index, _allUnits.Cc.Name,
                                   _allUnits.Cc.MineralCost, _allUnits.Cc.GasCost,
                                   0,0, false, 11,false,false, new List<Unit>(),_currentLocationIndex, 0, 0,"M"));

            UpdateUnitSelect();
            UpdateCommandCard();
            UpdateBase();
        }

        private void OpenFileDialog1FileOk(object sender, CancelEventArgs e)
        {
        }


        private void UnitSelectClicked(object sender, EventArgs e)
        {

        }


        private void LblTestTimeClick(object sender, EventArgs e)
        {
        }


       
       //////////////////////////////////////////////
       /// 
       /// Command card Picture box Mouse events
       /// 
       /// 
       /// 
       /// ///////////////////////////
       
        private void PbAbil1Click(object sender, EventArgs e)
        {
            //Build SCV From CC CommandCard index 0
            if (_currentSelectionIndex == _allUnits.Cc.Index && _currentCommandCardIndex == 0)
            {
                BuildTscv();
                UpdateUnitSelect();
                UpdateCommandCard();
            }
            //Build CC From SCV CommandCard index 1
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 1)
            {
                // BuildTcc(6, 0, false, 0, false, 72000,true);
                _tempBuildingForPlacing = new Unit(_allUnits.Cc.Index, _allUnits.Cc.Name,
                                                   _allUnits.Cc.MineralCost, _allUnits.Cc.GasCost,
                                                   72000, 0, false, 11,
                                                   
                                                   false,
                                                   false, new List<Unit>(),0, 0, 0,"M");
                _currentCommandCardIndex = 3;


                UpdateUnitSelect();
                UpdateCommandCard();
            }

            if (_currentSelectionIndex == _allUnits.Barracks.Index && _currentCommandCardIndex == 0)
            {
                BuildTMarine();
                UpdateUnitSelect();
                UpdateCommandCard();
                


            }
        }
        private void PbAbil1MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Cc.Index && _currentCommandCardIndex == 0)
            {
                _abilPb[0].Image = Image.FromFile("T_cc_Abil_0_scv_T.jpg");
            }
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 1)
            {
                _abilPb[0].Image = Image.FromFile("T_scv_Abil_1_cc_T.jpg");
            }
        }

        private void PbAbil1MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Cc.Index && _currentCommandCardIndex == 0)
            {
                _abilPb[0].Image = Image.FromFile("T_cc_Abil_0_scv_F.jpg");
            }
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 1)
            {
                _abilPb[0].Image = Image.FromFile("T_scv_Abil_1_cc_F.jpg");
            }
        }






        private void PbAbil3Click(object sender, EventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 1)
            {
                _tempBuildingForPlacing = new Unit(27, "supplydepot", 100, 21750,0, false, 8, new List<Unit>());
                _currentCommandCardIndex = 3;

                UpdateUnitSelect();
                UpdateCommandCard();



            }


        }
        private void PbAbil3MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 1)
            {
                _abilPb[2].Image = Image.FromFile("T_scv_Abil_1_sd_T.jpg");
            }
        }

        private void PbAbil3MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 1)
            {
                _abilPb[2].Image = Image.FromFile("T_scv_Abil_1_sd_F.jpg");
            }
        }




        private void PbAbil6Click(object sender, EventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 1)
            {
                _tempBuildingForPlacing = new Unit(17, "barracks", 150, 0, 47125,0, false, new List<Unit>());
                _currentCommandCardIndex = 3;

                UpdateUnitSelect();
                UpdateCommandCard();


            }

        }
        private void PbAbil6MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 1)
            {
                _abilPb[5].Image = Image.FromFile("T_scv_Abil_1_barracks_T.jpg");
            }
        }

        private void PbAbil6MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 1)
            {
                _abilPb[5].Image = Image.FromFile("T_scv_Abil_1_barracks_F.jpg");
            }
        }






        private void PbAbil11MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 0)
                _abilPb[10].Image = Image.FromFile("T_scv_Abil_0_bs_T.jpg");
        }

        private void PbAbil11MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 0)
                _abilPb[10].Image = Image.FromFile("T_scv_Abil_0_bs_F.jpg");
        }

        private void PbAbil11Click(object sender, EventArgs e)
        {
            _currentCommandCardIndex = 1;
            UpdateCommandCard();
        }

        private void PbAbil12Click(object sender, EventArgs e)
        {
            _currentCommandCardIndex = 2;
            UpdateCommandCard();
        }

        private void PbAbil12MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 0)
                _abilPb[11].Image = Image.FromFile("T_scv_Abil_0_bas_T.jpg");
        }

        private void PbAbil12MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index && _currentCommandCardIndex == 0)
                _abilPb[11].Image = Image.FromFile("T_scv_Abil_0_bas_F.jpg");
        }



        //////////////////////////////////////////////

        private void TrainerFormMouseClick(object sender, MouseEventArgs e)
        {
            switch (_currentCommandCardIndex)
            {
                case 3:
                    _currentCommandCardIndex = 0;
                    _tempBuildingForPlacing = null;
                    UpdateCommandCard();
                    break;
                case 2:
                    _currentCommandCardIndex = 0;
                    _tempBuildingForPlacing = null;
                    UpdateCommandCard();
                    break;
            }
        }

        private void TextBox1KeyDown(object sender, KeyEventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Cc.Index && _currentCommandCardIndex == 0)
            {
                BuildTscv();
                UpdateUnitSelect();
                UpdateCommandCard();
            }

        }

        private void PbPlaceBuildingMouseClick(object sender, EventArgs e)
        {
            if (_currentSelectionIndex == _allUnits.Scv.Index &&
             _currentCommandCardIndex == 3)
            {
                BuildBuilding(_tempBuildingForPlacing,_currentLocationIndex);
                _currentCommandCardIndex = 0;
                _tempBuildingForPlacing = null;

                UpdateCommandCard();
                UpdateBase();
            }
        }

        private void lblTestUnitsSelected_Click(object sender, EventArgs e)
        {


        }

        private void cmdLocation0_Click(object sender, EventArgs e)
        {
            _currentLocationIndex = 0;
            UpdateBase();

        }

        private void cmdLocation1_Click(object sender, EventArgs e)
        {
            _currentLocationIndex = 1;
            UpdateBase();
        }

        private void CmdLocation2Click(object sender, EventArgs e)
        {
            _currentLocationIndex = 2;
            UpdateBase();
        }

        private void CmdLocation3Click(object sender, EventArgs e)
        {
            _currentLocationIndex = 3;
            UpdateBase();    
        }

        private void CmdLocation4Click(object sender, EventArgs e)
        {
            _currentLocationIndex = 4;
            UpdateBase();    
        }

        private void CmdLocation5Click(object sender, EventArgs e)
        {
            _currentLocationIndex = 5;
            UpdateBase();    
        }

        private void CmdLocation6Click(object sender, EventArgs e)
        {
            _currentLocationIndex = 6;
            UpdateBase();
        }

        private void CmdLocation7Click(object sender, EventArgs e)
        {
            _currentLocationIndex = 7;
            UpdateBase();   
            }

        private void CmdLocation8Click(object sender, EventArgs e)
        {
            _currentLocationIndex = 8;
            UpdateBase();
        }

        private void CmdBase0MClick(object sender, EventArgs e)
        {
            List<List<Unit>> tempSelect = new List<List<Unit>>();

               foreach (var tempunit in _currentUnits[_allUnits.Scv.Index])
            {
                if (tempunit.Location == _currentLocationIndex)
                {
                    tempSelect[_allUnits.Scv.Index].Add(tempunit);

                }
            }
            CopyUnitList(tempSelect,_selectedUnits);


            


        }

        private void TxtWorkerRallyTextChanged(object sender, EventArgs e)
        {
            List<List<Unit>> templist = GetLocationUnitList(_currentLocationIndex);

            if (templist[_allUnits.Cc.Index].Count > 0)
            {
                templist[_allUnits.Cc.Index][0].WorkerRally = Convert.ToInt32(txtWorkerRally.Text);
                templist[_allUnits.Cc.Index][0].ScvState = cbScvState.SelectedItem.ToString();
            }
        }

        private void UnitSelectClicked(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                PictureBox pb = sender as PictureBox;

                if (pb != null) lstErrors.Items.Add(pb.Name);
               
            }
            else
            {
                CopyUnitList(_controlG3, _selectedUnits);
            }
        }

     

      

       
    }
}