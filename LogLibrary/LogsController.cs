using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LogsController
    {
        LogsDAL logsDAL = new LogsDAL();
        List<Logs> logList = new List<Logs>();
        Logs logs = new Logs();
        public List<Logs> GetAllLogs()
        {
            return logsDAL.GetAllLogs();
        }

        public Logs GetLogsByID(int id)
        {
            return logsDAL.GetLogById(id);
        }

        public void SetLogs(Logs logs)
        {
            logsDAL.CreateLog(logs);
        }
    }
}
