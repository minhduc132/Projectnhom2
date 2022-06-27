var cateId = 0;

$(document).ready(function () {
    $('#CategoryTable').DataTable({
        "processing": "true",
        "serverSide": "true",
        "filter": "true",
        "ajax":
        {
            "url": "/api/CategoryApi",
            "type": "POST",
            "datatype": "json",
        },
        "columns": [
            { "data": "name" },
            { "data": "summary" },
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

    $("#createCategory").click(function () {

        var data = {
            name: $("#recipient-name").val(),
            summary: $("#message-text").val()
        };

        if (cateId > 0) {
            data.id = cateId;

            $.post({
                "url": "/api/CategoryApi/update/" + cateId,
                'data': JSON.stringify(data),
                "dataType": "JSON",
                'contentType': 'application/json',
            }).done(function (data, status) {
                alert("Data: " + data.code + ", " + data.message);

                $("#CreateNew").modal('hide');

                var oTable = $('#CategoryTable').DataTable();
                oTable.draw();

                $("#recipient-name").val();
                $("#message-text").val();
            });
        } else {
            $.post({
                "url": "/api/CategoryApi/create",
                'data': JSON.stringify(data),
                "dataType": "JSON",
                'contentType': 'application/json',
            }).done(function (data, status) {
                alert("Data: " + data.code + ", " + data.message);

                $("#CreateNew").modal('hide');

                var oTable = $('#CategoryTable').DataTable();
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
    var url = "api/CategoryApi/delete/" + id;
    $.post(url, function (data) {
        oTable = $('#CategoryTable').DataTable();
        oTable.draw();
    });
}

function EditData(id) {
    $("#CreateNew").modal('show');

    $.get("/api/CategoryApi/" + id, function (data) {
        cateId = data.id;
        $("#recipient-name").val(data.name);
        $("#message-text").val(data.summary);
    });
}