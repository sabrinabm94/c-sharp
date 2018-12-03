$(".register-account").submit(function (event) {
    event.preventDefault();

    var id = $('#id').val();
    var type = $('#type').val();
    var userId = $('#userId').val();

    if (type != '', userId != '') {
        var account = {
            id: id,
            type: type,
            userId: userId
        }

        $.ajax({
            url: 'http://localhost:54681/api/account/register',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                if (data != null) {
                    alert("Sucess!");

                    $('#type').val("");
                    $('#userId').val("");
                } else {
                    alert("Already registred!");
                }
            },
            error: function (error) {
                console.log(error);
                alert("Error: " + error);
            },
            data: JSON.stringify(account),
        });
    } else {
        alert("Fill all the fields!");
    }
});