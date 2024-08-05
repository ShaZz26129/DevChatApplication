using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class CpmMyGuide
    {
        public string MID { get; set; }
        public string ID { get; set; }
        public string PID { get; set; }
        public int MAPID { get; set; }
        public string Name { get; set; }
        public string RID { get; set; }
        public string PRES { get; set; }
        public string RESPONSIBLE { get; set; }
        public string Approver { get; set; }
        public string AssignedTo { get; set; }
        public string Decision { get; set; }
        public string Complete { get; set; }
        public string Quality { get; set; }
        public string Owner { get; set; }
        public DateTime? StartDate { get; set; }
        public object DueDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Progress { get; set; }
        public string Department { get; set; }
        public string Meeting { get; set; }
        public string Company { get; set; }
        public int? jobId { get; set; }
        public string Priority { get; set; }
        public string Attachment { get; set; }
        public string Reminder { get; set; }
        public string Duration { get; set; }
        public string ToleranceTime { get; set; }
        public string UrlIcon { get; set; }
        public string HelpIocn { get; set; }
        public string CommentIcon { get; set; }
        public string Affects { get; set; }
        public string Otype { get; set; }
        public string CompanyId { get; set; }
        public string DeptId { get; set; }
        public int KPWGHT { get; set; }
        public int WTTOTALCOUNT { get; set; }
        public int WTBLANKCOUNT { get; set; }
        public int WTWeightSUM { get; set; }
        public int WTWeightAvg { get; set; }
        public int ReadValue { get; set; }
        public int BASELINE { get; set; }
        public int RealWeight { get; set; }
        public int MINVALUE { get; set; }
        public int MAXVALUE { get; set; }
        public int Optim { get; set; }
        public int TARGET { get; set; }
    }

    public class CpmMyGuideResponse
    {
        public List<CpmMyGuide> Result { get; set; }
        public int Status { get; set; }
        public object Message { get; set; }
    }
}
