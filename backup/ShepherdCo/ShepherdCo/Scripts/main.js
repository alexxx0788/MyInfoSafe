$(document).ready(function() {
    LoadBalance();
    LoadStocks();
    setInterval(function () { LoadStocks(); }, 5000);
});


function LoadBalance() {
    $.get("api/balance", function (data) {
        $(".balance").html(data);
    });
}

function LoadStocks() {
    $.get("api/stock", function (data) {
        $('#tableBody').empty();
        $(data).each(function (index, element) {
            $('#tableBody').append(GenerateTableRow(element));
        });
    });
}

function GenerateTableRow(element) {
    return '<tr><td>' + element.Company + '</td><td>' + element.Price + '</td><td><span class="' + GetChangeClassName(element.Change) + '">' + element.Change + '</span></td><td><span class="' + GetChangeClassName(element.ChangePersentage) + '">' + element.ChangePersentage + '</span></td><td>'+GenerateBuyButton(element.StockId)+'</td></tr>';
}

function GetChangeClassName(value) {
    return value > 0 ? 'green' : 'red';
}

function GenerateBuyButton(id) {
    return '<button href="/Home/Order/' + id + '" class="modal-link btn btn-success">Buy</button>';
}

function UpdateBalance(successFunc, login, balance, userId) {
    var user = {
        UserId: userId,
        Login: login,
        Balance: balance
    };

    var json = JSON.stringify(user);
    $.ajax({
        url: '/api/balance/'+userId,
        type: 'PUT',
        contentType: "application/json; charset=utf-8",
        data: json,
        success: function (result) {
            LoadBalance();
            successFunc;
        }
    });
}


$(function() {
    // Initialize numeric spinner input boxes
    //$(".numeric-spinner").spinedit();

    // Initalize modal dialog
    // attach modal-container bootstrap attributes to links with .modal-link class.
    // when a link is clicked with these attributes, bootstrap will display the href content in a modal dialog.
    $('body').on('click', '.modal-link', function(e) {
        e.preventDefault();
        $(this).attr('data-target', '#modal-container');
        $(this).attr('data-toggle', 'modal');
    });

    // Attach listener to .modal-close-btn's so that when the button is pressed the modal dialog disappears
    $('body').on('click', '.modal-close-btn', function() {
        $('#modal-container').modal('hide');
    });

    //clear modal cache, so that new content can be loaded
    $('#modal-container').on('hidden.bs.modal', function() {
        $(this).removeData('bs.modal');
    });

    $('#CancelModal').on('click', function() {
        return false;
    });
});