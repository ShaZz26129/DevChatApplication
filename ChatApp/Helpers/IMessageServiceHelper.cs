using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Helpers
{
    public interface IMessageServiceHelper
    {
        Task<ApplyLeaveMessMailResponseModel> PostApplyLeaveMessmail(List<ApplyLeaveMessMailRequestModel> applyLeaveMessMail);
        Task<MessmailContentModel> GetMessMailContent(string FolderName, int TenantId, int MessBoxId, int appicationID, int PageId, bool apiStatus, bool Admin, string sType, int otype, int oid, int thrdid, int parentid, bool status, int startrow, int endrow, int pendrow, int pgsize, int objtype);
    }
}
