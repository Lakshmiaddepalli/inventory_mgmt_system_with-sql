using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace gowri
{
    class productsmanager
    {
        public int InsertProducts(product prod)
        {

            //Create the SQL Query for inserting an article
            string sqlQuery = String.Format("Insert into product (pId, pname ,catname, pprice,pdesc,pquantity,measurename) Values({0}, '{1}', '{2}', {3},'{4}',{5},'{6}' );"
            + "Select @@Identity", prod.ProductID, prod.ProductName, prod.CategoryName, prod.ProductPrice, prod.ProductDescription, prod.ProductQuantity,prod.MeasureName);

            //Create and open a connection to SQL Server 
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            //Create a Command object
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            try
            {
                //Execute the command to SQL Server and return the newly created ID
                int newProductID = Convert.ToInt32((decimal)command.ExecuteScalar());
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
            return prod.ProductID;
        }


             public bool DeleteProducts(int prodID)
        {
	         bool result = false;
 
	//Create the SQL Query for deleting an article
	string sqlQuery = String.Format("delete from product where pId = {0}",prodID);
 
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

    


             public void GetProduct()
             {

                
                 string sqlQuery = String.Format("select * from product");

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
                        
                         Console.WriteLine(dataReader[0] + " " + dataReader[1] + " " + dataReader[2] + " " + dataReader[3] + " " + dataReader[4] + " " + dataReader[5] + " " + dataReader[6]);

                     }
                 }

              

             }

             public void GetProductById(int prodId)
             {
                

                 //Create the SQL Query for returning an article category based on its primary key
                 string sqlQuery = String.Format("select * from product where pId={0}", prodId);

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
                         Console.WriteLine(dataReader[0] + " " + dataReader[1] + " " + dataReader[2] + " " + dataReader[3] + " " + dataReader[4] + " " + dataReader[5] + " " + dataReader[6]);
                     }
                 }

                 
             }

        
        public int UpdateProducts(product prod)
        {

            //Create the SQL Query for inserting an article
            string createQuery = String.Format("Insert into product (pId, pname ,catname, pprice,pdesc,pquantity,measurename) Values({0}, '{1}', '{2}', {3},'{4}',{5},'{6}' );"
            + "Select @@Identity", prod.ProductID, prod.ProductName, prod.CategoryName, prod.ProductPrice, prod.ProductDescription, prod.ProductQuantity, prod.MeasureName);

            //Create the SQL Query for updating an article
            string updateQuery = String.Format("Update product  SET pname='{1}', catname = '{2}',pprice = {3}, pdesc ='{4}', pquantity = {5}, measurename ='{6}' Where pId = {0};",
                prod.ProductID, prod.ProductName, prod.CategoryName, prod.ProductPrice, prod.ProductDescription, prod.ProductQuantity, prod.MeasureName);

            //Create and open a connection to SQL Server 
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();

            //Create a Command object
            SqlCommand command = null;

            if (prod.ProductID != 0)
                command = new SqlCommand(updateQuery, connection);
            else
                command = new SqlCommand(createQuery, connection);

            int savedProductID = 0;
            try
            {
                //Execute the command to SQL Server and return the newly created ID
                var commandResult = command.ExecuteScalar();
                if (commandResult != null)
                {
                    savedProductID = Convert.ToInt32(commandResult);
                }
                else
                {
                    //the update SQL query will not return the primary key but if doesn't throw exception 
                    //then we will take it from the already provided data
                    savedProductID = prod.ProductID;
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

            return savedProductID;
        }


        //Console.WriteLine("5. UPDATE PRODUCT DETAILS");
        public void supplyproduct(int p,int q)
        {
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();
            string sqlQuery = String.Format("select * from product where pId={0}", p);
            SqlCommand sqc = new SqlCommand(sqlQuery, connection);
            SqlDataReader dr = sqc.ExecuteReader();
            while (dr.Read())
            {
                int price1 = (int)dr["pprice"];
                int qty1 = (int)dr["pquantity"];


                string connectionstring1 = null; // connection string
                connectionstring1 = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
                SqlConnection conn1 = new SqlConnection(connectionstring1);
                conn1.Open();
                SqlCommand sqc1 = new SqlCommand("UPDATE product SET pquantity =" + (qty1 + q) + "WHERE pId =" + p, conn1);
                sqc1.ExecuteNonQuery();
                conn1.Close();



            }//while
            connection.Close();




        }


        public void BuyProduct(int prodId,int custId,bill newBill,int q)
        {
            int price;
            string str = str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection connection = new SqlConnection(str);
            connection.Open();
            SqlCommand sqc = new SqlCommand("SELECT * FROM Product WHERE pId =" + prodId, connection);
            SqlDataReader dr = sqc.ExecuteReader();
            while (dr.Read())
            {
                int price1 = (int)dr["pprice"];
                int qty = (int)dr["pquantity"];
                if (q > qty)
                {
                    Console.WriteLine("Limited Stalk");
                }
                else
                {
                   price = price1 * q;
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Console.WriteLine("BILL REPORT");
                    Console.WriteLine("Price :" + " " + price);
                    newBill.Price = price;
                    string connectionstring1 = null; // connection string
                    connectionstring1 = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
                    SqlConnection conn1 = new SqlConnection(connectionstring1);
                    conn1.Open();
                    SqlCommand sqc1 = new SqlCommand("UPDATE product SET pquantity =" + (qty - q) + "WHERE pId =" + prodId, conn1);
                    sqc1.ExecuteNonQuery();
                    conn1.Close();
                }


            }//while

            connection.Close();
            //printing
            
            string pname, cname;
            string connectionstring4 = null; // connection string
            connectionstring4 = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
            SqlConnection conn4 = new SqlConnection(connectionstring4);
            conn4.Open();
            SqlCommand sqc4 = new SqlCommand("SELECT * FROM product WHERE pId =" + prodId, conn4);
            SqlDataReader dr2 = sqc4.ExecuteReader();
            while (dr2.Read())
            {
                pname = (string)dr2["pname"];
                Console.WriteLine("\n");
                Console.WriteLine("  Product Name :" + pname);

            }
            dr2.Close();//while
            conn4.Close();

            string connectionstring5 = null; // connection string
            connectionstring5 = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True"; 
            SqlConnection conn5 = new SqlConnection(connectionstring5);
            conn5.Open();
            SqlCommand sqc6 = new SqlCommand("SELECT * FROM Customer WHERE Custid =" + custId, conn5);
            SqlDataReader dr3 = sqc6.ExecuteReader();
            while (dr3.Read())
            {
                cname = (string)dr3["cname"];
                Console.WriteLine("Customer Name : " + cname);

            }//while
            dr3.Close();
            conn5.Close();

            Console.WriteLine(" Quantity : " + q);
          //  Console.WriteLine("price : " + price);
            
        }

    }
}
