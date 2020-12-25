
$('.delete-button').click(function (evt) {
    debugger;
    var id=$(this).attr("data-id");
    if (confirm("Siteyi silmek istediğinize emin misiniz ?")) {
    $.ajax({
        type: "POST",
        url: '/Site/Delete?id='+id,
        //data: { Id: id }, //use id here
        dataType: "json",
        success: function (data) {
            // alert("Data has been deleted.");
            debugger;
            alert(data.message);
            window.location.href = window.location.pathname + window.location.search + window.location.hash;
        },
        error: function () {
            alert("Silme işlemi gerçekleştirilirken hata ile karşılaşıldı");
        }
    });
}
});
function refreshPage() {
}