
//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();
});

//Load Data function
function loadData() {
    $.ajax({
        url: "/Shipper/GetbyID",
        type: "GET",
        delay: 1,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.mavandon + '</td>';
                html += '<td>' + item.madonhang + '</td>';
                html += '<td>' + item.tennguoigui + '</td>';
                html += '<td>' + item.tennguoinhan + '</td>';
                html += '<td>' + item.sdtnguoinhan + '</td>';
                html += '<td>' + item.diachinguoinhan + '</td>';
                html += '<td>' + item.dichvu + '</td>';
                html += '<td>' + item.loaihang + '</td>';
                html += '<td>' + item.ghichu + '</td>';
                html += '<td>' + item.trangthai + '</td>';
                html += '<td>' + item.phiship + '</td>';
                html += '<td>' + item.cod + '</td>';
                html += '<td><a href="../Delivery/Details/'+item.Id+'">Xem chi tiết</a ></td>';
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

function getbyID(EmpID) {
    $('#mavandon').css('border-color', 'lightgrey');
    $('#madonhang').css('border-color', 'lightgrey');
    $('#tennguoigui').css('border-color', 'lightgrey');
    $('#tennguoinhan').css('border-color', 'lightgrey');
    $('#sdtnguoinhan').css('border-color', 'lightgrey');
    $('#diachinguoinhan').css('border-color', 'lightgrey');
    $('#soluong').css('border-color', 'lightgrey');
    $('#giatri').css('border-color', 'lightgrey');
    $('#dichvu').css('border-color', 'lightgrey');
    $('#loaihang').css('border-color', 'lightgrey');
    $('#cannang').css('border-color', 'lightgrey');
    $('#ghichu').css('border-color', 'lightgrey');
    $('#trangthai').css('border-color', 'lightgrey');
    $('#phiship').css('border-color', 'lightgrey');
    $('#cod').css('border-color', 'lightgrey');
    $('#ngaytaodon').css('border-color', 'lightgrey');
    $('#Shipper').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Shipper/GetbyID/ " + EmpID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#mavandon').val(result.mavandon);
            $('#madonhang').val(result.madonhang);
            $('#tennguoigui').val(result.tennguoigui);
            $('#tennguoinhan').val(result.tennguoinhan);
            $('#sdtnguoinhan').val(result.sdtnguoinhan);
            $('#diachinguoinhan').val(result.diachinguoinhan);
            $('#soluong').val(result.soluong);
            $('#giatri').val(result.giatri);
            $('#dichvu').val(result.dichvu);
            $('#loaihang').val(result.loaihang);
            $('#cannang').val(result.cannang);
            $('#ghichu').val(result.ghichu);
            $('#trangthai').val(result.trangthai);
            $('#phiship').val(result.phiship);
            $('#cod').val(result.cod);
            $('#ngaytaodon').val(result.ngaytaodon);
            $('#Shipper').val(result.Shipper);

            $('#myModal').modal('show');
            $('#btnUpdate').show();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record
function Update() {
    var empObj = {
        Id: $('#Id').val(),
        mavandon: $('#mavandon').val(),
        madonhang: $('#madonhang').val(),
        tennguoigui: $('#tennguoigui').val(),
        tennguoinhan: $('#tennguoinhan').val(),
        sdtnguoinhan: $('#sdtnguoinhan').val(),
        diachinguoinhan: $('#diachinguoinhan').val(),
        soluong: $('#soluong').val(),
        giatri: $('#giatri').val(),
        dichvu: $('#dichvu').val(),
        loaihang: $('#loaihang').val(),
        cannang: $('#cannang').val(),
        ghichu: $('#ghichu').val(),
        trangthai: $('#trangthai').val(),
        phiship: $('#phiship').val(),
        cod: $('#cod').val(),
        ngaytaodon: $('#ngaytaodon').val(),
        Shipper: $('#Shipper').val(),
    };
    $.ajax({
        url: "/Shipper/Update",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#Id').val("");
            $('#mavandon').val("");
            $('#madonhang').val("");
            $('#tennguoigui').val("");
            $('#tennguoinhan').val("");
            $('#sdtnguoinhan').val("");
            $('#diachinguoinhan').val("");
            $('#soluong').val("");
            $('#giatri').val("");
            $('#dichvu').val("");
            $('#loaihang').val("");
            $('#cannang').val("");
            $('#ghichu').val("");
            $('#trangthai').val("");
            $('#phiship').val("");
            $('#cod').val("");
            $('#ngaytaodon').val("");
            $('#Shipper').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

