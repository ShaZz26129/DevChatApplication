using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class CommonChatModel
    {
        public string OldSystemEmpCode { get; set; }
        public string EmpName { get; set; }
        public string Subject { get; set; }
        public string _Threadid { get; set; }
        public string _ParentId { get; set; }
        public string _Id { get; set; }
        public string _Oid { get; set; }
        public int _Objecttype { get; set; }
        public int _Otype { get; set; }
        public string foldid { get; set; }
        public string TenantId { get; set; }
        public string Time { get; set; }
        public int index { get; set; }
        public string CurrentTab { get; set; }
        public string ParticipantID { get; set; }
        public string AuthorName { get; set; }
        public string ContentBody { get; set; }
        public string PageName { get; set; }
        public string ParentSubject { get; set; }
        public string Cardnumber { get; set; }
    }

}
