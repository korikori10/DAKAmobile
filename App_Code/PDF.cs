using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
    string file;
    string svgImage;

    public string File
    {
        get
        {
            return file;
        }

        set
        {
            file = value;
        }
    }

    public string SvgImage
    {
        get
        {
            return svgImage;
        }

        set
        {
            svgImage = value;
        }
    }

    public PDF()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string fillForm(Employee e)
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
            string formFile = System.Web.HttpContext.Current.Server.MapPath("~/Contract/Default/חוזה_עבודה_-_חלק_א.pdf");
            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/Contract/" + e.Employee_pass_id));
            string savepath = System.Web.HttpContext.Current.Server.MapPath("~/Contract/" +e.Employee_pass_id +"/חוזה_עבודה_-_חלק_א.pdf");
            PdfReader pdfReader = new PdfReader(formFile);
            //Full path to the Unicode Arial file
            string ARIALUNI_TFF = System.Web.HttpContext.Current.Server.MapPath("~/HF/Arimo-Regular.ttf");

            //Create a base font object making sure to specify IDENTITY-H
            BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //Create a specific font object
           // iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 12);

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
                            formFields.SetFieldProperty(field.Key, "textfont", bf, null);
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
                return savepath;
            }
        
        
        }
        catch (Exception ex)
        {
            return null;
            // write to log
            throw (ex);
        }
        finally
        {
        }
    }
    public void AddSignature(string svgString, string fileString)
    {

        // System.Buffer.BlockCopy(svgString.ToCharArray(), 0, bytes, 0, bytes.Length);
        svgString = svgString.Split(',')[1];
        //byte[] data = Convert.FromBase64String(svgString); //new byte[svgString.Length * sizeof(char)];
        Byte[] bytes = Convert.FromBase64String(svgString);
        iTextSharp.text.Image itextImage = iTextSharp.text.Image.GetInstance(bytes);
        //  System.Drawing.ImageConverter imageConverter = new System.Drawing.ImageConverter();
        //System.Drawing.Image image = (System.Drawing.Image)imageConverter.ConvertFrom(data) as System.Drawing.Image;
        // image.Save("c:\\hello", ImageFormat.Jpeg);
        string saveFileString = fileString.Split('.')[0];
        using (Stream inputPdfStream = new FileStream(fileString, FileMode.Open, FileAccess.Read, FileShare.Read))
            
        //using (Stream inputImageStream = new FileStream("some_image.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
        using (Stream outputPdfStream = new FileStream(saveFileString + "_signed.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
        {
            var reader = new PdfReader(inputPdfStream);
            var stamper = new PdfStamper(reader, outputPdfStream);
            var pdfContentByte = stamper.GetOverContent(1);
            //  iTextSharp.text.Image itextImage = iTextSharp.text.Image.GetInstance(image, BaseColor.BLACK);
            // Image image = Image.GetInstance(inputImageStream);
            itextImage.SetAbsolutePosition(100, 200);
            itextImage.Width = 100;
            pdfContentByte.AddImage(itextImage);
            stamper.Close();


        }
    }
}