using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GurmeetDhaliwal_PreSCreening
{
     [DataContract]
    public class CarsSelectionClass
    {
         string manufacture;
         string make;
         DateTime release_year;
         string color;
         int seating;
  
        [DataMember]
        public string Manufacture
        {
            set { manufacture = value; }
            get { return manufacture; }
        }
        [DataMember]
        public string Make
        {
            set { make = value; }
            get { return make; }
        }
        [DataMember]
        public DateTime Release_Year
        {
            set { release_year = value; }
            get { return release_year; }
        }
        [DataMember]
        public string Color
        {
            set { color = value; }
            get { return color; }
        }

        [DataMember]
        public int Seating
        {
            set { seating = value; }
            get { return seating; }
        }
      

    }
}
