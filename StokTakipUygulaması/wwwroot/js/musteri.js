var dataTable;

$(document).ready(function () {
  
    loadDataTable();
   
});



function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Musteri/GetAll"
        },
        "columns": [
            { "data": "isim", "width": "25%" }, 
            { "data": "telefon", "width": "25%" },
            { "data": "adres", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Musteri/Duzenle/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>

                                <a onclick=Delete("/Musteri/Sil/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>

                            </div>
                            `;
                }, "width": "25%"
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
        text: "Silinen müşteri geri alınamayacak.",
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