var dataTable;

$(document).ready(function () {
  
    loadDataTable();
   
});



function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/AltKategori/GetAll"
        },
        "columns": [
            { "data": "isim", "width": "40%" }, 
            { "data": "kategori.isim", "width": "40%" }, 
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/AltKategori/Duzenle/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>

                                <a onclick=Delete("/AltKategori/Sil/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>

                            </div>
                            `;
                }, "width": "20%"
            }
        ],
        "columnDefs": [{
            "targets": '_all',
            "defaultContent": ""
        }],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.24/i18n/Turkish.json"
        }
        
    });
}

function Delete(url) {
    swal({
        title: "Silmek istediğine emin misin?",
        text: "Silinen alt kategori geri alınamayacak.",
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