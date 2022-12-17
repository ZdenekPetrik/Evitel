using EvitelLib2.Common;
using EvitelLib2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib2.Repository
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
                {
                    _applicationName = System.Configuration.ConfigurationManager.AppSettings["AppName"];
                }
                return _applicationName;
            }
            set { _applicationName = value; }
        }


        public String GetSettingS(string Name)
        {
            Evitel2Context db = new Evitel2Context();
            IQueryable<MainSetting> ms = db.MainSettings.Select(n => n).Where(n => n.Name == Name);
            MainSetting[] MainS = ms.ToArray();
            if (ms.Count() == 1)
            {
                return MainS[0].SValue;
            }
            else
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSettingS - no able found param " + Name, "", IdUser);
            }
            return "";
        }
        public int GetSettingI(string Name)
        {
            Evitel2Context db = new Evitel2Context();
            IQueryable<MainSetting> ms = db.MainSettings.Select(n => n).Where(n => n.Name == Name);
            MainSetting[] MainS = ms.ToArray();
            if (ms.Count() == 1)
            {
                return MainS[0].IValue ?? 0;
            }
            else
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSettingI - no able found param " + Name, "", IdUser);
            }
            return 0;
        }


        public DateTime GetSettingD(string Name)
        {
            Evitel2Context db = new Evitel2Context();
            IQueryable<MainSetting> ms = db.MainSettings.Select(n => n).Where(n => n.Name == Name);
            MainSetting[] MainS = ms.ToArray();
            if (ms.Count() == 1)
            {
                DateTime dt = MainS[0].DValue ?? MyMinDate;
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
            Evitel2Context db = new Evitel2Context();
            IQueryable<MainSetting> ms = db.MainSettings.Select(n => n).Where(n => n.Name == Name);
            MainSetting[] MainS = ms.ToArray();
            if (ms.Count() == 1)
            {
                return MainS[0].IValue == 1 ? true : false;
            }
            else
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSettingB - no able found param " + Name, "", IdUser);
            }
            return false;
        }
        public bool SetSetting(string Name, string sValue)
        {
            Evitel2Context db = new Evitel2Context();
            try
            {
                {
                    var stud = (from s in db.MainSettings
                                where s.Name == Name
                                select s).FirstOrDefault();
                    stud.SValue = sValue;
                    int num = db.SaveChanges();
                }
            }
            catch (Exception Ex)
            {
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "SetSetting String - no able write param " + Name + ", Value = " + sValue + ".  " + GetInnerException(Ex), "", IdUser);
                return false;
            }
            return true;
        }
        public bool SetSetting(string Name, int iValue)
        {
            Evitel2Context db = new Evitel2Context();
            try
            {
                {
                    var stud = (from s in db.MainSettings
                                where s.Name == Name
                                select s).FirstOrDefault();
                    stud.IValue = iValue;
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
            Evitel2Context db = new Evitel2Context();
            try
            {
                var stud = (from s in db.MainSettings
                            where s.Name == Name
                            select s).FirstOrDefault();
                stud.DValue = dtValue;
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
            Evitel2Context db = new Evitel2Context();
            try
            {
                {
                    var stud = (from s in db.MainSettings
                                where s.Name == Name
                                select s).FirstOrDefault();
                    stud.IValue = bValue ? 1 : 0;
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
            if (ex.Source == "EntityFramework") { return "Neznama chyba"; }
            /*                if (ex.GetType() == typeof(System.Data.DataColumnChangeEventArgs   Entity.Validation.DbEntityValidationException))
                            {
                                if (((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.Count() > 0)
                                {
                                    return "EntityFramework -> " + ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                                }
                            }
            */
            return ex.Message;
        }
        /*
        public string CN
        {
            get
            {
                return (new DBEvitel()).Database.Connection.ConnectionString;
            }
        }
        */
        #endregion 
        #region LOGIN
        public LoginUser LoginUserNamePasswordExists(string LoginName, string LoginPassword)
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
            try
            {
                var loginUsr = from l in db.LoginUsers.Include("LoginAccessUsers") where l.LoginName == LoginName && LoginName == l.LoginName && l.LoginPassword == LoginPassword && LoginPassword == l.LoginPassword select l;
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
            Evitel2Context db = new Evitel2Context();
            try
            {
                var loginUsr = from l in db.LoginUsers where l.LoginName == LoginName && LoginName == l.LoginName select l;
                return loginUsr.FirstOrDefault();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "LoginUserNameExists() " + GetInnerException(Ex), "", IdUser);
            }
            return null;
        }
        public bool ChangePassword(int loginUserId, string newLoginPassword)
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
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
        internal LoginUser AddLoginUser(string firstName, string lastName, string loginName, string loginPassword)
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
                Evitel2Context db = new Evitel2Context();
                var cnt = (from l in db.LoginUsers
                           where l.LoginName == loginName
                           select l).Count();
                if (cnt > 0)
                {
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
            Evitel2Context db = new Evitel2Context();
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

        public bool Test()
        {
            return true;
        }

        public List<WMainEventLog> GetMainEventLog(string OrderBy, bool AscendingOrder, DateTime? dtFrom, DateTime? dtTo, string program, int? loginUserId, eEventCode? eventCode, eEventSubCode? eventSubCode, string text, string value)
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
            try
            {
                var mainEventLogs = from l in db.WMainEventLogs select l;
                if (dtFrom != null && dtFrom >= MyMinDate)
                    mainEventLogs = mainEventLogs.Where(p => p.DtCreate > dtFrom);
                if (dtTo != null && dtTo > MyMinDate)
                    mainEventLogs = mainEventLogs.Where(p => p.DtCreate < dtTo);
                var l4 = mainEventLogs.ToList();

                if (!string.IsNullOrEmpty(program) && program.Trim().Length > 0)
                    mainEventLogs = mainEventLogs.Where(p => p.Program == program.Trim());
                if (loginUserId != null)
                    mainEventLogs = mainEventLogs.Where(p => p.LoginUserId == loginUserId);
                if (eventCode != null)
                    mainEventLogs = mainEventLogs.Where(p => p.EventCode == (int)eventCode);
                if (eventSubCode != null)
                    mainEventLogs = mainEventLogs.Where(p => p.EventSubCode == (int)eventSubCode);
                if (!string.IsNullOrEmpty(text) && text.Trim().Length > 0)
                    mainEventLogs = mainEventLogs.Where(p => p.Text.Contains(text));
                if (!string.IsNullOrEmpty(value) && value.Trim().Length > 0)
                    mainEventLogs = mainEventLogs.Where(p => p.Value.Contains(value));
                mainEventLogs = mainEventLogs.OrderBy(p => p.DtCreate);
                return mainEventLogs.ToList();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetMainEventLog() " + GetInnerException(Ex), "", IdUser);
            }
            return null;


        }


        public List<State> GetAllStates()
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
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
        public List<WIntervent> GetWIntervents(int? RegionId, string Name, string Contact)
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
            try
            {
                
                var wIntervents = from i in db.WIntervents  select i;
                if (RegionId != null)
                   wIntervents = wIntervents.Where(x => x.RegionId == RegionId);
                if (Name.Length > 0 )
                    wIntervents = wIntervents.Where(x => x.Name.Contains(Name) || x.SurName.Contains(Name));
                if (Contact.Length > 0 )
                    wIntervents = wIntervents.Where(x => x.PrivatePhone.Contains(Name) || x.Phone.Contains(Name) ||x.MobilPhone.Contains(Name)|| x.Email.Contains(Name));
                wIntervents = wIntervents.OrderBy(p => p.RegionOrder);
                return wIntervents.ToList();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GeWIntervents() " + GetInnerException(Ex), "", IdUser);
            }
            return null;
        }
        public List<Region> GetRegions()
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
            try
            {
                var regions = from r in db.Regions orderby r.RegionOrder select r;
                return regions.ToList();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetRegions() " + GetInnerException(Ex), "", IdUser);
            }
            return null;
        }
        public List<ESubTypeIntervence> GetSubTypeIntervence()
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
            try
            {
                var subTypeIntervence = from e in db.ESubTypeIntervences orderby e.TypeIntervenceId select e;
                return subTypeIntervence.ToList();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSubTypeIntervence() " + GetInnerException(Ex), "", IdUser);
            }
            return null;
        }

        public bool InterventDeleteUnDelete(int interventId, bool isDelete)
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
            try
            {
                var intervent = (from intv in db.Intervents where intv.InterventId == interventId select intv).FirstOrDefault();
                if (intervent.InterventId == interventId) {
                   intervent.DtDeleted = isDelete ? DateTime.Now : null;
                   db.SaveChanges();
                }
                return true;
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "InterventDeleteUnDelete() " + GetInnerException(Ex), "", IdUser);
            }
            return false;
        }


        public bool SaveUserColumn(string nameOfDGW, int externIdUser, List<UserColumn> userColumns)
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
            try
            {
                bool RefreshNeeded = false;
                bool WriteNeeded = false;
                var userColumnsDB = from uc in db.UserColumns where nameOfDGW == uc.Name && userColumns[0].LoginUserId == externIdUser orderby uc.ColumnIndex select uc;
                if (userColumnsDB.Count() == userColumns.Count())
                {
                    for (int i = 0; i < userColumnsDB.Count(); i++)
                    {
                        var newRow = (from nr in userColumns where nr.ColumnIndex == i select nr).FirstOrDefault();
                        if (newRow.ColumnIndex != i)
                        {
                            RefreshNeeded = true;
                            break;
                        }
                        var dbRow = userColumnsDB.Where(x => x.ColumnIndex == i).First();
                        if (dbRow == null)
                        {
                            RefreshNeeded = true;
                        }
                        else
                        {
                            if (newRow.DisplayIndex != dbRow.DisplayIndex || newRow.Visible != dbRow.Visible || newRow.Width != dbRow.Width)
                            {
                                dbRow.Width = newRow.Width;
                                dbRow.Visible = newRow.Visible;
                                dbRow.DisplayIndex = newRow.DisplayIndex;
                                WriteNeeded = true;
                            }
                        }
                    }

                }
                else
                {
                    RefreshNeeded = true;
                }
                if (RefreshNeeded)
                {
                    db.UserColumns.RemoveRange(userColumnsDB);
                    db.UserColumns.AddRange(userColumns);
                }
                if (WriteNeeded || RefreshNeeded)
                    db.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "SaveUserColumn() " + GetInnerException(Ex), "", IdUser);
            }
            return false;


        }

        public List<UserColumn> GetUserColumn(string nameOfDGW)
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
            try
            {
                var userColumnsDB = from uc in db.UserColumns where uc.Name == nameOfDGW && uc.LoginUserId == IdUser orderby uc.ColumnIndex select uc;
                return userColumnsDB.ToList();
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetUserColumn() " + GetInnerException(Ex), "", IdUser);
            }
            return null;
        }

        public int WriteCall(DateTime datetimeStartCall)
        {
            sErr = "";
            Evitel2Context db = new Evitel2Context();
            try
            {
                Call call = new Call();
                call.DtStartCall = datetimeStartCall;
                call.LoginUserId = IdUser;
                db.Calls.Add(call);
                db.SaveChanges();
                return call.CallId;
            }
            catch (Exception Ex)
            {
                sErr = GetInnerException(Ex);
                new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "WriteCall() " + GetInnerException(Ex), "", IdUser);
            }
            return -1;
         }
    }
}

