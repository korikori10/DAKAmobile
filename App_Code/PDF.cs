using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        string[] propNames = new string[] {"Employee_pass_id", "Fname", "Lname", "Origin_country", "Phone" ,"Birthday","Fam_stat_code","Gender","Il_citizen", "Active","Occupation_code","Business", "Food_include", "Food_pay", "Salary_hour", "Sabatical", "Salary_overtime", "Salary_trans", "Day_off", "Com_app", "Monthly_rent", "Insurance", "Add", "Add_city", "Add_num" };
        try
        {
            string formFile = "C:\\Users\\Tom\\Documents\\לימודים\\שנה ג\\פרוייקט גמר\\הצהרת_בריאות_עברית_אנגליתedit.pdf";
            string savepath = "C:\\Users\\Tom\\Documents\\לימודים\\שנה ג\\פרוייקט גמר\\הצהרת_בריאות_עברית_אנגליתedited.pdf";
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
                    foreach (string name in propNames)
                    {
                        if (name == field.Key)
                        {
                            formFields.SetField(field.Key, e.Fname);
                            return;
                        }
                    }
                    //    Console.WriteLine("{0}, {1}",
                    //        field.Key,
                    //        field.Value);
                    //}

                    //             }
                    pdfStamper.FormFlattening = true;
                    pdfStamper.Close();

                }
            }
        }
        catch
        {
        }
        finally
        {
        }
    }

}