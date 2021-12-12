var uri = 'http://localhost:1484/api/Register';

function RegisterSubmitEvent() {
    if ($("#txtUsername").val() === "") {
        alert("Enter Username");
        return false;
    }
    else if ($("#txtPassword").val() === "") {
        alert("Enter Password");
        return false;
    }
    else if ($("#txtName").val() === "") {
        alert("Enter Name");
        return false;
    }
    else if ($("#txtMobileNo").val() === "") {
        alert("Enter MobileNo");
        return false;

    }
    else if ($("#txtEmailId").val() === "") {
        alert("Enter EmailId");
        return false;
    }
    else {
        const item = {
            'username': $("#txtUsername").val(),
            'password': $("#txtPassword").val(),
            'name': $("#txtName").val(),
            'mobileno': $("#txtMobileNo").val(),
            'emailid': $("#txtEmailId").val(),
            dd: { "type": 0 }
        };

        $.ajax({
            type: 'POST',
            accepts: 'application/json',
            url: uri,
            crossDomain: true,
            contentType: 'application/json',
            data: JSON.stringify(item),
            error: function (jqXHR, textStatus, errorThrown) {
                alert('here');
            },
            success: function (result) {
                var res = JSON.parse(result);
                alert("Inserted SuccessFully, Details are Username : " + res.Username + " Password : " + res.Password + " Name : " + res.Name + " MobileNo : " + res.MobileNo + " EmailId : " + res.EmailId);
            }
        });

    }
}