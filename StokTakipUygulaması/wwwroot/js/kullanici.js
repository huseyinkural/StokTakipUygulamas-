var dataTable;

$(document).ready(function () {
  
    loadDataTable();
   
});



function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/KullaniciIslemleri/GetAll"
        },
        "columns": [
            { "data": "isim", "width": "20%" },
            { "data": "soyisim", "width": "20%" },
            { "data": "kullaniciAdi",  "width": "20%" },          
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/KullaniciIslemleri/Duzenle/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>

                                <a onclick=Delete("/KullaniciIslemleri/Sil/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>

                            </div>
                            `;
                }, "width": "20%"
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
        text: "Silinen personel giriş yapamayacak.",
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