using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;


/// <summary>
/// Summary description for PDF
/// </summary>
public class PDF
{
    public PDF()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void fillForm(Employee e)
    {
        Dictionary<string, string> props = new Dictionary<string, string>();
        PropertyInfo[] properties = e.GetType().GetProperties();
        foreach (PropertyInfo pi in properties)
        {
            if (pi.GetValue(e, null) != null)
            {

            props.Add(pi.Name, pi.GetValue(e, null).ToString());
            }

        }
        // string[] propNames = new string[] { "Employee_pass_id", "Fname", "Lname", "Origin_country", "Phone", "Birthday", "Fam_stat_code", "Gender", "Il_citizen", "Active", "Occupation_code", "Business", "Food_include", "Food_pay", "Salary_hour", "Sabatical", "Salary_overtime", "Salary_trans", "Day_off", "Com_app", "Monthly_rent", "Insurance", "Add", "Add_city", "Add_num" };
        try
        {
            string formFile = "C:\\Users\\Tom\\Documents\\לימודים\\שנה ג\\פרוייקט גמר\\חוזה_עבודה_-_חלק_א.pdf";
            string savepath = "C:\\Users\\Tom\\Documents\\לימודים\\שנה ג\\פרוייקט גמר\\חוזה_עבודה_-_חלק_אEdit.pdf";
            PdfReader pdfReader = new PdfReader(formFile);
     
            using (FileStream stream = new FileStream(savepath, FileMode.Create))
            {
                PdfStamper pdfStamper = new PdfStamper(pdfReader, stream);
                AcroFields formFields = pdfStamper.AcroFields;
                formFields.GenerateAppearances = true;
                //               foreach (DictionaryEntry de in formFields.Fields)
                // {
                foreach (var field in formFields.Fields)
                {
                    foreach (KeyValuePair<string, string> name in props)
                    {
                        if (name.Key == field.Key)
                        {
                            formFields.SetField(field.Key, name.Value);
                 
                        }
                    }



                //    Console.WriteLine("{0}, {1}",
                //        field.Key,
                //        field.Value);
                //}

                      }
                pdfStamper.FormFlattening = true;
                pdfStamper.Close();

            }
        
        
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
        }
    }

}