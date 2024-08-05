using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class JobByIdResult
    {
        public int JobId { get; set; }
        public string lblOverView { get; set; }
        public string lblWhattodo { get; set; }
        public string lblHowtodo { get; set; }
        public string lblDesiredResult { get; set; }
        public string lblAchievable { get; set; }
        public string lblWhattodoWF { get; set; }
        public string lblHowtodoWF { get; set; }
        public string lblDesiredResultWF { get; set; }
        public string lblAchievableWF { get; set; }
        public string LnkUrl { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string CatgId { get; set; }
        public int TenantId { get; set; }
        public int OUId { get; set; }
        public object AppPara { get; set; }
        public object ConnectionString { get; set; }
        public object ApiMessMailCallParameters { get; set; }
        public int Otype { get; set; }
        public object OId { get; set; }
        public bool Admin { get; set; }
        public int ApplicationId { get; set; }
        public int MessBoxId { get; set; }
        public bool ApiStatus { get; set; }
        public string SType { get; set; }
        public object logStatus { get; set; }
        public int PageId { get; set; }
        public object ConnApplicationId { get; set; }
        public int NoRows { get; set; }
        public object ShortOverView { get; set; }
        public List<object> JobSkill { get; set; }
        public object UserId { get; set; }
        public object SearchTxt { get; set; }
    }

    public class JobByIdResponse
    {
        public JobByIdResult Result { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
