using System;
using System.Data.Linq;
//using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;

/*
Changes from SKP Hotel 1 and 2

in version 1 i used the generic SQL database provided by visual studio like i was instructed to via the project guidelines
but that requires that the sql database server is installed beforehand on the users computer to run this application 
so i found a library online called SQLite that is a completely self contained SQL engine and implimented that instead so that the user could run this program without any required software
 
 Unfortunatly a side effect of this was that in the original program i used the entity model and LINQ to Read write and update the database 
 but linq only works with update and read  with SQLite so i had to modifiy the insert portion of the code to use a more generic way of 
 inserting  a reservation into the database.
 

*/
namespace SKPHotel_2._0
{
    public partial class Form1 : Form
    {
        private DataContext dc = null;
        private Table<EntityReservations> tReservations = null;
        private Graphics g = null;
        private string _drawStr = "";
        private Color _brushColor = Color.Red;
        private SQLiteConnection conn;

        public Form1()
        {
            InitializeComponent();
        }
        //Check if inputed data meets required Criteria 
        private bool DataGood()
        {
            _brushColor = Color.Red;
            //Check if name field is under Max length
            string name = txtName.Text;
            if (name.Count() >= 50)
            {
                _drawStr = "Name field must be less than 50 characters";
                return false;
            }


            //Check to make sure there is a first and last name
            char[] delim = {' '};
            string[] tokens = name.Split(delim);
            //Check number of names
            Console.Write(tokens.Count());
            if (tokens.Count() < 2)
            {
                _drawStr = "Must have a first and last name seperated by a space";
                return false;
            }


            //Check To make sure names are the right length
            for (int i = 0; i < tokens.Count(); i++)
            {
                if (tokens[i].Count() <= 2)
                {
                    _drawStr = "Name is to short must be atleast 3 letters";
                    return false;
                }
            }


            //Validate dates
            if (DTPCheckOut.Value < DTPCheckIn.Value)
            {
                _drawStr = "Check in date must be before check out date";
                return false;
            }
            if (DTPCheckIn.Value < DateTime.Now)
            {
                _drawStr = "You must book a check in date after todays date";
                return false;
            }


            //Check length of request inputed
            if (txtRequests.Text.Count() >= 50)
            {
                _drawStr = "Request fields must be less than 50 characters";
                return false;
            }
            _brushColor = Color.Green;
            _drawStr = "Reservation added successfully.";
            return true;
        }

        //My professor required that we used pain string in our project since we learned it in class 
        //or else i would have used a normal text field
        private void paintNotes()
        {
            try
            {
                g.Clear(DefaultBackColor);
                SolidBrush sb = new SolidBrush(_brushColor);
                Font myFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                g.DrawString(_drawStr, myFont, sb, new PointF(14f, 265f));
            }
            catch (Exception ex)
            {

            }
        }
        //Get data from SQL database and Bind it to Datagrid
        private void GetData()
        {
            
            //Connection String
            string connStr = "data source=|DataDirectory|\\SKPdb.s3db";
           // create a Connection object 
            conn = new SQLiteConnection(connStr);
            

        //Create DataContect for dataset
            dc = new DataContext(conn);
            conn.CreateCommand();

            //get generic table
            tReservations = dc.GetTable<EntityReservations>();

            //Set Datasource and Display the Data in DataGridView dgReservations
            bindingSource1.DataSource = tReservations;
            dgReservations.DataSource = bindingSource1;
            dgReservations.ClearSelection();
       
        }
        //Set the state of controls in the application
        private void setControlState(string state)
        { 
            //Set state for writing to database/booking reservation
            if (state.Equals("w"))
            {
                lblId.Text = "";
                cmdBook.Text = "Book";

                cmdUpdate.Enabled = false;
                cmdRemove.Enabled = false;
                clearText();
            }
             //Set state for update or delete reservation
            else if (state.Equals("u/d"))
            {
                cmdBook.Text = "Return to Book Mode";
                cmdUpdate.Enabled = true;
                cmdRemove.Enabled = true;
            }
        }
        //Clear all text in application 
        private void clearText()
        {

            cmbSmoke.SelectedIndex = 0;
            cmbBalcony.SelectedIndex = 0;
            cmbBeds.SelectedIndex = 1;
            lblIDlabel.Hide();
            lblId.Text = "";
            txtName.Text = "";
            txtRequests.Text = "";
            DTPCheckIn.Value = DateTime.Now.AddDays(1.0);
            DTPCheckOut.Value = DateTime.Now.AddDays(2.0);
            dgReservations.ClearSelection();
            txtName.Focus();
        }

        //Book button click event
        private void cmdBook_Click(object sender, EventArgs e)
        {
            if (cmdBook.Text.Equals("Book"))
            {
                //If user imput is fine add a row to the database
                if (DataGood())
                {
                    //create NEW row for table
                    SQLiteTransaction trans;
                    string SQL =
                        "INSERT INTO tReservations ( Name,Smoking,Balcony,NumOfBeds,CheckIn,CheckOut,Requests) VALUES";
                    SQL += "(@Name,@Smoking,@Balcony,@NumOfBeds,@CheckIn,@CheckOut,@Requests)";

                    SQLiteCommand cmd = new SQLiteCommand(SQL);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Smoking", cmbSmoke.Text);
                    cmd.Parameters.AddWithValue("@Balcony", cmbBalcony.Text);
                    cmd.Parameters.AddWithValue("@NumOfBeds", cmbBeds.SelectedIndex + 1);
                    cmd.Parameters.AddWithValue("@CheckIn", DTPCheckIn.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@CheckOut", DTPCheckOut.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Requests", txtRequests.Text);


                    cmd.Connection = conn;
                    conn.Open();
                    trans = conn.BeginTransaction();
                    int retval = 0;
                    try
                    {
                        retval = cmd.ExecuteNonQuery();
                        _drawStr = retval == 1 ? "Reservation Added" : _drawStr;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                    finally
                    {
                        trans.Commit();
                        cmd.Dispose();

                    }

                }
                GetData();
                clearText();
            }


            else
            {
                setControlState("w");
                txtName.Focus();
            }
            paintNotes();
        }
        //Update button Click event
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (DataGood())
            {
                //get selected row
                IQueryable<EntityReservations> query =
                    from row in tReservations
                    where row.Id.Equals(Convert.ToInt32(lblId.Text))
                    select row;

                //iterate through query
                foreach (EntityReservations row in query)
                {
                    row.Id = Convert.ToInt32(lblId.Text);
                    row.Name = txtName.Text;
                    row.Smoking = cmbSmoke.Text;
                    row.Balcony = cmbBalcony.Text;
                    row.NumOfBeds = Convert.ToInt32(cmbBeds.SelectedIndex + 1);
                    row.CheckIn = DTPCheckIn.Value.ToString("yyyy-MM-dd");
                    row.CheckOut = DTPCheckOut.Value.ToString("yyyy-MM-dd");
                    row.Requests = txtRequests.Text;
                }
                txtName.KeyPress += new KeyPressEventHandler(txtName_KeyPress);
                //Update database
                dc.SubmitChanges();

                GetData();
                clearText();
                setControlState("w");
                _brushColor = Color.Green;
                _drawStr = "Update Successful";


            }
            paintNotes();
        }
        //Delete button event
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Reservation",
                                                        "Confirm Delete",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);


            if (dialogResult == DialogResult.Yes)
            {
                IQueryable<EntityReservations> query =
                    from row in tReservations
                    where row.Id.Equals(lblId.Text)
                    select row;

                foreach (EntityReservations row in query)
                {
                    tReservations.DeleteOnSubmit(row);
                }
                dc.SubmitChanges();
                GetData();
                clearText();
                setControlState("w");
                _brushColor = Color.Green;
                _drawStr = "Reservations Sucessfully Removed";
                paintNotes();
            }
        }
        //Input validation for Name field
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox) sender).Text.Length;
            ((TextBox) sender).SelectionStart = len;
            if (c != 8)
            {


                if ((c < 65 || c > 95) && (c < 97 || c > 122) && c != 32)
                {
                    e.Handled = true;
                }

            }
        }
        //Event for clicking on a reservation 
        private void dgReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _drawStr = "";
                paintNotes();
                lblId.Text = dgReservations.CurrentRow.Cells[0].Value.ToString();
                lblIDlabel.Show();
                txtName.Text = dgReservations.CurrentRow.Cells[1].Value.ToString();
                cmbSmoke.SelectedIndex = dgReservations.CurrentRow.Cells[2].Value.ToString().Equals("Yes") ? 1 : 0;
                cmbBalcony.SelectedIndex = dgReservations.CurrentRow.Cells[3].Value.ToString().Equals("Yes") ? 1 : 0;
                cmbBeds.SelectedIndex = Convert.ToInt32(dgReservations.CurrentRow.Cells[4].Value) - 1;
                DTPCheckIn.Value = DateTime.ParseExact(dgReservations.CurrentRow.Cells[5].Value.ToString(), "yyyy-MM-dd",
                                                       null);
                DTPCheckOut.Value = DateTime.ParseExact(dgReservations.CurrentRow.Cells[6].Value.ToString(),
                                                        "yyyy-MM-dd", null);

                if (dgReservations.CurrentRow.Cells[7].Value != null)
                {


                    txtRequests.Text = dgReservations.CurrentRow.Cells[7].Value.ToString();
                }
                setControlState("u/d");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                _brushColor = Color.Red;
                _drawStr = "No Reservations to sort ";
                paintNotes();
            }
            }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetData();
            clearText();
            setControlState("w");
            g = pnlControls.CreateGraphics();
            txtName.Focus();
            txtName.ContextMenu = new ContextMenu();
            txtRequests.ContextMenu = new ContextMenu();

        }
    }
    }
