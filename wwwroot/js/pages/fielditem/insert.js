$(document).ready(function () {

    $('#submit').click(function (evt) {
        debugger;
        var list = [];
        var siteId = $('#siteId').val();
        var definitionId = $('#definitionId').val();
        var fieldId = $('#fieldId').val();
        var values = document.getElementsByClassName("txtfrm");
        for (var i = 0; i < values.length; i++) {
            list.push(values[i].value);
        }

        var model = { 'fieldId': fieldId, 'definitionId': definitionId, 'siteId': siteId, 'values': list };
        $.ajax({
            method: "POST",
            dataType: 'json',
            data: { model: model }, //use id here
            url: '/FieldItem/Create',
            success: function (data) {
                // alert("Data has been deleted.");
                debugger;
                alert(data.message);
                window.location.href = window.location.pathname + window.location.search + window.location.hash;
            },
            error: function () {
                alert("Ekleme işlemi gerçekleştirilirken hata ile karşılaşıldı");
            }
        });

    });
});