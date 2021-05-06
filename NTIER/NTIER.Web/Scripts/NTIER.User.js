if (typeof (NTIER) === "undefined") {
    NTIER = {};
};


NTIER.User = function NTIER$User(page) {

    var object = this;
    var _page = page;

    //Add / Edit fields
    var $userId = $('#userId', _page);
    var $userTypeId = $('#userTypeId', _page);
    var $username = $('#username', _page);
    var $email = $('#email', _page);
    var $password = $('#password', _page);
    var $confirmPassword = $('#confirmPassword', _page);
    var $firstname = $('#firstname', _page);
    var $lastname = $('#lastname', _page);
    var $active = $('#active', _page);


    var $modalForm = $("#modal-form", _page);
    var $userModal = $("#userModal", _page);



    //View fields
    var $userIdView = $('#userIdView', _page);
    var $userTypeIdView = $('#userTypeIdView', _page);
    var $usernameView = $('#usernameView', _page);
    var $emailView = $('#emailView', _page);
    var $firstnameView = $('#firstnameView', _page);
    var $lastnameView = $('#lastnameView', _page);
    var $activeView = $('#activeView', _page);


    var $viewModal = $("#viewModal", _page);

    //Delete Field(s)
    var $userIdDelete = $('#userIdDelete', _page);

    var $modalFormDelete = $("#modalFormDelete", _page);


    this.Save = function NTIER$Save(id, callback) {
        var successful = false;

        $.post("/User/save/" + id + "?timestamp=" + new Date(),
            $("#modal-form").serialize(),
            function (data) {

                result = eval(data);

                if (callback != null && typeof (callback) == "function") {

                    if (result.error) {
                        //DisplayPrompt("Error", result.message);
                        alert(result.message);
                        if (callback != null && typeof (callback) == "function") {
                            callback(successful);
                        }
                        return;
                    }
                    else if (result.error == false) {
                        successful = true;
                    }

                    if (callback != null && typeof (callback) == "function") {
                        callback(result);
                    }
                }
            });



    }

    this.Initilize = function NTIER$Initilize(id, callback) {


        var successful = false;
        $.post("/User/initialize/" + id + "?timestamp=" + Date(),
            {
                "__RequestVerificationToken": $("input[name='__RequestVerificationToken']").val()
            },
            function (data) {
                result = eval(data);

                if (result.error) {
                    //DisplayPrompt("Error", result.message);
                    alert(result.message);
                    if (callback != null && typeof (callback) == "function") {
                        callback(successful);
                    }
                    return;
                }

                successful = true;

                $userId.val(result.data.UserId);
                $userTypeId.val(result.data.UserTypeId);
                $username.val(result.data.Username);
                //$password.val(result.data.Password);
                //$confirmPassword.val(result.data.Password);
                $email.val(result.data.Email);
                $firstname.val(result.data.Firstname);
                $lastname.val(result.data.Lastname);
                $active.attr('checked', result.data.Active);



                if (callback != null && typeof (callback) == "function") {
                    callback(successful);
                }
            });





    }


    this.InitilizeView = function NTIER$InitilizeView(id, callback) {


        var successful = false;
        $.post("/User/initialize/" + id + "?timestamp=" + Date(),
            {
                "__RequestVerificationToken": $("input[name='__RequestVerificationToken']").val()
            },
            function (data) {
                result = eval(data);

                if (result.error) {
                    //DisplayPrompt("Error", result.message);
                    alert(result.message);
                    if (callback != null && typeof (callback) == "function") {
                        callback(successful);
                    }
                    return;
                }

                successful = true;

                $userIdView.val(result.data.UserId);
                $userTypeIdView.val(result.data.UserTypeId);
                $usernameView.val(result.data.Username);
                //$password.val(result.data.Password);
                //$confirmPassword.val(result.data.Password);
                $emailView.val(result.data.Email);
                $firstnameView.val(result.data.Firstname);
                $lastnameView.val(result.data.Lastname);
                $activeView.val(result.data.Active);



                if (callback != null && typeof (callback) == "function") {
                    callback(successful);
                }
            });





    }

    this.Delete = function NTIER$Delete(id, callback) {
        var successful = false;

        $.post("/User/Delete/" + id,
            {
                "__RequestVerificationToken": $("input[name='__RequestVerificationToken']").val()
            },
            function (data) {
                result = eval(data);

                if (result.error) {
                    //DisplayPrompt("Error", result.message);
                    alert(result.message);
                    if (callback != null && typeof (callback) == "function") {
                        callback(successful);
                    }
                    return;
                }
                else if (result.error == false) {
                    successful = true;
                }

                if (callback != null && typeof (callback) == "function") {
                    callback(result);
                }

            });



    }

    this.ClearUserForm = function NTIER$ClearUserForm() {
    
        $userId.val("00000000-0000-0000-0000-000000000000");
        $userTypeId.val("");
        $username.val("");
        $email.val("");
        $password.val("");
        $confirmPassword.val("");
        $firstname.val("");
        $lastname.val("");
        $active.attr("checked", false);

    }




}





