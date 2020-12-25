
$('.delete-button').click(function (evt) {
    var id = $(this).attr("data-id");
    var definitionId = $(this).attr("data-definitionId");
    var siteId = $(this).attr("data-siteId");
    if (confirm("Alanı silmek istediğinize emin misiniz ?")) {
        debugger;
        var model = { 'id': id, 'definitionId': definitionId, 'siteId': siteId };
        debugger;

        $.ajax({
            method: "POST",
            dataType: 'json',
            data: { model: model }, //use id here
            url: '/Field/Delete',
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