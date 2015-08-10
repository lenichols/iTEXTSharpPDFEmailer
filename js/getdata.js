
$(document).ready(function() {

	$("input[type=checkbox]").click(function() { 
	if ($(this).is(':checked')) {
		$this = $(this);
		localStorage[$this.attr("id")] = $this.checked = true;
		//$(this).prop('checked',false);
		//alert("is checked");
	}
	if($(this).is(':not(:checked)')) {
		$this = $(this);
		localStorage.removeItem([$this.attr("id")]);
	}
	});
$("#Preparedby").val(localStorage.getItem("preparedby"));
$("input[name=newStatus]").val(localStorage.getItem("status"));
$("input[name=DatePrepared]").val(localStorage.getItem("dateprep"));
$("input[name=CrewLeader]").val(localStorage.getItem("crewlead"));
$("input[name=FollowUpDate]").val(localStorage.getItem("followupdt"));
$("input[name=VehicleNum]").val(localStorage.getItem("vehiclenum"));

$("input[name=evalPrinted]").val(localStorage.getItem("PrintedName"));
$("input[name=EvalDate]").val(localStorage.getItem("LeaderSig"));
				  //checkbox//
	  //$("input[name=InspNeeded1]").val(localStorage.getItem("inspasneed100"));
if (localStorage.getItem('inspasneed100') == 'true') { 
    document.getElementById("MainContent_InspNeeded1").checked = true;
	} else{
    document.getElementById("MainContent_InspNeeded1").checked = false;
	}
//checkbox//
//$("input[name=Contrwk]").val(localStorage.getItem("contr100"));
if (localStorage.getItem('contr100') == 'true') { 
    document.getElementById("MainContent_Contrwk").checked = true;
	} else{
    document.getElementById("MainContent_Contrwk").checked = false;
	}

	  	
$("input[name=AliasofTit]").val(localStorage.getItem("titlealias"));
$("input[name=Dist]").val(localStorage.getItem("district"));
$("input[name=Contrctr]").val(localStorage.getItem("contr"));
$("textarea[name=WrkDesc]").val(localStorage.getItem("description"));
$("input[name=JobNum]").val(localStorage.getItem("jobnumber"));
$("input[name=Address]").val(localStorage.getItem("jbaddress"));

//$("input[name=crewDay]").val(localStorage.getItem("crewDay"));
	
if (localStorage.getItem('crewDay') == 'true') { 
    document.getElementById("MainContent_crewDay").checked = true;
	} else{
    document.getElementById("MainContent_crewDay").checked = false;
	}
	
//$("input[name=crewUnit]").val(localStorage.getItem("crewUnit"));
	
if (localStorage.getItem('crewUnit') == 'true') { 
    document.getElementById("MainContent_crewUnit").checked = true;
	} else{
    document.getElementById("MainContent_crewUnit").checked = false;
	}
	
//$("input[name=server]").val(localStorage.getItem("crewBid"));

if (localStorage.getItem('crewBid') == 'true') { 
    document.getElementById("MainContent_crewBid").checked = true;
	} else{
    document.getElementById("MainContent_crewBid").checked = false;
	}
	
//$("input[name=ExFacMarkdY]").val(localStorage.getItem("exFacY"));
	
if (localStorage.getItem('exFacY') == 'true') { 
    document.getElementById("MainContent_ExFacMarkd").checked = true;
	} else{
    document.getElementById("MainContent_ExFacMarkd").checked = false;
	}
	
//$("input[name=ExFacMarkdN]").val(localStorage.getItem("exFacN"));
	
if (localStorage.getItem('exFacN') == 'true') { 
    document.getElementById("MainContent_ExFacMarkdN").checked = true;
	} else{
    document.getElementById("MainContent_ExFacMarkdN").checked = false;
	}

$("input[name=ArrivDates1]").val(localStorage.getItem("ar1"));
$("input[name=DeptDates1]").val(localStorage.getItem("departt1"));
$("input[name=PJQ1]").val(localStorage.getItem("pjqnm1"));
	  //checkbox//
	  //$("input[name=ContrEquip1]").val(localStorage.getItem("equipTrench"));
if (localStorage.getItem('equipTrench') == 'true') { 
    document.getElementById("MainContent_ContrEquip1").checked = true;
	} else{
    document.getElementById("MainContent_ContrEquip1").checked = false;
	}
$("input[name=DateUsed1]").val(localStorage.getItem("tm21"));
	
$("input[name=ArrivDates2]").val(localStorage.getItem("ar2"));
$("input[name=DeptDates2]").val(localStorage.getItem("departt2"));
$("input[name=PJQ2]").val(localStorage.getItem("pjqnm2"));
//checkbox//
	  //$("input[name=ContrEquip2]").val(localStorage.getItem("equipSidBoom"));
if (localStorage.getItem('equipSidBoom') == 'true') { 
    document.getElementById("MainContent_ContrEquip2").checked = true;
	} else{
    document.getElementById("MainContent_ContrEquip2").checked = false;
	}
//
$("input[name=DateUsed2]").val(localStorage.getItem("tm22"));
	
	
$("input[name=ArrivDates3]").val(localStorage.getItem("ar3"));
$("input[name=DeptDates3]").val(localStorage.getItem("departt3"));
$("input[name=PJQ3]").val(localStorage.getItem("pjqnm3"));
//checkbox//
	  //$("input[name=ContrEquip3]").val(localStorage.getItem("equipWatTru"));
if (localStorage.getItem('equipWatTru') == 'true') { 
    document.getElementById("MainContent_ContrEquip3").checked = true;
	} else{
    document.getElementById("MainContent_ContrEquip3").checked = false;
	}
//
$("input[name=DateUsed3]").val(localStorage.getItem("tm23"));
$("input[name=ArrivDates4]").val(localStorage.getItem("ar4"));
$("input[name=DeptDates4]").val(localStorage.getItem("departt4"));
$("input[name=PJQ4]").val(localStorage.getItem("pjqnm4"));
//checkbox//
	  //$("input[name=ContrEquip4]").val(localStorage.getItem("equipTraHo"));
if (localStorage.getItem('equipTraHo') == 'true') { 
    document.getElementById("MainContent_ContrEquip4").checked = true;
	} else{
    document.getElementById("MainContent_ContrEquip4").checked = false;
	}
//
$("input[name=DateUsed4]").val(localStorage.getItem("tm24"));
$("input[name=MainFt]").val(localStorage.getItem("mainfootage"));

if (localStorage.getItem('equipOth') == 'true') { 
    document.getElementById("MainContent_ContrEquip5").checked = true;
	} else{
    document.getElementById("MainContent_ContrEquip5").checked = false;
	}

//$("input[name=ContrEquip5]").val(localStorage.getItem("equipOth"));
$("input[name=DateUsed5]").val(localStorage.getItem("tm25"));
//checkbox//
	  //$("input[name=InstPerDes]").val(localStorage.getItem("instPerDesY"));
if (localStorage.getItem('instPerDesY') == 'true') { 
    document.getElementById("MainContent_InstPerDes").checked = true;
	} else{
    document.getElementById("MainContent_InstPerDes").checked = false;
	}
//$("input[name=InstPerDes2]").val(localStorage.getItem("instPerDesN"));
if (localStorage.getItem('instPerDesN') == 'true') { 
    document.getElementById("MainContent_InstPerDes2").checked = true;
	} else{
    document.getElementById("MainContent_InstPerDes2").checked = false;
	}
//checkbox//
//
$("input[name=SvcInst]").val(localStorage.getItem("svcinstalled"));
$("input[name=StbsInst]").val(localStorage.getItem("stubsinst"));
//
//checkbox//
$("input[name=SandNoLfts]").val(localStorage.getItem("numlifts"));
$("input[name=SandLinFt]").val(localStorage.getItem("linearft"));

//checkbox
//$("input[name=BackFill]").val(localStorage.getItem("bkfillABC"));
if (localStorage.getItem('bkfillABC') == 'true') { 
    document.getElementById("MainContent_BackFill").checked = true;
	} else{
    document.getElementById("MainContent_BackFill").checked = false;
	}
	  //$("input[name=BackFill2]").val(localStorage.getItem("bkfillSlur"));
if (localStorage.getItem('bkfillSlur') == 'true') { 
    document.getElementById("MainContent_BackFill2").checked = true;
	} else{
    document.getElementById("MainContent_BackFill2").checked = false;
	}
//$("input[name=BackFill3]").val(localStorage.getItem("bkfillNat"));
if (localStorage.getItem('bkfillNat') == 'true') { 
    document.getElementById("MainContent_BackFill3").checked = true;
	} else{
    document.getElementById("MainContent_BackFill3").checked = false;
	}
//$("input[name=BackFill4]").val(localStorage.getItem("bkfillScr"));
if (localStorage.getItem('bkfillScr') == 'true') { 
    document.getElementById("MainContent_BackFill4").checked = true;
	} else{
    document.getElementById("MainContent_BackFill4").checked = false;
	}
//
//checkbox//
//$("input[name=Installa]").val(localStorage.getItem("instOpn"));
if (localStorage.getItem('instOpn') == 'true') { 
    document.getElementById("MainContent_Installa").checked = true;
	} else{
    document.getElementById("MainContent_Installa").checked = false;
	}
//$("input[name=Installa2]").val(localStorage.getItem("instJt"));
if (localStorage.getItem('instJt') == 'true') { 
    document.getElementById("MainContent_Installa2").checked = true;
	} else{
    document.getElementById("MainContent_Installa2").checked = false;
	}
//$("input[name=Installa3]").val(localStorage.getItem("instBor"));
if (localStorage.getItem('instBor') == 'true') { 
    document.getElementById("MainContent_Installa3").checked = true;
	} else{
    document.getElementById("MainContent_Installa3").checked = false;
	}
//$("input[name=Installa4]").val(localStorage.getItem("instInser"));
if (localStorage.getItem('instInser') == 'true') { 
    document.getElementById("MainContent_Installa4").checked = true;
	} else{
    document.getElementById("MainContent_Installa4").checked = false;
	}
  //
  $("input[name=Laborer]").val(localStorage.getItem("jclasslab"));
  $("input[name=CrwLead]").val(localStorage.getItem("jclasscrewl"));
  $("input[name=Othr1]").val(localStorage.getItem("jclassoth"));
  $("input[name=Fitr]").val(localStorage.getItem("jclassfitter"));
  $("input[name=TrkDrvr]").val(localStorage.getItem("jclasstruckd"));
  $("input[name=Othr2]").val(localStorage.getItem("jclassoth2"));
  $("input[name=Weldr]").val(localStorage.getItem("jclassweld"));
  $("input[name=Oprtr]").val(localStorage.getItem("jclassoper"));

//workmanship - need to finish getting item names
//$("input[name=evalcrew]").val(localStorage.getItem("eval1"));
if (localStorage.getItem('eval1') == 'true') { 
    document.getElementById("MainContent_evalcrew").checked = true;
			} else{
    document.getElementById("MainContent_evalcrew").checked = false;
			}
//$("input[name=evalindiv]").val(localStorage.getItem("eval2"));
if (localStorage.getItem('eval2') == 'true') { 
    document.getElementById("MainContent_evalindiv").checked = true;
			} else{
    document.getElementById("MainContent_evalindiv").checked = false;
			}
//$("input[name=opsmanok]").val(localStorage.getItem("ops1"));
if (localStorage.getItem('ops1') == 'true') { 
    document.getElementById("MainContent_opsmanok").checked = true;
			} else{
    document.getElementById("MainContent_opsmanok").checked = false;
			}
//$("input[name=chgaugcal]").val(localStorage.getItem("char1"));
if (localStorage.getItem('char1') == 'true') { 
    document.getElementById("MainContent_chgaugcal").checked = true;
			} else{
    document.getElementById("MainContent_chgaugcal").checked = false;
			}
$("input[name=addr1]").val(localStorage.getItem("lineaddress"));
//$("input[name=succs1]").val(localStorage.getItem("succs1"));
if (localStorage.getItem('succs1') == 'true') { 
    document.getElementById("MainContent_succs1").checked = true;
			} else{
    document.getElementById("MainContent_succs1").checked = false;
			}
//$("input[name=unsuccs1]").val(localStorage.getItem("unsuccs1"));
if (localStorage.getItem('unsuccs1') == 'true') { 
    document.getElementById("MainContent_unsuccs1").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs1").checked = false;
			}
//$("input[name=notapp1]").val(localStorage.getItem("notapp1"));
if (localStorage.getItem('notapp1') == 'true') { 
    document.getElementById("MainContent_notapp1").checked = true;
			} else{
    document.getElementById("MainContent_notapp1").checked = false;
			}
$("input[name=addr2]").val(localStorage.getItem("pipeinsaddress"));
//$("input[name=succs2]").val(localStorage.getItem("succs2"));
if (localStorage.getItem('succs2') == 'true') { 
    document.getElementById("MainContent_succs2").checked = true;
			} else{
    document.getElementById("MainContent_succs2").checked = false;
			}
//$("input[name=unsuccs2]").val(localStorage.getItem("unsuccs2"));
if (localStorage.getItem('unsuccs2') == 'true') { 
    document.getElementById("MainContent_unsuccs2").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs2").checked = false;
			}
//$("input[name=notapp2]").val(localStorage.getItem("notapp2"));
if (localStorage.getItem('notapp2') == 'true') { 
    document.getElementById("MainContent_notapp2").checked = true;
			} else{
    document.getElementById("MainContent_notapp2").checked = false;
			}
$("input[name=addr3]").val(localStorage.getItem("piprepaddress"));
//$("input[name=succs3]").val(localStorage.getItem("succs3"));
if (localStorage.getItem('succs3') == 'true') { 
    document.getElementById("MainContent_succs3").checked = true;
			} else{
    document.getElementById("MainContent_succs3").checked = false;
			}
//$("input[name=unsuccs3]").val(localStorage.getItem("unsuccs3"));
if (localStorage.getItem('unsuccs3') == 'true') { 
    document.getElementById("MainContent_unsuccs3").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs3").checked = false;
			}
//$("input[name=notapp3]").val(localStorage.getItem("notapp3"));
if (localStorage.getItem('notapp3') == 'true') { 
    document.getElementById("MainContent_notapp3").checked = true;
			} else{
    document.getElementById("MainContent_notapp3").checked = false;
			}
$("input[name=addr4]").val(localStorage.getItem("leakaddress"));
//un$("input[name=succs4]").val(localStorage.getItem("succs4"));
if (localStorage.getItem('succs4') == 'true') { 
    document.getElementById("MainContent_succs4").checked = true;
			} else{
    document.getElementById("MainContent_succs4").checked = false;
			}
//$("input[name=unsuccs4]").val(localStorage.getItem("unsuccs4"));
if (localStorage.getItem('unsuccs4') == 'true') { 
    document.getElementById("MainContent_unsuccs4").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs4").checked = false;
			}
//$("input[name=notapp4]").val(localStorage.getItem("notapp4"));
if (localStorage.getItem('notapp4') == 'true') { 
    document.getElementById("MainContent_notapp4").checked = true;
			} else{
    document.getElementById("MainContent_notapp4").checked = false;
			}
$("input[name=addr5]").val(localStorage.getItem("emeraddress"));
//$("input[name=succs5]").val(localStorage.getItem("succs5"));
if (localStorage.getItem('succs5') == 'true') { 
    document.getElementById("MainContent_succs5").checked = true;
			} else{
    document.getElementById("MainContent_succs5").checked = false;
			}
//$("input[name=unsuccs5]").val(localStorage.getItem("unsuccs5"));
if (localStorage.getItem('unsuccs5') == 'true') { 
    document.getElementById("MainContent_unsuccs5").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs5").checked = false;
			}
//$("input[name=notapp5]").val(localStorage.getItem("notapp5"));
if (localStorage.getItem('notapp5') == 'true') { 
    document.getElementById("MainContent_notapp5").checked = true;
			} else{
    document.getElementById("MainContent_notapp5").checked = false;
			}

$("input[name=addr6]").val(localStorage.getItem("valvaddress"));

//$("input[name=succs6]").val(localStorage.getItem("succs6"));
if (localStorage.getItem('succs6') == 'true') { 
    document.getElementById("MainContent_succs6").checked = true;
			} else{
    document.getElementById("MainContent_succs6").checked = false;
			}
//$("input[name=unsuccs6]").val(localStorage.getItem("unsuccs6"));
if (localStorage.getItem('unsuccs6') == 'true') { 
    document.getElementById("MainContent_unsuccs6").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs6").checked = false;
			}
//$("input[name=notapp6]").val(localStorage.getItem("notapp6"));
if (localStorage.getItem('notapp6') == 'true') { 
    document.getElementById("MainContent_notapp6").checked = true;
			} else{
    document.getElementById("MainContent_notapp6").checked = false;
			}

$("input[name=addr7]").val(localStorage.getItem("regstaaddress"));

//$("input[name=succs7]").val(localStorage.getItem("succs7"));
if (localStorage.getItem('succs7') == 'true') { 
    document.getElementById("MainContent_succs7").checked = true;
			} else{
    document.getElementById("MainContent_succs4").checked = false;
			}
//$("input[name=unsuccs7]").val(localStorage.getItem("unsuccs7"));
if (localStorage.getItem('unsuccs7') == 'true') { 
    document.getElementById("MainContent_unsuccs7").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs7").checked = false;
			}
//$("input[name=notapp7]").val(localStorage.getItem("notapp7"));
if (localStorage.getItem('notapp7') == 'true') { 
    document.getElementById("MainContent_notapp7").checked = true;
			} else{
    document.getElementById("MainContent_notapp7").checked = false;
			}

$("input[name=addr8]").val(localStorage.getItem("regmtaddress"));

//$("input[name=succs8]").val(localStorage.getItem("succs8"));
if (localStorage.getItem('succs8') == 'true') { 
    document.getElementById("MainContent_succs8").checked = true;
			} else{
    document.getElementById("MainContent_succs8").checked = false;
			}
//$("input[name=unsuccs8]").val(localStorage.getItem("unsuccs8"));
if (localStorage.getItem('unsuccs8') == 'true') { 
    document.getElementById("MainContent_unsuccs8").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs8").checked = false;
			}
//$("input[name=notapp8]").val(localStorage.getItem("notapp8"));
if (localStorage.getItem('notapp8') == 'true') { 
    document.getElementById("MainContent_notapp8").checked = true;
			} else{
    document.getElementById("MainContent_notapp8").checked = false;
			}

$("input[name=addr9]").val(localStorage.getItem("hazaddress"));

//$("input[name=succs9]").val(localStorage.getItem("succs9"));
if (localStorage.getItem('succs9') == 'true') { 
    document.getElementById("MainContent_succs9").checked = true;
			} else{
    document.getElementById("MainContent_succs9").checked = false;
			}
//$("input[name=unsuccs9]").val(localStorage.getItem("unsuccs9"));
if (localStorage.getItem('unsuccs9') == 'true') { 
    document.getElementById("MainContent_unsuccs9").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs9").checked = false;
			}
//$("input[name=notapp9]").val(localStorage.getItem("notapp9"));
if (localStorage.getItem('notapp9') == 'true') { 
    document.getElementById("MainContent_notapp9").checked = true;
			} else{
    document.getElementById("MainContent_notapp9").checked = false;
			}

$("input[name=addr10]").val(localStorage.getItem("msamtaddress"));

//$("input[name=succs10]").val(localStorage.getItem("succs10"));
if (localStorage.getItem('succs10') == 'true') { 
    document.getElementById("MainContent_succs10").checked = true;
			} else{
    document.getElementById("MainContent_succs10").checked = false;
			}
//$("input[name=unsuccs10]").val(localStorage.getItem("unsuccs10"));
if (localStorage.getItem('unsuccs10') == 'true') { 
    document.getElementById("MainContent_unsuccs10").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs10").checked = false;
			}
//$("input[name=notapp10]").val(localStorage.getItem("notapp10"));
if (localStorage.getItem('notapp10') == 'true') { 
    document.getElementById("MainContent_notapp10").checked = true;
			} else{
    document.getElementById("MainContent_notapp10").checked = false;
			}

$("input[name=addr11]").val(localStorage.getItem("jclnaddress"));

//$("input[name=succs11]").val(localStorage.getItem("succs11"));
if (localStorage.getItem('succs11') == 'true') { 
    document.getElementById("MainContent_succs11").checked = true;
			} else{
    document.getElementById("MainContent_succs11").checked = false;
			}
//$("input[name=unsuccs11]").val(localStorage.getItem("unsuccs11"));
if (localStorage.getItem('unsuccs11') == 'true') { 
    document.getElementById("MainContent_unsuccs11").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs11").checked = false;
			}
//$("input[name=notapp11]").val(localStorage.getItem("notapp11"));
if (localStorage.getItem('notapp11') == 'true') { 
    document.getElementById("MainContent_notapp11").checked = true;
			} else{
    document.getElementById("MainContent_notapp11").checked = false;
			}

$("input[name=addr12]").val(localStorage.getItem("docuaddress"));

//$("input[name=succs12]").val(localStorage.getItem("succs12"));
if (localStorage.getItem('succs12') == 'true') { 
    document.getElementById("MainContent_succs12").checked = true;
			} else{
    document.getElementById("MainContent_succs12").checked = false;
			}
//$("input[name=unsuccs12]").val(localStorage.getItem("unsuccs12"));
if (localStorage.getItem('unsuccs12') == 'true') { 
    document.getElementById("MainContent_unsuccs12").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs12").checked = false;
			}
//$("input[name=notapp12]").val(localStorage.getItem("notapp12"));
if (localStorage.getItem('notapp12') == 'true') { 
    document.getElementById("MainContent_notapp12").checked = true;
			} else{
    document.getElementById("MainContent_notapp12").checked = false;
			}

$("input[name=addr13]").val(localStorage.getItem("odraddress"));

//$("input[name=succs13]").val(localStorage.getItem("succs13"));
if (localStorage.getItem('succs13') == 'true') { 
    document.getElementById("MainContent_succs13").checked = true;
			} else{
    document.getElementById("MainContent_succs13").checked = false;
			}
//$("input[name=unsuccs13]").val(localStorage.getItem("unsuccs13"));
if (localStorage.getItem('unsuccs13') == 'true') { 
    document.getElementById("MainContent_unsuccs13").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs13").checked = false;
			}
$("input[name=notapp13]").val(localStorage.getItem("notapp13"));
if (localStorage.getItem('notapp13') == 'true') { 
    document.getElementById("MainContent_notapp13").checked = true;
			} else{
    document.getElementById("MainContent_notapp13").checked = false;
			}

$("input[name=addr14]").val(localStorage.getItem("pataddress"));

//$("input[name=succs14]").val(localStorage.getItem("succs14"));
if (localStorage.getItem('succs14') == 'true') { 
    document.getElementById("MainContent_succs14").checked = true;
			} else{
    document.getElementById("MainContent_succs14").checked = false;
			}
//$("input[name=unsuccs14]").val(localStorage.getItem("unsuccs14"));
if (localStorage.getItem('unsuccs14') == 'true') { 
    document.getElementById("MainContent_unsuccs14").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs14").checked = false;
			}
//$("input[name=notapp14]").val(localStorage.getItem("notapp14"));
if (localStorage.getItem('notapp14') == 'true') { 
    document.getElementById("MainContent_notapp14").checked = true;
			} else{
    document.getElementById("MainContent_notapp14").checked = false;
			}

$("input[name=addr15]").val(localStorage.getItem("propdocaddr"));

//$("input[name=succs15]").val(localStorage.getItem("succs15"));
if (localStorage.getItem('succs15') == 'true') { 
    document.getElementById("MainContent_succs15").checked = true;
			} else{
    document.getElementById("MainContent_succs15").checked = false;
			}
//$("input[name=unsuccs15]").val(localStorage.getItem("unsuccs15"));
if (localStorage.getItem('unsuccs15') == 'true') { 
    document.getElementById("MainContent_unsuccs15").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs15").checked = false;
			}
//$("input[name=notapp15]").val(localStorage.getItem("notapp15"));
if (localStorage.getItem('notapp15') == 'true') { 
    document.getElementById("MainContent_notapp15").checked = true;
			} else{
    document.getElementById("MainContent_notapp15").checked = false;
			}

$("input[name=addr16]").val(localStorage.getItem("delfoladdr"));

//$("input[name=succs16]").val(localStorage.getItem("succs16"));
if (localStorage.getItem('succs16') == 'true') { 
    document.getElementById("MainContent_succs16").checked = true;
			} else{
    document.getElementById("MainContent_succs16").checked = false;
			}
//$("input[name=unsuccs16]").val(localStorage.getItem("unsuccs16"));
if (localStorage.getItem('unsuccs16') == 'true') { 
    document.getElementById("MainContent_unsuccs16").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs16").checked = false;
			}
//$("input[name=notapp16]").val(localStorage.getItem("notapp16"));
if (localStorage.getItem('notapp16') == 'true') { 
    document.getElementById("MainContent_notapp16").checked = true;
			} else{
    document.getElementById("MainContent_notapp16").checked = false;
			}

$("input[name=addr17]").val(localStorage.getItem("propaddress"));

//$("input[name=succs17]").val(localStorage.getItem("succs17"));
if (localStorage.getItem('succs17') == 'true') { 
    document.getElementById("MainContent_succs17").checked = true;
			} else{
    document.getElementById("MainContent_succs17").checked = false;
			}
//$("input[name=unsuccs17]").val(localStorage.getItem("unsuccs17"));
if (localStorage.getItem('unsuccs17') == 'true') { 
    document.getElementById("MainContent_unsuccs17").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs17").checked = false;
			}
//$("input[name=notapp17]").val(localStorage.getItem("notapp17"));
if (localStorage.getItem('notapp17') == 'true') { 
    document.getElementById("MainContent_notapp17").checked = true;
			} else{
    document.getElementById("MainContent_notapp17").checked = false;
			}

$("input[name=addr18]").val(localStorage.getItem("commskaddr"));

//$("input[name=succs18]").val(localStorage.getItem("succs18"));
if (localStorage.getItem('succs18') == 'true') { 
    document.getElementById("MainContent_succs18").checked = true;
			} else{
    document.getElementById("MainContent_succs18").checked = false;
			}
//$("input[name=unsuccs18]").val(localStorage.getItem("unsuccs18"));
if (localStorage.getItem('unsuccs18') == 'true') { 
    document.getElementById("MainContent_unsuccs18").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs18").checked = false;
			}
//$("input[name=notapp18]").val(localStorage.getItem("notapp18"));
if (localStorage.getItem('notapp18') == 'true') { 
    document.getElementById("MainContent_notapp18").checked = true;
			} else{
    document.getElementById("MainContent_notapp18").checked = false;
			}

$("input[name=addr19]").val(localStorage.getItem("qualwrkaddr"));

//$("input[name=succs19]").val(localStorage.getItem("succs19"));
if (localStorage.getItem('succs19') == 'true') { 
    document.getElementById("MainContent_succs19").checked = true;
			} else{
    document.getElementById("MainContent_succs19").checked = false;
			}
//$("input[name=unsuccs19]").val(localStorage.getItem("unsuccs19"));
if (localStorage.getItem('unsuccs19') == 'true') { 
    document.getElementById("MainContent_unsuccs19").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs19").checked = false;
			}
//$("input[name=notapp19]").val(localStorage.getItem("notapp19"));
if (localStorage.getItem('notapp19') == 'true') { 
    document.getElementById("MainContent_notapp19").checked = true;
			} else{
    document.getElementById("MainContent_notapp19").checked = false;
			}
			
			
			
//######## workmanship comment box
$("textarea[name=commWrk]").val(localStorage.getItem("workcom"));
//######## time management comment box
$("textarea[name=commTM]").val(localStorage.getItem("tmcom"));



$("input[name=addr20]").val(localStorage.getItem("sitesfaddr"));

//$("input[name=succs20]").val(localStorage.getItem("succs20"));
if (localStorage.getItem('succs20') == 'true') { 
    document.getElementById("MainContent_succs20").checked = true;
			} else{
    document.getElementById("MainContent_succs20").checked = false;
			}
//$("input[name=unsuccs20]").val(localStorage.getItem("unsuccs20"));
if (localStorage.getItem('unsuccs20') == 'true') { 
    document.getElementById("MainContent_unsuccs20").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs20").checked = false;
			}
//$("input[name=notapp20]").val(localStorage.getItem("notapp20"));
if (localStorage.getItem('notapp20') == 'true') { 
    document.getElementById("MainContent_notapp20").checked = true;
			} else{
    document.getElementById("MainContent_notapp20").checked = false;
			}

$("input[name=addr21]").val(localStorage.getItem("vehinsaddr"));

//$("input[name=succs21]").val(localStorage.getItem("succs21"));
if (localStorage.getItem('succs21') == 'true') { 
    document.getElementById("MainContent_succs21").checked = true;
			} else{
    document.getElementById("MainContent_succs21").checked = false;
			}
//$("input[name=unsuccs21]").val(localStorage.getItem("unsuccs21"));
if (localStorage.getItem('unsuccs21') == 'true') { 
    document.getElementById("MainContent_unsuccs21").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs21").checked = false;
			}
//$("input[name=notapp21]").val(localStorage.getItem("notapp21"));
if (localStorage.getItem('notapp21') == 'true') { 
    document.getElementById("MainContent_notapp21").checked = true;
			} else{
    document.getElementById("MainContent_notapp21").checked = false;
			}

$("input[name=addr22]").val(localStorage.getItem("toolinsaddr"));

//$("input[name=succs22]").val(localStorage.getItem("succs22"));
if (localStorage.getItem('succs22') == 'true') { 
    document.getElementById("MainContent_succs22").checked = true;
			} else{
    document.getElementById("MainContent_succs22").checked = false;
			}
//$("input[name=unsuccs22]").val(localStorage.getItem("unsuccs22"));
if (localStorage.getItem('unsuccs22') == 'true') { 
    document.getElementById("MainContent_unsuccs22").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs22").checked = false;
			}
//$("input[name=notapp22]").val(localStorage.getItem("notapp22"));
if (localStorage.getItem('notapp22') == 'true') { 
    document.getElementById("MainContent_notapp22").checked = true;
			} else{
    document.getElementById("MainContent_notapp22").checked = false;
			}

$("input[name=addr23]").val(localStorage.getItem("mataddr"));

//$("input[name=succs23]").val(localStorage.getItem("succs23"));
if (localStorage.getItem('succs23') == 'true') { 
    document.getElementById("MainContent_succs23").checked = true;
			} else{
    document.getElementById("MainContent_succs23").checked = false;
			}
//$("input[name=unsuccs23]").val(localStorage.getItem("unsuccs23"));
if (localStorage.getItem('unsuccs23') == 'true') { 
    document.getElementById("MainContent_unsuccs23").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs23").checked = false;
			}
//$("input[name=notapp23]").val(localStorage.getItem("notapp23"));
if (localStorage.getItem('notapp23') == 'true') { 
    document.getElementById("MainContent_notapp23").checked = true;
			} else{
    document.getElementById("MainContent_notapp23").checked = false;
			}

$("input[name=addr24]").val(localStorage.getItem("tluseaddr"));

//$("input[name=succs24]").val(localStorage.getItem("succs24"));
if (localStorage.getItem('succs24') == 'true') { 
    document.getElementById("MainContent_succs24").checked = true;
			} else{
    document.getElementById("MainContent_succs24").checked = false;
			}
//$("input[name=unsuccs24]").val(localStorage.getItem("unsuccs24"));
if (localStorage.getItem('unsuccs24') == 'true') { 
    document.getElementById("MainContent_unsuccs24").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs24").checked = false;
			}
//$("input[name=notapp24]").val(localStorage.getItem("notapp24"));
if (localStorage.getItem('notapp24') == 'true') { 
    document.getElementById("MainContent_notapp24").checked = true;
			} else{
    document.getElementById("MainContent_notapp24").checked = false;
			}

$("input[name=addr25]").val(localStorage.getItem("persafeaddr"));

//$("input[name=succs25]").val(localStorage.getItem("succs25"));
if (localStorage.getItem('succs25') == 'true') { 
    document.getElementById("MainContent_succs25").checked = true;
			} else{
    document.getElementById("MainContent_succs25").checked = false;
			}
//$("input[name=unsuccs25]").val(localStorage.getItem("unsuccs25"));
if (localStorage.getItem('unsuccs25') == 'true') { 
    document.getElementById("MainContent_unsuccs25").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs25").checked = false;
			}
//$("input[name=notapp25]").val(localStorage.getItem("notapp25"));
if (localStorage.getItem('notapp25') == 'true') { 
    document.getElementById("MainContent_notapp25").checked = true;
			} else{
    document.getElementById("MainContent_notapp25").checked = false;
			}

$("input[name=addr26]").val(localStorage.getItem("vehsafaddr"));

//$("input[name=succs26]").val(localStorage.getItem("succs26"));
if (localStorage.getItem('succs26') == 'true') { 
    document.getElementById("MainContent_succs26").checked = true;
			} else{
    document.getElementById("MainContent_succs26").checked = false;
			}
//$("input[name=unsuccs26]").val(localStorage.getItem("unsuccs26"));
if (localStorage.getItem('unsuccs26') == 'true') { 
    document.getElementById("MainContent_unsuccs26").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs26").checked = false;
			}
//$("input[name=notapp26]").val(localStorage.getItem("notapp26"));
if (localStorage.getItem('notapp26') == 'true') { 
    document.getElementById("MainContent_notapp26").checked = true;
			} else{
    document.getElementById("MainContent_notapp26").checked = false;
			}

$("textarea[name=comm2]").val(localStorage.getItem("comment2"));

$("input[name=addr27]").val(localStorage.getItem("watrunpraddr"));

//$("input[name=succs27]").val(localStorage.getItem("succs27"));
if (localStorage.getItem('succs27') == 'true') { 
    document.getElementById("MainContent_succs27").checked = true;
			} else{
    document.getElementById("MainContent_succs27").checked = false;
			}
//$("input[name=unsuccs27]").val(localStorage.getItem("unsuccs27"));
if (localStorage.getItem('unsuccs27') == 'true') { 
    document.getElementById("MainContent_unsuccs27").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs27").checked = false;
			}
//$("input[name=notapp27]").val(localStorage.getItem("notapp27"));
if (localStorage.getItem('notapp27') == 'true') { 
    document.getElementById("MainContent_notapp27").checked = true;
			} else{
    document.getElementById("MainContent_notapp27").checked = false;
			}

$("input[name=addr28]").val(localStorage.getItem("envperaddr"));

//$("input[name=succs28]").val(localStorage.getItem("succs28"));
if (localStorage.getItem('succs28') == 'true') { 
    document.getElementById("MainContent_succs28").checked = true;
			} else{
    document.getElementById("MainContent_succs28").checked = false;
			}
//$("input[name=unsuccs28]").val(localStorage.getItem("unsuccs28"));
if (localStorage.getItem('unsuccs28') == 'true') { 
    document.getElementById("MainContent_unsuccs28").checked = true;
			} else{
    document.getElementById("MainContent_unsuccs28").checked = false;
			}
//$("input[name=notapp28]").val(localStorage.getItem("notapp28"));
if (localStorage.getItem('notapp28') == 'true') { 
    document.getElementById("MainContent_notapp28").checked = true;
			} else{
    document.getElementById("MainContent_notapp28").checked = false;
			}
$("textarea[name=train1]").val(localStorage.getItem("trnneed"));
$("textarea[name=train2]").val(localStorage.getItem("trprov"));
$("textarea[name=evalnot1]").val(localStorage.getItem("evalnot100"));
//$("input[name=succsTime1]").val(localStorage.getItem("succsTime1"));
if (localStorage.getItem('succsTime1') == 'true') { 
    document.getElementById("MainContent_succsTime1").checked = true;
			} else{
    document.getElementById("MainContent_succsTime1").checked = false;
			}
//$("input[name=succsGenSafe1]").val(localStorage.getItem("succsGenSafe1"));
if (localStorage.getItem('succsGenSafe1') == 'true') { 
    document.getElementById("MainContent_succsGenSafe1").checked = true;
			} else{
    document.getElementById("MainContent_succsGenSafe1").checked = false;
			}
//$("input[name=succsTime2]").val(localStorage.getItem("succsTime2"));
if (localStorage.getItem('succsTime2') == 'true') { 
    document.getElementById("MainContent_succsTime2").checked = true;
			} else{
    document.getElementById("MainContent_succsTime2").checked = false;
			}
//$("input[name=succsGenSafe2]").val(localStorage.getItem("succsGenSafe2"));
if (localStorage.getItem('succsGenSafe2') == 'true') { 
    document.getElementById("MainContent_succsGenSafe2").checked = true;
			} else{
    document.getElementById("MainContent_succsGenSafe2").checked = false;
			}
//$("input[name=succsTime3]").val(localStorage.getItem("succsTime3"));
if (localStorage.getItem('succsTime3') == 'true') { 
    document.getElementById("MainContent_succsTime3").checked = true;
			} else{
    document.getElementById("MainContent_succsTime3").checked = false;
			}
//$("input[name=succsGenSafe3]").val(localStorage.getItem("succsGenSafe3"));
if (localStorage.getItem('succsGenSafe3') == 'true') { 
    document.getElementById("MainContent_succsGenSafe3").checked = true;
			} else{
    document.getElementById("MainContent_succsGenSafe3").checked = false;
			}
});