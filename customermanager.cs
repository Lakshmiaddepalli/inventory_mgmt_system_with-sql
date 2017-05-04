using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace gowri
{
    class customermanager
    {

        public int InsertCustomer(customer cust)
        {

            //Create the SQL Query for inserting an article
            string sqlQuery = String.Format("Insert into Customer (custid,cname,phoneno) Values({0}, '{1}', {2} );"
            + "Select @@Identity", cust.CustomerID, cust.CustomerName, cust.CustomerPhoneNo);

            //Create and open a connection to SQL Server 
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            try
            {
                //Execute the command to SQL Server and return the newly created ID
                int CustomerID = Convert.ToInt32((decimal)command.ExecuteScalar());
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
            return cust.CustomerID;
        }


        public bool DeleteCustomer(int custID)
        {
            bool result = false;

            //Create the SQL Query for deleting an article
            string sqlQuery = String.Format("delete from Customer where custid = {0}", custID);

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



        public void GetCustomer()
        {



            //Create the SQL Query for returning all the articles
            string sqlQuery = String.Format("select * from Customer");

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


                    Console.WriteLine(dataReader[0] + " " + dataReader[1] + " " + dataReader[2]);

                }
            }



        }


        public void GetCustomerById(int custId)
        {


            //Create the SQL Query for returning an article category based on its primary key
            string sqlQuery = String.Format("select * from Customer where custid={0}", custId);

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
                    Console.WriteLine(dataReader[0] + " " + dataReader[1] + " " + dataReader[2]);
                }
            }


        }


        public int UpdateCustomer(customer cust)
        {

            //Create the SQL Query for inserting an article
            string createQuery = String.Format("Insert into Customer (custid, cname ,phoneno) Values({0}, '{1}', {2});"
            + "Select @@Identity", cust.CustomerID, cust.CustomerName, cust.CustomerPhoneNo);

            //Create the SQL Query for updating an article
            string updateQuery = String.Format("Update Customer  SET cname='{1}', phoneno = {2} Where custid = {0};",
                 cust.CustomerID, cust.CustomerName, cust.CustomerPhoneNo);


            //Create and open a connection to SQL Server 
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            //Create a Command object
            SqlCommand command = null;

            if (cust.CustomerID != 0)
                command = new SqlCommand(updateQuery, connection);
            else
                command = new SqlCommand(createQuery, connection);

            int savedCustomerID = 0;
            try
            {
                //Execute the command to SQL Server and return the newly created ID
                var commandResult = command.ExecuteScalar();
                if (commandResult != null)
                {
                    savedCustomerID = Convert.ToInt32(commandResult);
                }
                else
                {
                    //the update SQL query will not return the primary key but if doesn't throw exception 
                    //then we will take it from the already provided data
                    savedCustomerID = cust.CustomerID;
                }
            }
            catch (Exception ex)
            {
                //there was a problem executing the script
            }

            //Close and dispose
            command.Dispose();
            connection.Close();
            connection.Dispose();

            return savedCustomerID;
        }


    }
}
