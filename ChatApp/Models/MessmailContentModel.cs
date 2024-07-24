using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class MessmailContentModel
    {
        public List<MessmailContentModel1> Result { get; set; }
        public int Status { get; set; }
        public object Message { get; set; }
    }
    public class MessmailContentModel1
    {
        public int TenantId { get; set; }
        public string Threadid { get; set; }
        public string Id { get; set; }
        public string Oid { get; set; }
        public int Objecttype { get; set; }
        public int Otype { get; set; }
        public int Status { get; set; }
        public string Replyto { get; set; }
        public string Message { get; set; }
        public string Parentsubject { get; set; }
        public string Participant { get; set; }
        public string Attachment { get; set; }
        public string Author { get; set; }
        public string Versiondate { get; set; }
        public int Unread { get; set; }
        public string ParentId { get; set; }
        public string ShortMessage { get; set; }
        public string subject { get; set; }
        public int Mid { get; set; }
        public object ParticipantWF { get; set; }
        public object Pmid { get; set; }
        public int RowId { get; set; }
        public double DataSize { get; set; }
        public DateTime timestamp { get; set; }
        public int Sync { get; set; }
        public double TotSize { get; set; }
        public object TotRows { get; set; }
        public int RecCount { get; set; }
        public int TRowId { get; set; }
        public int Disp { get; set; }
        public int TickRankDisplay { get; set; }
    }
}
