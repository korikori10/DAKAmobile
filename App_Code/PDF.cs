﻿using iTextSharp.text;
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

    public List<string> fillForm(Employee e)
    {
        Dictionary<string, string> props = new Dictionary<string, string>();
        PropertyInfo[] properties = e.GetType().GetProperties();
        foreach (PropertyInfo pi in properties)
        {
            if (pi.GetValue(e, null) != null)
            {
                if (pi.PropertyType == typeof(DateTime))
                {
                    string bday = pi.GetValue(e, null).ToString().Split(' ')[0];
                    props.Add(pi.Name, bday);

                }
                else
                {
                    props.Add(pi.Name, pi.GetValue(e, null).ToString());

                }
            }

        }
       
            DirectoryInfo d = new DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~/Contract/Default"));
        List<string> filesPaths = new List<string>();
        foreach (var file in d.GetFiles("*.pdf"))
        {

        
        try
        {
                string formFile = file.FullName; //System.Web.HttpContext.Current.Server.MapPath("~/Contract/Default/חוזה_עבודה_-_חלק_א.pdf");
            Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/Contract/" + e.Employee_pass_id));
            string savepath = System.Web.HttpContext.Current.Server.MapPath("~/Contract/" +e.Employee_pass_id +"/"+file.Name);
           
                string relSavePath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath + "/Contract/" + e.Employee_pass_id + "/" + file.Name;
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





                      }
                pdfStamper.FormFlattening = false;
                pdfStamper.Close();
                filesPaths.Add(relSavePath);
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
        return filesPaths;
    }

    public List<string> AddSignature(string svgString, string[] fileString)
    {
        List<string> savePaths = new List<string>();
        svgString = svgString.Split(',')[1];
        Byte[] bytes = Convert.FromBase64String(svgString);
        iTextSharp.text.Image itextImage = iTextSharp.text.Image.GetInstance(bytes);
        foreach (var file in fileString)
        {


            try
            {

                string fullPath = System.Web.HttpContext.Current.Server.MapPath("~" + file.Replace(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + HttpContext.Current.Request.ApplicationPath, ""));
                int idx = fullPath.LastIndexOf('.');
                int idx2 = file.LastIndexOf('.');
                string fileEnd = "_signed" + Path.GetRandomFileName() + ".pdf";
                string saveFileString = fullPath.Substring(0, idx) +fileEnd;
                string relSaveString = file.Substring(0, idx2) + fileEnd; ;
                using (Stream inputPdfStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read))

                
                using (Stream outputPdfStream = new FileStream(saveFileString, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    var reader = new PdfReader(inputPdfStream);
                    var stamper = new PdfStamper(reader, outputPdfStream);
                    var pdfContentByte = stamper.GetOverContent(1);

                    AcroFields formFields = stamper.AcroFields;
                    if (formFields.Fields.ContainsKey("signature"))
                    {
                        int i = 0;
                        foreach (var field in formFields.Fields)
                        {
                            if (field.Key == "signature")
                            {
                                AcroFields.FieldPosition f = formFields.GetFieldPositions(field.Key)[i];
                                int page = formFields.GetFieldPositions(field.Key)[i].page;//get(i).page;
                                formFields.SetField("Start_date", DateTime.Now.ToString("yyyy/MM/dd"));
                                iTextSharp.text.Rectangle rect = f.position;
                                itextImage.ScaleToFit(rect.Width, rect.Height);
                                int p = reader.NumberOfPages;

                                itextImage.SetAbsolutePosition(rect.Left, rect.Bottom);
                                i++;
                                pdfContentByte = stamper.GetOverContent(page);
                                pdfContentByte.AddImage(itextImage);

                            }
                        }

                    }
                    stamper.FormFlattening = true;
                    stamper.Close();


                }
                System.IO.File.Delete(fullPath);
                savePaths.Add( relSaveString);

            }
            catch (Exception ex)
            {

                // write to log
                throw (ex);
            }

        }
        return savePaths;
    }
}