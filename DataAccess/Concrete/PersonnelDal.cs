using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class PersonnelDal : IRepository<Personnel>
    {
        static PersonnelDal personnelDal;
        SqlService sqlService;
        SqlDataReader dataReader;
        LogService logService;
        SecurityProcess securityProcess;
        bool result;

        public PersonnelDal()
        {
            sqlService = SqlDatabase.GetInstance();
            logService = LogService.GetInstance();
            securityProcess = SecurityProcess.GetInstance();
        }
        public string Add(Personnel entity)
        {
            try
            {
                dataReader = sqlService.StoreReader("PersonelEkle", new SqlParameter("@sicilno", entity.PersonNo), new SqlParameter("@adsoyad", entity.Name),
                    new SqlParameter("@departman", entity.DepartmentId), new SqlParameter("@yetkiid", entity.AuthId));
                if (dataReader.Read())
                {
                    result = dataReader[0].ConBool();
                }
                dataReader.Close();
                if (result)
                {
                    //return entity.PersonNo + " Sicil Numarası Daha Önce Kullanılmış";
                    return "0";
                }
                //return entity.Name + " Personel Kaydı Başarıyla Tamamlanmıştır";
                return logService.Info("Personel Ekleme", "Sicil No: " + entity.PersonNo, "İsim: " + entity.Name, "Departman Id: " + entity.DepartmentId, "Yetki Id: " + entity.AuthId);
            }
            catch (Exception ex)
            {
                //return ex.Message;
                return logService.Error(ex.Message, "Personel Ekleme", "Sicil No: " + entity.PersonNo, "İsim: " + entity.Name, "Departman Id: " + entity.DepartmentId, "Yetki Id: " + entity.AuthId);
            }
        }

        public string Delete(int id)
        {
            try
            {
                sqlService.Stored("PersonelSil", new SqlParameter("@id", id));
                //return "Personel Başarıyla Silindi";
                return logService.Info("Personel Sil", "Person Id : " + id);
            }
            catch (Exception ex)
            {
                //return ex.Message; 
                return logService.Error(ex.Message, "Personel Sil", "Person Id : " + id);
            }
        }

        public Personnel Get(int id)
        {
            return null;
        }

        public List<Personnel> GetList()
        {
            try
            {
                List<Personnel> personnels = new List<Personnel>();
                dataReader = sqlService.StoreReader("PersonelListesi");
                while (dataReader.Read())
                {
                    personnels.Add(new Personnel(dataReader["ID"].ConInt(), dataReader["DEPARTMAN_ID"].ConInt(), dataReader["YETKI_ID"].ConInt(), dataReader["SICILNO"].ToString(), dataReader["AD_SOYAD"].ToString(), dataReader["DEPARTMAN_AD"].ToString(), dataReader["YETKI_AD"].ToString()));
                }
                dataReader.Close();
                return personnels;               
            }
            catch (Exception ex)
            {
                return new List<Personnel>();
            }
        }

        public DataTable GetTable()
        {
            try
            {
                DataTable dataTable = sqlService.GetDataTable("PersonelListesi");
                return dataTable;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string Update(Personnel entity, string oldName)
        {
            try
            {
                sqlService.Stored("PersonelGuncelle", new SqlParameter("@sicilno", entity.PersonNo), new SqlParameter("@adsoyad", entity.Name), new SqlParameter("@departmanId", entity.DepartmentId), new SqlParameter("@yetkiId", entity.AuthId));
                return entity.Name + " Personeli Başarıyla Güncellendi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static PersonnelDal GetInstance()
        {
            if (personnelDal == null)
            {
                personnelDal = new PersonnelDal();
            }
            return personnelDal;
        }

        public object[] Login(string personNo, string password)
        {
            try
            {                
                object[] infos = null;
                string password2 = securityProcess.Encrypt("key", password);
                dataReader = sqlService.StoreReader("PersonelLogin", new SqlParameter("@sicilno", personNo), new SqlParameter("@sifre", password2));
                if (dataReader.Read())
                {
                    string name, departmentName, authName; int id, departmentId, authId;

                    id = dataReader["ID"].ConInt();
                    name = dataReader["AD_SOYAD"].ToString();
                    departmentId = dataReader["DEPARTMAN_ID"].ConInt();
                    departmentName = dataReader["DEPARTMAN_AD"].ToString();
                    authId = dataReader["YETKI_ID"].ConInt();
                    authName = dataReader["YETKI_AD"].ToString();

                    infos = new object[] { id, personNo, name, departmentId, departmentName, authId, authName };
                }
                dataReader.Close();
                return infos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetPersonnelNameByPersonNo(string personNo)
        {
            try
            {
                string personnelName = "";
                dataReader = sqlService.StoreReader("PersonelIsmi", new SqlParameter("@sicilno", personNo));
                if (dataReader.Read())
                {
                    personnelName = dataReader["AD_SOYAD"].ToString();
                }
                dataReader.Close();
                return personnelName;
            }
            catch
            {
                return "";
            }
        }

        public string UpdatePassword(string personNo, string password)
        {
            try
            {
                string password2 = securityProcess.Encrypt("key", password);
                dataReader = sqlService.StoreReader("SifreGuncelle", new SqlParameter("@sicilno", personNo), new SqlParameter("@sifre", password2));
                dataReader.Close();
                return logService.Info("Şifre Güncelleme", "Sicil No : " + personNo);
            }
            catch (Exception ex)
            {
                return logService.Error(ex.Message, "Şifre Güncelleme", "Sicil No : " + personNo);
            }
        }
    }
}
