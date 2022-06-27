var cateId = 0;
$(document).ready(function () {
    $('#ProductTable').DataTable({
        "processing": "true",
        "serverSide": "true",
        "filter": "true",
        "ajax":
        {
            "url": "/api/ProductApi",
            "type": "POST",
            "datatype": "json",
        },
        "columns": [
            { "data": "name" },
            { "data": "amount" },
            { "data": "price" },
            {
                "data": "id",
                "render": function (data, type, row, meta) {
                    return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.id + "'); >Delete</a>";
                    //return "<a class='btn btn-danger'  href='Categories/Delete/" + row.id + "'  >Delete</a>";
                }
            },
            {
                "data": "id",
                "render": function (data, type, row, meta) {
                    return "<a href='#' class='btn btn-danger' onclick=EditData('" + row.id + "'); >Edit</a>";
                    //return "<a class='btn btn-danger' href='Categories/Edit/" + row.id + "' >Edit</a>";
                }
            }
        ]
    });

    $("#createProduct").click(function () {

        var data = {
            name: $("#Name-name").val(),
            amount: $("#Amount-amount").val(),
            price: $("#Price-price").val()
        };

        if (cateId > 0) {
            data.id = cateId;

            $.post({
                "url": "/api/ProductApi/update/" + cateId,
                'data': JSON.stringify(data),
                "dataType": "JSON",
                'contentType': 'application/json',
            }).done(function (data, status) {
                alert("Data: " + data.code + ", " + data.message);

                $("#CreateNew").modal('hide');

                var oTable = $('#ProductTable').DataTable();
                oTable.draw();

                $("#Name-name").val();
                $("#Amount-amount").val();
                $("#Price-price").val();
            });
        } else {
            $.post({
                "url": "/api/ProductApi/create",
                'data': JSON.stringify(data),
                "dataType": "JSON",
                'contentType': 'application/json',
            }).done(function (data, status) {
                alert("Data: " + data.code + ", " + data.message);

                $("#CreateNew").modal('hide');

                var oTable = $('#ProductTable').DataTable();
                oTable.draw();
            });
        }
        cateId = 0;
    });

});

function DeleteData(CustomerID) {
    if (confirm("Are you sure you want to delete ...?")) {
        Delete(CustomerID);
    }
    else {
        return false;
    }
}


function Delete(id) {
    var url = "api/ProductApi/delete/" + id;
    $.post(url, function (data) {
        oTable = $('#ProductTable').DataTable();
        oTable.draw();
    });
}

function EditData(id) {
    $("#CreateNew").modal('show');

    $.get("/api/ProductApi/" + id, function (data) {
        cateId = data.id;
        $("#Name-name").val(data.name);
        $("#Amount-amount").val(data.amount);
        $("#Price-price").val(data.price);
    });
}