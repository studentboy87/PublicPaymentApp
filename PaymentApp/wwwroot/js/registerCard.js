﻿$(document).ready(function () {

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


    function updateCardExpiryDate(cardExDate, exMonth, exYear) {
        $(exMonth).bind('keypress keyup blur click', function () {
            var month = $(exMonth).val();
            var year = $(exYear).val();
            var date = new Date(year, month, 0).getDate();

            if (date < 10) {
                date = '0' + dt;
            }
            var displayDate = year + month + date;
            $(cardExDate).val(displayDate);
        });
    }


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

    $('#ExpiryMonth').change(updateCardExpiryDate($('#CardExpiryDate'), $('#ExpiryMonth'), $('#ExpiryYear')));
    $('#ExpiryYear').change(updateCardExpiryDate($('#CardExpiryDate'), $('#ExpiryMonth'), $('#ExpiryYear')));


});

