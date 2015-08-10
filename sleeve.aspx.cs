using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Net.Mime;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.Reflection;
using System.Linq;
using System.Web;
using System.IO;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


//[assembly: AssemblyTitle("SimpleRESTServices")]
public partial class Sleeve : System.Web.UI.Page
{

    [WebMethod]
    public void SyncToFileManager()
    {

        var appUUID = Request.Form.Get("genUUID");
        string filenamenew = "sleeve-" + Request.Form.Get("genUUID") + ".pdf";
        string httpContainer = "http://xx.xxx.xxx.xxx/UploadedFiles/" + filenamenew;

        // Insert a new record into Contact
        string connString = ConfigurationManager.ConnectionStrings["swgProd"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(connString);

        conn.Open();

        MySqlCommand cmd = conn.CreateCommand();

        cmd.CommandText = "INSERT INTO filemanager (UUID, FileName, FileLink, isActive) VALUES (@UUID1,@FileName1,@FileLink1,@isActive1)";

        //filemanager attributes
        cmd.Parameters.AddWithValue("?UUID1", appUUID);
        cmd.Parameters.AddWithValue("?FileName1", filenamenew);
        cmd.Parameters.AddWithValue("?@FileLink1", httpContainer);
        cmd.Parameters.AddWithValue("?@isActive1", "YES");

        int rowsAffected = cmd.ExecuteNonQuery();

        if (rowsAffected > 0)
        {

            conn.Close();

            SendMsg();
        }

    }

    


    
[WebMethod]  
public void SendMsg()
{

        string toemailaddress = Request.Form.Get("email");
        string youremailadd = Request.Form.Get("youremail");

        var pathToAttachment = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/sleeve-" + Request.Form.Get("genUUID") + ".pdf");

        MailMessage mm = new MailMessage();

        try
        {
            HttpFileCollection uploadFilCol = Request.Files;
            for (int i = 0; i < uploadFilCol.Count; i++)
            {
                HttpPostedFile file = uploadFilCol[i];
                string fileExt = Path.GetExtension(file.FileName).ToLower();
                string fileName = Server.MapPath("./UploadedFiles/") + "sleeve-" + Request.Form.Get("genUUID") + Path.GetFileName(file.FileName) + Path.GetExtension(file.FileName).ToLower();
                if (file != null)
                {
                    mm.Attachments.Add(
                        new Attachment(fileName)
                    );
                }
            }
        }
        catch
        {

        }

        Attachment data = new Attachment(pathToAttachment, MediaTypeNames.Application.Octet);
        ContentDisposition disposition = data.ContentDisposition;
        disposition.CreationDate = System.IO.File.GetCreationTime(pathToAttachment);
        disposition.ModificationDate = System.IO.File.GetLastWriteTime(pathToAttachment);
        disposition.ReadDate = System.IO.File.GetLastAccessTime(pathToAttachment);

        string x = Request.Form.Get("email");
        string xs = Request.Form.Get("youremail");

        mm.To.Add(new MailAddress(x));

        MailAddress addressBCC = new MailAddress(xs);
        mm.Bcc.Add(addressBCC);

        mm.Subject = "" + Request.Form.Get("inspByNew") + "Submitted a New Sleeve Inspection Form";
        mm.Body = "To view the message, please use an HTML compatible email viewer! *** This is an automatically generated email, please do not reply*** This is an automatically generated email, please do not reply *** " + Request.Form.Get("inspByNew") + " has completed a Sleeve Inspection Record. Please see the attached form (.pdf).";

        mm.Attachments.Add(data);

        SmtpClient client = new SmtpClient();
        client.Port = 587;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("postmaster@xxx.xxxxxx-xxxxx.com", "xxxxxx-xxxxx");
        client.Host = "smtp.mailgun.org";

        try
        {
            client.Send(mm);
            //Complete();

            string resultResponse = "finished";
            Response.Write(resultResponse);
            Response.End();
            //MessageBox.Show("Email Sent!");
        }
        catch (Exception ex)
        {

        }

        client.Dispose();
    }



[WebMethod]
public void MakeThePDF(){

        var pdfPath = Path.Combine(Server.MapPath("~/PDFTemplates/SleeveBlank.pdf"));

        // Get the form fields for this PDF and fill them in!
        var formFieldMap = PDFHelper.GetFormFieldNames(pdfPath);
        var newidfromform = Request.Form.Get("genUUID");
        
        //formFieldMap["text500"] = text500");
        //formFieldMap["text200"] = text200");
        formFieldMap["contractName"] = Request.Form.Get("contractName");
        formFieldMap["reinspectDate"] = Request.Form.Get("reinspectDate");
        formFieldMap["Reinspection"] = Request.Form.Get("Reinspection");
        formFieldMap["glueProceedure"] = Request.Form.Get("glueProceedure");
        formFieldMap["locNew"] = Request.Form.Get("locNew");
        formFieldMap["sleeveFootage"] = Request.Form.Get("sleeveFootage");
        formFieldMap["signatureNameSL"] = Request.Form.Get("signatureNameSL");
        formFieldMap["sleeveMobile"] = Request.Form.Get("sleeveMobile");
        formFieldMap["explanationSummary"] = Request.Form.Get("explanationSummary");
        formFieldMap["projName"] = Request.Form.Get("projName");
        formFieldMap["InspType"] = Request.Form.Get("InspType");
        formFieldMap["sleeveContractor"] = Request.Form.Get("sleeveContractor");
        formFieldMap["numFtSleeve"] = Request.Form.Get("numFtSleeve");
        formFieldMap["officeSleeve"] = Request.Form.Get("officeSleeve");
        formFieldMap["dtNotified"] = Request.Form.Get("dtNotified");
        formFieldMap["sleeveSize"] = Request.Form.Get("sleeveSize");
        formFieldMap["inspDateNew"] = Request.Form.Get("inspDateNew");
        formFieldMap["WR"] = Request.Form.Get("wRNumber");
        formFieldMap["appVersion"] = Request.Form.Get("appVersion");
        formFieldMap["muleSL"] = Request.Form.Get("muleSL");
        formFieldMap["inspByName"] = Request.Form.Get("inspByName");
        formFieldMap["SleeveAcceptance"] = Request.Form.Get("SleeveAcceptance");
        formFieldMap["sleeveDept"] = Request.Form.Get("sleeveDept");
        formFieldMap["DeveloperName"] = Request.Form.Get("DeveloperName");
        formFieldMap["deptTrench"] = Request.Form.Get("deptTrench");

        if (Request.Form.Get("native1") != null)
            formFieldMap["native1"] = "Yes";

        if (Request.Form.Get("serviceTrenchRej") != null)
            formFieldMap["serviceTrenchRej"] = "Yes";

        if (Request.Form.Get("servicetrenchNo") != null)
            formFieldMap["servTrenNo"] = "Yes";

        if (Request.Form.Get("sand1") != null)
            formFieldMap["sand1"] = "Yes";

        var signature = Request.Form.Get("sleevesignature");
        var idEncoded = Request.Form.Get("genUUID");
        var grabFile = "sleeve-" + idEncoded + ".pdf";

        var pdfContents = PDFHelper.Generate2PDF(pdfPath, formFieldMap, signature);
        //GenPDF(pdfPath, formFieldMap, signature);

       PDFHelper.ReturnPDF(pdfContents, "sleeve-" + idEncoded + ".pdf");

       SyncToFileManager();
  
    }


[WebMethod]
protected void Page_Load(object sender, EventArgs e)
{
    syncDBnow();
}

[WebMethod]
private void syncDBnow()
{

        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.Cache.SetNoStore();

        //create pdf first
        //var getAttachedFile = FileUploadControl.PostedFile;
        var appUUID = Request.Form.Get("genUUID");

        // Insert a new record into Contact
        string connString = ConfigurationManager.ConnectionStrings["swgProd"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(connString);

        conn.Open();

        MySqlCommand cmd = conn.CreateCommand();
        //MySqlCommand cmd2 = conn.CreateCommand();

        cmd.CommandText = "INSERT INTO sleeve (UUID, sleevetype,inspectiondate,inspectedby,datenotified,projname,wr,developler,sleevecontractor,location,contactname,office,mobile,sleevefootage,servicetrench,depthsleeve,glueproc,muletape,sleevesize,shade,native,reinspectiondate,sleeveaccept,explanation,trenchdepth,numft,name, versionNumber, signaturedate) VALUES (@UUIDQ,@field1,@field2,@field3,@field4,@field5,@field6,@field7,@field8,@field9,@field10,@field11,@field12,@field13,@field14,@field15,@field16,@field17,@field18,@field19,@field20,@field21,@field22,@field23,@field24,@field25,@field26,@verNum,@DateSigned)";

        

        //sleeve attributes
        cmd.Parameters.AddWithValue("?UUIDQ", Request.Form.Get("genUUID"));
        cmd.Parameters.AddWithValue("?field1", Request.Form.Get("InspType"));
        cmd.Parameters.AddWithValue("?field2", Request.Form.Get("inspDateNew").NullString());

        cmd.Parameters.AddWithValue("?field3", Request.Form.Get("inspByName"));
        cmd.Parameters.AddWithValue("?field4", Request.Form.Get("dtNotified").NullString());
        cmd.Parameters.AddWithValue("?field5", Request.Form.Get("projName"));
        cmd.Parameters.AddWithValue("?field6", Request.Form.Get("wRNumber"));
        cmd.Parameters.AddWithValue("?field7", Request.Form.Get("DeveloperName"));
        cmd.Parameters.AddWithValue("?field8", Request.Form.Get("sleeveContractor"));
        cmd.Parameters.AddWithValue("?field9", Request.Form.Get("locNew"));
        cmd.Parameters.AddWithValue("?field10", Request.Form.Get("contractName"));

        cmd.Parameters.AddWithValue("?field11", Request.Form.Get("officeSleeve"));
        cmd.Parameters.AddWithValue("?field12", Request.Form.Get("sleeveMobile"));
        cmd.Parameters.AddWithValue("?field13", Request.Form.Get("sleeveFootage"));
        cmd.Parameters.AddWithValue("?field14", Request.Form.Get("serviceTrenchNo"));
        cmd.Parameters.AddWithValue("?field15", Request.Form.Get("sleeveDept"));
        cmd.Parameters.AddWithValue("?field16", Request.Form.Get("glueProceedure"));
        cmd.Parameters.AddWithValue("?field17", Request.Form.Get("muleSL"));
        cmd.Parameters.AddWithValue("?field18", Request.Form.Get("sleeveSize"));
        cmd.Parameters.AddWithValue("?field19", Request.Form.Get("sand1"));
        cmd.Parameters.AddWithValue("?field20", Request.Form.Get("native1"));

        cmd.Parameters.AddWithValue("?field21", Request.Form.Get("reinspectDate").NullString());
        cmd.Parameters.AddWithValue("?field22", Request.Form.Get("SleeveAcceptance"));
        cmd.Parameters.AddWithValue("?field23", Request.Form.Get("explanationSummary"));
        cmd.Parameters.AddWithValue("?field24", Request.Form.Get("deptTrench"));
        cmd.Parameters.AddWithValue("?field25", Request.Form.Get("numFtSleeve"));
        cmd.Parameters.AddWithValue("?field26", Request.Form.Get("signatureNameSL"));
        cmd.Parameters.AddWithValue("?verNum", Request.Form.Get("appVersion"));
        cmd.Parameters.AddWithValue("?DateSigned", Request.Form.Get("nameSleeveSigNew").NullString());

        int rowsAffected = cmd.ExecuteNonQuery();
        //int rowsAffectedCmd2 = cmd2.ExecuteNonQuery();

        if (rowsAffected > 0)
        {

            conn.Close();

            //get uploaded files
            try
            {
                HttpFileCollection uploadFilCol = Request.Files;
                for (int i = 0; i < uploadFilCol.Count; i++)
                {
                    HttpPostedFile file = uploadFilCol[i];
                    string fileExt = Path.GetExtension(file.FileName).ToLower();
                    string fileName = "sleeve-" + Request.Form.Get("genUUID") + Path.GetFileName(file.FileName) + Path.GetExtension(file.FileName).ToLower();

                    if (fileName != string.Empty)
                    {
                        try
                        {
                            if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".png")
                            {
                                file.SaveAs(Server.MapPath("./UploadedFiles/") + fileName);

                                // now insert image names into filemanager
                                string connString2 = ConfigurationManager.ConnectionStrings["swgProd"].ConnectionString;
                                MySqlConnection conn2 = new MySqlConnection(connString);

                                conn2.Open();

                                MySqlCommand cmd2 = conn2.CreateCommand();

                                string httpContainer2 = "http://xx.xxx.xxx.xxx/UploadedFiles/" + "sleeve-" + Request.Form.Get("genUUID") + Path.GetFileName(file.FileName) + Path.GetExtension(file.FileName).ToLower();

                                cmd2.CommandText = "INSERT INTO filemanager (UUID, FileName, FileLink, isActive) VALUES (@UUID2,@FileName2,@FileLink2,@isActive2)";

                                //filemanager attributes
                                cmd2.Parameters.AddWithValue("?UUID2", appUUID);
                                cmd2.Parameters.AddWithValue("?FileName2", fileName);
                                cmd2.Parameters.AddWithValue("?@FileLink2", httpContainer2);
                                cmd2.Parameters.AddWithValue("?@isActive2", "YES");

                                int rowsAffected2 = cmd2.ExecuteNonQuery();
                                //int rowsAffectedCmd2 = cmd2.ExecuteNonQuery();

                                if (rowsAffected2 > 0)
                                {

                                    conn2.Close();

                                }


                            }
                            else
                            {
                                //
                            }


                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch
            {

            }

            MakeThePDF();

        }
        else
        {

        }
        //end dbsync
    }


}
