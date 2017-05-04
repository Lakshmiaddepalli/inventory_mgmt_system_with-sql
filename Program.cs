using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace gowri
{
    class Program
    {

        public static void login()
        {
            SqlConnection con;
            string str;
            string name;
            string pswd;
            try
            {

               string textToEnter = "SALES INVENTORY MANAGEMENT SYSTEM";
               Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
               str = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\gowri\documents\visual studio 2013\Projects\Laksh\Laksh\login.mdf;Integrated Security=True";
               con = new SqlConnection(str);
               con.Open();
               //Console.WriteLine("Database connected");
               Console.WriteLine("ADMIN LOGIN MODULE");
               Console.WriteLine("1.REGISTER");
               Console.WriteLine("2.LOGIN");
               Console.WriteLine("SELECT AN OPTION:");
               int z = int.Parse(Console.ReadLine());
               switch (z)
               {
                   case 1:
                       Console.Clear();
                       Console.WriteLine("REGISTER");
                       Console.WriteLine("enter username");
                       name = Console.ReadLine();
                       Console.WriteLine("enter password");
                       pswd = Console.ReadLine();
                       string query = " INSERT INTO login (username,password) VALUES ('" + name + "','" + pswd + "')";
                       SqlCommand ins = new SqlCommand(query, con);
                       ins.ExecuteNonQuery();
                       Console.WriteLine("Registeration Successful. . .");
                       break;

                   case 2:
                       Console.Clear();
                       Console.WriteLine("LOGIN");
                       Console.WriteLine("enter username");
                       name = Console.ReadLine();
                       Console.WriteLine("enter password");
                       pswd = Console.ReadLine();
                       SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE username='" + name + "' AND password='" + pswd + "'", con);
                      // string query = " INSERT INTO login (username,password) VALUES ('" + name + "','" + pswd + "')";
                      // SqlCommand ins = new SqlCommand(query, con);
                      // ins.ExecuteNonQuery();
                       DataTable dt = new DataTable();
                       sda.Fill(dt);  
                       if (dt.Rows[0][0].ToString() == "1")  
                         {
                             Console.WriteLine("Login Successful. . .");
                         }  
                        else
                           Console.WriteLine("Invalid username or password"); 
                         break;

                         default:
                         Console.Clear();
                         Console.WriteLine("ENTER CORRECT OPTION");
                         break;
                       
               }
               // string q = "SELECT * FROM login";
               // SqlCommand view = new SqlCommand(q, con);
              //  SqlDataReader dr = view.ExecuteReader();
               /* while(dr.Read())
                {
                    Console.WriteLine("\n ID: "+dr.GetValue(0).ToString());
                    Console.WriteLine("\n USERNAME: " + dr.GetValue(1).ToString());
                    Console.WriteLine("\n PASSWORD: " + dr.GetValue(2).ToString());
                }*/
                con.Close();
            }
            catch (SqlException x)
            {
                Console.WriteLine(x.Message);
            }
            Console.ReadLine();
        }





        static void Main(string[] args)
        {

            product newProduct = new product();
            productsmanager pm = new productsmanager();
            category newCategory = new category();
            categorymanager cm = new categorymanager();
            supplier newSupplier = new supplier();
            suppliermanager sm = new suppliermanager();
            bill newBill = new bill();
            billmanager bm = new billmanager();
            customer newCustomer = new customer();
            customermanager ccm = new customermanager();
            complaints newComplaints = new complaints();
            complaintsmanager cpm = new complaintsmanager();

                 login();

                 Console.Clear();
                  
                 Console.WriteLine("1.CATEGORY AND MEASURE MODULE");
                 Console.WriteLine("2.STOCK AND PRODUCT MODULE");
                 Console.WriteLine("3.SUPPLIER MODULE");
                 Console.WriteLine("4.CUSTOMER ORDERS MODULE");
                 Console.WriteLine("5.PAYMENT AND BILL MAINTAINANCE MODULE");
                 Console.WriteLine("6.COMPLAINTS MODULE");
                 Console.WriteLine("7. EXIT");
                 Console.WriteLine("SELECT AN OPTION:");
                 int op = int.Parse(Console.ReadLine());
                 Console.Clear();


                 do
                 {
                switch (op) 
               {
                   case 1:
                       //Console.Clear();
                       Console.WriteLine("\n");
                       Console.WriteLine("\n");
                       Console.WriteLine("\n");

                       Console.WriteLine("CATEGORY AND MEASURE MODULE");
                       Console.WriteLine("WHAT OPERATION DO YOU WANT TO PERFORM?");
                       Console.WriteLine("1. ADD CATEGORY ");
                       Console.WriteLine("2. DELETE  CATEGORY");
                       Console.WriteLine("3. VIEW CATEGORY ");
                       Console.WriteLine("4. VIEW CATEGORY BY ID ");
                       Console.WriteLine("5. UPDATE CATEGORY DETAILS");
                       Console.WriteLine("6. EXIT");
                       Console.WriteLine("SELECT AN OPTION:");
                       int op2 = int.Parse(Console.ReadLine());
                       switch (op2)
                       {
                           case 1:
                               Console.Clear();
                               Console.WriteLine("ADD CATEGORY");
                               string cn, mn;
                               int cid;
                               Console.WriteLine("ENTER CATEGORY ID");
                               cid = int.Parse(Console.ReadLine());
                               newCategory.CategoryID= cid;
                               Console.WriteLine("Enter category name");
                               cn = Console.ReadLine();
                               newCategory.CategoryName = cn;
                               Console.WriteLine("enter measurename");
                               mn = Console.ReadLine();
                               newCategory.MeasureName = mn;
                               int newCategoryId = cm.InsertCategory(newCategory);
                               Console.WriteLine("category inserted" + " " + newCategoryId.ToString());
                               break;

                           case 2:
                               Console.Clear();
                               Console.WriteLine("DELETE CATEGORY");
                               int x;
                               Console.WriteLine("enter cid you want to delete");
                               x = int.Parse(Console.ReadLine());
                               newCategory.CategoryID = x;
                               bool catdel = cm.DeleteCategory(x);
                               if (catdel)
                               {
                                   Console.WriteLine("category deleted" + x.ToString());
                               }
                               else
                               {
                                   Console.WriteLine("categoryid" + x.ToString() + "doesnt exist");
                               }
                               break;

                           case 3:
                               Console.Clear();
                               Console.WriteLine("VIEW");
                               Console.WriteLine("view the table");
                               cm.GetCategory();
                               break;

                           case 4:
                               Console.Clear();
                               Console.WriteLine("VIEW BY ID");
                               //Console.WriteLine("This is part of inner switch ");
                               Console.WriteLine("view the table by id");
                               int y = int.Parse(Console.ReadLine());
                               Console.Clear();
                               cm.GetCategoryById(y);
                               break;

                           case 5:
                               Console.Clear();
                               Console.WriteLine("UPDATE");
                               //Console.WriteLine("This is part of inner switch ");
                               Console.WriteLine("update?");
                               bool ans = Convert.ToBoolean(Console.ReadLine());
                               if (ans)
                               {
                                   string cn1, mn1;
                                   int cid1;
                                   Console.WriteLine("enter cid you want to update");
                                   cid1 = int.Parse(Console.ReadLine());
                                   newCategory.CategoryID = cid1;
                                   Console.WriteLine("enter categoryname");
                                   cn1 = Console.ReadLine();
                                   newCategory.CategoryName = cn1;
                                   Console.WriteLine("enter measure name");
                                   mn1 = Console.ReadLine();
                                   newCategory.MeasureName = mn1;
                                   int savedCategoryId = cm.UpdateCategory(newCategory);
                                   Console.WriteLine("category updated" + " " + savedCategoryId.ToString());
                               }
                               break;

                           case 6:
                               Console.Clear();
                               Console.WriteLine("EXITING CATEGORY AND MEASURE MODULE ");
                               Console.Clear();

                               break;

                           default:
                               Console.Clear();
                               Console.WriteLine("ENTER CORRECT OPTION");
                               break;

                       }
                       break;
                    
                    
                    
                    
                    
                    case 2: 
                   //Console.Clear();
                   Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");

                   Console.WriteLine("STOCK AND PRODUCT MODULE");
                   Console.WriteLine("WHAT OPERATION DO YOU WANT TO PERFORM?"); 
                   Console.WriteLine("1. ADD PRODUCT ");
                   Console.WriteLine("2. DELETE PRODUCT ");
                   Console.WriteLine("3. VIEW PRODUCT");
                   Console.WriteLine("4. VIEW PRODUCT BY ID ");
                   Console.WriteLine("5. UPDATE PRODUCT DETAILS");
                   Console.WriteLine("6. BUY PRODUCTS");
                   Console.WriteLine("7. SUPPLY PRODUCTS ");  
                   Console.WriteLine("8. EXIT");
                   Console.WriteLine("SELECT AN OPTION:");
                    int op1 = int.Parse(Console.ReadLine());
                        switch (op1)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("INSERT");
                                string pn, cn, pd, mn;
                                int pp, pq, pid;
                                Console.WriteLine("ENTER PRODUCT ID");
                                pid = int.Parse(Console.ReadLine());
                                newProduct.ProductID = pid;
                                Console.WriteLine("Enter category name");
                                cn = Console.ReadLine();
                                newProduct.CategoryName = cn;
                                Console.WriteLine("enter product name");
                                pn = Console.ReadLine();
                                newProduct.ProductName = pn;
                                Console.WriteLine("enter price");
                                pp = int.Parse(Console.ReadLine());
                                newProduct.ProductPrice = pp;
                                Console.WriteLine("enter product description");
                                pd = Console.ReadLine();
                                newProduct.ProductDescription = pd;
                                Console.WriteLine("enter product quantity");
                                pq = int.Parse(Console.ReadLine());
                                newProduct.ProductQuantity = pq;
                                Console.WriteLine("enter measurename");
                                mn = Console.ReadLine();
                                newProduct.MeasureName = mn;
                                int newProductId = pm.InsertProducts(newProduct);
                                Console.WriteLine("product inserted" + " " + newProductId.ToString());
                                break;

                            case 2:
                               Console.Clear();
                                Console.WriteLine("DELETE");
                                int x;
                                Console.WriteLine("enter pid you want to delete");
                                x = int.Parse(Console.ReadLine());
                                newProduct.ProductID = x;
                                bool proddel = pm.DeleteProducts(x);
                                if (proddel)
                                {
                                    Console.WriteLine("product deleted" + x.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("productid" + x.ToString() + "doesnt exist");
                                }
                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("VIEW");
                                Console.WriteLine("view the table");
                                pm.GetProduct();
                                break;

                            case 4:
                              Console.Clear();
                                Console.WriteLine("VIEW BY ID");
                                //Console.WriteLine("This is part of inner switch ");
                                Console.WriteLine("view the table by id");
                                int y = int.Parse(Console.ReadLine());
                                Console.Clear();
                                pm.GetProductById(y);
                                break;

                            case 5:
                               Console.Clear();
                                Console.WriteLine("UPDATE");
                                //Console.WriteLine("This is part of inner switch ");
                                Console.WriteLine("update?");
                                bool ans = Convert.ToBoolean(Console.ReadLine());
                                if (ans)
                                {
                                    string pn1, cn1, pd1, mn1;
                                    int pp1, pq1, pid1;
                                    Console.WriteLine("enter pid you want to update");
                                    pid1 = int.Parse(Console.ReadLine());
                                    newProduct.ProductID = pid1;
                                    Console.WriteLine("enter categoryname");
                                    cn1 = Console.ReadLine();
                                    newProduct.CategoryName = cn1;
                                    Console.WriteLine("enter product name");
                                    pn1 = Console.ReadLine();
                                    newProduct.ProductName = pn1;
                                    Console.WriteLine("enter price");
                                    pp1 = int.Parse(Console.ReadLine());
                                    newProduct.ProductPrice = pp1;
                                    Console.WriteLine("enter product description");
                                    pd1 = Console.ReadLine();
                                    newProduct.ProductDescription = pd1;
                                    Console.WriteLine("enter product quantity");
                                    pq1 = int.Parse(Console.ReadLine());
                                    newProduct.ProductQuantity = pq1;
                                    Console.WriteLine("enter measure name");
                                    mn1 = Console.ReadLine();
                                    newProduct.MeasureName = mn1;
                                    int savedProductId = pm.UpdateProducts(newProduct);
                                    Console.WriteLine("product updated" + " " + savedProductId.ToString());
                                }
                                break;



                            case 6:
                                Console.Clear();
                                Console.WriteLine("BUY PRODUCTS");
                                int cId, pId, q;
                                Console.WriteLine("Enter Customer ID : ");
                                cId = int.Parse(Console.ReadLine());
                                newBill.CustomerId = cId;
                               Console.WriteLine("Enter Product ID : ");
                               pId = int.Parse(Console.ReadLine());
                               newBill.ProductID = pId;
                               Console.WriteLine("Enter the quantity purchased : ");
                               q= int.Parse(Console.ReadLine());
                               newBill.Quantity = q;
                               pm.BuyProduct(pId,cId,newBill, q);
                               bm.InsertBill(newBill);
                               break;
                            
                            
                            case 7:
                                Console.Clear();
                                Console.WriteLine("SUPPLY PRODUCTS");
                                int pid2,q1;
                                Console.WriteLine("enter pid you want to supply products");
                                pid2 = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter quantity to add");
                                q1 = int.Parse(Console.ReadLine());
                                pm.supplyproduct(pid2, q1);
                                Console.WriteLine(q1.ToString() + " " + "products added");
                                break;
                            
                            
                            
                            case 8:
                                Console.Clear();
                                Console.WriteLine("EXITING STOCK AND PRODUCT MODULE");
                                Console.Clear();
                                
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("ENTER CORRECT OPTION");
                                break;

                        }
                        break;


                    case 3:
                        //Console.Clear();
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");

                        Console.WriteLine("SUPPLIER MODULE");
                        Console.WriteLine("WHAT OPERATION DO YOU WANT TO PERFORM?");
                        Console.WriteLine("1. ADD SUPPLIER ");
                        Console.WriteLine("2. DELETE  SUPPLIER");
                        Console.WriteLine("3. VIEW SUPPLIER ");
                        Console.WriteLine("4. VIEW SUPPLIER BY ID ");
                        Console.WriteLine("5. UPDATE SUPPLIER DETAILS");
                        Console.WriteLine("6. EXIT");
                        Console.WriteLine("SELECT AN OPTION:");
                        int op3 = int.Parse(Console.ReadLine());
                        switch (op3)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("ADD SUPPLIER");
                                string sn;
                                int sid,pid,q;
                                Console.WriteLine("ENTER SUPPLIER ID");
                                sid = int.Parse(Console.ReadLine());
                                newSupplier.SupplierID = sid;
                                Console.WriteLine("Enter SUPPLIER name");
                                sn = Console.ReadLine();
                                newSupplier.SupplierName = sn;
                                Console.WriteLine("ENTER product Id ");
                                pid = int.Parse(Console.ReadLine());
                                newSupplier.ProductId = pid;
                                Console.WriteLine("ENTER quantity");
                                q = int.Parse(Console.ReadLine());
                                newSupplier.Quantity = q;
                                int newSupplierId = sm.InsertSuppliers(newSupplier);
                                Console.WriteLine("supplier inserted" + " " + newSupplierId.ToString());
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("DELETE SUPPLIER");
                                int x;
                                Console.WriteLine("enter sid you want to delete");
                                x = int.Parse(Console.ReadLine());
                                newSupplier.SupplierID = x;
                                bool supdel = sm.DeleteSuppliers(x);
                                if (supdel)
                                {
                                    Console.WriteLine("supplier deleted" + x.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("supplierid" + x.ToString() + "doesnt exist");
                                }
                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("VIEW");
                                Console.WriteLine("view the table");
                                sm.GetSupplier();
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("VIEW BY ID");
                                //Console.WriteLine("This is part of inner switch ");
                                Console.WriteLine("view the table by id");
                                int y = int.Parse(Console.ReadLine());
                                Console.Clear();
                                sm.GetSupplierById(y);
                                break;

                            case 5:
                                Console.Clear();
                                Console.WriteLine("UPDATE");
                                //Console.WriteLine("This is part of inner switch ");
                                Console.WriteLine("update?");
                                bool ans = Convert.ToBoolean(Console.ReadLine());
                                if (ans)
                                {
                                    string sn1;
                                    int sid1,q1,pid1;
                                    Console.WriteLine("enter sid you want to update");
                                    sid1 = int.Parse(Console.ReadLine());
                                    newCategory.CategoryID = sid1;
                                    Console.WriteLine("enter supplier name");
                                    sn1 = Console.ReadLine();
                                    newSupplier.SupplierName = sn1;
                                    Console.WriteLine("enter product id");
                                    pid1 = int.Parse(Console.ReadLine());
                                    newSupplier.ProductId = pid1;
                                    Console.WriteLine("enter quantity");
                                    q1 = int.Parse(Console.ReadLine());
                                    newSupplier.Quantity = q1;
                                    int savedSupplierId = sm.UpdateSuppliers(newSupplier);
                                    Console.WriteLine("supplier updated" + " " + savedSupplierId.ToString());
                                }
                                break;

                            case 6:
                                Console.Clear();
                                Console.WriteLine("EXITING SUPPLIER MODULE ");
                                Console.Clear();

                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("ENTER CORRECT OPTION");
                                break;

                        }
                        break;


                    case 4:
                        //Console.Clear();
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");

                        Console.WriteLine("CUSTOMER MODULE");
                        Console.WriteLine("WHAT OPERATION DO YOU WANT TO PERFORM?");
                        Console.WriteLine("1. ADD CUSTOMER ");
                        Console.WriteLine("2. DELETE  CUSTOMER");
                        Console.WriteLine("3. VIEW CUSTOMER ");
                        Console.WriteLine("4. VIEW CUSTOMER BY ID ");
                        Console.WriteLine("5. UPDATE CUSTOMER DETAILS");
                        Console.WriteLine("6. EXIT");
                        Console.WriteLine("SELECT AN OPTION:");
                        int op4 = int.Parse(Console.ReadLine());
                        switch (op4)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("ADD CUSTOMER");
                                string cn;
                                int cid,mn;
                                Console.WriteLine("ENTER CUSTOMER ID");
                                cid = int.Parse(Console.ReadLine());
                                newCustomer.CustomerID = cid;
                                Console.WriteLine("Enter customer name");
                                cn = Console.ReadLine();
                                newCustomer.CustomerName = cn;
                                Console.WriteLine("enter phoneno");
                                mn = int.Parse(Console.ReadLine());
                                newCustomer.CustomerPhoneNo = mn;
                                int newCustomerId = ccm.InsertCustomer(newCustomer);
                                Console.WriteLine("customer inserted" + " " + newCustomerId.ToString());
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("DELETE CUSTOMER");
                                int x;
                                Console.WriteLine("enter cid you want to delete");
                                x = int.Parse(Console.ReadLine());
                                newCustomer.CustomerID = x;
                                bool catdel = ccm.DeleteCustomer(x);
                                if (catdel)
                                {
                                    Console.WriteLine("customer deleted" + x.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("customerid" + x.ToString() + "doesnt exist");
                                }
                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("VIEW");
                                Console.WriteLine("view the table");
                                ccm.GetCustomer();
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("VIEW BY ID");
                                //Console.WriteLine("This is part of inner switch ");
                                Console.WriteLine("view the table by id");
                                int y = int.Parse(Console.ReadLine());
                                Console.Clear();
                                ccm.GetCustomerById(y);
                                break;

                            case 5:
                                Console.Clear();
                                Console.WriteLine("UPDATE");
                                //Console.WriteLine("This is part of inner switch ");
                                Console.WriteLine("update?");
                                bool ans = Convert.ToBoolean(Console.ReadLine());
                                if (ans)
                                {
                                    string cn1;
                                    int cid1,mn1;
                                    Console.WriteLine("enter cid you want to update");
                                    cid1 = int.Parse(Console.ReadLine());
                                    newCustomer.CustomerID = cid1;
                                    Console.WriteLine("enter customername");
                                    cn1 = Console.ReadLine();
                                    newCustomer.CustomerName = cn1;
                                    Console.WriteLine("enter phone number");
                                    mn1 = int.Parse(Console.ReadLine());
                                    newCustomer.CustomerPhoneNo = mn1;
                                    int savedCustomerId = ccm.UpdateCustomer(newCustomer);
                                    Console.WriteLine("customer updated" + " " + savedCustomerId.ToString());
                                }
                                break;

                            case 6:
                                Console.Clear();
                                Console.WriteLine("EXITING CUSTOMER MODULE ");
                                Console.Clear();

                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("ENTER CORRECT OPTION");
                                break;

                        }
                        break;

                    case 5:
                        //Console.Clear();
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");

                        Console.WriteLine("BILL MODULE");
                        Console.WriteLine("WHAT OPERATION DO YOU WANT TO PERFORM?");
                        Console.WriteLine("1. VIEW BILLS ");
                        Console.WriteLine("2. VIEW BILLS BY ID ");
                        Console.WriteLine("3. EXIT");
                        Console.WriteLine("SELECT AN OPTION:");
                        int op5 = int.Parse(Console.ReadLine());
                        switch (op5)
                        {
                           

                            case 1:
                                Console.Clear();
                                Console.WriteLine("VIEW");
                                Console.WriteLine("view the table");
                                bm.GetBill();
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("VIEW BY ID");
                                //Console.WriteLine("This is part of inner switch ");
                                Console.WriteLine("view the table by id");
                                int y = int.Parse(Console.ReadLine());
                                Console.Clear();
                                bm.GetBillById(y);
                                break;

                            case 5:
                                Console.Clear();
                                Console.WriteLine("UPDATE");
                                //Console.WriteLine("This is part of inner switch ");
                                Console.WriteLine("update?");
                                bool ans = Convert.ToBoolean(Console.ReadLine());
                                if (ans)
                                {
                                    string cn1;
                                    int cid1, mn1;
                                    Console.WriteLine("enter cid you want to update");
                                    cid1 = int.Parse(Console.ReadLine());
                                    newCustomer.CustomerID = cid1;
                                    Console.WriteLine("enter customername");
                                    cn1 = Console.ReadLine();
                                    newCustomer.CustomerName = cn1;
                                    Console.WriteLine("enter phone number");
                                    mn1 = int.Parse(Console.ReadLine());
                                    newCustomer.CustomerPhoneNo = mn1;
                                    int savedCustomerId = ccm.UpdateCustomer(newCustomer);
                                    Console.WriteLine("customer updated" + " " + savedCustomerId.ToString());
                                }
                                break;

                            case 6:
                                Console.Clear();
                                Console.WriteLine("EXITING BILLING MODULE ");
                                Console.Clear();

                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("ENTER CORRECT OPTION");
                                break;

                        }
                        break;

                    case 6:
                        //Console.Clear();
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");

                        Console.WriteLine("COMPLAINTS MODULE");
                        Console.WriteLine("WHAT OPERATION DO YOU WANT TO PERFORM?");
                        Console.WriteLine("1. ADD COMPLAINTS ");
                        Console.WriteLine("2. DELETE  COMPLAINTS");
                        Console.WriteLine("3. VIEW COMPLAINTS ");
                        Console.WriteLine("4. VIEW COMPLAINTS BY ID ");
                        Console.WriteLine("5. EXIT");
                        Console.WriteLine("SELECT AN OPTION:");
                        int op6 = int.Parse(Console.ReadLine());
                        switch (op6)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("ADD COMPLAINTS");
                                string tn;
                                int cid,cid1,pid,s,p;
                                Console.WriteLine("ENTER COMPLAINTS ID");
                                cid = int.Parse(Console.ReadLine());
                                newComplaints.complaintId=cid;
                                Console.WriteLine("ENTER CUSTOMER ID");
                                cid1 = int.Parse(Console.ReadLine());
                                newComplaints.customerId=cid1;
                                Console.WriteLine("ENTER PRODUCTS ID");
                                pid = int.Parse(Console.ReadLine());
                                newComplaints.ProductId=pid;
                                Console.WriteLine("ENTER STATUS");
                                s = int.Parse(Console.ReadLine());
                                newComplaints.status=s;
                                Console.WriteLine("ENTER PRIORITY");
                                p= int.Parse(Console.ReadLine());
                                newComplaints.priority=p;
                                Console.WriteLine("Enter technicians name");
                                tn = Console.ReadLine();
                                newComplaints.technicianname = tn;
                                int newComplaintsId = cpm.InsertComplaints(newComplaints);
                                Console.WriteLine("complaint inserted" + " " + newComplaints.ToString());
                                break;

                            case 2:
                                Console.Clear();
                                Console.WriteLine("DELETE Complaints");
                                int x;
                                Console.WriteLine("enter cid you want to delete");
                                x = int.Parse(Console.ReadLine());
                                newComplaints.complaintId = x;
                                bool catdel = cpm.DeleteComplaints(x);
                                if (catdel)
                                {
                                    Console.WriteLine("complaint deleted" + x.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("complaintid" + x.ToString() + "doesnt exist");
                                }
                                break;

                            case 3:
                                Console.Clear();
                                Console.WriteLine("VIEW");
                                Console.WriteLine("view the table");
                                cpm.GetComplaints();
                                break;

                            case 4:
                                Console.Clear();
                                Console.WriteLine("VIEW BY ID");
                                //Console.WriteLine("This is part of inner switch ");
                                Console.WriteLine("view the table by id");
                                int y = int.Parse(Console.ReadLine());
                                Console.Clear();
                                cpm.GetComplaintsById(y);
                                break;

                            

                            case 5:
                                Console.Clear();
                                Console.WriteLine("EXITING COMPLAINTS MODULE ");
                                Console.Clear();

                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("ENTER CORRECT OPTION");
                                break;

                        }
                        break;
                    
                  }//main switch close
                
                
                 }while(op!=7);
               
        }
    }
}
