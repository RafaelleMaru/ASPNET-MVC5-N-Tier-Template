/*
UI scripts
Dendent to: NTIER.UserType.js
*/

var userType = null;
var $userTypeModal = $("#userTypeModal");
var $viewModal = $("#viewModal");
var $userTypeModalForm = $("#userTypeModalForm");

var $userTypeId = $("#userTypeId");


var $modalFormDelete = $("#deleteModalForm");
var $userTypeIdDelete = $("#userTypeIdDelete");

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
                "targets": [1],
                "visible": true,
                "searchable": false
            },
            {
                "targets": [-1],
                "visible": true
            }
        ],
        columns: [
            { 'data': 'UserTypeName', "name": "UserType", "autoWidth": true },            
            {
                'data': 'UserTypeId',
                'name': "Action",
                'render': function (data, type, row, meta) {
                    return '<button class="btn btn-default btn-sm" itemId="' + data + '" onClick=\'showModal("' + data + '", "View - User Type", "true")\'> View</button> ' +
                        '<button class="btn btn-default btn-sm edit-data" itemId="' + data + '"  onClick=\'showModal("' + data + '", "Edit - User Type", null)\'> Edit</button> ' +
                        '<button class="btn btn-default btn-sm" onClick=\'showConfirmationModal("' + data + '", "Delete - User Type")\'> Delete</button> ' +
                        '<a href="/Permission/?id=' + data +'" data class="btn btn-default btn-sm">Permission</a>';
                },
                'visible': true
            }
            
        ],
        bServerSide: true,
      
        sAjaxSource: $baseUrl + "WebService/UserTypeListService.asmx/GetUserTypeList",

        sServerMethod: 'POST'
    });


    function reloadDatatable() {
        //Reload datatable without changing the selected page.
        $table.ajax.reload(null, false);
    }

    //Bootstrap Form Validation
    $userTypeModalForm.bootstrapValidator({
        // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        excluded: [':disabled'], //For remove validations
        fields: {
           

            userTypeName: {
                validators: {
                    stringLength: {
                        min: 2
                    },
                    notEmpty: {
                        message: "Please supply your Username"
                    }
                }
            }

        }
    })
        .on('success.form.bv',
        function (e) {
            $('#success_message').slideDown({ opacity: "show" }, "slow"); // Do something ...
            $('#modal-form').data("bootstrapValidator").resetForm();

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





    //Opening Modal Function
    $("#userTypeModal").on("shown.bs.modal",
        function (e) {


        });

    //Closing Modal Function
    $("#userTypeModal").on("hidden.bs.modal",
        function (e) {

            //Reset form validations
            $("#modal-form").bootstrapValidator("resetForm", true);
            //Set userTypeId as 0
            $("#userTypeId").val("0");
            reloadDatatable();
        });





    userType = new NTIER.UserType();


    $("#create-data").click(function () {
        $("#userTypeId").val("0");
        showModal($("#userTypeId").val(), "Add User Type", null);
    });


    $("#edit-data").click(function () {
        $("#userTypeId").val($("#userTypeIdView").val());
        showModal($("#userTypeId").val(), "Edit User", null);
    });


    $userTypeModalForm.submit(function () {
        
        userType.Save($("#userTypeId").val(), SaveCallbackUser);
        
    });

    $("#deleteModalFormYesButton").click(function () {
        
        userType.Delete($("#userTypeIdDelete").val(), function(successful) {
            if (!successful) {
                $("#deleteModal").modal('hide');
            }

        });

    });


}); // end of $(document).ready()



function SaveCallbackUser(result) {
    if (result) {
        $userTypeModal.modal('hide');
    }
};

function DeleteCallbackUser(result) {
    if (result) {

    }
};

function showModal(id, title, viewOnly) {

    if (id !== "0") {

        userType.Initialize(id,
            function (successful) {

                if (successful) {

                    if (viewOnly) {
                        $("#viewModalTitle").text(title);
                        $("#viewModal").modal("show");
                    } else {
                        $viewModal.modal('hide');

                        $("#userTypeModalTitle").text(title);
                        $("#userTypeModal").modal("show");
                    }

                }
            });


    } else {
        $("#userTypeModalTitle").text(title);
        $("#userTypeModal").modal("show");
    }

}

function showConfirmationModal(id, title) {
    $("#userTypeIdDelete").val(id);
    $("#deleteModalTitle").text(title);
    $("#deleteModal").modal("show");
}

