$(document).ready(function() {


});

function populateDropdown(controlid, list, selectedId, key, text, callback) {
    var $options = $("#" + controlid);

    $options.html("");
    if (key == null || key == "undefined") key = "Key";
    if (text == null || text == "undefined") text = "Value";

    $.each(list,
        function (item) {
            $options.append($("<option />").val(list[item][key]).text(list[item][text]));
        });

    if (selectedId != null && selectedId != '') {
        $options.val(selectedId);
    }

    if (callback != null && typeof (callback) == "function") {
        callback();
    }

} // -- end of populateDropdown


function getAndPopulateDropdown(endpoint, parameters, controlid, selectedId, callback, key, value) {

    $.post(endpoint,
        parameters,
        function (data) {

            var result = eval(data);

            if (result.error) {
                DisplayPrompt("Error", result.message);
                return;
            } else if (result.error == false) {
                successful = true;
            }

            populateDropdown(controlid, result.data, selectedId, key, value, callback);

        }); //-- end of post

} //-- end of getAndPopulateDropdown



//Dialog using jquery ui only.
function DisplayPrompt(title, content) {
    $("#dialog-message").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 1000
        },
        hide: {
            effect: "explode",
            duration: 1000
        },
        modal: true,
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
} // --end of DisplayPrompt


function DisplayCallBackSuccess(element, message, modal) {
    $(element).value(message);
    $(modal).modal('toggle'); 
}