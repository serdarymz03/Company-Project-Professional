using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager
    {
        static AdminManager adminManager;
        AdminProcess adminProcess;

        private AdminManager()
        {
            adminProcess = AdminProcess.GetInstance();
        }
        public void BackUp(string filePath, string fileName)
        {
            try
            {                
                adminProcess.BackUp(filePath, fileName);
            }
            catch
            {

            }
        }
        public static AdminManager GetInstance()
        {
            if (adminManager == null)
            {
                adminManager = new AdminManager();
            }
            return adminManager;
        }
    }
}
