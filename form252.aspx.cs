using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mime;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using net.openstack.Providers.Rackspace;
using net.openstack.Core.Domain;
using System.Security.Permissions;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using iTextSharp.text;
using iTextSharp.text.pdf;
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



//[assembly: AssemblyTitle("SimpleRESTServices")]

public partial class Create252 : System.Web.UI.Page
{
    
[WebMethod]  
public void SyncToFileManager(){


    var appUUID = Request.Form.Get("genUUID");
    string filenamenew = "252-" + Request.Form.Get("genUUID") + ".pdf";
    string httpContainer = "http://xx.xxx.xxx.xxx/UploadedFiles/" + filenamenew;

    // Insert a new record into Contact
    string connString = ConfigurationManager.ConnectionStrings["swgProd"].ConnectionString;
    MySqlConnection conn = new MySqlConnection(connString);

    conn.Open();

    MySqlCommand cmd = conn.CreateCommand();

    try
    {
        cmd.CommandText = "INSERT INTO filemanager (UUID, FileName, FileLink, isActive) VALUES (@UUID1,@FileName1,@FileLink1,@isActive1)";

        //filemanager attributes
        cmd.Parameters.AddWithValue("?UUID1", appUUID);
        cmd.Parameters.AddWithValue("?FileName1", filenamenew);
        cmd.Parameters.AddWithValue("?@FileLink1", httpContainer);
        cmd.Parameters.AddWithValue("?@isActive1", "YES");

        int rwsInserted = cmd.ExecuteNonQuery();
        //int rowsAffectedCmd2 = cmd2.ExecuteNonQuery();

        if (rwsInserted > 0)
        {

            conn.Close();

            SendMsg();
            //get uploaded files
        }
    }
    catch
    {

    }

}

[WebMethod]  
public void SendMsg()
{

        string toemailaddress = Request.Form.Get("email");
        string youremailadd = Request.Form.Get("youremail");

        var pathToAttachment = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/252-" + Request.Form.Get("genUUID") + ".pdf");

        MailMessage mm = new MailMessage();

        try
        {
            HttpFileCollection uploadFilCol = Request.Files;
            for (int i = 0; i < uploadFilCol.Count; i++)
            {
                HttpPostedFile file = uploadFilCol[i];
                string fileExt = Path.GetExtension(file.FileName).ToLower();
                string fileName = Server.MapPath("./UploadedFiles/") + "252-" + Request.Form.Get("genUUID") + Path.GetFileName(file.FileName) + Path.GetExtension(file.FileName).ToLower();
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

        mm.Subject = "New SWG FORM252 Completed - Field Evaluation from " + Request.Form.Get("Preparedby");
        mm.Body = "To view the message, please use an HTML compatible email viewer! *** This is an automatically generated email, please do not reply *** "+ Request.Form.Get("Preparedby") +" has completed a 252 Form Evaluation. Please see the attached form (.pdf).";

        mm.Attachments.Add(data);

        //mm.Attachments.Add(new Attachment(memoryStream, "252-" + genUUID") + ".pdf"));
        SmtpClient client = new SmtpClient();
        client.Port = 587;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("postmaster@xxx.xxx-xxx.com", "xxxxxx-xxxx");
        client.Host = "smtp.mailgun.org";

        try
        {
            client.Send(mm);

        }
        catch (Exception ex)
        {

        }

        client.Dispose();
    }




[WebMethod]
public void MakeThePDF()
{

    var pdfPath = Path.Combine(Server.MapPath("~/PDFTemplates/swgForm252Blank.pdf"));

    // Get the form fields for this PDF and fill them in!
    var formFieldMap = PDFHelper.GetFormFieldNames(pdfPath);
    var newidfromform = Request.Form.Get("genUUID");


    //formFieldMap["text500"] = text500");
    //formFieldMap["text200"] = text200");
    formFieldMap["Preparedby"] = Request.Form.Get("Preparedby");
    formFieldMap["addr22"] = Request.Form.Get("addr22");
    formFieldMap["MainFt"] = Request.Form.Get("MainFt");
    formFieldMap["addr27"] = Request.Form.Get("addr27");
    formFieldMap["Laborer"] = Request.Form.Get("Laborer");
    formFieldMap["train2"] = Request.Form.Get("train2");
    formFieldMap["DeptDates1"] = Request.Form.Get("DeptDates1");
    formFieldMap["comm2"] = Request.Form.Get("comm2");
    formFieldMap["addr25"] = Request.Form.Get("addr25");
    formFieldMap["addr15"] = Request.Form.Get("addr15");
    formFieldMap["train1"] = Request.Form.Get("train1");
    formFieldMap["ArrivDates2"] = Request.Form.Get("ArrivDates2");
    formFieldMap["FollowUpDate"] = Request.Form.Get("FollowUpDate");
    formFieldMap["addr24"] = Request.Form.Get("addr24");
    formFieldMap["addr14"] = Request.Form.Get("addr14");
    formFieldMap["WrkDesc"] = Request.Form.Get("WrkDesc");
    formFieldMap["CrewLeader"] = Request.Form.Get("CrewLeader");
    formFieldMap["JobNum"] = Request.Form.Get("JobNum");
    formFieldMap["DeptDates3"] = Request.Form.Get("DeptDates3");
    formFieldMap["Address"] = Request.Form.Get("Address");
    formFieldMap["Contrctr"] = Request.Form.Get("Contrctr");
    formFieldMap["PJQ4"] = Request.Form.Get("PJQ4");
    formFieldMap["PJQ1"] = Request.Form.Get("PJQ1");
    formFieldMap["PJQ2"] = Request.Form.Get("PJQ2");
    formFieldMap["PJQ3"] = Request.Form.Get("PJQ3");
    formFieldMap["DeptDates2"] = Request.Form.Get("DeptDates2");
    formFieldMap["addr26"] = Request.Form.Get("addr26");
    formFieldMap["addr16"] = Request.Form.Get("addr16");
    formFieldMap["addr17"] = Request.Form.Get("addr17");
    formFieldMap["addr21"] = Request.Form.Get("addr21");
    formFieldMap["addr11"] = Request.Form.Get("addr11");
    formFieldMap["SandNoLfts"] = Request.Form.Get("SandNoLfts");
    formFieldMap["DeptDates4"] = Request.Form.Get("DeptDates4");
    formFieldMap["ArrivDates1"] = Request.Form.Get("ArrivDates1");
    formFieldMap["Dist"] = Request.Form.Get("Dist");
    formFieldMap["addr20"] = Request.Form.Get("addr20");
    formFieldMap["addr10"] = Request.Form.Get("addr10");

    formFieldMap["addr1"] = Request.Form.Get("addr1");
    formFieldMap["addr2"] = Request.Form.Get("addr2");
    formFieldMap["addr3"] = Request.Form.Get("addr3");
    formFieldMap["addr4"] = Request.Form.Get("addr4");
    formFieldMap["addr5"] = Request.Form.Get("addr5");
    formFieldMap["addr6"] = Request.Form.Get("addr6");
    formFieldMap["addr7"] = Request.Form.Get("addr7");
    formFieldMap["addr8"] = Request.Form.Get("addr8");
    formFieldMap["addr9"] = Request.Form.Get("addr9");

    formFieldMap["addr18"] = Request.Form.Get("addr18");
    formFieldMap["addr19"] = Request.Form.Get("addr19");
    formFieldMap["addr23"] = Request.Form.Get("addr23");

    formFieldMap["addr12"] = Request.Form.Get("addr12");
    formFieldMap["addr13"] = Request.Form.Get("addr13");
    formFieldMap["addr28"] = Request.Form.Get("addr28");

    formFieldMap["DatePrepared"] = Request.Form.Get("DatePrepared");
    formFieldMap["VehicleNum"] = Request.Form.Get("VehicleNum");
    formFieldMap["AliasofTit"] = Request.Form.Get("AliasofTit");
    formFieldMap["ArrivDates3"] = Request.Form.Get("ArrivDates3");
    formFieldMap["ArrivDates4"] = Request.Form.Get("ArrivDates4");

    formFieldMap["DateUsed1"] = Request.Form.Get("DateUsed1");
    formFieldMap["DateUsed2"] = Request.Form.Get("DateUsed2");
    formFieldMap["DateUsed3"] = Request.Form.Get("DateUsed3");
    formFieldMap["DateUsed4"] = Request.Form.Get("DateUsed4");
    formFieldMap["DateUsed5"] = Request.Form.Get("DateUsed5");

    formFieldMap["SvcInst"] = Request.Form.Get("SvcInst");
    formFieldMap["SandLinFt"] = Request.Form.Get("SandLinFt");

    formFieldMap["Fitr"] = Request.Form.Get("Fitr");
    formFieldMap["TrkDrvr"] = Request.Form.Get("TrkDrvr");
    formFieldMap["Oprtr"] = Request.Form.Get("Oprtr");

    formFieldMap["Othr1"] = Request.Form.Get("Othr1");
    formFieldMap["Othr2"] = Request.Form.Get("Othr2");
    formFieldMap["commTM"] = Request.Form.Get("commTM");
    formFieldMap["evalnot1"] = Request.Form.Get("evalnot1");
    formFieldMap["StbsInst"] = Request.Form.Get("StbsInst");
    formFieldMap["Weldr"] = Request.Form.Get("Weldr");
    formFieldMap["CrwLead"] = Request.Form.Get("CrwLead");
    formFieldMap["EvalDate"] = Request.Form.Get("EvalDate");
    formFieldMap["evalPrinted"] = Request.Form.Get("evalPrinted");
    formFieldMap["commWrk"] = Request.Form.Get("commWrk");

    formFieldMap["gaugetext"] = Request.Form.Get("gaugetext");
    formFieldMap["gaugedt"] = Request.Form.Get("gaugedt");


    if (Request.Form.Get("succs3") != null)
        formFieldMap["succs3"] = "Yes";

    if (Request.Form.Get("succs10") != null)
        formFieldMap["succs10"] = "Yes";

    if (Request.Form.Get("notapp20") != null)
        formFieldMap["notapp20"] = "Yes";

    if (Request.Form.Get("unsuccs6") != null)
        formFieldMap["unsuccs6"] = "Yes";

    if (Request.Form.Get("unsuccs7") != null)
        formFieldMap["unsuccs7"] = "Yes";

    if (Request.Form.Get("BackFill") != null)
        formFieldMap["BackFill"] = "Yes";

    if (Request.Form.Get("unsuccs27") != null)
        formFieldMap["unsuccs27"] = "Yes";

    if (Request.Form.Get("unsuccs26") != null)
        formFieldMap["unsuccs26"] = "Yes";

    if (Request.Form.Get("unsuccs25") != null)
        formFieldMap["unsuccs25"] = "Yes";

    if (Request.Form.Get("unsuccs24") != null)
        formFieldMap["unsuccs24"] = "Yes";

    if (Request.Form.Get("notapp12") != null)
        formFieldMap["notapp12"] = "Yes";

    if (Request.Form.Get("succs17") != null)
        formFieldMap["succs17"] = "Yes";

    if (Request.Form.Get("unsuccs20") != null)
        formFieldMap["unsuccs20"] = "Yes";

    if (Request.Form.Get("unsuccs18") != null)
        formFieldMap["unsuccs18"] = "Yes";

    if (Request.Form.Get("unsuccs19") != null)
        formFieldMap["unsuccs19"] = "Yes";

    if (Request.Form.Get("succsGenSafe3") != null)
        formFieldMap["succsGenSafe3"] = "Yes";

    if (Request.Form.Get("unsuccs28") != null)
        formFieldMap["unsuccs28"] = "Yes";

    if (Request.Form.Get("succsGenSafe1") != null)
        formFieldMap["succsGenSafe1"] = "Yes";

    if (Request.Form.Get("InstPerDes") != null)
        formFieldMap["InstPerDes"] = "Yes";

    if (Request.Form.Get("unsuccs2") != null)
        formFieldMap["unsuccs2"] = "Yes";

    if (Request.Form.Get("evalindiv") != null)
        formFieldMap["evalindiv"] = "Yes";

    if (Request.Form.Get("notapp5") != null)
        formFieldMap["notapp5"] = "Yes";

    if (Request.Form.Get("succs24") != null)
        formFieldMap["succs24"] = "Yes";

    if (Request.Form.Get("unsuccs21") != null)
        formFieldMap["unsuccs21"] = "Yes";

    if (Request.Form.Get("notapp14") != null)
        formFieldMap["notapp14"] = "Yes";

    if (Request.Form.Get("opsmanok") != null)
        formFieldMap["opsmanok"] = "Yes";

    if (Request.Form.Get("crewDay") != null)
        formFieldMap["topmostSubform[0].Page1[0].c1_01[1]"] = "Yes";

    if (Request.Form.Get("crewBid") != null)
        formFieldMap["topmostSubform[0].Page1[0].c1_01[3]"] = "Yes";

    if (Request.Form.Get("notapp8") != null)
        formFieldMap["notapp8"] = "Yes";

    if (Request.Form.Get("unsuccs9") != null)
        formFieldMap["unsuccs9"] = "Yes";

    if (Request.Form.Get("ContrEquip3") != null)
        formFieldMap["ContrEquip3"] = "Yes";

    if (Request.Form.Get("succs8") != null)
        formFieldMap["succs8"] = "Yes";

    if (Request.Form.Get("unsuccs4") != null)
        formFieldMap["unsuccs4"] = "Yes";

    if (Request.Form.Get("succs9") != null)
        formFieldMap["succs9"] = "Yes";

    if (Request.Form.Get("notapp24") != null)
        formFieldMap["notapp24"] = "Yes";

    if (Request.Form.Get("BackFill3") != null)
        formFieldMap["BackFill3"] = "Yes";

    if (Request.Form.Get("BackFill2") != null)
        formFieldMap["BackFill2"] = "Yes";

    if (Request.Form.Get("BackFill4") != null)
        formFieldMap["BackFill4"] = "Yes";

    if (Request.Form.Get("succsGenSafe2") != null)
        formFieldMap["succsGenSafe2"] = "Yes";

    if (Request.Form.Get("succs28") != null)
        formFieldMap["succs28"] = "Yes";

    if (Request.Form.Get("succs14") != null)
        formFieldMap["succs14"] = "Yes";

    if (Request.Form.Get("unsuccs18") != null)
        formFieldMap["unsuccs18"] = "Yes";

    if (Request.Form.Get("unsuccs16") != null)
        formFieldMap["unsuccs16"] = "Yes";

    if (Request.Form.Get("unsuccs15") != null)
        formFieldMap["unsuccs15"] = "Yes";

    if (Request.Form.Get("unsuccs14") != null)
        formFieldMap["unsuccs14"] = "Yes";

    if (Request.Form.Get("unsuccs13") != null)
        formFieldMap["unsuccs13"] = "Yes";

    if (Request.Form.Get("unsuccs12") != null)
        formFieldMap["unsuccs12"] = "Yes";

    if (Request.Form.Get("unsuccs11") != null)
        formFieldMap["unsuccs11"] = "Yes";

    if (Request.Form.Get("unsuccs10") != null)
        formFieldMap["unsuccs10"] = "Yes";

    if (Request.Form.Get("notapp23") != null)
        formFieldMap["notapp23"] = "Yes";

    if (Request.Form.Get("succs22") != null)
        formFieldMap["succs22"] = "Yes";

    if (Request.Form.Get("unsuccs1") != null)
        formFieldMap["unsuccs1"] = "Yes";

    if (Request.Form.Get("notapp21") != null)
        formFieldMap["notapp21"] = "Yes";

    if (Request.Form.Get("succs6") != null)
        formFieldMap["succs6"] = "Yes";

    if (Request.Form.Get("notapp15") != null)
        formFieldMap["notapp15"] = "Yes";

    if (Request.Form.Get("succs11") != null)
        formFieldMap["succs11"] = "Yes";

    if (Request.Form.Get("succs21") != null)
        formFieldMap["succs21"] = "Yes";

    if (Request.Form.Get("notapp27") != null)
        formFieldMap["notapp27"] = "Yes";

    if (Request.Form.Get("notapp25") != null)
        formFieldMap["notapp25"] = "Yes";

    if (Request.Form.Get("succs7") != null)
        formFieldMap["succs7"] = "Yes";

    if (Request.Form.Get("notapp19") != null)
        formFieldMap["notapp19"] = "Yes";

    if (Request.Form.Get("notapp13") != null)
        formFieldMap["notapp13"] = "Yes";

    if (Request.Form.Get("succs26") != null)
        formFieldMap["succs26"] = "Yes";

    if (Request.Form.Get("succs4") != null)
        formFieldMap["succs4"] = "Yes";

    if (Request.Form.Get("unsuccs3") != null)
        formFieldMap["unsuccs3"] = "Yes";

    if (Request.Form.Get("notapp2") != null)
        formFieldMap["notapp2"] = "Yes";

    if (Request.Form.Get("succs12") != null)
        formFieldMap["succs12"] = "Yes";

    if (Request.Form.Get("notapp17") != null)
        formFieldMap["notapp17"] = "Yes";

    if (Request.Form.Get("notapp3") != null)
        formFieldMap["notapp3"] = "Yes";

    if (Request.Form.Get("notapp4") != null)
        formFieldMap["notapp4"] = "Yes";

    if (Request.Form.Get("succs5") != null)
        formFieldMap["succs5"] = "Yes";

    if (Request.Form.Get("succs2") != null)
        formFieldMap["succs2"] = "Yes";

    if (Request.Form.Get("succs25") != null)
        formFieldMap["succs25"] = "Yes";

    if (Request.Form.Get("evalcrew") != null)
        formFieldMap["evalcrew"] = "Yes";

    if (Request.Form.Get("succs23") != null)
        formFieldMap["succs23"] = "Yes";

    if (Request.Form.Get("notapp1") != null)
        formFieldMap["notapp1"] = "Yes";

    if (Request.Form.Get("notapp16") != null)
        formFieldMap["notapp16"] = "Yes";

    if (Request.Form.Get("crewUnit") != null)
        formFieldMap["topmostSubform[0].Page1[0].c1_01[2]"] = "Yes";

    if (Request.Form.Get("unsuccs23") != null)
        formFieldMap["unsuccs23"] = "Yes";

    if (Request.Form.Get("notapp22") != null)
        formFieldMap["notapp22"] = "Yes";

    if (Request.Form.Get("unsuccs5") != null)
        formFieldMap["unsuccs5"] = "Yes";

    if (Request.Form.Get("unsuccs7") != null)
        formFieldMap["unsuccs7"] = "Yes";

    if (Request.Form.Get("succsTime1") != null)
        formFieldMap["succsTime1"] = "Yes";

    if (Request.Form.Get("succs20") != null)
        formFieldMap["succs20"] = "Yes";

    if (Request.Form.Get("notapp11") != null)
        formFieldMap["notapp11"] = "Yes";

    if (Request.Form.Get("succs19") != null)
        formFieldMap["succs19"] = "Yes";

    if (Request.Form.Get("notapp18") != null)
        formFieldMap["notapp18"] = "Yes";

    if (Request.Form.Get("succsTime2") != null)
        formFieldMap["succsTime2"] = "Yes";

    if (Request.Form.Get("unsuccs22") != null)
        formFieldMap["unsuccs22"] = "Yes";

    if (Request.Form.Get("unsuccs8") != null)
        formFieldMap["unsuccs8"] = "Yes";

    if (Request.Form.Get("notapp28") != null)
        formFieldMap["notapp28"] = "Yes";

    if (Request.Form.Get("InspNeeded1") != null)
        formFieldMap["topmostSubform[0].Page1[0].c1_01[8]"] = "Yes";

    if (Request.Form.Get("succsTime3") != null)
        formFieldMap["succsTime3"] = "Yes";

    if (Request.Form.Get("succs13") != null)
        formFieldMap["succs13"] = "Yes";

    if (Request.Form.Get("succs1") != null)
        formFieldMap["succs1"] = "Yes";

    if (Request.Form.Get("ExFacMarkd") != null)
        formFieldMap["topmostSubform[0].Page1[0].c1_01[4]"] = "Yes";

    if (Request.Form.Get("ExFacMarkdN") != null)
        formFieldMap["topmostSubform[0].Page1[0].c1_01[5]"] = "Yes";

    if (Request.Form.Get("unsuccs7") != null)
        formFieldMap["unsuccs7"] = "YES";

    if (Request.Form.Get("notapp6") != null)
        formFieldMap["notapp6"] = "YES";

    if (Request.Form.Get("succs18") != null)
        formFieldMap["succs18"] = "Yes";

    if (Request.Form.Get("notapp7") != null)
        formFieldMap["notapp7"] = "Yes";

    if (Request.Form.Get("succs16") != null)
        formFieldMap["succs16"] = "Yes";

    if (Request.Form.Get("notapp26") != null)
        formFieldMap["notapp26"] = "Yes";

    if (Request.Form.Get("Installa") != null)
        formFieldMap["Installa"] = "Yes";

    if (Request.Form.Get("Installa2") != null)
        formFieldMap["Installa2"] = "Yes";

    if (Request.Form.Get("Installa3") != null)
        formFieldMap["Installa3"] = "Yes";

    if (Request.Form.Get("Installa4") != null)
        formFieldMap["Installa4"] = "Yes";

    if (Request.Form.Get("InstPerDes2") != null)
        formFieldMap["topmostSubform[0].Page1[0].c1_01[7]"] = "Yes";

    if (Request.Form.Get("InstPerDes") != null)
        formFieldMap["topmostSubform[0].Page1[0].c1_01[6]"] = "Yes";

    if (Request.Form.Get("Contrwk") != null)
        formFieldMap["topmostSubform[0].Page1[0].c1_01[9]"] = "Yes";
    if (Request.Form.Get("succs15") != null)
        formFieldMap["succs15"] = "Yes";

    if (Request.Form.Get("ContrEquip5") != null)
        formFieldMap["ContrEquip5"] = "Yes";

    if (Request.Form.Get("ContrEquip4") != null)
        formFieldMap["ContrEquip4"] = "Yes";

    if (Request.Form.Get("ContrEquip1") != null)
        formFieldMap["ContrEquip1"] = "Yes";

    if (Request.Form.Get("ContrEquip2") != null)
        formFieldMap["ContrEquip2"] = "Yes";

    if (Request.Form.Get("notapp9") != null)
        formFieldMap["notapp9"] = "Yes";

    if (Request.Form.Get("succs27") != null)
        formFieldMap["succs27"] = "Yes";

    if (Request.Form.Get("succs2") != null)
        formFieldMap["succs2"] = "Yes";

    if (Request.Form.Get("notapp10") != null)
        formFieldMap["notapp10"] = "Yes";

    if (Request.Form.Get("notapp6") != null)
        formFieldMap["notapp6"] = "Yes";

    if (Request.Form.Get("chgaugcal") != null)
        formFieldMap["chgaugcal"] = "Yes";

    var signature = Request.Form.Get("newsig").ToString();
    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(signature);

    var idEncoded = Request.Form.Get("genUUID");
    var grabFile = "252-" + idEncoded + ".pdf";

    var pdfContents = PDFHelper.GeneratePDF(pdfPath, formFieldMap, signature);
    //GenPDF(pdfPath, formFieldMap, signature);

    PDFHelper.ReturnPDF(pdfContents, "252-" + idEncoded + ".pdf");

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

        var appUUID = Request.Form.Get("genUUID");

        // Insert a new record into Contact
        string connString = ConfigurationManager.ConnectionStrings["swgProd"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(connString);

       

        conn.Open();


        MySqlCommand cmd = conn.CreateCommand();
        //MySqlCommand cmd2 = conn.CreateCommand();

        cmd.CommandText = "INSERT INTO xxxxxx (UUID, Preparedby, DTPrepared, newStatus, CrewLeader, FollowUpDate, VehicleNum, InspNeeded1, Contrwk, AliasofTit, Dist, Contrctr, WrkDesc, JobNum, Address, crewDay, crewUnit, crewBid, ExFacMarkd, ArrivDates1, DeptDates1, PJQ1, ContrEquip1, DateUsed1, ArrivDates2, DeptDates2, PJQ2, ContrEquip2, DateUsed2, ArrivDates3, DeptDates3, PJQ3, ContrEquip3, DateUsed3, ArrivDates4, DeptDates4, PJQ4, ContrEquip4, DateUsed4, ContrEquip5, DateUsed5, MainFt, InstPerDes, InstPerDes2, SvcInst, StbsInst, SandNoLfts, SandLinFt, BackFill, BackFill2, BackFill3, BackFill4, Laborer, CrwLead, Othr1, Fitr, TrkDrvr, Othr2, Weldr, Oprtr, evalcrew, evalindiv, opsmanok, chgaugcal, addr1, succs1, unsuccs1, notapp1, addr2, succs2, unsuccs2, notapp2, addr3, succs3, unsuccs3, notapp3, addr4, succs4, unsuccs4, notapp4, addr5, succs5, unsuccs5, notapp5, addr6, succs6, unsuccs6, notapp6, addr7, succs7, unsuccs7, notapp7, addr8, succs8, unsuccs8, notapp8, addr9, succs9, unsuccs9, notapp9, addr10, succs10, unsuccs10, notapp10, addr11, succs11, unsuccs11, notapp11, addr12, succs12, unsuccs12, notapp12, addr13, succs13, unsuccs13, notapp13, addr14, succs14, unsuccs14, notapp14, addr15, succs15, unsuccs15, notapp15, addr16, succs16, unsuccs16, notapp16, addr17, succs17, unsuccs17, notapp17, addr18, succs18, unsuccs18, notapp18, addr19, succs19, unsuccs19, notapp19, addr20, succs20, unsuccs20, notapp20, addr21, succs21, unsuccs21, notapp21, addr22, succs22, unsuccs22, notapp22, addr23, succs23, unsuccs23, notapp23, addr24, succs24, unsuccs24, notapp24, addr25, succs25, unsuccs25, notapp25, addr26, succs26, unsuccs26, notapp26, comm2, addr27, succs27, unsuccs27, notapp27, addr28, succs28, unsuccs28, notapp28, train1, train2, evalnot1, email, youremail, Installa, Installa2, Installa3, Installa4, WorkmanshipComment, TimeManagementComment, versionNumber, signaturedate, printnamesignature, succ1, unsucc1, succ2, unsucc2, succ3, unsucc3, ExFacMarkdN, gaugetext, gaugedt) VALUES (@UUID1, @Preparedby1, @dtprepared1, @newStatus1, @CrewLeader1, @FollowUpDate1, @VehicleNum1, @InspNeeded11, @Contrwk1, @AliasofTit1, @Dist1, @Contrctr1, @WrkDesc1, @JobNum1, @Address1, @crewDay1, @crewUnit1, @crewBid1, @ExFacMarkd1, @ArrivDates11, @DeptDates11, @PJQ11, @ContrEquip11, @DateUsed11, @ArrivDates21, @DeptDates21, @PJQ21, @ContrEquip21, @DateUsed21, @ArrivDates31, @DeptDates31, @PJQ31, @ContrEquip31, @DateUsed31, @ArrivDates41, @DeptDates41, @PJQ41, @ContrEquip41, @DateUsed41, @ContrEquip51, @DateUsed51, @MainFt1, @InstPerDes1, @InstPerDes21, @SvcInst1, @StbsInst1, @SandNoLfts1, @SandLinFt1, @BackFill1, @BackFill21, @BackFill31, @BackFill41, @Laborer1, @CrwLead1, @Othr11, @Fitr1, @TrkDrvr1, @Othr21, @Weldr1, @Oprtr1, @evalcrew1, @evalindiv1, @opsmanok1, @chgaugcal1, @addr11a, @succs11a, @unsuccs11a, @notapp11a, @addr21a, @succs21a, @unsuccs21a, @notapp21a, @addr31, @succs31, @unsuccs31, @notapp31, @addr41, @succs41, @unsuccs41, @notapp41, @addr51, @succs51, @unsuccs51, @notapp51, @addr61, @succs61, @unsuccs61, @notapp61, @addr71, @succs71, @unsuccs71, @notapp71, @addr81, @succs81, @unsuccs81, @notapp81, @addr91, @succs91, @unsuccs91, @notapp91, @addr101, @succs101, @unsuccs101, @notapp101, @addr111, @succs111, @unsuccs111, @notapp111, @addr121, @succs121, @unsuccs121, @notapp121, @addr131, @succs131, @unsuccs131, @notapp131, @addr141, @succs141, @unsuccs141, @notapp141, @addr151, @succs151, @unsuccs151, @notapp151, @addr161, @succs161, @unsuccs161, @notapp161, @addr171, @succs171, @unsuccs171, @notapp171, @addr181, @succs181, @unsuccs181, @notapp181, @addr191, @succs191, @unsuccs191, @notapp191, @addr201, @succs201, @unsuccs201, @notapp201, @addr211, @succs211, @unsuccs211, @notapp211, @addr221, @succs221, @unsuccs221, @notapp221, @addr231, @succs231, @unsuccs231, @notapp231, @addr241, @succs241, @unsuccs241, @notapp241, @addr251, @succs251, @unsuccs251, @notapp251, @addr261, @succs261, @unsuccs261, @notapp261, @comm21, @addr271, @succs271, @unsuccs271, @notapp271, @addr281, @succs281, @unsuccs281, @notapp281, @train11, @train21, @evalnot11, @email1, @youremail1, @Installa1, @Installa21, @Installa31, @Installa41, @wrkcom1, @tmcom1, @appVersion1, @crewDate1, @crewPrinted1, @success11, @unsuccess11, @success21, @unsuccess21, @success31, @unsuccess31, @ExFacMarkdN1, @gaugetext, @gaugedt)";

        //252form attributes
        cmd.Parameters.AddWithValue("?UUID1", Request.Form.Get("genUUID"));
        cmd.Parameters.AddWithValue("?Preparedby1", Request.Form.Get("Preparedby"));
        cmd.Parameters.AddWithValue("?dtprepared1", Request.Form.Get("DatePrepared").NullString());

        cmd.Parameters.AddWithValue("?newStatus1", Request.Form.Get("newStatus"));
        cmd.Parameters.AddWithValue("?CrewLeader1", Request.Form.Get("CrewLeader"));
        cmd.Parameters.AddWithValue("?FollowUpDate1", Request.Form.Get("FollowUpDate").NullString());
        cmd.Parameters.AddWithValue("?VehicleNum1", Request.Form.Get("VehicleNum"));
        cmd.Parameters.AddWithValue("?InspNeeded11", Request.Form.Get("InspNeeded1"));
        cmd.Parameters.AddWithValue("?Contrwk1", Request.Form.Get("Contrwk"));
        cmd.Parameters.AddWithValue("?AliasofTit1", Request.Form.Get("AliasofTit"));
        cmd.Parameters.AddWithValue("?Dist1", Request.Form.Get("Dist"));

        cmd.Parameters.AddWithValue("?Contrctr1", Request.Form.Get("Contrctr"));
        cmd.Parameters.AddWithValue("?WrkDesc1", Request.Form.Get("WrkDesc"));
        cmd.Parameters.AddWithValue("?JobNum1", Request.Form.Get("JobNum"));
        cmd.Parameters.AddWithValue("?Address1", Request.Form.Get("Address"));
        cmd.Parameters.AddWithValue("?crewDay1", Request.Form.Get("crewDay"));
        cmd.Parameters.AddWithValue("?crewUnit1", Request.Form.Get("crewUnit"));
        cmd.Parameters.AddWithValue("?crewBid1", Request.Form.Get("crewBid"));
        cmd.Parameters.AddWithValue("?ExFacMarkd1", Request.Form.Get("ExFacMarkd"));
        cmd.Parameters.AddWithValue("?ExFacMarkdN1", Request.Form.Get("ExFacMarkdN"));
        cmd.Parameters.AddWithValue("?ArrivDates11", Request.Form.Get("ArrivDates1").NullString());

        cmd.Parameters.AddWithValue("?DeptDates11", Request.Form.Get("DeptDates1").NullString());
        cmd.Parameters.AddWithValue("?PJQ11", Request.Form.Get("PJQ1"));
        cmd.Parameters.AddWithValue("?ContrEquip11", Request.Form.Get("ContrEquip1"));
        cmd.Parameters.AddWithValue("?DateUsed11", Request.Form.Get("DateUsed1").NullString());
        cmd.Parameters.AddWithValue("?ArrivDates21", Request.Form.Get("ArrivDates2").NullString());
        cmd.Parameters.AddWithValue("?DeptDates21", Request.Form.Get("DeptDates2").NullString());
        cmd.Parameters.AddWithValue("?PJQ21", Request.Form.Get("PJQ2"));
        cmd.Parameters.AddWithValue("?ContrEquip21", Request.Form.Get("ContrEquip2"));
        cmd.Parameters.AddWithValue("?DateUsed21", Request.Form.Get("DateUsed2").NullString());
        cmd.Parameters.AddWithValue("?ArrivDates31", Request.Form.Get("ArrivDates3").NullString());

        cmd.Parameters.AddWithValue("?DeptDates31", Request.Form.Get("DeptDates3").NullString());
        cmd.Parameters.AddWithValue("?PJQ31", Request.Form.Get("PJQ3"));
        cmd.Parameters.AddWithValue("?ContrEquip31", Request.Form.Get("ContrEquip3"));
        cmd.Parameters.AddWithValue("?DateUsed31", Request.Form.Get("DateUsed3").NullString());
        cmd.Parameters.AddWithValue("?ArrivDates41", Request.Form.Get("ArrivDates4").NullString());
        cmd.Parameters.AddWithValue("?DeptDates41", Request.Form.Get("DeptDates4").NullString());
        cmd.Parameters.AddWithValue("?PJQ41", Request.Form.Get("PJQ4"));
        cmd.Parameters.AddWithValue("?ContrEquip41", Request.Form.Get("ContrEquip4"));
        cmd.Parameters.AddWithValue("?DateUsed41", Request.Form.Get("DateUsed4").NullString());
        cmd.Parameters.AddWithValue("?ContrEquip51", Request.Form.Get("ContrEquip5"));

        cmd.Parameters.AddWithValue("?DateUsed51", Request.Form.Get("DateUsed5").NullString());
        cmd.Parameters.AddWithValue("?MainFt1", Request.Form.Get("MainFt"));
        cmd.Parameters.AddWithValue("?InstPerDes1", Request.Form.Get("InstPerDes"));
        cmd.Parameters.AddWithValue("?InstPerDes21", Request.Form.Get("InstPerDes2"));
        cmd.Parameters.AddWithValue("?SvcInst1", Request.Form.Get("SvcInst"));
        cmd.Parameters.AddWithValue("?StbsInst1", Request.Form.Get("StbsInst"));
        cmd.Parameters.AddWithValue("?SandNoLfts1", Request.Form.Get("SandNoLfts"));
        cmd.Parameters.AddWithValue("?SandLinFt1", Request.Form.Get("SandLinFt"));
        cmd.Parameters.AddWithValue("?BackFill1", Request.Form.Get("BackFill"));
        cmd.Parameters.AddWithValue("?BackFill21", Request.Form.Get("BackFill2"));

        cmd.Parameters.AddWithValue("?BackFill31", Request.Form.Get("BackFill3"));
        cmd.Parameters.AddWithValue("?BackFill41", Request.Form.Get("BackFill4"));
        cmd.Parameters.AddWithValue("?Laborer1", Request.Form.Get("Laborer"));
        cmd.Parameters.AddWithValue("?CrwLead1", Request.Form.Get("CrwLead"));
        cmd.Parameters.AddWithValue("?Othr11", Request.Form.Get("Othr1"));
        cmd.Parameters.AddWithValue("?Fitr1", Request.Form.Get("Fitr"));
        cmd.Parameters.AddWithValue("?TrkDrvr1", Request.Form.Get("TrkDrvr"));
        cmd.Parameters.AddWithValue("?Othr21", Request.Form.Get("Othr2"));
        cmd.Parameters.AddWithValue("?Weldr1", Request.Form.Get("Weldr"));
        cmd.Parameters.AddWithValue("?Oprtr1", Request.Form.Get("Oprtr"));

        cmd.Parameters.AddWithValue("?evalcrew1", Request.Form.Get("evalcrew"));
        cmd.Parameters.AddWithValue("?evalindiv1", Request.Form.Get("evalindiv"));
        cmd.Parameters.AddWithValue("?opsmanok1", Request.Form.Get("opsmanok"));
        cmd.Parameters.AddWithValue("?chgaugcal1", Request.Form.Get("chgaugcal"));
        cmd.Parameters.AddWithValue("?addr11a", Request.Form.Get("addr1"));
        cmd.Parameters.AddWithValue("?succs11a", Request.Form.Get("succs1"));
        cmd.Parameters.AddWithValue("?unsuccs11a", Request.Form.Get("unsuccs1"));
        cmd.Parameters.AddWithValue("?notapp11a", Request.Form.Get("notapp1"));
        cmd.Parameters.AddWithValue("?addr21a", Request.Form.Get("addr2"));
        cmd.Parameters.AddWithValue("?succs21a", Request.Form.Get("succs2"));

        cmd.Parameters.AddWithValue("?unsuccs21a", Request.Form.Get("unsuccs2"));
        cmd.Parameters.AddWithValue("?notapp21a", Request.Form.Get("notapp2"));
        cmd.Parameters.AddWithValue("?addr31", Request.Form.Get("addr3"));
        cmd.Parameters.AddWithValue("?succs31", Request.Form.Get("unsuccs3"));
        cmd.Parameters.AddWithValue("?unsuccs31", Request.Form.Get("unsuccs3"));
        cmd.Parameters.AddWithValue("?notapp31", Request.Form.Get("notapp3"));
        cmd.Parameters.AddWithValue("?addr41", Request.Form.Get("addr4"));
        cmd.Parameters.AddWithValue("?succs41", Request.Form.Get("succs4"));
        cmd.Parameters.AddWithValue("?unsuccs41", Request.Form.Get("unsuccs4"));
        cmd.Parameters.AddWithValue("?notapp41", Request.Form.Get("notapp4"));

        cmd.Parameters.AddWithValue("?addr51", Request.Form.Get("addr5"));
        cmd.Parameters.AddWithValue("?succs51", Request.Form.Get("succs5"));
        cmd.Parameters.AddWithValue("?unsuccs51", Request.Form.Get("unsuccs5"));
        cmd.Parameters.AddWithValue("?notapp51", Request.Form.Get("notapp5"));
        cmd.Parameters.AddWithValue("?addr61", Request.Form.Get("addr6"));
        cmd.Parameters.AddWithValue("?succs61", Request.Form.Get("succs6"));
        cmd.Parameters.AddWithValue("?unsuccs61", Request.Form.Get("unsuccs6"));
        cmd.Parameters.AddWithValue("?notapp61", Request.Form.Get("notapp6"));
        cmd.Parameters.AddWithValue("?addr71", Request.Form.Get("addr7"));
        cmd.Parameters.AddWithValue("?succs71", Request.Form.Get("succs7"));

        cmd.Parameters.AddWithValue("?unsuccs71", Request.Form.Get("unsuccs7"));
        cmd.Parameters.AddWithValue("?notapp71", Request.Form.Get("notapp7"));
        cmd.Parameters.AddWithValue("?addr81", Request.Form.Get("addr8"));
        cmd.Parameters.AddWithValue("?succs81", Request.Form.Get("succs8"));
        cmd.Parameters.AddWithValue("?unsuccs81", Request.Form.Get("unsuccs8"));
        cmd.Parameters.AddWithValue("?notapp81", Request.Form.Get("notapp8"));
        cmd.Parameters.AddWithValue("?addr91", Request.Form.Get("addr9"));
        cmd.Parameters.AddWithValue("?succs91", Request.Form.Get("succs9"));
        cmd.Parameters.AddWithValue("?unsuccs91", Request.Form.Get("unsuccs9"));
        cmd.Parameters.AddWithValue("?notapp91", Request.Form.Get("notapp9"));

        cmd.Parameters.AddWithValue("?addr101", Request.Form.Get("addr10"));
        cmd.Parameters.AddWithValue("?succs101", Request.Form.Get("succs10"));
        cmd.Parameters.AddWithValue("?unsuccs101", Request.Form.Get("unsuccs10"));
        cmd.Parameters.AddWithValue("?notapp101", Request.Form.Get("notapp10"));
        cmd.Parameters.AddWithValue("?addr111", Request.Form.Get("addr11"));
        cmd.Parameters.AddWithValue("?succs111", Request.Form.Get("succs11"));
        cmd.Parameters.AddWithValue("?unsuccs111", Request.Form.Get("unsuccs11"));
        cmd.Parameters.AddWithValue("?notapp111", Request.Form.Get("notapp11"));
        cmd.Parameters.AddWithValue("?addr121", Request.Form.Get("addr12"));
        cmd.Parameters.AddWithValue("?succs121", Request.Form.Get("succs12"));

        cmd.Parameters.AddWithValue("?unsuccs121", Request.Form.Get("unsuccs12"));
        cmd.Parameters.AddWithValue("?notapp121", Request.Form.Get("notapp12"));
        cmd.Parameters.AddWithValue("?addr131", Request.Form.Get("addr13"));
        cmd.Parameters.AddWithValue("?succs131", Request.Form.Get("succs13"));
        cmd.Parameters.AddWithValue("?unsuccs131", Request.Form.Get("unsuccs13"));
        cmd.Parameters.AddWithValue("?notapp131", Request.Form.Get("notapp13"));
        cmd.Parameters.AddWithValue("?addr141", Request.Form.Get("addr14"));
        cmd.Parameters.AddWithValue("?succs141", Request.Form.Get("succs14"));
        cmd.Parameters.AddWithValue("?unsuccs141", Request.Form.Get("unsuccs14"));
        cmd.Parameters.AddWithValue("?notapp141", Request.Form.Get("notapp14"));

        cmd.Parameters.AddWithValue("?comm11", Request.Form.Get("comm2"));
        cmd.Parameters.AddWithValue("?addr151", Request.Form.Get("addr15"));
        cmd.Parameters.AddWithValue("?succs151", Request.Form.Get("succs15"));
        cmd.Parameters.AddWithValue("?unsuccs151", Request.Form.Get("unsuccs15"));
        cmd.Parameters.AddWithValue("?notapp151", Request.Form.Get("notapp15"));
        cmd.Parameters.AddWithValue("?addr161", Request.Form.Get("addr16"));
        cmd.Parameters.AddWithValue("?succs161", Request.Form.Get("succs16"));
        cmd.Parameters.AddWithValue("?notapp161", Request.Form.Get("notapp16"));
        cmd.Parameters.AddWithValue("?addr171", Request.Form.Get("addr17"));
        cmd.Parameters.AddWithValue("?succs171", Request.Form.Get("succs17"));

        cmd.Parameters.AddWithValue("?unsuccs171", Request.Form.Get("unsuccs17"));
        cmd.Parameters.AddWithValue("?notapp171", Request.Form.Get("notapp17"));
        cmd.Parameters.AddWithValue("?addr181", Request.Form.Get("addr18"));
        cmd.Parameters.AddWithValue("?succs181", Request.Form.Get("succs18"));
        cmd.Parameters.AddWithValue("?unsuccs181", Request.Form.Get("unsuccs18"));
        cmd.Parameters.AddWithValue("?notapp181", Request.Form.Get("notapp18"));
        cmd.Parameters.AddWithValue("?addr191", Request.Form.Get("addr19"));
        cmd.Parameters.AddWithValue("?succs191", Request.Form.Get("succs19"));
        cmd.Parameters.AddWithValue("?unsuccs191", Request.Form.Get("unsuccs19"));
        cmd.Parameters.AddWithValue("?notapp191", Request.Form.Get("notapp19"));

        cmd.Parameters.AddWithValue("?addr201", Request.Form.Get("addr20"));
        cmd.Parameters.AddWithValue("?succs201", Request.Form.Get("succs20"));
        cmd.Parameters.AddWithValue("?unsuccs201", Request.Form.Get("unsuccs20"));
        cmd.Parameters.AddWithValue("?notapp201", Request.Form.Get("notapp20"));
        cmd.Parameters.AddWithValue("?addr211", Request.Form.Get("addr21"));
        cmd.Parameters.AddWithValue("?succs211", Request.Form.Get("succs21"));
        cmd.Parameters.AddWithValue("?unsuccs211", Request.Form.Get("unsuccs21"));
        cmd.Parameters.AddWithValue("?notapp211", Request.Form.Get("notapp21"));
        cmd.Parameters.AddWithValue("?addr221", Request.Form.Get("addr22"));
        cmd.Parameters.AddWithValue("?succs221", Request.Form.Get("succs22"));

        cmd.Parameters.AddWithValue("?unsuccs221", Request.Form.Get("unsuccs22"));
        cmd.Parameters.AddWithValue("?notapp221", Request.Form.Get("notapp22"));
        cmd.Parameters.AddWithValue("?addr231", Request.Form.Get("addr23"));
        cmd.Parameters.AddWithValue("?succs231", Request.Form.Get("succs23"));
        cmd.Parameters.AddWithValue("?unsuccs231", Request.Form.Get("unsuccs23"));
        cmd.Parameters.AddWithValue("?notapp231", Request.Form.Get("notapp23"));
        cmd.Parameters.AddWithValue("?addr241", Request.Form.Get("addr24"));
        cmd.Parameters.AddWithValue("?succs241", Request.Form.Get("succs24"));
        cmd.Parameters.AddWithValue("?unsuccs241", Request.Form.Get("unsuccs24"));
        cmd.Parameters.AddWithValue("?notapp241", Request.Form.Get("notapp24"));

        cmd.Parameters.AddWithValue("?addr251", Request.Form.Get("addr25"));
        cmd.Parameters.AddWithValue("?succs251", Request.Form.Get("succs25"));
        cmd.Parameters.AddWithValue("?unsuccs251", Request.Form.Get("unsuccs25"));
        cmd.Parameters.AddWithValue("?notapp251", Request.Form.Get("notapp25"));
        cmd.Parameters.AddWithValue("?addr261", Request.Form.Get("addr26"));
        cmd.Parameters.AddWithValue("?succs261", Request.Form.Get("succs26"));
        cmd.Parameters.AddWithValue("?unsuccs261", Request.Form.Get("unsuccs26"));
        cmd.Parameters.AddWithValue("?notapp261", Request.Form.Get("notapp26"));
        cmd.Parameters.AddWithValue("?comm21", Request.Form.Get("comm2"));
        cmd.Parameters.AddWithValue("?addr271", Request.Form.Get("addr27"));


        cmd.Parameters.AddWithValue("?succs271", Request.Form.Get("succs27"));
        cmd.Parameters.AddWithValue("?unsuccs271", Request.Form.Get("unsuccs27"));
        cmd.Parameters.AddWithValue("?notapp271", Request.Form.Get("notapp27"));
        cmd.Parameters.AddWithValue("?addr281", Request.Form.Get("addr28"));
        cmd.Parameters.AddWithValue("?succs281", Request.Form.Get("succs28"));
        cmd.Parameters.AddWithValue("?unsuccs281", Request.Form.Get("unsuccs28"));
        cmd.Parameters.AddWithValue("?notapp281", Request.Form.Get("notapp28"));
        cmd.Parameters.AddWithValue("?train11", Request.Form.Get("train1"));
        cmd.Parameters.AddWithValue("?train21", Request.Form.Get("train2"));
        cmd.Parameters.AddWithValue("?evalnot11", Request.Form.Get("evalnot1"));

        cmd.Parameters.AddWithValue("?email1", Request.Form.Get("email"));
        cmd.Parameters.AddWithValue("?youremail1", Request.Form.Get("youremail"));
        cmd.Parameters.AddWithValue("?Installa1", Request.Form.Get("Installa"));
        cmd.Parameters.AddWithValue("?Installa21", Request.Form.Get("Installa2"));
        cmd.Parameters.AddWithValue("?Installa31", Request.Form.Get("Installa3"));
        cmd.Parameters.AddWithValue("?Installa41", Request.Form.Get("Installa4"));
        cmd.Parameters.AddWithValue("?tmcom1", Request.Form.Get("comm2"));
        cmd.Parameters.AddWithValue("?wrkcom1", Request.Form.Get("commWrk"));
        cmd.Parameters.AddWithValue("?appVersion1", Request.Form.Get("appVersion"));
        cmd.Parameters.AddWithValue("?crewDate1", Request.Form.Get("EvalDate").NullString());

        cmd.Parameters.AddWithValue("?crewPrinted1", Request.Form.Get("evalPrinted"));
        cmd.Parameters.AddWithValue("?success11", Request.Form.Get("succsTime1"));
        cmd.Parameters.AddWithValue("?unsuccess11", Request.Form.Get("succsGenSafe1"));
        cmd.Parameters.AddWithValue("?success21", Request.Form.Get("succsTime2"));
        cmd.Parameters.AddWithValue("?unsuccess21", Request.Form.Get("succsGenSafe2"));
        cmd.Parameters.AddWithValue("?success31", Request.Form.Get("succsTime3"));
        cmd.Parameters.AddWithValue("?unsuccess31", Request.Form.Get("succsGenSafe3"));
        cmd.Parameters.AddWithValue("?gaugetext", Request.Form.Get("gaugetext"));
        cmd.Parameters.AddWithValue("?gaugedt", Request.Form.Get("gaugedt").NullString());


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
                    //string fileName = "252-" + Request.Form.Get("genUUID") + Path.GetFileName(file.FileName);
                    string fileName = "252-" + Request.Form.Get("genUUID") + Path.GetFileName(file.FileName) + Path.GetExtension(file.FileName).ToLower();
                    if (fileName != string.Empty)
                    {
                        try
                        {
                            if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".png")
                            {
                                file.SaveAs(Server.MapPath("./UploadedFiles/") + fileName);

                                //Console.Write("Make PDF Initiating...");

                                // now insert image names into filemanager
                                string connString2 = ConfigurationManager.ConnectionStrings["swgProd"].ConnectionString;
                                MySqlConnection conn2 = new MySqlConnection(connString);

                                conn2.Open();

                                MySqlCommand cmd2 = conn2.CreateCommand();

                                string httpContainer2 = "http://xx.xxx.xxx.xxx/UploadedFiles/" + "252-" + Request.Form.Get("genUUID") + Path.GetFileName(file.FileName) + Path.GetExtension(file.FileName).ToLower();

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


    }







    


}
