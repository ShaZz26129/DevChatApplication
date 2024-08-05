using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class JobUnderstoodResult
    {
        public string EmployeeId { get; set; }
        public int JobId { get; set; }
        public int MyProperty { get; set; }
        public string Remark { get; set; }
        public string LastUser { get; set; }
        public DateTime VersionDate { get; set; }
        public int TenantId { get; set; }
        public int TenantOuId { get; set; }
        public int ApplicationId { get; set; }
        public int OType { get; set; }
        public int Score { get; set; }
        public string RankedBy { get; set; }
        public DateTime ReadDate { get; set; }
        public DateTime RankedDate { get; set; }
        public int CategoryId { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
    }

    public class JobUnderstoodResponse
    {
        public JobUnderstoodResult Result { get; set; }
        public int Status { get; set; }
        public object Message { get; set; }
    }
}
