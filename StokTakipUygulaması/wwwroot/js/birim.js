var dataTable;

$(document).ready(function () {
  
    loadDataTable();
   
});



function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Birim/GetAll"
        },
        "columns": [
            { "data": "isim", "width": "60%" },              
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Birim/Duzenle/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>

                                <a onclick=Delete("/Birim/Sil/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>

                            </div>
                            `;
                }, "width": "40%"
            }
        ],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.24/i18n/Turkish.json"
        }
        
    });
}

function Delete(url) {
    swal({
        title: "Silmek istediğine emin misin?",
        text: "Silinen birim geri alınamayacak.",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}