﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Mail;



/// <summary>
/// Summary description for ajaxWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService] // REMEMBER TO UNCOMMENT THIS LINE
public class ajaxWebService : System.Web.Services.WebService
{
    string emp;
    string empl;
    public ajaxWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //Get all Employees
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getEmployees()
    {
        Employee e = new Employee();
        List<Employee> LE = e.getEmployees();
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonStringCategory =  js.Serialize(LE);
        return jsonStringCategory;

    }

    //Get all Businesses for selectize
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getBusinesses()
    {
        Business b = new Business();
        List<Business> LB = b.getBusinesses();
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        var jsonStringCategory = js.Serialize(LB);
        return jsonStringCategory;

    }

    //Get all Businesses for Datatable
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void getBusinessesTable()
    {
    
        Business b = new Business();
        List<Business> LB = b.getBusinesses();
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        var jsonStringCategory = js.Serialize(LB);
        Context.Response.Write(jsonStringCategory);

    }

    //Get all cities for selectize
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getCities()
    {
        City c = new City();
        List<City> LC = c.getCities();
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonStringCategory = js.Serialize(LC);
        return jsonStringCategory;

    }

    //Get all Countries for selectize
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getCountries()
    {
        Country c = new Country();
        List<Country> LC = c.getCountries();
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonStringCategory = js.Serialize(LC);
        return jsonStringCategory;

    }

    //Get spesific Employess
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetEmployeeById(string pass)
    {
        Employee e = new Employee();
        e = e.getEmployeeById(pass);


        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonStringCategory = js.Serialize(e);
        return jsonStringCategory;

    }

    //Get all Employees without business
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void getEmployeesnobusiness()
    {
        Employee e = new Employee();
        List<Employee> LE = e.getEmployeesnobisiness();

        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        var jsonStringCategory = js.Serialize(LE);
        Context.Response.Write(jsonStringCategory);
        //return jsonStringCategory;

    }

    //Get all Employees without business for knobe statistic
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getEmployeesNoBusinessAmount()
    {
        Employee e = new Employee();
        List<Employee> LE = e.getEmployeesnobisiness();
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        var jsonStringCategory = js.Serialize(LE);
        //Context.Response.Write(jsonStringCategory);
        return jsonStringCategory;

    }

    //Get all Occupation for selectize
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getOccupation()
    {
        Occupation o = new Occupation();
        List<Occupation> LE = o.getOccupation();
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        var jsonStringCategory = js.Serialize(LE);
        //Context.Response.Write(jsonStringCategory);
        return jsonStringCategory;

    }

    //Insert an Employee
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertEmployee(string EmployeeInfo)
    {

        JavaScriptSerializer js = new JavaScriptSerializer();
       Employee e = js.Deserialize<Employee>(EmployeeInfo);
        e.Commence_date = DateTime.Now.ToString("dd/MM/yyy");
         int inserted = e.insertEmployee(e);
        PDF pdf = new PDF();
        List<string> contractPath = pdf.fillForm(e);

        if (inserted > 0)
        {


            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;
            string pushTXT = "נוסף עובד חדש מס' " + e.Employee_pass_id ;
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic MTZiZDk0Y2EtMzc5Ni00YWM5LWJmMjgtYWVmYjNhYjFkZTJi");

            var serializer = new JavaScriptSerializer();
            var obj = new
            {
                app_id = "83d04d9a-0af5-47ff-8e0d-daa16120ede1",
                contents = new { en = "Employee insurance status", he = pushTXT },
                headings = new { en = "Employee number " + e.Employee_pass_id + " insurance status has changed", he = "עובד חדש במערכת!" },
                included_segments = new string[] { "All" }
            };
            var param = serializer.Serialize(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
            }

            System.Diagnostics.Debug.WriteLine(responseContent);
        }
       
        string jsonStringCategory = js.Serialize(contractPath);
        return jsonStringCategory;

    }
    
    //Insert Signature into doc
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertSignature(string svgString, string[] fileString)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        PDF pdf = new PDF();
        List<string> saveFileString = pdf.AddSignature(svgString, fileString);
        string jsonStringCategory = js.Serialize(saveFileString);
        return jsonStringCategory;

    }

    //Update user Password
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void updateUserPass(string userName, string pass)
    {
        User u = new User();
        u.updatePass(userName, pass);
 

    }

    //update specific user
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string UpdateUser(string UserInfo)
    {
        try
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            User u = js.Deserialize<User>(UserInfo);



            int u1 = u.UpdateUser(u);
            // serialize to string
            string jsonStringCategory = js.Serialize(u1);
            return jsonStringCategory;
        }
        catch (Exception ex)
        {
            // write to log
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath("~/Log/DELog.txt")))
            {
                DBServices.Log(ex.GetType() + " - " + ex.Message, ex.StackTrace, w);

            }
            throw (ex);

        }
    }

    //Insert doc
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string InsertDoc(string FileInfo)
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Doc file = js.Deserialize<Doc>(FileInfo);

       int updated = file.updateDoc(file);
        // serialize to string
        string jsonStringCategory = js.Serialize(file);
        return jsonStringCategory;
    }

    //Update an Emmloyee
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string updateEmployee(string EmployeeInfo)
    {

        JavaScriptSerializer js = new JavaScriptSerializer();
        Employee e = js.Deserialize<Employee>(EmployeeInfo);

        e.updateEmp(e);
        PDF pdf = new PDF();
        List<string> contractPath = pdf.fillForm(e);
        string jsonStringCategory = js.Serialize(contractPath);
        return jsonStringCategory;

    }

    //Get Spesific user
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getUserByUserName(string username)
    {

        User u = new User();      
        u=u.getUserByUserName(username);

        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonStringCategory = js.Serialize(u);
        return jsonStringCategory;
    }

    //Validate User
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string validateUserByUserName(string username, string userPass)
    {
        bool match;
        User u = new User();
        match = u.getUserByUserName(username, userPass);

        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonStringCategory = js.Serialize(match);
        return jsonStringCategory;
    }

}



