﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
// REMEMBER TO ADD THIS NAMESPACE
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

/// <summary>
/// Summary description for ajaxWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService] // REMEMBER TO UNCOMMENT THIS LINE
public class ajaxWebService : System.Web.Services.WebService
{

    public ajaxWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

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

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetEmployeeById(string pass)
    {
        Employee e = new Employee();
        e.getEmployeeById(pass);


        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonStringCategory = js.Serialize(e);
        return jsonStringCategory;

    }

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

    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void insertEmployee(string[] emp)
    {
        string[] empl = emp;
        Employee e = new Employee();
        string employee = string.Join("", empl);
        //e.insertEmployee(emp);

        
        //e = (Employee)new JavaScriptSerializer().DeserializeObject(EmployeeInfo);
        

     
       

    }

    ////קבלת כל הקטגוריות הקיימות
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    //public string getCategory()
    //{

    //    Category c = new Category();
    //    List<Category> ls = c.getCategory();

    //    JavaScriptSerializer js = new JavaScriptSerializer();
    //    // serialize to string
    //    string jsonStringCategory = js.Serialize(ls);
    //    return jsonStringCategory;
    //}


    ////קבלת המוצרים באותה הקטגוריה
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    //public string getProductsByCat(string id)
    //{

    //    int categoryId = Convert.ToInt32(id);
    //    Category c = new Category();
    //    List<Product> ls = c.getProductsByCat(categoryId);

    //    JavaScriptSerializer js = new JavaScriptSerializer();
    //    // serialize to string
    //    string jsonStringCategory = js.Serialize(ls);
    //    return jsonStringCategory;
    //}


    ////קבלת כל הפרטים עבור מוצר
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public string getProduct(string id)
    //{

    //    int productId = Convert.ToInt32(id);
    //    Product p = new Product();
    //    Product p1 = p.getProduct(productId);

    //    JavaScriptSerializer js = new JavaScriptSerializer();
    //    // serialize to string
    //    string jsonStringCategory = js.Serialize(p1);
    //    return jsonStringCategory;
    //}


}
