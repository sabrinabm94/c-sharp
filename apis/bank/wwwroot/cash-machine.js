$('#target').hide();
var userid = Cookies.get('userid');
var accountid;

$.ajax({
    url: "http://localhost:54681/api/user/list/" + userid,
    context: document.body,
    success: function (results) {
        accountid = results.accountId;
    },
    statusCode: {
        404: function () {
            alert('Api off');
        },

        400: function () {
            alert('Invalid data, try again');
        }
    }
});


$("#transfer").change(function () {
    if ($('#transfer').is(':checked')) {
        $('#target').show();
    } else {
        $('#target').hide();
    }
});

$(".cashmachine").submit(function (event) {
    event.preventDefault();
    var target = $('#target').val();
    var value = $('#value').val();
    var action = '';

    if ($('#deposit').is(':checked')) {
        action = 'deposit';
    } else if ($('#transfer').is(':checked')) {
        action = 'transfer';
    } else if ($('#withdraw').is(':checked')) {
        action = 'withdraw';
    }

    if (accountid != '' && value != '' && action != '') {
        if (action == 'transfer' && target != '') {
            $.ajax({
                url: "http://localhost:54681/api/cashmachine/" + action + "/accountId=" + accountid + "&accountTarget=" + target + "&value=" + value,
                context: document.body,
                success: function (results) {
                    $('.results #balance-value').text("");
                    $('.results #balance-value').text(results);
                },
                statusCode: {
                    404: function () {
                        alert('Api off');
                    },

                    400: function () {
                        alert('Invalid data, try again');
                    }
                }
            });
        } else if (action == 'transfer' && target == '') {
            alert('Fill the target field');
        } else {
            $.ajax({
                url: "http://localhost:54681/api/cashmachine/" + action + "/accountId=" + accountid + "&value=" + value,
                context: document.body,
                success: function (results) {
                    $('.results #balance-value').text("");
                    $('.results #balance-value').text(results);

                    if (action == 'withdraw') {
                        $.ajax({
                            url: "http://localhost:54681/api/cashmachine/moneybills",
                            context: document.body,
                            success: function (results) {
                                $('.money-bills .list').html("");

                                $.each(results, function (i, result) {
                                    $('.money-bills .list').append("<li class='list-item'>Value: " + result.value + ", Quantity: " + result.quantity + "</li>");
                                });
                            }
                        });
                    }
                },
                statusCode: {
                    404: function () {
                        alert('Api off');
                    },

                    400: function () {
                        alert('Invalid data, try again');
                    }
                }
            });
        }
    } else {
        alert('Fill the target field and checkboxs');
    }
});