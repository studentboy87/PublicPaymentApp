//import { Date } from "core-js";

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


    function updateCardExpiryDate(cardExDate, modalExDate, exMonth, exYear) {
        $(exMonth).bind('keypress keyup blur click', function () {
            var month = $(exMonth).val();
            var year = $(exYear).val();
            var date = new Date(year, month, 0).getDate();
            var validationDate = new Date(year, month, 0);
            if (date < 10) {
                date = '0' + dt;
            }
            var displayDate = year + month + date;
            $(cardExDate).val(displayDate);
            $(modalExDate).val(month + "/" + year);

            var currentDate = new Date();
            var currentMonth = currentDate.getMonth()+1;
            var currentYear = currentDate.getFullYear();
            var endOfCurrentMonth = new Date(currentYear, currentMonth, 0);
            if (validationDate < endOfCurrentMonth) {
                //display span
                $('#expiredCardAlert').show();
            } else {
            //hide span
                $('#expiredCardAlert').hide();
            }

        });
    }


    /*
    var today, someday;
    var exMonth = document.getElementById("exMonth");
    var exYear = document.getElementById("exYear");
    today = new Date();
    someday = new Date();
    someday.setFullYear(exYear, exMonth, 1);

    if (someday < today) {
        alert("The expiry date is before today's date. Please select a valid expiry date");
        return false;
    }
    */

    $('#CardNumberString').change(lastFourDigits($('#CardNumberString'), $('#modalCardNum')));

    $(".holderName").change(function () {
        $('#modalCardOwnerName').val($(this).val());
    });
    $('.address1').change(function () {
        $('#modalAddress1').val($(this).val());
    });
    $('.address2').change(function () {
        $('#modalAddress2').val($(this).val());
    });
    $('.addressTowm').change(function () {
        $('#modalAddressTown').val($(this).val());
    });
    $('.addressCounty').change(function () {
        $('#modalAddressCounty').val($(this).val());
    });
    $('.addressPostCode').change(function () {
        $('#modalAddressPostCode').val($(this).val());
    });
    $('#CardExpiryDate').change(function () {
        $('#modalCardExpiryDate').val($(this).val());
    });

    $('#ExpiryMonth').change(updateCardExpiryDate($('#CardExpiryDate'), $('#modalCardExpiryDate'), $('#ExpiryMonth'), $('#ExpiryYear')));
    $('#ExpiryYear').change(updateCardExpiryDate($('#CardExpiryDate'),  $('#modalCardExpiryDate'),$('#ExpiryMonth'), $('#ExpiryYear')));


});

