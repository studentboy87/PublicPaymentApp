$(document).ready(function () {

    $("#registerCard").on("blur", "input", () => {
        if ($("#registerCard").valid()) {
            $("#btnSubmit").removeAttr("disabled");
        } else {
            $("#btnSubmit").attr("disabled", "disabled");
        }
    });

    function lastFourDigits(cardNum, cardNumModal) {
        $(cardNum).bind('keypress keyup blur', function () {
            var fullCardNum = $(cardNum).val();
            var trimmedCardNum = fullCardNum.slice(12, 16);
            var ast = "****-****-****-";
            $(cardNumModal).val(ast + trimmedCardNum);
        });

    }

    $('#CardNumberString').change(lastFourDigits($('#CardNumberString'), $('#modalCardNum')));

    $(".holderName").change(function () {
        $('#modalCardOwnerName').val($(this).val());
    });

});

