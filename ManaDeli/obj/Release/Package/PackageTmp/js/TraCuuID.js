
//Load Data in Table when documents is ready
$(document).ready(function () {
    //loadData();
});

//Load Data function
function loadData(mavandon) {
    $.ajax({
        url: "/Search/GetbyID/" + mavandon,
        type: "GET",
        delay: 1,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.mavandon + '</td>';
                html += '<td>' + item.cannang + '</td>';
                html += '<td>' + item.dichvu + '</td>';
                html += '<td>' + item.trangthai + '</td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Function for getting the Data Based upon Employee ID

function getbyID() {
    var myobj = JSON.parse(JSON.stringify(mavandon));
    $.ajax({
        url: "/Search/GetbyID/" + myobj,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.mavandon + '</td>';
                html += '<td>' + item.cannang + '</td>';
                html += '<td>' + item.dichvu + '</td>';
                html += '<td>' + item.trangthai + '</td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}