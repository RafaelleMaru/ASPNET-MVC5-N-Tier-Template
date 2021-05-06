/*
UI scripts
Dendent to: NTIER.UserTypeModule.js
*/

var userTypeModule = null;
var $userTypeId = $("#userTypeId");
var $userTypeNameLabel = $("#userTypeNameLabel");
var $permissionForm = $("#permissionForm");

$(document).ready(function() {


    userTypeModule = new NTIER.UserTypeModule();


    if ($userTypeId.val() != "") {

        userTypeModule.InitializePermission($userTypeId.val(), CallBackInitializePermission);
    } else {
        $userTypeNameLabel.text("N/A");
    }
    

    $("#permissionFormSaveButton").click(function () {

        userTypeModule.Save($userTypeId.val(), CallBackSave);
        
    });

    


});




function CallBackInitializePermission(result) {
    if (result) {
        alert('Initialized Permission!');
    }
};


function CallBackSave(result) {
    if (result) {
        DisplayGenericModal("Permission", "Permission has been saved!");
    }
}




