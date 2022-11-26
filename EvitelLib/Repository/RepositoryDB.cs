using EvitelLib.Common;
using EvitelLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib.Repository
{
    public class CRepositoryDB
    {

 #region Main
        public string sErr;
        private string _applicationName;
        private int _idUser;
        private DateTime MyMinDate = new DateTime(2000, 01, 01);

        public CRepositoryDB(int IdUser)
          : this()
        {
            this.IdUser = IdUser;
        }
        public CRepositoryDB(int IdUser, string ApplicationName)
          : this(IdUser)
        {
            this.ApplicationName = ApplicationName;
        }

  
        public CRepositoryDB()
        {
            IdUser = -99;
        }
        public int IdUser
        {
            get
            {
                return _idUser;
            }
            set { _idUser = value; }
        }     // ID uživatele, který využívá knihovnu (nebo -1 pokud nikdo neexistuje)


            // Jméno programu, který využívá knihovnu
        public string ApplicationName   
        {
            get
            {
                if (_applicationName == null)
                    _applicationName = System.Configuration.ConfigurationSettings.AppSettings["AppName"];
                return _applicationName;
            }
            set { _applicationName = value; }
        }
        public String GetSettingS(string Name)
        {
            DBEvitel db = new DBEvitel();
            IQueryable<MainSetting> ms = db.MainSettings.Select(n => n).Where(n => n.Name == Name);
            MainSetting[] MainS = ms.ToArray();
            if (ms.Count() == 1)
            {
                return MainS[0].sValue;
            }
            else
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSettingS - no able found param " + Name, "", IdUser);
            }
            return "";
        }
        public int GetSettingI(string Name)
        {
            DBEvitel db = new DBEvitel();
            IQueryable<MainSetting> ms = db.MainSettings.Select(n => n).Where(n => n.Name == Name);
            MainSetting[] MainS = ms.ToArray();
            if (ms.Count() == 1)
            {
                return MainS[0].iValue ?? 0;
            }
            else
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSettingI - no able found param " + Name, "", IdUser);
            }
            return 0;
        }

    
        public DateTime GetSettingD(string Name)
        {
            DBEvitel db = new DBEvitel();
            IQueryable<MainSetting> ms = db.MainSettings.Select(n => n).Where(n => n.Name == Name);
            MainSetting[] MainS = ms.ToArray();
            if (ms.Count() == 1)
            {
                DateTime dt = MainS[0].dValue ?? MyMinDate;
                if (MyMinDate == dt)
                {
                    new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSettingD - no able found param " + Name, "", IdUser);
                }
                return dt;
            }
            else
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSettingD - no able found param " + Name, "", IdUser);
            }
            return MyMinDate;
        }
        public bool GetSettingB(string Name)
        {
            DBEvitel db = new DBEvitel();
            IQueryable<MainSetting> ms = db.MainSettings.Select(n => n).Where(n => n.Name == Name);
            MainSetting[] MainS = ms.ToArray();
            if (ms.Count() == 1)
            {
                return MainS[0].iValue == 1 ? true : false;
            }
            else
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSettingB - no able found param " + Name, "", IdUser);
            }
            return false;
        }
        public bool SetSetting(string Name, string sValue)
        {
            DBEvitel db = new DBEvitel();
            try
            {
                {
                    var stud = (from s in db.MainSettings
                                where s.Name == Name
                                select s).FirstOrDefault();
                    stud.sValue = sValue;
                    int num = db.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "SetSetting String - no able write param " + Name + ", Value = " + sValue + ".  " + GetInnerException(Ex), "",IdUser);
                return false;
            }
            return true;
        }
        public bool SetSetting(string Name, int iValue)
        {
            DBEvitel db = new DBEvitel();
            try
            {
                {
                    var stud = (from s in db.MainSettings
                                where s.Name == Name
                                select s).FirstOrDefault();
                    stud.iValue = iValue;
                    int num = db.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "SetSetting Int - no able write param " + Name + ", Value = " + iValue + ".  " + GetInnerException(Ex), "", IdUser);
                return false;
            }
            return true;
        }
        public bool SetSetting(string Name, DateTime dtValue)
        {
            DBEvitel db = new DBEvitel();
            try
            {
                var stud = (from s in db.MainSettings
                            where s.Name == Name
                            select s).FirstOrDefault();
                stud.dValue = dtValue;
                int num = db.SaveChanges();
            }
            catch (Exception Ex)
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "SetSetting DateTime - no able write param " + Name + ", Value = " + dtValue + ".  " + GetInnerException(Ex), "", IdUser);
                return false;
            }
            return true;
        }
        public bool SetSetting(string Name, bool bValue)
        {
            DBEvitel db = new DBEvitel();
            try
            {
                {
                    var stud = (from s in db.MainSettings
                                where s.Name == Name
                                select s).FirstOrDefault();
                    stud.iValue = bValue ? 1 : 0;
                    int num = db.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "SetSetting bool - no able write param " + Name + ", Value = " + bValue + ".  " + GetInnerException(Ex), "", IdUser);
                return false;
            }
            return true;
        }
        private string GetInnerException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return string.Format("{0} > {1} ", ex.InnerException.Message, GetInnerException(ex.InnerException));
            }
            if (ex.Source == "EntityFramework")
                if (ex.GetType() == typeof(System.Data.Entity.Validation.DbEntityValidationException))
                {
                    if (((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.Count() > 0)
                    {
                        return "EntityFramework -> " + ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                    }
                }
            return ex.Message;
        }

        public string CN
        {
            get
            {
                return (new DBEvitel()).Database.Connection.ConnectionString;
            }
        }

        #endregion
        #region LOGIN
        public LoginUser LoginUserNamePasswordExists(string LoginName, string LoginPassword)
        {
            sErr = "";
            DBEvitel db = new DBEvitel();
            try
            {
                var loginUsr = from l in db.LoginUsers where l.LoginName.CompareTo(LoginName) == 0 && l.LoginPassword.CompareTo(LoginPassword) == 0 select l;
                return loginUsr.FirstOrDefault();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "LoginUserNamePasswordExists() " + GetInnerException(Ex), "", IdUser);
            }
            return null;
        }
        public LoginUser LoginUserNameExists(string LoginName)
        {
            sErr = "";
            DBEvitel db = new DBEvitel();
            try
            {
                var loginUsr = from l in db.LoginUsers where l.LoginName.CompareTo(LoginName) == 0 select l;
                return loginUsr.FirstOrDefault();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "LoginUserNameExists() " + GetInnerException(Ex), "", IdUser);
            }
            return null;
        }
        public bool  ChangePassword(int loginUserId, string newLoginPassword)
        {
            sErr = "";
            DBEvitel db = new DBEvitel();
            try
            {
                var exp = (from l in db.LoginUsers
                           where l.LoginUserId == loginUserId
                           select l).FirstOrDefault();
                if (exp == null || exp.LoginUserId != loginUserId)
                {
                    sErr = "No Exist loginUser = " + loginUserId.ToString();
                    return false;
                }
                exp.LoginPassword = newLoginPassword;
                db.SaveChanges();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "ChangePassword() " + GetInnerException(Ex), "", IdUser);
                return false;
            }
            return true;
        }
        internal LoginUser AddLoginUser(string firstName, string lastName , string loginName, string loginPassword)
        {
            sErr = "";
            LoginUser newUser = new LoginUser
            {
                Created = DateTime.Now,
                LastName = lastName,
                FirstName = firstName,
                LoginName = loginName,
                LoginPassword = loginPassword
            };
            try
            {
                DBEvitel db = new DBEvitel();
                var cnt = (from l in db.LoginUsers
                           where l.LoginName == loginName
                           select l).Count();
                if (cnt > 0) {
                    new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "AddLoginUser() no able add user loginName = '" + loginName + "'. It's exists.", "", IdUser);
                    return null;
                }

                db.LoginUsers.Add(newUser);
                db.SaveChanges();
                var exp = (from l in db.LoginUsers
                           where l.LoginName == loginName
                           select l).FirstOrDefault();
                return exp;
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "AddLoginUser() " + GetInnerException(Ex), "", IdUser);
                return null;
            }

        }
        public List<LoginUser> GetUsers()
        {
            sErr = "";
            DBEvitel db = new DBEvitel();
            try
            {
                var loginUsr = from l in db.LoginUsers select l;
                return loginUsr.ToList();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetUsers() " + GetInnerException(Ex), "", IdUser);
            }
            return null;
        }




        #endregion

        public bool Test() {
            return true;
        }

        public List<MainEventLog> GetMainEventLog(string OrderBy, bool AscendingOrder, DateTime dtFrom, DateTime dtTo, string program, int? loginUserId, eEventCode? eventCode, eEventSubCode? eventSubCode, string text, string value)
        {
            sErr = "";
            DBEvitel db = new DBEvitel();
            try
            {
                var mainEventLogs = from l in db.MainEventLogs select l;
                if (dtFrom != null && dtFrom >= MyMinDate)
                    mainEventLogs = mainEventLogs.Where(p => p.dtCreate > dtFrom);
                if (dtTo != null && dtTo > MyMinDate)
                    mainEventLogs = mainEventLogs.Where(p => p.dtCreate < dtTo);
                if (!string.IsNullOrEmpty(program) && program.Trim().Length > 0)
                    mainEventLogs = mainEventLogs.Where(p => p.Program == program.Trim());
                if (loginUserId  != null)
                    mainEventLogs = mainEventLogs.Where(p => p.LoginUserId == loginUserId);
                if (eventCode != null)
                    mainEventLogs = mainEventLogs.Where(p => p.eventType == eventCode);
                if (eventSubCode != null)
                    mainEventLogs = mainEventLogs.Where(p => p.eventSubType == eventSubCode);
                if (!string.IsNullOrEmpty(text) && text.Trim().Length > 0)
                    mainEventLogs = mainEventLogs.Where(p => p.Text == text);
                if (!string.IsNullOrEmpty(value) && value.Trim().Length > 0)
                    mainEventLogs = mainEventLogs.Where(p => p.Value == value);
                mainEventLogs = (IQueryable<MainEventLog>)mainEventLogs.OrderBy(orderingFunction);
                return mainEventLogs.ToList(); 
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetMainEventLog() " + GetInnerException(Ex), "", IdUser);
            }
            return null;
         

        }
        static string filterString = "dtCreate";
        Func<dynamic, dynamic> orderingFunction = i =>
                             filterString == "dtCreate" ? i.dtCreate :
                             filterString == "something" ? i.columnx : "";


        public List<State> GetAllStates()
        {
            sErr = "";
            DBEvitel db = new DBEvitel();
            try
            {
                var states = from s in db.States select s;
                return states.ToList();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetStates() " + GetInnerException(Ex), "", IdUser);
            }
            return null;
        }

    }

   

}
