/*
    For Password Rating
    https://github.com/jzaefferer/jquery-validation.password
*/
var LOWER = /[a-z]/,
    UPPER = /[A-Z]/,
    DIGIT = /[0-9]/,
    DIGITS = /[0-9].*[0-9]/,
    SPECIAL = /[^a-zA-Z0-9]/,
    SAME = /^(.)\1+$/;

function rating(rate, message) {
    return {
        rate: rate,
        messageKey: message
    };
}

function uncapitalize(str) {
    return str.substring(0, 1).toLowerCase() + str.substring(1);
}


//$.validator.passwordRating = function (password) {
//    if (!password || password.length < 8)
//        return rating(0, "too-short");
//    if (SAME.test(password))
//        return rating(1, "very-weak");

//    var lower = LOWER.test(password),
//        upper = UPPER.test(uncapitalize(password)),
//        digit = DIGIT.test(password),
//        digits = DIGITS.test(password),
//        special = SPECIAL.test(password);

//    if (lower && upper && digit || lower && digits || upper && digits || special)
//        return rating(4, "strong");
//    if (lower && digit || upper && digit)
//        return rating(3, "good");
//    return rating(2, "weak");
//}

//$.validator.passwordRating.messages = {
//    "similar-to-username": "Error: Password is too similar to username",
//    "too-short": "Error: Password is too short",
//    "very-weak": "Error: Password is very weak",
//    "weak": "Error: Password is weak",
//    "good": "Yay! Good password",
//    "strong": "Yay! Strong password"
//}


$.validator.addMethod("customemail",
    function (value, element) {
        return /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/.test(value);
    },
    "Please provide valid Email"
);
$.validator.addMethod("emailormobile",
    function (value, element) {
        if (/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/.test(value) || (value.length == 10 && !isNaN(value))) {
            return true;
        }
        return false;
    },
    "Please provide valid Email/Mobile"
);

$.validator.addMethod("mobile",
    function (value, element) {
        if (/^([0|+[0-9]{1,5})?([7-9][0-9]{9})$/.test(value) || (value.length == 10 && !isNaN(value))) {
            return true;
        }
        return false;
    },
    "Please provide valid Mobile"
);

$.validator.addMethod("tendigits", function (value, element) {
    if (value.length == 10 && !isNaN(value))
        return true;
    return false;
}, "10 Digits");   // error message

$.validator.addMethod("lessthanequalto100", function (value, element) {
    if (value == "")
        return true;
    var nValue = parseInt(value);
    if (nValue > 0 && nValue <= 100)
        return true;
    return false;
}, "Between 1-100");   // error message

$.validator.addMethod("zipcode", function (value, element) {
    var CheckZipCode = /^((?!(0))[0-9]{6})$/;
    if (CheckZipCode.test(value)) {
        return true;
    } else {
        return false;
    }


}, "Invalid zipcode");   // error message



$.validator.addMethod("greaterThanZero", function (value, element) {
    if (value == "")
        return true;
    var nValue = parseInt(value);
    if (nValue > 0)
        return true;
    return false;
}, "Has to be > 0");   // error message


$.validator.addMethod("greaterThanEqualToZero", function (value, element) {
    if (value == "")
        return true;
    var nValue = parseInt(value);
    if (nValue >= 0)
        return true;
    return false;
}, "Has to be > 0");   // error message

$.validator.addMethod("validPositiveNegativeInteger", function (value, element) {
    if (value == "")
        return true;
    var nValue = parseInt(value);
    if (nValue >= 0 || nValue <= 0)
        return true;
    return false;
}, "Has to be valid number (< 0) OR (= 0) OR (> 0) ");   // error message

$.validator.addMethod("dcfInput", function (value, element) {
    if (value == "")
        return false;
    var count = (value.match(/\./g) || []).length;
    if (count <= 1)
        return true;
    return false;
}, "Has to be valid number");   // error message


$.validator.addMethod("alreadyexists", function (value, element) {

    if ($(element).data("alreadyexists") === null) {
        return true;
    } else {
        if (value == $(element).data("alreadyexists")) {
            return false;
        } else {
            return true;
        }
    }
}, "Already exists");   // error message

$.validator.addMethod("expectedDate", function (value, element) {
    var curDate = new Date();
    var today = new Date();
    var numberOfDaysToAdd = 34;
    curDate.setDate(curDate.getDate() + numberOfDaysToAdd);
    var inputDate = ApplicationJS.ParseDate(value);
    if (inputDate < curDate && inputDate >= today)
        return true;
    return false;
}, "Expected date of arrival should be within 34 days from today");   // error message

$.validator.addMethod("arrivalStartDate", function (value, element) {
    var processingTime = $('select[id$=drpDeliverySpeed]').val();
    var numberOfDaysToAdd = 0;
    var curDate = new Date();
    var today = new Date();
    if (processingTime == '1') {
        numberOfDaysToAdd = 1;
        curDate.setDate(curDate.getDate() + numberOfDaysToAdd);
        var inputDate = ApplicationJS.ParseDate(value);
        if (inputDate < curDate) {
            $.validator.messages.arrivalStartDate = "Expected date of arrival needs to be at least one day away from today";  // error message
            return false;
        }
    }
    else {
        numberOfDaysToAdd = 3;
        curDate.setDate(curDate.getDate() + numberOfDaysToAdd);
        var inputDate = ApplicationJS.ParseDate(value);
        if (inputDate < curDate) {
            $.validator.messages.arrivalStartDate = "Expected date of arrival needs to be at least three day away from today";  // error message
            return false;
        }
    }
    return true;
}, "");

$.validator.addMethod("departureDate", function (value, element) {
    var arrivalDate = ApplicationJS.ParseDate($('input[id$=txtExpectedArrivalDate]').val());
    var arrivalDate2 = ApplicationJS.ParseDate($('input[id$=txtExpectedArrivalDate]').val());
    var numberOfDaysToAdd = 30;
    arrivalDate.setDate(arrivalDate.getDate() + numberOfDaysToAdd);
    var inputDate = ApplicationJS.ParseDate(value);
    if (inputDate <= arrivalDate && inputDate > arrivalDate2)
        return true;
    return false;
}, "Expected date of departure should be within 30 days from Date of Arrival");   // error message


$.validator.addMethod("passportExpiry", function (value, element) {
    var issueDate = ApplicationJS.ParseDate($('input[id$=txtDateOfIssue]').val());
    var numberOfMonthsToAdd = 4;
    issueDate.setMonth(issueDate.getMonth() + numberOfMonthsToAdd);
    var inputDate = ApplicationJS.ParseDate(value);
    if (inputDate >= issueDate)
        return true;
    return false;
}, "Your passport should be valid for atleast 6 months after your expected date of arrival in India");   // error message


$.validator.addMethod("afterDoB", function (value, element) {
    var dob = ApplicationJS.ParseDate($('input[id$=txtDoB]').val());
    var numberOfMonthsToAdd = 0;
    dob.setMonth(dob.getMonth() + numberOfMonthsToAdd);
    var inputDate = ApplicationJS.ParseDate(value);
    if (inputDate > dob)
        return true;
    return false;
}, "It should be greater than your Date of Birth");   // error message


$.validator.addMethod("passportEmbassyExpiry", function (value, element) {
    var issueDate = ApplicationJS.ParseDate($('input[id$=txtPassportDateOfIssue]').val());
    var numberOfMonthsToAdd = 4;
    issueDate.setMonth(issueDate.getMonth() + numberOfMonthsToAdd);
    var inputDate = ApplicationJS.ParseDate(value);
    if (inputDate >= issueDate)
        return true;
    return false;
}, "Your passport should be valid for atleast 6 months after your expected date of arrival in India");   // error message



$.validator.addMethod("passportCardExpiry", function (value, element) {
    var issueDate = ApplicationJS.ParseDate($('input[id$=txtPassportCardDateOfIssue]').val());
    var numberOfMonthsToAdd = 0;
    issueDate.setMonth(issueDate.getMonth() + numberOfMonthsToAdd);
    var inputDate = ApplicationJS.ParseDate(value);
    if (inputDate >= issueDate)
        return true;
    return false;
}, "It should be after Date of Issue");   // error message


$.validator.addMethod("maxDate", function (value, element) {
    var curDate = new Date();
    var inputDate = ApplicationJS.ParseDate(value);
    if (inputDate < curDate)
        return true;
    return false;
}, "It should be before today's date");   // error message

$.validator.addMethod("lessThanToday", function (value, element) {
    var curDate = new Date();
    var inputDate = ApplicationJS.ParseDate(value);
    if (inputDate < curDate)
        return true;
    return false;
}, "It needs to be a date in the past");   // error message

$.validator.addMethod("lessThanTodayEmptyAllowed", function (value, element) {
    var curDate = new Date();
    var inputDate = ApplicationJS.ParseDate(value);
    if (value == "")
        return true;
    if (inputDate < curDate)
        return true;
    return false;
}, "It needs to be a date in the past");   // error message

$.validator.addMethod("greaterThanToday", function (value, element) {
    var curDate = new Date();
    var inputDate = ApplicationJS.ParseDate(value);
    if (inputDate > curDate)
        return true;
    return false;
}, "It needs to be a future date");   // error message

$.validator.addMethod("greaterThanTodayEmptyAllowed", function (value, element) {
    var curDate = new Date();
    var inputDate = VibeJS.ParseDate(value);
    if (value == "")
        return true;
    if (inputDate > curDate)
        return true;
    return false;
}, "It needs to be a future date");   // error message

$.validator.addMethod("minLengthEmptyAllowed", function (value, element) {
    if (value == "")
        return true;
    if (value.length >= 10)
        return true;
    return false;
}, "Please enter at least 10 digit number");   // error message


$.validator.addMethod("chkTerms", function (value, element) {
    return ($('input[id$=chkTC]:checked').length > 0);
}, "Please agree to our Terms and Conditions");   // error message

$.validator.addMethod("chkPC", function (value, element) {
    return ($('input[id$=chkPrivacyCheck]:checked').length > 0);
}, "Please confirm that you have read the notice");   // error message

$.validator.addMethod("expirygreaterthantoday", function (value, element) {
    var expiryYear = $('input[id$=txtYear]').val();
    var expiryMonth = $('select[id$=drpMonth]').val();
    var curDate = new Date();
    if (expiryYear > curDate.getFullYear())
        return true;

    else if ((expiryYear == curDate.getFullYear()) && (expiryMonth > curDate.getMonth()))
        return true;
    return false;
}, "It needs to be a future date");   // error message

$.validator.addMethod("checkCVVDigitCount", function (value, element) {
    var cardCVV = $('input[id$=txtCVV2]').val();
    var cardType = $('select[id$=drpCardType]').val();
    if (cardType == '4') {
        if (cardCVV.length == 4)
            return true;
    }
    else if (cardCVV.length == 3)
        return true;
    return false;
}, "Please check number of digits in CVV");   // error message

$.validator.addMethod("passwordStrengthRequired", function (value, element) {
    // use untrimmed value
    var password = element.value;

    var rating = $.validator.passwordRating(password);
    // update message for this field

    var meter = $(".password-meter", element.form);

    meter.find(".password-meter-bar").removeClass().addClass("password-meter-bar").addClass("password-meter-" + rating.messageKey);
    meter.find(".password-meter-message")
        .removeClass()
        .addClass("password-meter-message")
        .addClass("password-meter-message-" + rating.messageKey)
        .text($.validator.passwordRating.messages[rating.messageKey]);
    // display process bar instead of error message
    return rating.rate > 2;
}, "&nbsp;");

$.validator.addMethod("validDoB", function (value, element) {
    var dateLimit = new Date();
    dateLimit.setFullYear(dateLimit.getFullYear() - 18);
    var inputDate = VibeJS.ParseDate(value);
    if (inputDate < dateLimit)
        return true;
    return false;
}, "Age < 18? Please refer to T&C");   // error message

$.validator.addMethod("validDate", function (value, element) {
    var inputDate = VibeJS.ParseDate(value);
    if (inputDate instanceof Date)
        return true;
    return false;
}, "Please enter valid date");   // error message

$.validator.addMethod("otp", function (value, element) {
    if (value.length == 6)
        return true;
    return false;
}, "Please enter valid 6-digit OTP");   // error message

$.validator.addMethod("url", function (value, element) {
    if (value.length > 3)
        return true;
    return false;
}, "Please enter valid URL");   // error message

/*$.validator.addMethod("tinymce", function (value, element) {
    tinyMCE.get(element.id).save();
    alert($(element).text());
});*/

var ValidateRules = {

    /* TMS */
    SignUp: function() {
        $('input[id$=txtPUBGUsername]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
    },
    /* TMS */

    Registration: function () {
        $('input[id$=txtFirstName]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtLastName]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtDateOfBirth]').tryrules('add', {
            required: true,
            validDate: true,
            validDoB: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtEmailAddress]').tryrules('add', {
            required: true,
            email: true,
            alreadyexists: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required",
                email: "<i class='fa fa-warning'></i> Invalid"
            }
        });
        $('input[id$=txtMobileNumber]').tryrules('add', {
            required: true,
            tendigits: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtPassword]').tryrules('add', {
            required: true,
            passwordStrengthRequired: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtConfirmPassword]').tryrules('add', {
            required: true,
            equalTo: $('input[id$=txtPassword]'),
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('select[id$=drpGender]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
    },

    OTPVerifications: function () {
        $('input[id$=txtEmailOTP]').tryrules('add', {
            required: true,
            otp: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtMobileOTP]').tryrules('add', {
            required: true,
            otp: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
    },

    SetPreferences: function () {
        $('input[id$=txtMinAskingValue]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtMaxAskingValue]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtMinBusinessRevenue]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtMaxBusinessRevenue]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
    },

    UpdateProfile: function () {
        $('input[id$=txtFirstName]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtLastName]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtDateOfBirth]').tryrules('add', {
            required: true,
            validDate: true,
            validDoB: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtMinInvestmentRange]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Should be >0"
            }
        });
        $('input[id$=txtMaxInvestmentRange]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Should be >0"
            }
        });
        $('input[id$=txtEmailAddress]').tryrules('add', {
            required: true,
            email: true,
            alreadyexists: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required",
                email: "<i class='fa fa-warning'></i> Invalid"
            }
        });
        $('input[id$=txtMobileNumber]').tryrules('add', {
            required: true,
            tendigits: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('select[id$=drpGender]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
    },

    Login: function () {
        $('input[id$=txtUserId]').tryrules('add', {
            required: true,
            emailormobile: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required",
                emailormobile: "<i class='fa fa-warning'></i> Invalid Email or Mobile"
            }
        });
        $('input[id$=txtLoginPassword]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
    },

    NoDealFound: function () {
        $('input[id$=txtEmailAddress]').tryrules('add', {
            required: true,
            email: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
    },

    EmptySearch: function () {
        $('input[id$=txtEmailAddress]').tryrules('add', {
            required: true,
            email: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
    },

    ContactUs: function () {

        $('input[id$=txtMessage]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtSubject]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtEmail]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtName]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
    },

    BusinessRegistration: function () {
        $('input[id$=txtBusinessName]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtEmailAddress]').tryrules('add', {
            required: true,
            email: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtContactNumber]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtProfit]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Should be >0"
            }
        });
        $('input[id$=txtRevenue]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Should be >0"
            }
        });
        $('select[id$=drpYearOfSetup]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('select[id$=drpNumberOfEmployee]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('select[id$=drpBusinessCategory]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });

        $('select[id$=drpBusinessSubCategory]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('textarea[id$=txtPresentationDescription]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtStreetAddress]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('select[id$=drpBusinessState]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('select[id$=drpBusinessCity]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtZipCode]').tryrules('add', {
            required: true,
            zipcode: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });


        $('select[id$=drpBusinessType]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });

    },

    PostDealGoals: function () {
        /*$('select[id$=drpGoals]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });*/
    },
    
    PostDeal: function () {
        $('input[id$=txtPresentationTitle]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('textarea[id$=txtPresentationDescription]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('select[id$=drpBusinessCategory]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });

        $('select[id$=drpBusinessSubCategory]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtGrossRevenue]').tryrules('add', {
            greaterThanEqualToZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtMinimumValue]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtDebtFundingAmount]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtAskingValuation]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtMaximumValue]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtFranchiseAreaRequired]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtFranchiseNumberOfOutlets]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtFranchiseFee]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtNPA_ReservePrice]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtNPA_EMD]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtNetProfit]').tryrules('add', {
            validPositiveNegativeInteger: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtEBITDA]').tryrules('add', {
            validPositiveNegativeInteger: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtCashFlow]').tryrules('add', {
            validPositiveNegativeInteger: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtWorkingCapital]').tryrules('add', {
            validPositiveNegativeInteger: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });

        $('input[id$=txtCarriedForwardLosses]').tryrules('add', {
            greaterThanEqualToZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtEBITDA]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtEBITDA]').tryrules('add', {
            greaterThanZero: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });


        $('input[id$=txtRateOfInterest]').tryrules('add', {
            lessthanequalto100: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtDebtEquityRatio]').tryrules('add', {
            lessthanequalto100: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtEquityDilution]').tryrules('add', {
            lessthanequalto100: true,
            messages: {
                lessthanequalto100: "<i class='fa fa-warning'></i> Between 1-100"
            }
        });
        $('input[id$=txtNPA_AuctionDate]').tryrules('add', {
            greaterThanTodayEmptyAllowed: true,
            messages: {
                greaterThanTodayEmptyAllowed: "<i class='fa fa-warning'></i> > Today"
            }
        });
        $('input[id$=Panel_NPA_EMDLastDate]').tryrules('add', {
            greaterThanTodayEmptyAllowed: true,
            messages: {
                greaterThanTodayEmptyAllowed: "<i class='fa fa-warning'></i> > Today"
            }
        });
        $("[data-validation=date-today]").each(function () {
            $(this).tryrules('add', {
                greaterThanTodayEmptyAllowed: true,
                messages: {
                    greaterThanTodayEmptyAllowed: "<i class='fa fa-warning'></i> > Today"
                }
            });
        });
    },
    
    ChangePassword: function () {
        $('input[id$=txtOldPassword]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required",
                email: "<i class='fa fa-warning'></i> Invalid"
            }
        });
        $('input[id$=txtNewPassword]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtNewPasswordAgain]').tryrules('add', {
            required: true,
            equalTo: $('input[id$=txtNewPassword]'),
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });

    },

    ResetPassword: function () {
        $('input[id$=txtResetPassword]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('input[id$=txtConfirmPassword]').tryrules('add', {
            required: true,
            equalTo: $('input[id$=txtResetPassword]'),
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });

    },

    ForgotPassword: function () {
        $('input[id$=txtEmailId]').tryrules('add', {
            required: true,
            email: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required",
                email: "<i class='fa fa-warning'></i> Invalid"
            }
        });
    },

    ExpressInterest: function () {
        $('textarea[id$=txtInterestPich]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
    },

    ProductAndService: function () {
        $('input[id$=txtProductServiceTitle]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('textarea[id$=txtProductSeviceDescription]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('select[id$=drpEntityInfo]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });

    },

    DealStatusUpdate: function () {
        $('textarea[id$=txtActivityNote]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('select[id$=drpActivityTypes]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });

    },

    DealFollowupUpdate: function () {
        $('textarea[id$=txtActivityNote]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });
        $('select[id$=drpActivityTypes]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });

    },

    DocumentManager: function () {
        $('input[id$=txtDocumentTitle]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required",
            }
        });
        $('input[id$=fileDocument]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required"
            }
        });

    },

    InstanceDocumentAddValidation: function (lnkTrigger) {
        $(lnkTrigger).closest(".row").find('input[id$=txtInstanceDocumentTitle]').tryrules('add', {
            required: true,
            messages: {
                required: "<i class='fa fa-warning'></i> Required",
            }
        });
    },

    InstanceDocumentRemoveValidation: function () {
        if ($('input[id$=txtInstanceDocumentTitle]').length > 0) {
            $('input[id$=txtInstanceDocumentTitle]').each(function () {
                $(this).rules('remove');
                $(this).data('TryRules', null);
            });

        }
    },

    DCF: function () {
        $('input.txtdcfvalues').each(function () {
            $(this).tryrules('add', {
                dcfInput: true,
                messages: {
                    dcfInput: "<i class='fa fa-warning'></i>"
                }
            });
        });
    },

    AddBusinessCorporateEquity: function () {
        $('input.corp-equity').each(function () {
            $(this).tryrules('add', {
                lessthanequalto100: true
            });
        });
    }
}

