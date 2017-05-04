using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace gowri
{
    class complaintsmanager
    {

        public int InsertComplaints(complaints comp)
        {

            //Create the SQL Query for inserting an article
            string sqlQuery = String.Format("Insert into complaints (complaintId, cId ,technicianname, status,priority,pId) Values({0}, {1}, '{2}', {3},{4},{5} );"
            + "Select @@Identity", comp.complaintId,comp.customerId,comp.technicianname,comp.status,comp.priority,comp.ProductId);

            //Create and open a connection to SQL Server 
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            try
            {
                //Execute the command to SQL Server and return the newly created ID
                int newComplaintID = Convert.ToInt32((decimal)command.ExecuteScalar());
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
            return comp.complaintId;
        }


        public bool DeleteComplaints(int compID)
        {
            bool result = false;

            //Create the SQL Query for deleting an article
            string sqlQuery = String.Format("delete from complaints  where complaintId = {0}", compID);

            //Create and open a connection to SQL Server 
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            // Execute the command
            int rowsDeletedCount = command.ExecuteNonQuery();
            if (rowsDeletedCount != 0)
                result = true;
            // Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();


            return result;
        }




        public void GetComplaints()
        {


            string sqlQuery = String.Format("select * from complaints");

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

                    Console.WriteLine(dataReader[0] + " " + dataReader[1] + " " + dataReader[2] + " " + dataReader[3] + " " + dataReader[4] + " " + dataReader[5]);

                }
            }



        }

        public void GetComplaintsById(int compId)
        {


            //Create the SQL Query for returning an article category based on its primary key
            string sqlQuery = String.Format("select * from complaints where complaintId={0}", compId);

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
                    Console.WriteLine(dataReader[0] + " " + dataReader[1] + " " + dataReader[2] + " " + dataReader[3] + " " + dataReader[4] + " " + dataReader[5]);
                }
            }


        }

    }
}
