using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using NTIER.BLL;
using NTIER.Common;
using NTIER.Common.Entity;
using NTIER.DAL;
using Rafaelle.Framework;

namespace NTIER.Web.WebService
{
    /// <summary>
    /// Summary description for UserTypeListService
    /// </summary>
    [WebService(Namespace = Constants.Namespace)]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UserTypeListService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetUserTypeList(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0,
            string sSearch)
        {
            List<UserTypeEntity> listResult = new List<UserTypeEntity>();
            int recordCount = 0;
            int recordCountSelected = 0;

            if (!string.IsNullOrEmpty(sSearch))
            {
                listResult = UserTypeBLL.SearchAndOrderBy(iDisplayLength, iDisplayStart, (UserTypeDAL.Column)iSortCol_0, (SortOrderDirection)SortOrder.GetIntVal(sSortDir_0), sSearch, out recordCount, out recordCountSelected);
            }
            else
            {
                listResult = UserTypeBLL.SelectAllPagedOrderBy(iDisplayLength, iDisplayStart, (UserTypeDAL.Column)iSortCol_0, (SortOrderDirection)SortOrder.GetIntVal(sSortDir_0), out recordCount, out recordCountSelected);
            }

            var result = new
            {
                iTotalRecords = recordCount,
                iTotalDisplayRecords = recordCountSelected,
                aaData = listResult
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }
    }
}
