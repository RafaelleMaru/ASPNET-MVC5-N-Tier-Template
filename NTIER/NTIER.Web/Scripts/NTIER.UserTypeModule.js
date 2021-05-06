if (typeof (NTIER) === "undefined") {
    NTIER = {};
};

NTIER.UserTypeModule = function NTIER$UserTypeModule(page) {
    var object = this;
    var _page = page;

    var $userTypeId = $('#userTypeId', _page);
    //Load table
    this.InitializePermission = function NTIER$InitializePermission(id, callback) {

      
        var successful = false;

        $.ajax({

            async: true,

            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Permission/Index/" + id,
            dataType: "json",
            success: function (data) {

                result = eval(data);

                if (result.error) {

                    DisplayGenericModal("Error", result.message);
                    if (callback != null && typeof (callback) == "function") {
                        callback(successful);
                    }
                    return;
                }

                successful = true;
                //alert(JSON.stringify(result.data));
               
                    //for(var module in result.data.UserTypeModuleList)
                    //{
                    //    alert(module);
                    //}
                    
                    //$("#Add_" + module.ModuleId)
                
                    //alert(result.data[0].UserTypeModuleList[1].ModuleId);
                    //alert(result.data.UserTypeModuleList[1].BitwisePermission.Add);

                var i;
                for (i = 0; i < result.data.UserTypeModuleList.length; i++) {


                    $("#Add_" + result.data.UserTypeModuleList[i].ModuleId).prop("checked", result.data.UserTypeModuleList[i].BitwisePermission.Add);
                    $("#Edit_" + result.data.UserTypeModuleList[i].ModuleId).prop("checked", result.data.UserTypeModuleList[i].BitwisePermission.Edit);
                    $("#Delete_" + result.data.UserTypeModuleList[i].ModuleId).prop("checked", result.data.UserTypeModuleList[i].BitwisePermission.Delete);
                    $("#View_" + result.data.UserTypeModuleList[i].ModuleId).prop("checked", result.data.UserTypeModuleList[i].BitwisePermission.View);
                    $("#ListView_" + result.data.UserTypeModuleList[i].ModuleId).prop("checked", result.data.UserTypeModuleList[i].BitwisePermission.ListView);
                    $("#Approve_" + result.data.UserTypeModuleList[i].ModuleId).prop("checked", result.data.UserTypeModuleList[i].BitwisePermission.Approve);
                    $("#Download_" + result.data.UserTypeModuleList[i].ModuleId).prop("checked", result.data.UserTypeModuleList[i].BitwisePermission.Download);
                    $("#Upload_" + result.data.UserTypeModuleList[i].ModuleId).prop("checked", result.data.UserTypeModuleList[i].BitwisePermission.Upload);

                  

                }

                
            },
            error: function (xhr, status, err) {
                //alert(status);
                if (callback != null && typeof (callback) == "function") {
                    callback(status);
                }
                return;
            }
        });


    }

    //Save Table Permission Form
    this.Save = function NTIER$Save(id, callback) {

        //alert('entered Save function');
        

        var dataObject = [];
        var _itemId, _add, _edit, _delete, _view, _listView, _approve, _download, _upload;

        var myRows = [];
        var $headers = $("th");
        var $rows = $("#permissionTable tbody tr").each(function(index) {
            var $cells = $(this).find("td");
            myRows[index] = {};

            
            $cells.each(function(cellIndex) {

                switch (cellIndex) {
                case 0:
                    _itemId = $cells[cellIndex].getAttribute("itemId");
                    break;
                case 1:
                    _add = $(this).find('input:checkbox')[0].checked;
                    break;
                case 2:
                    _edit = $(this).find('input:checkbox')[0].checked;
                    break;
                case 3:
                    _delete = $(this).find('input:checkbox')[0].checked;
                    break;
                case 4:
                    _view = $(this).find('input:checkbox')[0].checked;
                    break;
                case 5:
                    _listView = $(this).find('input:checkbox')[0].checked;
                    break;
                case 6:
                    _approve = $(this).find('input:checkbox')[0].checked;
                    break;
                case 7:
                    _download = $(this).find('input:checkbox')[0].checked;
                    break;
                case 8:
                    _upload = $(this).find('input:checkbox')[0].checked;

                    dataObject.push(
                        {
                            ModuleId: _itemId,
                            Add: _add,
                            Edit: _edit,
                            Delete: _delete,
                            View: _view,
                            ListView: _listView,
                            Approve: _approve,
                            Download: _download,
                            Upload: _upload
                        });


                    break;

                }
                
                // _itemId = $cells[cellIndex].getAttribute("itemId");
                // _add = $cells[cellIndex].find('input:checkbox')[0].checked;
                // _edit = $cells[cellIndex].find('input:checkbox')[0].checked;
                // _delete = $cells[cellIndex].find('input:checkbox')[0].checked;
                // _view = $cells[cellIndex].find('input:checkbox')[0].checked;
                // _listView = $cells[cellIndex].find('input:checkbox')[0].checked;
                // _approve = $cells[cellIndex].find('input:checkbox')[0].checked;
                // _download = $cells[cellIndex].find('input:checkbox')[0].checked;
                // _upload = $cells[cellIndex].find('input:checkbox')[0].checked;


                //alert(_itemId + _add + _edit + _delete + _view + _listView + _approve + _download + _upload);
                //data.push(
                //    {
                //        moduleId: $cells[cellIndex].getAttribute("itemId"),
                //        Add: $cells[cellIndex].find('input:checkbox')[0].checked,
                //        Edit: _edit,
                //        Delete: _delete,
                //        View: _view,
                //        ListView: _listView,
                //        Approve: _approve,
                //        Download: _download,
                //        Upload: _upload
                //});


                myRows[index][$($headers[cellIndex]).html()] = $(this).html();

            });
        });
        

        //Save UserType Form

        var model = JSON.stringify(dataObject);


        //alert(model);

        //dataObject.push({ id: id }, dataObject);
        

        var form = $('#permissionForm');
        var token = $('input[name="__RequestVerificationToken"]', form).val();
        
        $.ajax({
            type: "POST",
            contentType: " application/json",
            url: "/Permission/SavePermission/" + id,
            data: JSON.stringify(dataObject),
            dataType:"json",
            success: function (data) {

                result = eval(data);

                if (result != null) {
                    
                    //window.location = BaseUrl + "/?id=" + result.id;
                } else {
                    alert("Something went wrong");
                } 
                callback(true);
            },
            //failure: function (data) {
            //    var result = eval(data);
            //    alert(result.message);
            //},
            error: function (data) {
                var result = eval(data);
                DisplayGenericModal("Error", result.message);
            }  


            //error: function (XMLHttpRequest, textStatus, errorThrown) {
            //    alert(JSON.stringify(XMLHttpRequest));
            //    debugger;
            //}
        });
       
        


    }


}