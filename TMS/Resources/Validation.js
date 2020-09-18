function validationCheck() {
    var summary = "";
    summary += isvalidFirstname();
    summary += isvalidLastname();
    summary += isvalidEmail();
    summary += isvalidMobileno();
    if (summary != "") {
        alert(summary);
        return false;
    }
    else {
        return true;
    }
}
function isvalidFirstname() {
    var id;
    var temp = document.getElementById("<%=txtFirstName.ClientID %>");
    id = temp.value;
    if (id == "") {
        return ("Please enter First Name" + "\n");
    }
    else {
        return "";
    }
}
function isvalidLastname() {
    var id;
    var temp = document.getElementById("<%=txtLastName.ClientID %>");
    id = temp.value;
    if (id == "") {
        return ("Please enter Last Name" + "\n");
    }
    else {
        return "";
    }
}
function isvalidEmail() {
    var id;
    var temp = document.getElementById("<%=txtEmailID.ClientID %>");
    id = temp.value;
    var re = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
    if (id == "") {
        return ("Please Enter Email" + "\n");
    }
    else if (re.test(id)) {
        return "";
    }

    else {
        return ("Email should be in the form abc@xyz.com" + "\n");
    }
}
function isvalidMobileno() {
    var id;
    var temp = document.getElementById("<%=txtMobile.ClientID %>");
    id = temp.value;
    var re;
    re = /^[0-9]+$/;
    var digits = /\d(10)/;
    if (id == "") {
        return ("Please Enter Mobile no" + "\n");
    }
    else if (re.test(id)) {
        return "";
    }

    else {
        return ("Phone no should be digits only" + "\n");
    }
}