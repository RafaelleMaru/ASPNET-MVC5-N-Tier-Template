$(document).ready(function() {
    var BaseUrl = "http://localhost:54770";

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
    //$("#promptModal").modal();
} // --end of DisplayPrompt


function DisplayCallBackSuccess(element, message, modal) {
    $(element).value(message);
    $(modal).modal('toggle'); 
}

function isGuid(stringToTest) {
    if (stringToTest[0] === "{") {
        stringToTest = stringToTest.substring(1, stringToTest.length - 1);
    }
    var regexGuid = /^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$/gi;
    return regexGuid.test(stringToTest);
}

function DisplayGenericModal(title, body) {
    $("#genericModalTitle").text(title);
    $("#genericModalBody").text(body);
    $("#genericModal").modal("show");
}