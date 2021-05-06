
//Validation
//Saving
//Refreshing


$(document).ready(function() {
    var $baseUrl = $('base').attr('href');
    var $formDialogUser, form,
    $userId = $("#UserId"),
    //emailRegex = /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/,
    $usertype = $("#UserTypeId"),
    $username = $("#Username"),
    $email = $("#Email"),
    $firstname = $("#Firstname"),
    $lastname = $("#Lastname"),
    $active = $("#Active"),

    allFields = $([]).add($userId).add($usertype).add($username).add($email).add($firstname).add($lastname).add($active),
    tips = $(".validateTips");
       
        //Datatable
        var $table = $('#datatable').DataTable({
            select: true,
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

                    "targets": -1,
                    'visible': false
                }
            ],
            columns: [
                { 'data': 'Username', "name": "Username", "autoWidth": true },
                { 'data': 'Email', "name": "Email", "autoWidth": true },
                { 'data': 'Firstname', "name": "Firstname", "autoWidth": true },
                { 'data': 'Lastname', "name": "Lastname", "autoWidth": true },
                { 'data': 'Active', "name": "Active", "autoWidth": true },
                {
                    'data': 'UserId', 
                    'name': "Action",
                    'render': function (data, type, row, meta) {
                        return '<button class="btn btn-default btn-sm" itemId="' + data + '"> View</button> ' +
                            '<button class="btn btn-default btn-sm edit-data" itemId="' + data + '"> Edit</button> ' +
                            '<button class="btn btn-default btn-sm"> Delete</button>';
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
            //$(tableTools.fnContainer()).insertBefore('#datatable_wrapper');


    
    function updateTips(t) {
        tips
            .text(t)
            .addClass("ui-state-highlight");
        setTimeout(function () {
            tips.removeClass("ui-state-highlight", 1500);
        }, 500);
    }

    function checkLength(o, n, min, max) {
        if (o.val().length > max || o.val().length < min) {
            o.addClass("ui-state-error");
            updateTips("Length of " + n + " must be between " +
                min + " and " + max + ".");
            return false;
        } else {
            return true;
        }
    }

    function checkRegexp(o, regexp, n) {
        if (!(regexp.test(o.val()))) {
            o.addClass("ui-state-error");
            updateTips(n);
            return false;
        } else {
            return true;
        }
    }


    $("#create-data").click(function () {
        $userId.val("0");
        $("#userModalTitle").text("Add User");
        $("#userModal").modal("show");

        
    });

    //Opening Modal Function
    $("#userModal").on("shown.bs.modal",
        function (e) {

            //Load UserType
            getAndPopulateDropdown("/UserType/KeyValueList/", null, "UserTypeId", "");
            
        });
    //Closing Modal Function
    $("#userModal").on("hidden.bs.modal",
        function (e) {
            
            //Reset form validations
            $("#modal-form").bootstrapValidator("resetForm", true);


        });
    

});