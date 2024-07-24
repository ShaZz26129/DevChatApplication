using ChatApp.DbOperation.Table;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.DbOperation
{
    public class SendMessageDbOperation
    {
        private SQLiteConnection conn;

        public SendMessageDbOperation()
        {
            conn = DependencyService.Get<ISQlite>().GetConnection();
            conn.CreateTable<SendMessageTable>();
        }

        #region Get Members
        public IEnumerable<SendMessageTable> GetMembers()
        {

            var members = (from mem in conn.Table<SendMessageTable>() select mem);
            return members.ToList();
        }

        #endregion
        #region Insert Opreations
        public string AddMember(SendMessageTable member)
        {
            conn.Insert(member);
            return "success";
        }
        //public string InsertData(EmployeeOfflineDataTable member)
        //{

        //}
        #endregion

        #region Delete Members
        public string DeleteMember(int id)
        {
            conn.Delete<SendMessageTable>(id);
            return "success";
        }
        #endregion

        #region DropTable
        public string Droptable()
        {
            conn.DropTable<SendMessageTable>();
            return "success";
        }
        #endregion

        #region Update members
        public string UpdateMember(SendMessageTable member)
        {
            var i = conn.Update(member);
            return "success";
        }
        #endregion
        public string DeleteAll()
        {
            conn.DeleteAll<SendMessageTable>();
            return "success";
        }
    }

}
