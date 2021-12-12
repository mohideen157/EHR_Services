var uri = 'http://localhost:1484/api/Values';
let todos = null;
function LoginSubmitEvent() {
    if (($("#txtUsername").val() === "") && ($("#txtPassword").val() === "")) {
        $.ajax({
            type: 'GET',
            url: uri,
            crossDomain: true,
            success: function (result) {
                var res = JSON.parse(result);
                //alert("Username : " + res.Username + " Password : " + res.Password);
                alert("User already exists first if ");
            },
            error: function () {
                alert(Error);
            }
        });
    }
    else if (($("#txtUsername").val() !== "") && ($("#txtPassword").val() === "")) {
        $.ajax({
            type: 'GET',
            url: uri + "/" + $("#txtUsername").val(),
            crossDomain: true,
            success: function (result) {
                var res = JSON.parse(result);
                //alert("Username : " + res.Username + " Password : " + res.Password);
                alert("User already exists second if");
            },
            error: function () {
                alert(Error);
            }
        });
    }
    else {
        const item = {
            'username': $("#txtUsername").val(),
            'password': $("#txtPassword").val(),
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
                //alert("Username : " + res.Username + " Password : " + res.Password);
                alert("User already exists Last else");
            }
        });

    }
}
