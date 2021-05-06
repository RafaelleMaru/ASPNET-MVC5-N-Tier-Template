
//Validation
//Saving
//Refreshing


var $user = null;
var $passwordGroupField = $("#passwordGroupField");
var $confirmPasswordGroupField = $("#confirmPasswordGroupField");
var $modalForm = $("#modal-form");
var $modalFormSubmit = $("#modalFormSubmit");

$(document).ready(function() {
    var $baseUrl = $('base').attr('href');


        //Datatable
        var $table = $('#datatable').DataTable({
            //select: true,
            responsive: true,
            dom: 'Bfrtip',
            lengthMenu: [
                [10, 25, 50, -1],
                ['10 rows', '25 rows', '50 rows', 'Show all']
            ],
            buttons: [
                'pageLength',
                'colvis',
                {
                    extend: 'copy',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                {
                    extend: 'excelHtml5',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                {
                    extend: 'csvHtml5',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                {
                    extend: 'pdfHtml5',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                {
                    extend: 'print',
                    exportOptions: {
                        columns: ':visible'
                    }
                }
            ],
            columnDefs: [
                {
                    "targets": [4],
                    "visible": true,
                    "searchable": false
                },
                {

                    "targets": [-1],
                    'visible': true
                }
            ],
            columns: [
                { 'data': 'Username', "name": "Username", "autoWidth": true },
                //{ 'data': 'Email', "name": "Email", "autoWidth": true },
                { 'data': 'Firstname', "name": "Firstname", "autoWidth": true },
                { 'data': 'Lastname', "name": "Lastname", "autoWidth": true },
                { 'data': 'Active', "name": "Active", "autoWidth": true },
                {
                    'data': 'UserId', 
                    'name': "Action",
                    'render': function (data, type, row, meta) {
                        return '<button class="btn btn-default btn-sm" itemId="' + data + '" onClick=\'showModal("' + data +'", "View - User", "true")\'> View</button> ' +
                            '<button class="btn btn-default btn-sm edit-data" itemId="' + data + '"  onClick=\'showModal("' + data +'", "Edit - User", null)\'> Edit</button> ' +
                            '<button class="btn btn-default btn-sm" onClick=\'showConfirmationModal("' + data +'", "Delete - User")\'> Delete</button>';
                    },
                    'visible': true,
                    'autoWidth': true
                }

                //{
                //    "defaultContent":
                //        "<button class=\"btn btn-default btn-sm\" itemId=\"" +  + "\"> View</button> " +
                //        '<button class="btn btn-default btn-sm editor_edit" data-toggle="modal"  data-target="#AddEditModal"> Edit</button> ' +
                //        "<button class=\"btn btn-default btn-sm\"> Delete</button>"
                //}
            ],
            bServerSide: true,
                    //sAjaxSource for DataHandler only
                    //sAjaxSource:  '@Url.Content("~/DataHandler/EmployeeDataHandler.ashx")'

                    //sAjaxSource and sServerMethod for web service
            sAjaxSource: $baseUrl + "WebService/UserListService.asmx/GetUserList",

            sServerMethod: 'POST'
    });


    var tableTools = new $.fn.dataTable.TableTools($table,
    {
        'sSwfPath': 'https://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf',

    });




    //Bootstrap Form Validation
    $modalForm.bootstrapValidator({
        // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        excluded: [':disabled'], //For remove validations
        fields: {
            userTypeId: {
                validators: {
                    notEmpty: {
                        message: "Please select User Type Username"
                    }
                }
            },

            username: {
                validators: {
                    stringLength: {
                        min: 2
                    },
                    notEmpty: {
                        message: "Please supply your Username"
                    }
                }
            },

            password: {
                validators: {
                    identical: {
                        field: 'confirmPassword',
                        message: 'Confirm your password below - type same password please'
                    },
                    stringLength: {
                        min: 8
                    },
                    notEmpty: {
                        message: "Please supply your Password"
                    }
                }
            },
            confirmPassword: {
                validators: {
                    identical: {
                        field: 'password',
                        message: 'The password and its confirm are not the same'
                    }
                }
            },

            firstname: {
                validators: {
                    stringLength: {
                        min: 2
                    },
                    notEmpty: {
                        message: "Please supply your first name"
                    }
                }
            },
            lastname: {
                validators: {
                    stringLength: {
                        min: 2
                    },
                    notEmpty: {
                        message: "Please supply your last name"
                    }
                }
            },
            Email: {
                validators: {
                    notEmpty: {
                        message: "Please supply your email address"
                    },
                    emailAddress: {
                        message: "Please supply a valid email address"
                    }
                }
            }

        }
    })
        .on('success.form.bv',
        function (e) {
            $('#success_message').slideDown({ opacity: "show" }, "slow"); // Do something ...
            $modalForm.data("bootstrapValidator").resetForm();

            // Prevent form submission
            e.preventDefault();

            // Get the form instance
            var $form = $(e.target);

            // Get the BootstrapValidator instance
            var bv = $form.data("bootstrapValidator");

            // Use Ajax to submit form data
            $.post($form.attr('action'), $form.serialize(), function (result) {
                console.log(result);
            }, 'json');

        }); //-- end of BootstrapValidator






    user = new NTIER.User();


    $modalForm.submit(function () {
        user.Save($("#userId").val(), SaveCallbackUser);
    });


    $("#modalFormDelete").submit(function () {

        user.Delete($("#userIdDelete").val(), DeleteCallbackUser);

    });



    function reloadDatatable() {
        //Reload datatable without changing the selected page.
        $table.ajax.reload(null, false);
    }


    //Opening Modal Function
    $("#userModal").on("shown.bs.modal",
        function (e) {
            

        });

    //Closing Modal Function
    $("#userModal").on("hidden.bs.modal",
        function (e) {
            
            //Reset form validations
            $modalForm.data("bootstrapValidator").resetForm();
            user.ClearUserForm();
            //Set userId as empty guid
            $("#userId").val("00000000-0000-0000-0000-000000000000");
            reloadDatatable();
        });
    


    //Closing Modal Function
    $("#promptModal").on("hidden.bs.modal",
        function (e) {
            
            //Set userId as empty guid
            $("#userIdDelete").val("00000000-0000-0000-0000-000000000000");
            
        });


    

    $("#create-data").click(function () {
        $("#userId").val("00000000-0000-0000-0000-000000000000");
        showModal($("#userId").val(), "Add User", null);
    });

    $("#edit-data").click(function () {
        $("#userId").val($("#userIdView").val());
        showModal($("#userId").val(), "Edit User", null);
    });

    $("#delete-data").click(function () {
        $("#userId").val($userIdView.val());
        showModal($("#userId").val(), "Delete User", null);
    });


    $("#active").change(function() {
        $modalFormSubmit.removeAttr('disabled');

    });

}); //End of document ready


//Callbacks

function SaveCallbackUser(result) {
    if (result) {
        $("#userModal").modal('hide');
        
    }
};

function DeleteCallbackUser(result) {
    if (result) {

    }
};

function showModal(id, title, viewOnly) {


    if (viewOnly) {
        //Load UserType
        getAndPopulateDropdown("/UserType/KeyValueList/", null, "userTypeIdView", "");

        user.InitilizeView(id,
            function(successful) {


                $("#viewModalTitle").text(title);
                $("#viewModal").modal("show");

            });


    } else {
        //Load UserType
        getAndPopulateDropdown("/UserType/KeyValueList/", null, "userTypeId", "");


        if (id !== "00000000-0000-0000-0000-000000000000") {

            $("#viewModal").modal('hide');

            user.Initilize(id,
                function(successful) {


                    $("#userModalTitle").text(title);
                    $("#userModal").modal("show");

                });


        } else {
            $("#userModalTitle").text(title);
            $("#userModal").modal("show");
        }

    }

} //end of showModal

function showConfirmationModal(id, title) {
    $("#userIdDelete").val(id);
    $("#promtModalTitle").text(title);
    $("#promptModal").modal("show");
}
