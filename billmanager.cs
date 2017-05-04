using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace gowri
{
    class billmanager
    {
        public int InsertBill(bill b)
        {

            //Create the SQL Query for inserting an article
            string sqlQuery = String.Format("Insert into Bill (prodId,  custId ,quantity, price) Values({0}, {1}, {2}, {3});"
            + "Select @@Identity", b.ProductID, b.CustomerId, b.Quantity, b.Price);

            //Create and open a connection to SQL Server 
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            try
            {
                //Execute the command to SQL Server and return the newly created ID
                int newbillID = Convert.ToInt32((decimal)command.ExecuteScalar());
            }
            catch (InvalidCastException)
            {
                // Console.WriteLine("Conversion failed.");
            }

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            // Set return value
            return b.BillNo;
        }

        public void GetBill()
        {


            string sqlQuery = String.Format("select * from Bill");

            //Create and open a connection to SQL Server 
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            //Create DataReader for storing the returning table into server memory
            SqlDataReader dataReader = command.ExecuteReader();



            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {

                    Console.WriteLine(dataReader[0] + " " + dataReader[1] + " " + dataReader[2] + " " + dataReader[3] + " " + dataReader[4] );

                }
            }



        }

        public void GetBillById(int bno)
        {


            //Create the SQL Query for returning an article category based on its primary key
            string sqlQuery = String.Format("select * from Bill where Billno ={0}", bno);

            //Create and open a connection to SQL Server 
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();


            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader dataReader = command.ExecuteReader();

            //load into the result object the returned row from the database
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader[0] + " " + dataReader[1] + " " + dataReader[2] + " " + dataReader[3] + " " + dataReader[4] );
                }
            }


        }


    }
}
