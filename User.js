var dataTable;
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAll",
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "company.name", "width": "15%" },
            { "data": "role", "width": "15%" },
            {
                "data": {    // it means data is object
                    id: "id", lockoutEnd: "lockoutEnd"
                },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        //user locked
                        return `
                        <div class="text-center">
                        <a class="btn btn-danger" onClick=LockUnlock('${data.id}')>unlock</a>
                       </div>
                        `;   //
                    }
                    else {
                        //user unlock
                        return `
                        <div class="text-center">
                        <a class="btn btn-success" onClick=LockUnlock('${data.id}')>Lock</a>
                        </div>
                        `; //
                    }
                }
            }
        ]
    })
}
function LockUnlock(id) {
    $.ajax({
        url: "/Admin/User/LockUnlock",  //
        type: "POST", //
        data: JSON.stringify(id),
        contentType: "application/json",

        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload(); //
            }
            else {
                toastr.error(data.message);
            }
        }
    })
}
