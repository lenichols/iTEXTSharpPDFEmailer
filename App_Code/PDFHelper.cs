using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.IO;
using iTextSharp.text.pdf;
using System.Threading;
using iTextSharp.text;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


public class PDFHelper : System.Web.UI.Page
{


    public static Dictionary<string, string> GetFormFieldNames(string pdfPath)
    {
        var fields = new Dictionary<string, string>();

        var reader = new PdfReader(pdfPath);
        foreach (DictionaryEntry entry in reader.AcroFields.Fields)
            fields.Add(entry.Key.ToString(), string.Empty);
        //reader.Close();

        return fields;
    }

    [WebMethod]
    public static byte[] GeneratePDF(string pdfPath, Dictionary<string, string> formFieldMap, string sig)
    {

        var output = new MemoryStream();
        var reader = new PdfReader(pdfPath);
        var stamper = new PdfStamper(reader, output);
        var formFields = stamper.AcroFields;
        var document = new Document(PageSize.LETTER, 36, 36, 54, 54);
        var writer = PdfWriter.GetInstance(document, output);

        foreach (var fieldName in formFieldMap.Keys)
            formFields.SetField(fieldName, formFieldMap[fieldName]);

            //string signature = HttpContext.Current.Request.Form.Get("newsig");
            //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(signature);

            //string base64Image = HttpContext.Current.Request.Form.Get("newsig");
            string base64Image = sig;
            //string SigImg = base64Image.Split(',')[1];

            //string base64Img = sig;


            //if (sig != null) { 
            //Regex regex = new Regex(@"^data:image/(?<mediaType>[^;]+);base64,(?<data>.*)");
            //Match match = regex.Match(base64Image);

            PdfContentByte pdfContentByte = stamper.GetOverContent(1);
            //PdfContentByte pdfContentByte2 = stamper.GetOverContent(4);
            var image = iTextSharp.text.Image.GetInstance(
                System.Convert.FromBase64String(base64Image)
            );
            // System.Convert.FromBase64String(match.Groups["data"].Value)
            image.SetAbsolutePosition(270, 90);
            image.ScaleToFit(250f, 100f);
            pdfContentByte.AddImage(image);

            /*  var imagepath = "//test//";
              HttpFileCollection uploadFilCol = HttpContext.Current.Request.Files;
              for (int i = 0; i < uploadFilCol.Count; i++)
              {
                  HttpPostedFile file = uploadFilCol[i];

                  using (FileStream fs = new FileStream(imagepath +  "252-" + HttpContext.Current.Request.Form.Get("genUUID") + file, FileMode.Open))
                  {
                      HttpPostedFile file = uploadFilCol[i];

                      pdfContentByte2.AddImage(file);

                  }

 


              } */
       

        stamper.FormFlattening = true;

        stamper.Close();

        reader.Close();

        return output.ToArray();
        


    }



    public static byte[] Generate2PDF(string pdfPath, Dictionary<string, string> formFieldMap, string sig)
    {

        var output = new MemoryStream();
        var reader = new PdfReader(pdfPath);
        var stamper = new PdfStamper(reader, output);
        var formFields = stamper.AcroFields;
        var document = new Document(PageSize.LETTER, 36, 36, 54, 54);
        var writer = PdfWriter.GetInstance(document, output);

        foreach (var fieldName in formFieldMap.Keys)
            formFields.SetField(fieldName, formFieldMap[fieldName]);


        //string signature = HttpContext.Current.Request.Form.Get("newsig");
        //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(signature);

        //string base64Image = HttpContext.Current.Request.Form.Get("newsig");
        string base64Image = sig;
        //string SigImg = base64Image.Split(',')[1];

        //string base64Img = sig;


        //if (sig != null) { 
        //Regex regex = new Regex(@"^data:image/(?<mediaType>[^;]+);base64,(?<data>.*)");
        //Match match = regex.Match(base64Image);

        PdfContentByte pdfContentByte = stamper.GetOverContent(1);
        //PdfContentByte pdfContentByte2 = stamper.GetOverContent(4);
        var image = iTextSharp.text.Image.GetInstance(
            System.Convert.FromBase64String(base64Image)
        );
        // System.Convert.FromBase64String(match.Groups["data"].Value)
        image.SetAbsolutePosition(350, 100);
        image.ScaleToFit(250f, 100f);
        pdfContentByte.AddImage(image);

        /*  var imagepath = "//test//";
          HttpFileCollection uploadFilCol = HttpContext.Current.Request.Files;
          for (int i = 0; i < uploadFilCol.Count; i++)
          {
              HttpPostedFile file = uploadFilCol[i];

              using (FileStream fs = new FileStream(imagepath +  "252-" + HttpContext.Current.Request.Form.Get("genUUID") + file, FileMode.Open))
              {
                  HttpPostedFile file = uploadFilCol[i];

                  pdfContentByte2.AddImage(file);

              }

 


          } */


        stamper.FormFlattening = true;

        stamper.Close();

        reader.Close();

        return output.ToArray();



    }


  

    // See http://stackoverflow.com/questions/4491156/get-the-export-value-of-a-checkbox-using-itextsharp/
    public static string GetExportValue(AcroFields.Item item)
    {
        var valueDict = item.GetValue(0);
        var appearanceDict = valueDict.GetAsDict(PdfName.AP);

        if (appearanceDict != null)
        {
            var normalAppearances = appearanceDict.GetAsDict(PdfName.N);
            // /D is for the "down" appearances.

            // if there are normal appearances, one key will be "Off", and the other
            // will be the export value... there should only be two.
            if (normalAppearances != null)
            {
                foreach (var curKey in normalAppearances.Keys)
                    if (!PdfName.OFF.Equals(curKey))
                        return curKey.ToString().Substring(1); // string will have a leading '/' character, so remove it!
            }
        }

        // if that doesn't work, there might be an /AS key, whose value is a name with 
        // the export value, again with a leading '/', so remove it!
        var curVal = valueDict.GetAsName(PdfName.AS);
        if (curVal != null)
            return curVal.ToString().Substring(1);
        else
            return string.Empty;
    }

    public void ReturnPDF(byte[] contents)
    {
        ReturnPDF(contents, null);
    }

    public static void ReturnPDF(byte[] contents, string attachmentFilename)
    {
        

        var response = HttpContext.Current.Response;

      

        response.ContentType = "application/pdf";
        

        //response.Flush();
        //System.IO.File.WriteAllBytes(attachmentFilename, contents);
        //response.Close();


        System.IO.FileStream file = System.IO.File.Create(System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + attachmentFilename));

        file.Write(contents, 0, contents.Length);
        file.Close();

        




    }


}