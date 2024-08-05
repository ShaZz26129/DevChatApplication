using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class ScheduleInfo
    {
        public int Id { get; set; }
        public int OType { get; set; }
        public string Subject { get; set; }
        public int ItemType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string recurrenceData { get; set; }
        public int? ParentId { get; set; }
        public string Reminder { get; set; }
        public string EmployeeId { get; set; }
        public int TenantId { get; set; }
        public int TenantOuId { get; set; }
        public string Responsible { get; set; }
        public Color Background { get; set; }
    }
    public class Reminder
    {
        public TimeSpan TimeBeforeStart { get; set; }
        public bool IsDismissed { get; set; }
    }
    public class ScheduleInfoResult
    {
        public List<ScheduleInfo> Result { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
