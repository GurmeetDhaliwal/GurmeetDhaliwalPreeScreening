using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GurmeetDhaliwal_PreSCreening
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CarService : ICarService
    {
        public void addCar( string manufacure, string make, string color, DateTime release_year, int seating)
        {
            CarDatabaseEntities3 entitites = new CarDatabaseEntities3();
            try
            {
                 CAr car = new CAr
                {
                    Manufacture= manufacure,
                    Make = make,
                    Color = color ,
                    Release_Year = release_year,
                    Seating = seating
                };
                entitites.CArs.Add(car);
                entitites.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                throw;

            }
        }

        public List<CAr> getAllCars()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=CarDatabase;Integrated Security=True");
            List<CAr> carlist = new List<CAr>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from CArs", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CAr carinfo = new CAr();
                        carinfo.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                        carinfo.Manufacture = dt.Rows[i]["Manufacture"].ToString();
                        carinfo.Make = dt.Rows[i]["Make"].ToString();
                        carinfo.Color = dt.Rows[i]["Color"].ToString();
                        carinfo.Release_Year = Convert.ToDateTime(dt.Rows[i]["Release_Year"]);
                        carinfo.Seating = Convert.ToInt32(dt.Rows[i]["Seating"]);
                        carlist.Add(carinfo);
                    }
                    con.Close();
                }
                return carlist;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                throw;
            }
        }
    }
}
