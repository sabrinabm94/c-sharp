$.ajax({
    url: "https://localhost:44323/api/user/list/" + Cookies.get('userid'),
    context: document.body,
    success: function (results) {
        $('#id').text(results.id);
        $('#name').text(results.name);
        $('#username').text(results.username);
        $('#email').text(results.email);
        $('#phone').text(results.phone);
        $('#address').text(results.address);
        $('#accountId').text(results.accountId);

        $.ajax({
            url: "https://localhost:44323/api/account/list/" + results.accountId,
            context: document.body,
            success: function (results) {
                $('#account-id').text(results.id);
                $('#type').text(results.type);
                $('#balance').text(results.balance);
            },
            statusCode: {
                404: function () {
                    alert('Account: Api off');
                },

                400: function () {
                    alert('Invalid data, try again');
                }
            }
        });
    },
    statusCode: {
        404: function () {
            alert('User: Api off');
        },

        400: function () {
            alert('Invalid data, try again');
        }
    }
});