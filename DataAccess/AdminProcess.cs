using DataAccess.Abstract;
using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AdminProcess
    {
        static AdminProcess adminProcess;
        SqlService sqlService;
        private AdminProcess()
        {
            sqlService = SqlDatabase.GetInstance();
        }

        public void BackUp(string filePath,string fileName)
        {
            try
            {
                sqlService.Stored("YedekAl",new SqlParameter("@dosyaYolu", filePath), new SqlParameter("@dosyaIsmi", fileName));
            }
            catch (Exception ex)
            {

            }
        }


        public static AdminProcess GetInstance()
        {
            if (adminProcess==null)
            {
                adminProcess = new AdminProcess();
            }
            return adminProcess;
        }
    }
}
