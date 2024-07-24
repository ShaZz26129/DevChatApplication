using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class ParticipantsModel
    {
        public List<ParticipantsModel1> Result { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
    public class ParticipantsModel1
    {
        public string TenantID { get; set; }
        public int CompanyID { get; set; }
        public string ComapnyShortName { get; set; }
        public int RegionID { get; set; }
        public string RegionShortName { get; set; }
        public int DesignationID { get; set; }
        public string DesignationShortName { get; set; }
        public string DesignationFullName { get; set; }
        public string Name { get; set; }
        public string UserExID { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public int MessBoxID { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool DefaultDesignation { get; set; }
        public int SouceType { get; set; }
        public override string ToString()
        {
            return DesignationShortName.ToString();
        }
    }
}
