﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for DBServices
/// </summary>
public class DBServices
{

    public SqlDataAdapter da;
    public DataTable dt;
    private string table;
    private string name;
    private string nameDS;
    public DBServices()
    {
       
    }

    //Log writer:
    public static void Log(string logMessage, string errorMessage, TextWriter w)
    {
        w.Write("\r\nLog Entry : ");
        w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
            DateTime.Now.ToLongDateString());
        w.WriteLine(" Error :{0}", errorMessage);
        w.WriteLine(" Text :{0}", logMessage);
        w.WriteLine("UserName: {0}", Environment.UserName);
        w.WriteLine("-------------------------------");
    }

    #region connection and Createcommand
    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }
    #endregion

    #region SELECT COMMANDs

    /// <summary>
    /// reads employees from sql
    /// </summary>
    /// <returns>list of employees</returns>
    public List<Employee> readEmployees()
    {

        SqlConnection con = null;

        try
        {

            con = connect("DAKADBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM EMPLOYEE where dbo.EMPLOYEE.active = '1'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            List<Employee> Employees = new List<Employee>();

            while (dr.Read())
            {   // Read till the end of the data into a row
                Employee e = new Employee();
                e.Employee_pass_id = dr["employee_pass_id"].ToString();
                e.Lname = dr["lname"].ToString();
                e.Fname = dr["fname"].ToString();
                e.Birthday = Convert.ToDateTime(dr["birthday"]);
                e.Gender = Convert.ToBoolean(dr["gender"]);
                e.Picture = dr["Picture"].ToString();
                e.Origin_country = Convert.ToInt32(dr["origin_country"]);
                e.Il_citizen = Convert.ToBoolean(dr["il_citizen"]);
                e.Add_city = Convert.ToInt32(dr["add_city"]);
                e.Add = dr["add"].ToString();
                e.Add_num = Convert.ToInt32(dr["add_num"]);
                e.Phone = Convert.ToInt32(dr["phone"]);
                e.Com_app = Convert.ToBoolean(dr["com_app"]);
                e.Sys_id = Convert.ToInt32(getString(dr["michpal_id"]));
                e.Insurance = Convert.ToBoolean(dr["insurance"]);
                e.Com_insurance = Convert.ToBoolean(dr["com_insurance"]);
                e.Fam_stat_code = Convert.ToInt32(dr["fam_stat_code"]);
                e.Salary_hour = Convert.ToInt32(dr["salary_hour"]);
                e.Salary_overtime = Convert.ToInt32(dr["salary_overtime"]);
                e.Salary_trans = Convert.ToInt32(dr["salary_trans"]);
                e.Day_off = Convert.ToInt32(dr["day_off_id"]);
                e.Sabatical = Convert.ToInt32(dr["sabatical"]);
                e.Occupation_code = Convert.ToInt32(dr["occupation_code"]);
                e.Active = Convert.ToBoolean(dr["active"]);
                // e.Disable_reason = dr["disable_reason"].ToString();

                Employees.Add(e);
            }

            return Employees;
        }

        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            
            throw (ex);

        }


        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }


    }


    /// <summary>
    /// reads employee from sql
    /// </summary>
    /// <returns>employee</returns>
    public Employee ReadEmployee(string emp_pss_id) 
    {
        SqlConnection con = null;

        try
        {

            con = connect("DAKADBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM empUpdate where employee_pass_id = '" + emp_pss_id + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            Employee Emp = new Employee();
            while (dr.Read())
            {

                Emp = new Employee(dr["employee_pass_id"].ToString(), dr["lname"].ToString(), dr["fname"].ToString(), Convert.ToDateTime(dr["birthday"]), Convert.ToBoolean(dr["gender"]), dr["Picture"].ToString(), Convert.ToInt32(dr["origin_country"]), Convert.ToBoolean(dr["il_citizen"]), Convert.ToInt32(dr["add_city"]), dr["add"].ToString(), Convert.ToInt32(dr["add_num"]), Convert.ToInt32(dr["phone"]), Convert.ToBoolean(dr["com_app"]), Convert.ToInt32(getString(dr["michpal_id"])), Convert.ToBoolean(dr["insurance"]), Convert.ToBoolean(dr["com_insurance"]), Convert.ToInt32(dr["fam_stat_code"]), Convert.ToInt32(dr["salary_hour"]), Convert.ToInt32(dr["salary_overtime"]), Convert.ToInt32(dr["salary_trans"]), Convert.ToInt32(dr["day_off_id"]), Convert.ToInt32(dr["sabatical"]), Convert.ToInt32(dr["occupation_code"]), Convert.ToBoolean(dr["active"]),  Convert.ToInt32(getString(dr["bus_id"])));

            }

            return Emp;
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);

        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    /// <summary>
    /// reads employees without business from sql
    /// </summary>
    /// <returns>list of employees</returns>
    public List<Employee> readEmployeesNoBusiness()
    {

        SqlConnection con = null;

        try
        {

            con = connect("DAKADBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM v_emp_no_busi_dash";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            List<Employee> Employees = new List<Employee>();
            while (dr.Read())
            {   // Read till the end of the data into a row
                Employee e = new Employee();
                e.Employee_pass_id = dr["employee_pass_id"].ToString();
                e.Lname = dr["lname"].ToString();
                e.Fname = dr["fname"].ToString();
                e.Birthday = Convert.ToDateTime(dr["birthday"]);
                e.Gender = Convert.ToBoolean(dr["gender"]);
                e.Picture = dr["Picture"].ToString();
                e.Origin_country = Convert.ToInt32(dr["origin_country"]);
                e.Il_citizen = Convert.ToBoolean(dr["il_citizen"]);
                e.Add_city = Convert.ToInt32(dr["add_city"]);
                e.Add = dr["add"].ToString();
                e.Add_num = Convert.ToInt32(dr["add_num"]);
                e.Phone = Convert.ToInt32(dr["phone"]);
                e.Com_app = Convert.ToBoolean(dr["com_app"]);
                e.Sys_id = Convert.ToInt32(getString(dr["michpal_id"]));
                e.Insurance = Convert.ToBoolean(dr["insurance"]);
                e.Com_insurance = Convert.ToBoolean(dr["com_insurance"]);
                e.Fam_stat_code = Convert.ToInt32(dr["fam_stat_code"]);
                e.Salary_hour = Convert.ToInt32(dr["salary_hour"]);
                e.Salary_overtime = Convert.ToInt32(dr["salary_overtime"]);
                e.Salary_trans = Convert.ToInt32(dr["salary_trans"]);
                e.Day_off = Convert.ToInt32(dr["day_off_id"]);
                e.Sabatical = Convert.ToInt32(dr["sabatical"]);
                e.Occupation_code = Convert.ToInt32(dr["occupation_code"]);
                e.Active = Convert.ToBoolean(dr["active"]);
              //  e.Disable_reason = dr["disable_reason"].ToString();

                Employees.Add(e);
            }

            return Employees;
        }

        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);

        }


        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }


    }

    /// <summary>
    /// reads businesses from sql
    /// </summary>
    /// <returns>list of businesses</returns>
    public List<Business> readBusinesses()
    {
        SqlConnection con = null;
        try
        {

            con = connect("DAKADBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM BUSINESSES";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            List<Business> businesses = new List<Business>();
            while (dr.Read())
            {   // Read till the end of the data into a row
                Business b = new Business();           
                b.Bus_id = Convert.ToInt32(dr["bus_id"]);
                b.Bus_name = dr["bus_name"].ToString();
                b.Add_city = Convert.ToInt32(dr["add_city"]);
                b.Add = dr["add"].ToString();
                b.Add_num = Convert.ToInt32(dr["add_num"]);
                b.Phone = Convert.ToInt32(dr["phone"]);
                b.Bus_type_code = Convert.ToInt32(dr["bus_type_code"]);
                b.Contract_code = Convert.ToInt32(dr["contract_code"]);   
                businesses.Add(b);
            }

            return businesses;
        }

        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);

        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    /// <summary>
    /// reads business from sql
    /// </summary>
    /// <returns>business</returns>
    public Business ReadBusiness(int bus_id)
    {
        SqlConnection con = null;

        try
        {

            con = connect("DAKADBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM BUSINESSES where bus_id = '" + bus_id + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            Business Busi = new Business();
            while (dr.Read())
            {
                Busi = new Business(Convert.ToInt32(dr["bus_id"]),dr["bus_name"].ToString(),Convert.ToInt32(dr["add_city"]),dr["add"].ToString(),Convert.ToInt32(dr["add_num"]),Convert.ToInt32(dr["phone"]), Convert.ToInt32(dr["bus_type_code"]),Convert.ToInt32(dr["contract_code"]));
            }
           return Busi;
           
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);

        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    /// <summary>
    /// reads Users from sql
    /// </summary>
    /// <returns>list of Users</returns>
    public List<User> readUsers()
    {

        SqlConnection con = null;

        try
        {

            con = connect("DAKADBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM USERS";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            List<User> Users = new List<User>();
            while (dr.Read())
            {   // Read till the end of the data into a row
                User u = new User(); 
            
                u.Uid =Convert.ToInt32(dr["uid"]);
                u.U_name = dr["u_name"].ToString();
                u.U_pwd = dr["u_pwd"].ToString();
                u.Full_name= dr["full_name"].ToString();
                u.U_type_code = Convert.ToInt32(dr["U_type_code"]);
                u.Phone = Convert.ToInt32(dr["phone"]);
                u.User_img= dr["user_img"].ToString();


                Users.Add(u);
            }

            return Users;
        }

        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);

        }


        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }


    }

    /// <summary>
    /// reads User from sql
    /// </summary>
    /// <returns>User</returns>
    public User ReadUser(string username)
    {
        SqlConnection con = null;

        try
        {

            con = connect("DAKADBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM USER_V1 where u_name = @UserName" ;
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            cmd.Parameters.AddWithValue("@UserName", username);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            User user = new User();
            while (dr.Read())
            {
                user = new User(Convert.ToInt32(dr["uid"]), dr["u_name"].ToString(), dr["u_pwd"].ToString(), dr["full_name"].ToString(), Convert.ToInt32(dr["U_type_code"]), (dr["U_type_name"]).ToString(), Convert.ToInt32(dr["phone"]), (dr["user_img"]).ToString());
            }

            return user;

        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);

        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    /// <summary>
    /// reads Occupation from sql
    /// </summary>
    /// <returns>list of Occupation</returns>
    public List<Occupation> readOccupation()
    {
        SqlConnection con = null;
        try
        {

            con = connect("DAKADBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM Occupation";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            List<Occupation> occupations = new List<Occupation>();
            while (dr.Read())
            {   // Read till the end of the data into a row
                Occupation o = new Occupation();
                o.Occupation_code = Convert.ToInt32(dr["occupation_code"]);
                o.Occupation_desc = dr["occupation_desc"].ToString();

                occupations.Add(o);
            }

            return occupations;
        }

        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);

        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    /// <summary>
    /// reads Countries from sql
    /// </summary>
    /// <returns>list of Countries</returns>
    public List<Country> readCountries()
    {
        SqlConnection con = null;

        try
        {

            con = connect("DAKADBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM Country ";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            List<Country> countries = new List<Country>();
            while (dr.Read())
            {

                Country country = new Country();
                country.Id = Convert.ToInt32(dr["ID"]);
                country.Name = dr["CountryName"].ToString();
                country.Country_code = dr["country_code"].ToString();



                countries.Add(country);
            }
            return countries;
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);

        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    /// <summary>
    /// reads cities from sql
    /// </summary>
    /// <returns>list of cities</returns>
    public List<City> readCities()
    {
        SqlConnection con = null;

        try
        {

            con = connect("DAKADBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM CITY ";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            List<City> cities = new List<City>();
            while (dr.Read())
            {
                
            City city = new City();
                city.Id= Convert.ToInt32(dr["ID"]);
                city.Name= dr["CITYName"].ToString();


                cities.Add(city);
            }
            return cities;
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);

        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    #endregion



    #region INSERT COMMAND

    //--------------------------------------------------------------------
    // insert an Employee
    //--------------------------------------------------------------------
    public int insert(Employee emp)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DAKADBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        String cStr = BuildInsertCommand(emp);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command
        cmd.Parameters.AddWithValue("@Lname", emp.Lname);
        cmd.Parameters.AddWithValue("@Sys_id", emp.Sys_id);
        cmd.Parameters.AddWithValue("@Fname", emp.Fname);
        cmd.Parameters.AddWithValue("@Birthday", emp.Birthday.ToString("yyyy-MM-dd"));
        cmd.Parameters.AddWithValue("@Gender", emp.Gender);
        cmd.Parameters.AddWithValue("@Origin_country", emp.Origin_country);
        cmd.Parameters.AddWithValue("@Add", emp.Add);
        cmd.Parameters.AddWithValue("@Emp_id", emp.Employee_pass_id);
        cmd.Parameters.AddWithValue("@Picture", emp.Picture);
        cmd.Parameters.AddWithValue("@Phone", emp.Phone);

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command

            
        

            return numEffected;
        }
        catch (Exception ex)
        {

            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String for employee
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Employee emp)
    {
        String command;


        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, {1} ,{2}, {3}, {4}, {5}, {6}, '{7}', '{8}', {9}, '{10}', {11}, '{12}', {13}, '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}','{25}','{26}','{27}')", "@Emp_id", "@Lname", "@Fname", "@Birthday", "@Gender", "@Picture", "@Origin_country", emp.Il_citizen, emp.Add_city, "@Add", emp.Add_num, "@Phone", emp.Com_app, "@Sys_id", emp.Insurance, emp.Com_insurance, emp.Fam_stat_code, emp.Salary_hour, emp.Salary_overtime, emp.Salary_trans, emp.Day_off, emp.Sabatical, emp.Occupation_code, emp.Active, emp.Food_incloud, emp.Food_pay, emp.Monthly_rent, "false");//לבדוק מה סטרינג כי הוא מצריך גרשיים אחדיים ולאינט לא!לבדוק מי צריך מה לגבי בול והשאר
        String prefix = "INSERT INTO EMPLOYEE " + "(employee_pass_id,lname,fname,birthday,gender,Picture,origin_country,il_citizen,add_city,[add],add_num,phone,com_app,michpal_id,insurance,com_insurance,fam_stat_code,salary_hour,salary_overtime,salary_trans,day_off_id,sabatical,occupation_code,active,food_incloud,food_pay,monthly_rent,final_bill) ";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------
    // insert an Business
    //--------------------------------------------------------------------
    public int insert(Business busi)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DAKADBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        String cStr = BuildInsertCommand(busi);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {

            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String for employee
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Business busi)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, '{1}' ,{2}, {3}, {4}, {5}, {6}, {7})", busi.Bus_id, busi.Bus_name, busi.Add_city, busi.Add, busi.Add_num, busi.Phone, busi.Bus_type_code, busi.Contract_code);//לבדוק מה סטרינג כי הוא מצריך גרשיים אחדיים ולאינט לא!לבדוק מי צריך מה לגבי בול והשאר
        String prefix = "INSERT INTO BUSINESSES " + "(bus_id,bus_name,add_city,add,add_num,phone,bus_type_code,contract_code)";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------
    // insert an User
    //--------------------------------------------------------------------
    public int insert(User user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DAKADBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        String cStr = BuildInsertCommand(user);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {

            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String for employee
    //--------------------------------------------------------------------
    private String BuildInsertCommand(User user)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, '{1}' ,{2}, {3}, {4},{5},{6})", user.Uid, user.U_name, user.U_pwd, user.Full_name, user.U_type_code,user.Phone,user.User_img);//לבדוק מה סטרינג כי הוא מצריך גרשיים אחדיים ולאינט לא!לבדוק מי צריך מה לגבי בול והשאר
        String prefix = "INSERT INTO USERS " + "(uid,u_name,u_pwd,full_name,U_type_code,phone,user_img)";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------
    // insert an emp to Business
    //--------------------------------------------------------------------
    public int insertEmpBus(Employee emp)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DAKADBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        String cStr = BuildInsertCommandEmpBus(emp);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {

            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String for employee
    //--------------------------------------------------------------------
    private String BuildInsertCommandEmpBus(Employee emp)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', {1} ,'{2}')", emp.Employee_pass_id, emp.Business, DateTime.Now.ToString("yyyy-MM-dd"));
        String prefix = "INSERT INTO [employee in business] " + "(employee_pass_id, bus_id,start_date)";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------
    // insert a New DOc
    //--------------------------------------------------------------------
    public int inserNewtDoc(Doc emp)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DAKADBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        String cStr = BuildInsertNewDocCommand(emp);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {

            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.GetType() + " - " + ex.Message, ex.StackTrace, w);

            }

            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the Insert command String for employee docs
    //--------------------------------------------------------------------
    private String BuildInsertNewDocCommand(Doc emp)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}','{1}' ,'{2}', '{3}', '{4}','{5}','{6}')", emp.Doctype_id, emp.Img_url, DateTime.Now.ToString("yyyy-MM-dd"), emp.Ex_date, "True", emp.Employee_pass_id, emp.Doc_id);
        String prefix = "UPDATE DOCS SET active = 'false'  where emp_id = '" + emp.Employee_pass_id + "' and doctype_id='" + emp.Doctype_id + "' and last_update != '"+ DateTime.Now.ToString("yyyy-MM-dd") + "'; INSERT INTO DOCS " + "(doctype_id,img_url,last_update,ex_date,active,emp_id,doc_id)";
        command = prefix + sb.ToString();

        return command;
    }

    #endregion




    #region UPDATE COMMAND

    //--------------------------------------------------------------------
    // Update Employee
    //--------------------------------------------------------------------
    public int updateEmp(Employee emp)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DAKADBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        String cStr = BuildUpdateCommand(emp);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command
        cmd.Parameters.AddWithValue("@Lname", emp.Lname);
        cmd.Parameters.AddWithValue("@Fname", emp.Fname);
        cmd.Parameters.AddWithValue("@Birthday", emp.Birthday.ToString("yyyy-MM-dd"));
        cmd.Parameters.AddWithValue("@Gender", emp.Gender);
        cmd.Parameters.AddWithValue("@Origin_country", emp.Origin_country);
        cmd.Parameters.AddWithValue("@Add", emp.Add);
        cmd.Parameters.AddWithValue("@Emp_id", emp.Employee_pass_id);
        cmd.Parameters.AddWithValue("@Picture", emp.Picture);
        cmd.Parameters.AddWithValue("@Phone", emp.Phone);

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {

            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------
    // Build the business a employy command String
    //--------------------------------------------------------------------
    private String BuildUpdateCommand(Employee emp)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        String prefix = "UPDATE EMPLOYEE SET lname = @Lname, fname = @Fname, birthday = @Birthday, gender = @Gender, Picture = @Gender, origin_country = @Origin_country, il_citizen = '" + emp.Il_citizen + "', add_city = '" + emp.Add_city + "', [add] = @Add, add_num = '" +emp.Add_num + "', phone = '" +emp.Phone + "', com_app = '" + emp.Com_app + "', monthly_rent = '" + emp.Monthly_rent+ "', insurance = '" +emp.Insurance + "', com_insurance = '" + emp.Com_insurance + "', fam_stat_code = '" +emp.Fam_stat_code + "', salary_hour = '" + emp.Salary_hour + "', salary_overtime = '" + emp.Salary_overtime + "', salary_trans = '" + emp.Salary_trans + "', day_off_id = '" + emp.Day_off + "', sabatical = '" +emp.Sabatical + "', occupation_code = '" +emp.Occupation_code + "', active = '" + emp.Active + "', food_incloud = '" +emp.Food_incloud+ "', food_pay = '" +emp.Food_pay+ "', final_bill = '" +emp.Final_bill+ "' Where employee_pass_id = @Emp_id";
        command = prefix;// prefix;

        return command;
    }

    //--------------------------------------------------------------------
    // Update business
    //--------------------------------------------------------------------
    public int update(Business busi)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DAKADBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        String cStr = BuildUpdateCommand(busi);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {

            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------
    // Build the update a business command String
    //--------------------------------------------------------------------
    private String BuildUpdateCommand(Business busi)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
       // String prefix = "UPDATE EMPLOYEE SET lname = " /*+ emp.Inventory + " Where product_id = " + emp.ProductId*/;
        command = "";// prefix;

        return command;
    }


    ////--------------------------------------------------------------------
    //// Update user
    ////--------------------------------------------------------------------
    //public int updateUser(User u)
    //{

    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("DAKADBConnectionString"); // create the connection
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
    //        {
    //            Log(ex.Message, ex.StackTrace, w);

    //        }
    //        throw (ex);
    //    }

    //    String cStr = BuildUpdateCommand(u);      // helper method to build the insert string

    //    cmd = CreateCommand(cStr, con);             // create the command
    //    cmd.Parameters.AddWithValue("@U_name", u.U_name);
    //    cmd.Parameters.AddWithValue("@FullName", u.Full_name);
    //    cmd.Parameters.AddWithValue("@Phone", u.Phone);
    //    cmd.Parameters.AddWithValue("@U_img", u.User_img);

    //    try
    //    {
    //        int numEffected = cmd.ExecuteNonQuery(); // execute the command
    //        return numEffected;
    //    }
    //    catch (Exception ex)
    //    {

    //        // write to log
    //        using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
    //        {
    //            Log(ex.Message, ex.StackTrace, w);

    //        }
    //        throw (ex);
    //    }

    //    finally
    //    {
    //        if (con != null)
    //        {
    //            // close the db connection
    //            con.Close();
    //        }
    //    }

    //}


    ////--------------------------------------------------------------------
    //// Build the update a user command String
    ////--------------------------------------------------------------------
    //private String BuildUpdateCommand(User u)
    //{
    //    String command;

    //    StringBuilder sb = new StringBuilder();
    //  //  use a string builder to create the dynamic string
    //   String prefix = "UPDATE USERS SET u_name = @U_name, full_name = @FullName,U_type_code='" + u.U_type_code + "',phone= @Phone Where u_id = " + u.Uid;
    //    command = prefix;

    //    return command;
    //}
    //--------------------------------------------------------------------
    // Update user
    //--------------------------------------------------------------------
    public int updateUser(User u)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DAKADBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        String cStr = BuildUpdateuserCommand(u);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {

            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // Build the update a user command String
    //--------------------------------------------------------------------
    private String BuildUpdateuserCommand(User u)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        String prefix = "UPDATE USERS SET u_name = '" + u.U_name + "',full_name = '" + u.Full_name + "',phone = '" + u.Phone + "' Where uid = '" + u.Uid + "'";
        command = prefix;

        return command;
    }

  
    public int updateUserPass(string userName, string Pass)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DAKADBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        String cStr = BuildUpdateCommand(userName, Pass);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command
        cmd.Parameters.AddWithValue("@UserName", userName);
        cmd.Parameters.AddWithValue("@Pass", Pass);
        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {

            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------
    // Build the update a user command String
    //--------------------------------------------------------------------
    private String BuildUpdateCommand(string userName, string Pass)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        //  use a string builder to create the dynamic string
        String prefix = "UPDATE USERS SET u_pwd = @Pass Where u_name = @UserName";
        command = prefix;

        return command;
    }



    //--------------------------------------------------------------------
    // Update emp in bus end date UpdateFile
    //--------------------------------------------------------------------
    public int updateFinDate(Employee emp)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("DAKADBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        String cStr = BuildEndDateUpdateCommand(emp);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {

            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                Log(ex.Message, ex.StackTrace, w);

            }
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }



    //--------------------------------------------------------------------
    // Build the business a employy command String
    //--------------------------------------------------------------------
    private String BuildEndDateUpdateCommand(Employee emp)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        String prefix = "UPDATE [employee in business] SET end_date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' Where employee_pass_id = '" + emp.Employee_pass_id + "' and end_date is null";
        command = prefix;// prefix;

        return command;
    }

    #endregion


    private static object getString(object o)

    {

        if (o == DBNull.Value)
        {
            return o = "0";
        }
        return o;

    }
}
