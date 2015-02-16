﻿function AjaxCall(url, json) {
        return $.ajax({
            url: url,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(json)
        });
}

function AjaxSendForm(url, form) {
    return AjaxCall(url, FormToJson(form));
}


function FormToJson(form) {
    var unindexed_array = form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}
