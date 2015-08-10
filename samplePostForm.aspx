<!doctype html>
<html class="no-js" lang="en">
<head>
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0" />

<title> </title>
<script type="text/javascript" src="../js/jquery-1.11.1.js"></script>
<style>

</style>
<script type="text/javascript" language="JavaScript"> 
    
$(document).ready(function(){

//on form submit - post to aspx.cs in generator
$("#formWhole").submit(function(){
    
    function syncSubmit() {
            var iframe4 = document.createElement("IFRAME");
            iframe4.setAttribute("src", 'data:text/plain,');
            document.documentElement.appendChild(iframe4);
            window.frames[0].window.alert('Preparing PDF! This may take a minute!');
            iframe4.parentNode.removeChild(iframe4);
    }
    syncSubmit();
    
    var localbase64string = localStorage["signature"];
    var localbase64string2 = localStorage["sigsleeve"];
    var b64 = localbase64string.replace(/^data:image\/(png|jpg);base64,/, "");
    var b64a = localbase64string2.replace(/^data:image\/(png|jpg);base64,/, "");
    //var getdtnew = new Date(year, month, day);
  
    var formData = new FormData($(this)[0]);
    //formData.append( 'files', $('input[type=file]')[0].files[0]);
    formData.append( 'newsig', b64);
    //formData.append( 'sigsleeve', b64a);
    //formData.append( 'EvalDate', getdtnew);
    
    var insertSendPDF = 'http://xxx.xxxx.xxx.xxx/252form.aspx/syncDBnow/';

    $.ajaxSetup ({
        cache: false
    });
        console.log('Start');
        $.support.cors = true;
    
        $.ajax({
            type: 'POST',
            data: formData,
            async: false,
            processData: false,
            contentType: false,
            timeout: 500000,
            //contentType: "application/x-www-form-urlencoded",
            url: insertSendPDF,
            success: function(response){
                
                console.log("finished!");
                
                function itWorked(){
                var iframe = document.createElement("IFRAME");
                iframe.setAttribute("src", 'data:text/plain,');
                document.documentElement.appendChild(iframe);
                window.frames[0].window.alert('Email Sent! Resetting form...');
                iframe.parentNode.removeChild(iframe);
                } itWorked();

                var duration = 0.5, // animation time in seconds
                direction = "right"; // animation direction - left | right | top | bottom
                setTimeout(function() {
                    //doClear252();
                    window.location.replace("./../mainmenu.html");

                }, 100);
                nativetransitions.flip(duration, direction);

                    //doClear252();
                    window.location.replace("./../mainmenu.html");

           }, error:function (){  
                      function oops() {
                            var iframe77 = document.createElement("IFRAME");
                            iframe77.setAttribute("src", 'data:text/plain,');
                            document.documentElement.appendChild(iframe77);
                            window.frames[0].window.alert('Oops! Email not sent... Check your connection and try again!');
                            iframe77.parentNode.removeChild(iframe77);
                        }
                        oops();


            }

        });
    return false;
}); 
    

});
</script>
</head>
<body>
	<div id="fixedBox"></div>
	<br/><br/>
	<div class="confirm-messages" style="display:none;"></div>
<div id="formcontainer" style="display:block;margin-top:5%;">
<form id="formWhole" method="POST" enctype="multipart/form-data" action='' style="width:100% !important">

<div class="row" >
	<div>
		<label>Send to Supervisor</label>
		<select name="email" id="supemail" class="radius">
		  <option>Choose name:</option>
          	   <option value="lnichols@xxx-xxxx.com">L. Nichols</option>-->
		</select>&nbsp;&nbsp;&#187;&nbsp;&nbsp;
		<input type="hidden" name="filename" id="filename" value=""/>
		<label>cc (enter your email):</label><input type="text" size="45" id="cc" name="youremail" style="border:1px solid #ccc !important;background:#E7E4E4;border: #ccc 2px solid;border-radius:5px;">
	</div>
	<div style="clear:both;"></div>
	Upload photo(s):&nbsp;&nbsp;&nbsp;&nbsp;<input type="file" name="files[]" min="1" max="9" class="radius" multiple/>
	
        <!--<input type="submit" value="Upload" style="background:#ccc;color:#fff;" style="border: #ccc 2px solid;border-radius:25px;"/>-->
<hr style="width:100% !important;"/>
	<div style="clear:both;"></div><button id="gobk" class="backButton large" type="button" style="background:#5f5f5f;color:#fff;border: #5f5f5f 2px solid;border-radius:5px;font-size:1.7rem; ">Back to Edit</button><button id="printPDF" type="submit" style="background:#5f5f5f;color:#fff;border: #5f5f5f 2px solid;border-radius:5px;font-size:1.7rem;" class="large">Send PDF</button>&nbsp;*by clicking send you are sending Form 252 to the above recipients.

</div>

<hr style="width:100% !important;"/>
<table align="center" border="0" cellpadding="0" cellspacing="0" id="newtable">
  <tr>
    <td colspan="12"><img src="http://xx.xxx.xx.xxx/SWG252/protected/img/xxtrasmsw.png" ></td>
  </tr>
  <tr>
    <td colspan="12"><b>This form is used by Southwest Gas to document quality control inspections of contract personnel who perform construction activities</b><div style="clear:both;"></div><br/></td>
  </tr>
  <tr >
    <td width="11%">Prepared By</td>
    <td colspan="6" class="bb"><input type="text" name="Preparedby" id="preBy" ></td>
	<td colspan="1">Status&nbsp;<input type="text" name="newStatus" id="status" ></td>
    <td width="11%" align="right">Date Prepared</td>
    <td colspan="3" class="bb"><input type="text" name="DatePrepared" id="datBy" ></td>
  </tr>
  <tr>
    <td><span class="MsoNormal">Crew Leader</span></td>
    <td colspan="5" class="bb"><input type="text" name="CrewLeader" id="creLead" ></td>
    <td colspan="3" align="right">Follow-Up Date <i>(when required)</i></td>
    <td colspan="3" class="bb"><input type="text" name="FollowUpDate" id="follDat" ></td>
  </tr>
  <tr>
    <td><span class="MsoNormal">Vehicle Number</span></td>
    <td colspan="2" class="bb"><input type="text" name="VehicleNum" id="vehNu" ></td>
    <td colspan="3">SWG Inspector as needed&nbsp;      <input type="checkbox" name="InspNeeded1" id="inspasneed100" ></td>
    <td colspan="6">Contractor <i>(to be completed weekly)</i>      <input type="checkbox" name="Contrwk" id="contr100" ></td>
  </tr>
  <tr>
    <td>Atlas or Tile</td>
    <td width="16%" class="bb"><input type="text" name="AliasofTit" id="aliastit" ></td>
    <td width="7%">District</td>
    <td colspan="2" class="bb"><input type="text" name="Dist" id="dist1"></td>
    <td width="7%" align="right">Contractor</td>
    <td colspan="6" class="bb"><input type="text" name="Contrctr" id="contr2" ></td>
  </tr>
  <tr>
    <td><span>Work Description</span></td>
    <td colspan="11" class="bb"><textarea type="text" name="WrkDesc" id="WrkDesc" cols="80" rows="5" style="width:100%;" ></textarea></td>
    </tr>
  <tr>
    <td colspan="12">Job Number&nbsp;&nbsp;&nbsp;<span class="bb">
      <input type="text" name="JobNum" id="JobNum" class="bb"></span>
    </td>
    </tr>
  <tr>
    <td><span class="MsoNormal">Address</span></td>
    <td colspan="11" class="bb"><input type="text" name="Address" id="Address" ></td>
  </tr>
  <tr>
    <td><i>Crew Type</i></td>
    <td>
      <input type="checkbox" name="crewDay" id="crewDay" >
    Crew Day
    <input type="checkbox" name="crewUnit" id="crewUnit" >
Unit
<input type="checkbox" name="crewBid" id="crewBid" >
&nbsp;Bid</td>
    <td>&nbsp;</td>
    <td colspan="3"><i>Existing Facilities Marked:</i>
          <input type="checkbox" name="ExFacMarkd" id="exFacY">Yes
<input type="checkbox" name="ExFacMarkdN" id="exFacN">No</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td width="6%">&nbsp;</td>
    <td width="2%">&nbsp;</td>
    <td width="6%">&nbsp;</td>
  </tr>
  <tr>
    <td><i>Arrival:</i></td>
    <td >&nbsp;</td>
    <td colspan="3" align="center"><i>Departure:</i></td>
    <td colspan="3" align="center"><i>P.J.Q Number</i></td>
    <td colspan="2" align="center"><i>Contractor Equipment:</i></td>
    <td colspan="2" align="center"><i>Date/Time Used:</i></td>
  </tr>
  <tr>
    <td align="right">1.</td>
    <td class="bb"><input type="text" name="ArrivDates1" id="arriv1" ></td>
    <td align="right">1.</td>
    <td colspan="2" class="bb"><input type="text" name="DeptDates1" id="dept1" ></td>
    <td align="right">1.</td>
    <td colspan="2" class="bb"><input type="text" name="PJQ1" id="pjqnum1" ></td>
    <td align="right">Trencher</td>
    <td ><input type="checkbox" name="ContrEquip1" id="equipTrench" ></td>
    <td colspan="2">Hrs <input type="text" name="DateUsed1" id="time21"></td>
  </tr>
  <tr>
    <td align="right">2.</td>
    <td class="bb"><input type="text" name="ArrivDates2" id="arriv2" ></td>
    <td align="right">2.</td>
    <td colspan="2" class="bb"><input type="text" name="DeptDates2" id="dept2" ></td>
    <td align="right">2.</td>
    <td colspan="2" class="bb"><input type="text" name="PJQ2" id="pjqnum2" ></td>
    <td align="right">Side Boom</td>
    <td ><input type="checkbox" name="ContrEquip2" id="equipSidBoom" ></td>
    <td colspan="2">Hrs <input type="text" name="DateUsed2" id="time22"></td>
  </tr>
  <tr>
    <td align="right">3.</td>
    <td class="bb"><input type="text" name="ArrivDates3" id="arriv3" ></td>
    <td align="right">3.</td>
    <td colspan="2" class="bb"><input type="text" name="DeptDates3" id="dept3" ></td>
    <td align="right">3.</td>
    <td colspan="2" class="bb"><input type="text" name="PJQ3" id="pjqnum3" ></td>
    <td align="right">Water Truck</td>
    <td><input type="checkbox" name="ContrEquip3" id="equipWatTru" ></td>
    <td colspan="2">Hrs <input type="text" name="DateUsed3" id="time23"></td>
  </tr>
  <tr>
    <td align="right">4.</td>
    <td class="bb"><input type="text" name="ArrivDates4" id="arriv4" ></td>
    <td align="right">4.</td>
    <td colspan="2" class="bb"><input type="text" name="DeptDates4" id="dept4" ></td>
    <td align="right">4.</td>
    <td colspan="2" class="bb"><input type="text" name="PJQ4" id="pjqnum4" ></td>
    <td align="right">Track Hoe</td>
    <td ><input type="checkbox" name="ContrEquip4" id="equipTraHo" ></td>
    <td colspan="2">Hrs <input type="text" name="DateUsed4" id="time24"></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td align="right">Other</td>
    <td><input type="checkbox" name="ContrEquip5" id="equipOth" ></td>
    <td colspan="2">Hrs <input type="text" name="DateUsed5" id="time25"></td>
  </tr>
  <tr>
    <td>Main Footage Installed</td>
    <td colspan="2" class="bb"><input type="text" name="MainFt" id="mainFootIns" ></td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><span>Installed Per Design?</span></td>
    <td>
        <input type="checkbox" name="InstPerDes" id="instPerDesY" >Yes
		<input type="checkbox" name="InstPerDes2" id="instPerDesN" >No</td>
    <td>&nbsp;</td>
    <td width="8%" align="right"><span>Service Installed</span></td>
    <td colspan="2" class="bb"><input type="text" name="SvcInst" id="servInst" ></td>
    <td width="8%" align="right">Stubs Installed</td>
    <td colspan="2" class="bb"><input type="text" name="StbsInst" id="stubsInst" ></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>No. Lifts</td>
    <td class="bb"><input type="text" name="SandNoLfts" id="noLifts" ></td>
    <td align="right">Linear Feet</td>
    <td colspan="2" class="bb"><input type="text" name="SandLinFt" id="linFt" ></td>
    <td align="right"><i>Backfill:</i></td>
    <td colspan="6">
      <input type="checkbox" name="BackFill" id="bkfillABC" >
      ABC
  <input type="checkbox" name="BackFill2" id="bkfillSlur" >
 		Slurry
  <input type="checkbox" name="BackFill3" id="bkfillNat" >
    Native
  <input type="checkbox" name="BackFill4" id="bkfillScr" >
    Screened</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td align="right"><i>Installation:</i></td>
    <td colspan="6"><input type="checkbox" name="Installa" id="instOpn" >
    Open&nbsp;&nbsp;
    <input type="checkbox" name="Installa2" id="instJt" >
    Joint&nbsp;&nbsp;
    <input type="checkbox" name="Installa3" id="instBor" >
    Bore&nbsp;
    <input type="checkbox" name="Installa4" id="instInser" >
    &nbsp;Insertion</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><i>Job Classifications:</i></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>Laborer</td>
    <td class="bb"><input type="text" name="Laborer" id="jcLab" ></td>
    <td align="right">Crew Leader</td>
    <td colspan="2" class="bb"><input type="text" name="CrwLead" id="jcCL" ></td>
    <td align="right">Other</td>
    <td colspan="2" class="bb"><input type="text" name="Othr1" id="jcOth" ></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>Fitter</td>
    <td class="bb"><input type="text" name="Fitr" id="jcFit" ></td>
    <td align="right">Truck Driver</td>
    <td colspan="2" class="bb"><input type="text" name="TrkDrvr" id="jcTrD" ></td>
    <td align="right">Other</td>
    <td colspan="2" class="bb"><input type="text" name="Othr2" id="jcOth2" ></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>Welder</td>
    <td class="bb"><input type="text" name="Weldr" id="jcWel" ></td>
    <td align="right">Operator</td>
    <td colspan="2" class="bb"><input type="text" name="Oprtr" id="jcOp" ></td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><b>Evaluation of</b></td>
    <td><b>
    <input type="checkbox" name="evalcrew" id="eval1" >
    Crew</b>
        <input type="checkbox" name="evalindiv" id="eval2" >
	Individual</td>
    <td>&nbsp;</td>
    <td colspan="2">Ops Manual OK &nbsp;
            <input type="checkbox" name="opsmanok" id="ops1" >
    </td>
    <td colspan="4">Chart/Gauge Calibration OK - #
        <input type="checkbox" name="chgaugcal" id="char1" >
    </td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td colspan="12" bgcolor="#000000" align="center" style="color:white;"><strong>WORKMANSHIP (QUALITY)</strong></td>
  </tr>
  <tr>
    <td colspan="2" align="center"><strong>Address/Locations</strong></td>
    <td colspan="3" align="center">Type of Activity
    </td>
    <td colspan="3" align="center">* Successful</td>
    <td colspan="2" align="center">Unsuccessful</td>
    <td colspan="2" align="center">N/A</td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr1" id="addr1" ></td>
    <td colspan="3">1. Line Location</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs1" id="succs1" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs1" id="unsuccs1" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp1" id="notapp1" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr2" id="addr2" ></td>
    <td colspan="3">2. Pipe
    Installation</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs2" id="succs2" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs2" id="unsuccs2" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp2" id="notapp2" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr3" id="addr3" ></td>
    <td colspan="3">3. Pipe Repair</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs3" id="succs3" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs3" id="unsuccs3" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp3" id="notapp3" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr4" id="addr4" ></td>
    <td colspan="3">4. Leakage
    Survey/Centering</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs4" id="succs4" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs4" id="unsuccs4" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp4" id="notapp4" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr5" id="addr5" ></td>
    <td colspan="3">5. Emergency
    Response (Hit Truck)</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs5" id="succs5" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs5" id="unsuccs5" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp5" id="notapp5" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr6" id="addr6" ></td>
    <td colspan="3">6. Valve Installation/Maintenance</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs6" id="succs6" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs6" id="unsuccs6" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp6" id="notapp6" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr7" id="addr7" ></td>
    <td colspan="3">7. Regulator Station Installation</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs7" id="succs7" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs7" id="unsuccs7" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp7" id="notapp7" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr8" id="addr8" ></td>
    <td colspan="3">8. Regulator Station Maintenance</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs8" id="succs8" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs8" id="unsuccs8" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp8" id="notapp8" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr9" id="addr9" ></td>
    <td colspan="3">9. Hazard Location/Barricades</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs9" id="succs9" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs9" id="unsuccs9" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp9" id="notapp9" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr10" id="addr10" ></td>
    <td colspan="3">10. MSA Maintenance/Relights</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs10" id="succs10" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs10" id="unsuccs10" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp10" id="notapp10" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr11" id="addr11" ></td>
    <td colspan="3">11. Job Clean Up</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs11" id="succs11" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs11" id="unsuccs11" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp11" id="notapp11" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr12" id="addr12" ></td>
    <td colspan="3"><span class="MsoNormal">12. Documentation Correct/Clear</span></td>
    <td colspan="3" align="center"><input type="checkbox" name="succs12" id="succs12" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs12" id="unsuccs12" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp12" id="notapp12" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr13" id="addr13" ></td>
    <td colspan="3">13. Odorization Checks</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs13" id="succs13" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs13" id="unsuccs13" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp13" id="notapp13" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr14" id="addr14" ></td>
    <td colspan="3">14. Patrolling</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs14" id="succs14" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs14" id="unsuccs14" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp14" id="notapp14" ></td>
  </tr>
  <tr>
    <td>Comments</td>
    <td colspan="11" class="bb"><textarea name="commWrk" id="commWrk" cols="80" rows="5" style="width:100%;" ></textarea></td>
  </tr>
  <tr>
    <td colspan="8" style="background:#ccc;">&nbsp;</td>
    <td colspan="4" style="background:#ccc;">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="8"><div class="SummarySig large-12 columns">
        <label style="display:inline;">Crew Leader Printed Name</label>
                  <input id="evalPrinted" name="evalPrinted" type="text" style="width: 40% !important;display:inline;" class="radius">
             

        <label style="display:inline;">&nbsp;&nbsp;Date Signed</label>
                  <input id="EvalDate"  name="EvalDate" type="text" style="width: 30% !important;display:inline;" class="radius">
              
          </div></td>
    <td colspan="4">&nbsp;</td>
  </tr>
  <tr>
    <td><strong>Crew Leader/Individual</strong></td>
    <td colspan="7" class="bb"><div id="signedsig"  style="height: 100px; background-size: 250px 90px;background-repeat: no-repeat;display: block;"></div>
      <input type="hidden" name="newsig" id="newsig" value="" style="width:100%;height:100px;" ></td>
    <td colspan="4" class="bb">&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="3" align="center"><small><em><i>(Signature)
            </i></em></small></td>
    <td colspan="2">&nbsp;</td>
    <td colspan="4" align="center"><small><em>(Date Reviewed)
    </em></small></td>
  </tr>
  <tr>
    <td><strong>Supervisor</strong></td>
    <td colspan="7" class="bb">&nbsp;</td>
    <td colspan="4" class="bb">&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="3" align="center"><small><em>(Print Name &amp; Sign)</em></small></td>
    <td colspan="2">&nbsp;</td>
    <td colspan="4" align="center"><small><em>(Date Reviewed)</em></small></td>
  </tr>
  <tr>
    <td colspan="2">Manager/Superintendent</td>
    <td colspan="6" class="bb">&nbsp;</td>
    <td colspan="4" class="bb">&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="3" align="center"><small><em>(Print Name &amp; Sign)</em></small></td>
    <td colspan="2" >&nbsp;</td>
    <td colspan="4" align="center"><small><em>(Date Reviewed)</em></small></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td colspan="12" align="center" bgcolor="#000000" style="color:white;"><strong>TIME MANAGEMENT (PRODUCTIVITY)</strong></td>
  </tr>
  <tr>
    <td colspan="2" align="center"><strong>Address/Locations</strong></td>
    <td colspan="3" align="center"><strong>Type of Activity</strong></td>
    <td colspan="3" align="center"><strong>Successful</strong></td>
    <td colspan="2" align="center"><strong>Unsuccessful</strong></td>
    <td colspan="2" align="center"><strong>N/A</strong></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr15" id="addr15" ></td>
    <td colspan="3">1.&nbsp;Proper Documentation/Permit</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs15" id="succs15" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs15" id="unsuccs15" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp15" id="notapp15" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr16" id="addr16" ></td>
    <td colspan="3">2.&nbsp; Delegation/Follow-Up</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs16" id="succs16" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs16" id="unsuccs16" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp16" id="notapp16" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr17" id="addr17" ></td>
    <td colspan="3">3.&nbsp; Proper Tools and Equip</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs17" id="succs17" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs17" id="unsuccs17" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp17" id="notapp17" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr18" id="addr18" ></td>
    <td colspan="3">4.&nbsp;Communication Skills</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs18" id="succs18" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs18" id="unsuccs18" ></td>
    <td colspan="2" align="center"> <input type="checkbox" name="notapp18" id="notapp18" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr19" id="addr19" ></td>
    <td colspan="3">5.&nbsp;Quantity of Work Completed</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs19" id="succs19" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs19" id="unsuccs19" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp19" id="notapp19" ></td>
  </tr>
  <tr>
    <td><span class="MsoNormal">Comments</span></td>
    <td colspan="11" class="bb"><textarea name="commTM" id="commTM" cols="80" rows="5" style="width:100%;" ></textarea></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td colspan="12" align="center" bgcolor="#000000" style="color:white;"><strong>GENERAL (SAFETY)</strong></td>
  </tr>
  <tr>
    <td colspan="2" align="center"><strong>Address/Locations</strong></td>
    <td colspan="3" align="center"><strong>Type of Activity
         </strong></td>
    <td colspan="3" align="center"><b>Successful</b></td>
    <td colspan="2" align="center"><b>Unsuccessful</b></td>
    <td colspan="2" align="center"><span style="text-align:center"><b>N/A </b></span></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr20" id="addr20" ></td>
    <td colspan="3">1.&nbsp;Site Safety</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs20" id="succs20" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs20" id="unsuccs20" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp20" id="notapp20" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr21" id="addr21" ></td>
    <td colspan="3">2.&nbsp; Vehicle
      Inspection</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs21" id="succs21" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs21" id="unsuccs21" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp21" id="notapp21" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr22" id="addr22" ></td>
    <td colspan="3">3.&nbsp;Tool
      Inspection</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs22" id="succs22" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs22" id="unsuccs22" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp22" id="notapp22" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr23" id="addr23" ></td>
    <td colspan="3">4.&nbsp;Material</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs23" id="succs23" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs23" id="unsuccs23" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp23" id="notapp23" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr24" id="addr24" ></td>
    <td colspan="3">5.&nbsp;Tool Use
      and Maintenance</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs24" id="succs24" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs24" id="unsuccs24" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp24" id="notapp24" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr25" id="addr25"></td>
    <td colspan="3">6.&nbsp;Personal
      Safety Equipment</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs25" id="succs25" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs25" id="unsuccs25" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp25" id="notapp25" ></td>
  </tr>
  <tr>
    <td colspan="2" class="bb"><input type="text" name="addr26" id="addr26" ></td>
    <td colspan="3">7.&nbsp;Vehicle Security</td>
    <td colspan="3" align="center"><input type="checkbox" name="succs26" id="succs26" ></td>
    <td colspan="2" align="center"><input type="checkbox" name="unsuccs26" id="unsuccs26" >
</td>
    <td colspan="2" align="center"><input type="checkbox" name="notapp26" id="notapp26" ></td>
  </tr>
  <tr>
    <td colspan="2">&nbsp;</td>
    <td colspan="3">&nbsp;</td>
    <td colspan="3">&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td colspan="2">&nbsp;</td>
  </tr>
  <tr>
    <td>Comments</td>
    <td colspan="11" class="bb"><textarea name="comm2" id="comm2" cols="80" rows="5" style="width:100%;" ></textarea></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td colspan="12" align="center" bgcolor="#000000" style="color:white;"><strong>ENVIRONMENTAL</strong></td>
  </tr>
  <tr>
    <td colspan="12"></td>
  </tr>
  <tr>
    <td colspan="2"><input type="text" name="addr27" id="addr27" ></td>
    <td colspan="4">1. Water Runnoff Protection (Best Management Practices)</td>
    <td colspan="2"><input type="checkbox" name="succs27" id="succs27" ></td>
    <td colspan="2"><input type="checkbox" name="unsuccs27" id="unsuccs27" ></td>
    <td colspan="2"><input type="checkbox" name="notapp27" id="notapp27" ></td>
  </tr>
  <tr>
    <td colspan="2"><input type="text" name="addr28" id="addr28" ></td>
    <td colspan="4">2.  Environmental Permit Requirements</td>
    <td colspan="2"><input type="checkbox" name="succs28" id="succs28" ></td>
    <td colspan="2"><input type="checkbox" name="unsuccs28" id="unsuccs28" ></td>
    <td colspan="2"><input type="checkbox" name="notapp28" id="notapp28" ></td>
  </tr>
  <tr>
    <td colspan="12" align="center" bgcolor="#000000" style="color: white;"><b>TRAINING NEEDS IDENTIFIED</b></td>
  </tr>
  <tr>
    <td colspan="12"><textarea name="train1" id="train1" cols="80" rows="10" style="width:100%;" ></textarea></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  
  <tr>
    <td colspan="12" align="center" bgcolor="#000000" style="color: white;"><b>TRAINING PROVIDED</b></td>
  </tr>
  <tr>
    <td colspan="12"><textarea name="train2" id="train2" cols="80" rows="10" style="width:100%;" ></textarea></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td colspan="12" align="center" bgcolor="#000000" style="color:white"><b>EVALUATION SUMMARY</b></td>
  </tr>
  <tr>
    <td colspan="12"><textarea name="evalnot1" id="evaln" cols="80" rows="10" style="width:100%;" ></textarea></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td colspan="3">&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td colspan="5" bgcolor="#CCCCCC"><strong>OVERALL RATINGS</strong></td>
    <td colspan="3" bgcolor="#CCCCCC"><strong>Successful</strong></td>
    <td colspan="2" bgcolor="#CCCCCC"><strong>*Unsuccessful</strong></td>
    <td bgcolor="#CCCCCC">&nbsp;</td>
    <td bgcolor="#CCCCCC">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="5" bgcolor="#CCCCCC">WORKMANSHIP</td>
    <td colspan="3" bgcolor="#CCCCCC"><input type="checkbox" name="succsTime1" id="succsTime1" ></td>
    <td colspan="2" bgcolor="#CCCCCC"><input type="checkbox" name="succsGenSafe1" id="succsGenSafe1" ></td>
    <td bgcolor="#CCCCCC">&nbsp;</td>
    <td bgcolor="#CCCCCC">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="5" bgcolor="#CCCCCC">TIME MANAGEMENT</td>
    <td colspan="3" bgcolor="#CCCCCC"><input type="checkbox" name="succsTime2" id="succsTime2" ></td>
    <td colspan="2" bgcolor="#CCCCCC"><input type="checkbox" name="succsGenSafe2" id="succsGenSafe2" ></td>
    <td bgcolor="#CCCCCC">&nbsp;</td>
    <td bgcolor="#CCCCCC">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="5" bgcolor="#CCCCCC">GENERAL SAFETY    </td>
    <td colspan="3" bgcolor="#CCCCCC"><input type="checkbox" name="succsTime3" id="succsTime3" ></td>
    <td colspan="2" bgcolor="#CCCCCC"><input type="checkbox" name="succsGenSafe3" id="succsGenSafe3" ><br/>
    <input type="hidden" name="genUUID" id="genUUID">
    <input type="hidden" name="appVersion" id="appVersion" ></td>
    <td bgcolor="#CCCCCC">&nbsp;</td>
    <td bgcolor="#CCCCCC">&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>
</form>
<p>*Any Unsuccessful rating requires remedial action/training
and a completion date.</p>
</div>
</body>

</html>
