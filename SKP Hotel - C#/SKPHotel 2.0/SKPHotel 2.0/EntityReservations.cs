

using System.Data.Linq.Mapping;

namespace SKPHotel_2._0
{
    [Table(Name = "tReservations")]
    internal class EntityReservations
    {

        private int _id;
        private string _name;
        private string _smoking;
        private string _balcony;
        private int _numOfBeds;
        private string _checkIn;
        private string _checkOut;
        private string _requests;

        public EntityReservations()
        {

        }

        public EntityReservations(string name, string smoking, string balcony, int numOfBeds, string checkIn,
                                  string checkOut, string requests)
        {

            Name = name;
            Smoking = smoking;
            Balcony = balcony;
            NumOfBeds = numOfBeds;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Requests = requests;

        }

        // , IsDbGenerated = true, UpdateCheck = UpdateCheck.Never
        [Column(IsPrimaryKey = true, Storage = "_id", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Column(Storage = "_name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Column(Storage = "_smoking")]
        public string Smoking
        {
            get { return _smoking; }
            set { _smoking = value; }
        }

        [Column(Storage = "_balcony")]
        public string Balcony
        {
            get { return _balcony; }
            set { _balcony = value; }
        }

        [Column(Storage = "_numOfBeds")]
        public int NumOfBeds
        {
            get { return _numOfBeds; }
            set { _numOfBeds = value; }
        }

        [Column(Storage = "_checkIn")]
        public string CheckIn
        {
            get { return _checkIn; }
            set { _checkIn = value; }
        }

        [Column(Storage = "_checkOut")]
        public string CheckOut
        {
            get { return _checkOut; }
            set { _checkOut = value; }
        }

        [Column(Storage = "_requests")]
        public string Requests
        {
            get { return _requests; }
            set { _requests = value; }
        }
    }
}

