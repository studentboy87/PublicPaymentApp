$(document).ready(function () {
    //$('#registerCard').data("validator").settings.submitHandler = function (form) {
    //    $('#btnSubmit').attr("disabled", true).val("Working");
    //    form.submit();
    //};
    //$('form').submit(function () {
    //    if ($(this).valid()) {
    //        $('btnSubmit').attr("disabled", true).val();
    //    }
    //});


//var validation= function validateFrom() {  $('#registerCard').validate({
//        rules: {
//            CardNumberString: {},
//            CardOwnersName: {},
//            CardAddress.AddressLine1{},


//        }
//})}

    //var $form = $("#registerCard");
    //var $submitbutton = $("#btnSubmit");

    $("#registerCard").on("blur", "input", () => {
        if ($("#registerCard").valid()) {
            $("#btnSubmit").removeAttr("disabled");
            console.log("here");
        } else {
            $$("#btnSubmit").attr("disabled", "disabled");
        }
    });

});

