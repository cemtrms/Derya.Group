
$('.delete-button').click(function (evt) {
    var fieldValueId = $(this).attr("data-fieldValueId");
    var definitionId = $(this).attr("data-definitionId");
    var siteId = $(this).attr("data-siteId");
    var fieldId = $(this).attr("data-fieldId");
    var fieldItemId = $(this).attr("data-fieldItemId");

    if (confirm("Alanı silmek istediğinize emin misiniz ?")) {
        debugger;
        var model = { 'fieldItemId': fieldItemId, 'definitionId': definitionId, 'siteId': siteId, "fieldId": fieldId, 'fieldValueId': fieldValueId};
        debugger;

        $.ajax({
            method: "POST",
            dataType: 'json',
            data: { model: model }, //use id here
            url: '/FieldItem/Delete',
            success: function (data) {
                // alert("Data has been deleted.");
                debugger;
                alert(data.message);
                window.location.href = window.location.pathname + window.location.search + window.location.hash;
            },
            error: function (request, status, error) {
                alert(request..responseText);
            }
        });
    }
});
function refreshPage() {
}