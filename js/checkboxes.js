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
//clear checkboxes if button is clicked
$('.clear').click(
function(){ 	$(this).parents("#crewinfomain,#evalinfomain,#workmanshipmain,#timemgmtmain,#gensafetymain,#envmain,#trainingmain,#evalsummain,#sleeveInfoSL").find('input:checkbox').removeAttr('checked');
});