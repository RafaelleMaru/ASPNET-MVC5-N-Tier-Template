if (typeof (NTIER) === "undefined") {
    NTIER = {};
};


NTIER.UserType = function NTIER$UserType(page) {
    var object = this;
    var _page = page;


    var $userTypeId = $('#userTypeId', _page);
    var $userTypeName = $('#userTypeName', _page);
    
    var $userTypeIdView = $('#userTypeIdView', _page);
    var $userTypeNameView = $('#userTypeNameView', _page);


    //Save UserType Form
    this.Save = function NTIER$Save(id, callback) {
        var successful = false;

        $.post("/UserType/save/" + id + "?timestamp=" + new Date(),
            $("#userTypeModalForm").serialize(),
            function (data) {

                result = eval(data);

                if (callback != null && typeof (callback) == "function") {

                    if (result.error) {
                        
                        DisplayGenericModal("Error", result.message);

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



    //Initializes the UserType form.
    this.Initialize = function NTIER$Initialize(id, callback) {

        var successful = false;
        $.post("/UserType/Initialize/" + id,
            {
                "__RequestVerificationToken": $("input[name='__RequestVerificationToken']").val()
            },
            function (data) {
                result = eval(data);

                if (result.error) {
                    
                    DisplayGenericModal("Error", result.message);
                    if (callback != null && typeof (callback) == "function") {
                        callback(successful);
                    }
                    return;
                }

                successful = true;

                //Add / Edit Modal
                $userTypeId.val(result.data.UserTypeId);
                $userTypeName.val(result.data.UserTypeName);


                //View Modal
                $userTypeIdView.val(result.data.UserTypeId);
                $userTypeNameView.val(result.data.UserTypeName);



                if (callback != null && typeof (callback) == "function") {
                    callback(successful);
                }
            }); 

    }

    this.Delete = function NTIER$Delete(id, callback) {
        var successful = false;

        $.post("/UserType/Delete/" + id,
            {
                "__RequestVerificationToken": $("input[name='__RequestVerificationToken']").val()
            },
            function (data) {
                result = eval(data);

                if (result.error) {
                    
                    DisplayGenericModal("Error", result.message);
                  
                    if (callback != null && typeof (callback) == "function") {
                        callback(successful);
                    }
                    return;
                }
                if (callback != null && typeof (callback) == "function") {
                    callback(result);
                }

            });



    }

    
}