// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#edit-page').html("<div style='text-align: center'>" +
                        "<h2>" + res.name + " İsimli Şarkı Başarıyla Eklenmiştir.</h2></div>" +
                        "<div class='m-5' style='text-align: center; '><a class='btn btn-success btn-lg' onclick='refreshPage()'>Yeni Şarkı Ekle</a></div>" +
                        "<div class='m-5' style='text-align: center; '><a class='btn btn-primary btn-lg' href='http://localhost:56879/muziks/index'>Şarkıları Listele</a></div>")
                    //window.location.href = "/muziks/addsuccess/" + res.name;
                }
                else {
                    $('#edit-page').html("<div style='text-align: center'>" +
                        "<h2 class='color:red'>Hata: "+res.errMsg+"</h2></div>" +
                        "<div class='m-5' style='text-align: center; '><a class='btn btn-success btn-lg' onclick='refreshPage()'>Tekrar Deneyiniz</a></div>" +
                        "<div class='m-5' style='text-align: center; '><a class='btn btn-primary btn-lg' href='http://localhost:56879/muziks/index'>Şarkıları Listele</a></div>")
                }
            },
            error: function (err) {
                console.log(err);
            }
        })
        return false;
    } catch (e) {
        console.log(e);
    }
}

function refreshPage() {
    location.reload();
}
