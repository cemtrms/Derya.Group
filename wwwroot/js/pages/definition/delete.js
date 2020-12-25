
$('.delete-button').click(function (evt) {
    var id = $(this).attr("data-id");
    var siteId = $(this).attr("data-siteId");
    if (confirm("Tanımı silmek istediğinize emin misiniz ?")) {
        var model = { 'id': id, 'siteId': siteId };
        debugger;

        $.ajax({
            method: "POST",
            dataType: 'json',
            data: { model: model }, //use id here
            url: '/Definition/Delete',
            success: function (data) {
                // alert("Data has been deleted.");
                debugger;
                alert(data.message);
                window.location.href = window.location.pathname + window.location.search + window.location.hash;
            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });
    }
});
function refreshPage() {
}