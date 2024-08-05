using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class GuideTreeResult
    {
        public string ID { get; set; }
        public string PID { get; set; }
        public string Name { get; set; }
        public string CType { get; set; }
    }
    public class GuideTreeResponse
    {
        public List<GuideTreeResult> Result { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
