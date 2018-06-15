﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Employee
{
  private string employee_pass_id;
    private string lname;
    private string fname;
    private DateTime birthday;
    private bool gender;
    private string picture;
    private int origin_country;
    private bool il_citizen;
    private int add_city;
    private string add;
    private int add_num;
    private int phone;
    private bool com_app;
    private int sys_id;
    private bool insurance;
    private bool com_insurance;
    private int fam_stat_code;
    private double salary_hour;
    private double salary_overtime;
    private double salary_trans;
    private int day_off;
    private int sabatical;
    private int occupation_code;
    private bool active;
    private string disable_reason;
    private int business;
    private bool updateBus;
    private List<Business> busHistory;
    private int rent;
    private int department_code;
    bool food_incloud;
    float food_pay;
    float monthly_rent;
    bool final_bill;
    DateTime commence_date;

    MemoryStream ms;


    public Employee()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Employee(string employee_pass_id, string lname, string fname, DateTime birthday, bool gender, string picture, int origin_country, bool il_citizen, int add_city, string add, int add_num, int phone, bool com_app, int sys_id, bool insurance, bool com_insurance, int fam_stat_code, double salary_hour, double salary_overtime, double salary_trans, int day_off, int sabatical, int occupation_code, bool active, string disable_reason, int business ,int department_code)
    { 
        this.employee_pass_id = employee_pass_id;
        this.lname = lname;
        this.fname = fname;
        this.birthday = birthday;
        this.gender = gender;
        this.picture = picture;
        this.origin_country = origin_country;
        this.il_citizen = il_citizen;
        this.add_city = add_city;
        this.add = add;
        this.add_num = add_num;
        this.phone = phone;
        this.com_app = com_app;
        this.sys_id = sys_id;
        this.insurance = insurance;
        this.com_insurance = com_insurance;
        this.fam_stat_code = fam_stat_code;
        this.salary_hour = salary_hour;
        this.salary_overtime = salary_overtime;
        this.salary_trans = salary_trans;
        this.day_off = day_off;
        this.sabatical = sabatical;
        this.occupation_code = occupation_code;
        this.active = active;
        this.disable_reason = disable_reason;
        this.business = business;
        this.department_code = department_code;

    }

    public string Employee_pass_id
    {
        get
        {
            return employee_pass_id;
        }

        set
        {
            employee_pass_id = value;
        }
    }

    public string Lname
    {
        get
        {
            return lname;
        }

        set
        {
            lname = value;
        }
    }

    public string Fname
    {
        get
        {
            return fname;
        }

        set
        {
            fname = value;
        }
    }

    public DateTime Birthday
    {
        get
        {
            return birthday;
        }

        set
        {
            birthday = value;
        }
    }

    public bool Gender
    {
        get
        {
            return gender;
        }

        set
        {
            gender = value;
        }
    }

    public string Picture
    {
        get
        {
            return picture;
        }

        set
        {
            picture = value;
        }
    }

    public int Origin_country
    {
        get
        {
            return origin_country;
        }

        set
        {
            origin_country = value;
        }
    }

    public bool Il_citizen
    {
        get
        {
            return il_citizen;
        }

        set
        {
            il_citizen = value;
        }
    }

    public int Add_city
    {
        get
        {
            return add_city;
        }

        set
        {
            add_city = value;
        }
    }

    public string Add
    {
        get
        {
            return add;
        }

        set
        {
            add = value;
        }
    }

    public int Add_num
    {
        get
        {
            return add_num;
        }

        set
        {

            add_num = value;
        }
    }

    public int Phone
    {
        get
        {
            return phone;
        }

        set
        {
            phone = value;
        }
    }

    public bool Com_app
    {
        get
        {
            return com_app;
        }

        set
        {
            com_app = value;
        }
    }

    public int Sys_id
    {
        get
        {
            return sys_id;
        }

        set
        {
            sys_id = value;
        }
    }

    public bool Insurance
    {
        get
        {
            return insurance;
        }

        set
        {
            insurance = value;
        }
    }

    public bool Com_insurance
    {
        get
        {
            return com_insurance;
        }

        set
        {
            com_insurance = value;
        }
    }

    public int Fam_stat_code
    {
        get
        {
            return fam_stat_code;
        }

        set
        {
            fam_stat_code = value;
        }
    }

    public double Salary_hour
    {
        get
        {
            return salary_hour;
        }

        set
        {
            salary_hour = value;
        }
    }

    public double Salary_overtime
    {
        get
        {
            return salary_overtime;
        }

        set
        {
            salary_overtime = value;
        }
    }

    public double Salary_trans
    {
        get
        {
            return salary_trans;
        }

        set
        {
            salary_trans = value;
        }
    }

    public int Day_off
    {
        get
        {
            return day_off;
        }

        set
        {
            day_off = value;
        }
    }

    public int Sabatical
    {
        get
        {
            return sabatical;
        }

        set
        {
            sabatical = value;
        }
    }

    public int Occupation_code
    {
        get
        {
            return occupation_code;
        }

        set
        {
            occupation_code = value;
        }
    }

    public bool Active
    {
        get
        {
            return active;
        }

        set
        {
            active = value;
        }
    }

    public string Disable_reason
    {
        get
        {
            return disable_reason;
        }

        set
        {
            disable_reason = value;
        }
    }

    public int Business
    {
        get
        {
            return business;
        }

        set
        {
            business = value;
        }
    }

    public List<Business> BusHistory
    {
        get
        {
            return busHistory;
        }

        set
        {
            busHistory = value;
        }
    }

    public bool UpdateBus
    {
        get
        {
            return updateBus;
        }

        set
        {
            updateBus = value;
        }
    }

    public int Rent
    {
        get
        {
            return rent;
        }

        set
        {
            rent = value;
        }
    }

    public int Department_code
    {
        get
        {
            return department_code;
        }

        set
        {
            department_code = value;
        }
    }

    public bool Food_incloud
    {
        get
        {
            return food_incloud;
        }

        set
        {
            food_incloud = value;
        }
    }

    public float Food_pay
    {
        get
        {
            return food_pay;
        }

        set
        {
            food_pay = value;
        }
    }

    public float Monthly_rent
    {
        get
        {
            return monthly_rent;
        }

        set
        {
            monthly_rent = value;
        }
    }

    public bool Final_bill
    {
        get
        {
            return final_bill;
        }

        set
        {
            final_bill = value;
        }
    }

    public DateTime Commence_date
    {
        get
        {
            return commence_date;
        }

        set
        {
            commence_date = value;
        }
    }

    public List<Employee> getEmployees()
    {
        DBServices dbs = new DBServices();

        List<Employee> LE = dbs.readEmployees();

        return LE;
        
    }
    public List<Employee> getEmployeesnobisiness()
    {
        DBServices dbs = new DBServices();

        List<Employee> LE = dbs.readEmployeesNoBusiness();

        return LE;

    }

    public Employee getEmployeeById(string pass)
    {
        DBServices dbs = new DBServices();

        Employee e = dbs.ReadEmployee(pass);

        return e;

    }

    public int insertEmployee(Employee e)
    {

           // Employee e = new Employee();
            //ms = new MemoryStream(Encoding.UTF8.GetBytes(EmployeeInfo));
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(e.GetType());
            //e = ser.ReadObject(ms) as Employee;
            DBServices dbs = new DBServices();
             int inserted = dbs.insert(e);
          inserted +=  dbs.insertEmpBus(e);
        return inserted;
    }
    public void updateEmp(Employee e)
    {


        DBServices dbs = new DBServices();
        dbs.updateEmp(e);
        if (e.updateBus)
        {
            dbs.updateFinDate(e);
        dbs.insertEmpBus(e);
        }

    }

}