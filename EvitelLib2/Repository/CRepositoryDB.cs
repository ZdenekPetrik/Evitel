using EvitelLib2.Common;
using EvitelLib2.Model;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.Record.AutoFilter;
using NPOI.SS.Formula.Atp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;



// Toto je třeba zapsat do OnConfiguration
/*
    if (!optionsBuilder.IsConfigured)
      {
        var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBEvitel2"].ConnectionString;
        optionsBuilder.UseSqlServer(connectionString);
      }
*/

namespace EvitelLib2.Repository
{

  public enum eModifyRow
  {
    addRow,
    modifyRow,
    deleteRow,
    undeleteRow
  }

  public class CRepositoryDB
  {

    #region Main
    public string sErr;
    private string _applicationName;
    private int _idUser;
    private DateTime MyMinDate = new DateTime(2000, 01, 01);

    public string ConnectionString { get { return (new Evitel2DB()).Database.GetDbConnection().ConnectionString; } }

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
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
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
      }
      catch (Exception Ex)
      {
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSettingS(" + Name + ").  " + GetInnerException(Ex), "", IdUser);
        sErr = GetInnerException(Ex);
      }
      return "";
    }
    public int GetSettingI(string Name)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
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
      }
      catch (Exception Ex)
      {
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSettingI(" + Name + ").  " + GetInnerException(Ex), "", IdUser);
        sErr = GetInnerException(Ex);
        return 0;
      }
      return 0;
    }

    public DateTime GetSettingD(string Name)
    {
      Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
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
    public LoginUser AddLoginUser(string firstName, string lastName, string loginName, string loginPassword)
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
        Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
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

    public bool UpdateLoginUser(LoginUser user)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        if (user.LoginUserId > 0)
        {
          var x = from lau in db.LoginAccessUsers where lau.LoginUserId == user.LoginUserId select lau;
          db.LoginAccessUsers.RemoveRange(x);
          db.LoginUsers.Update(user);
          db.Entry(user).State = EntityState.Modified;
        }
        else
        {
          user.Created = DateTime.Now;
          db.LoginUsers.Add(user);
        }
        int countUpdate = db.SaveChanges();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UpdateLoginUser() " + GetInnerException(Ex), "", IdUser);
        return false;
      }
      return true;
    }




    #endregion

    public bool Test()
    {
      return true;
    }

    public List<WMainEventLog> GetMainEventLog(string OrderBy, bool AscendingOrder, DateTime? dtFrom, DateTime? dtTo, string program, int? loginUserId, eEventCode? eventCode, eEventSubCode? eventSubCode, string text, string value)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
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
      Evitel2DB db = new Evitel2DB();
      try
      {

        var wIntervents = from i in db.WIntervents select i;
        if (RegionId != null)
          wIntervents = wIntervents.Where(x => x.RegionId == RegionId);
        if (Name.Length > 0)
          wIntervents = wIntervents.Where(x => x.Name.Contains(Name) || x.SurName.Contains(Name));
        if (Contact.Length > 0)
          wIntervents = wIntervents.Where(x => x.PrivatePhone.Contains(Name) || x.Phone.Contains(Name) || x.MobilPhone.Contains(Name) || x.Email.Contains(Name));
        wIntervents = wIntervents.OrderBy(p => p.RegionOrder).ThenBy(p => p.SurName);
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
      Evitel2DB db = new Evitel2DB();
      try
      {
        var regions = from r in db.Regions orderby r.RegionOrder select r;
        return regions.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetRegions() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<ETypeIncident> GetTypeIncident()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var typeIncident = from e in db.ETypeIncidents orderby e.TypeIncidentId select e;
        return typeIncident.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetTypeIncident() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public List<ESubTypeIncident> GetSubTypeIncident()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var subTypeIncident = from e in db.ESubTypeIncidents orderby e.TypeIncidentId select e;
        return subTypeIncident.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSubTypeIncident() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public bool InterventDeleteUnDelete(int interventId, bool isDelete)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var intervent = (from intv in db.Intervents where intv.InterventId == interventId select intv).FirstOrDefault();
        if (intervent.InterventId == interventId)
        {
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

    #region UserColumn
    public bool SaveUserColumn(string nameOfDGW, int externIdUser, List<UserColumn> userColumns)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
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
              if (newRow.DisplayIndex != dbRow.DisplayIndex || newRow.Width != dbRow.Width)
              {
                dbRow.Width = newRow.Width;
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

    public void DeleteUserColumn(string nameOfDGW, int idUser)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var userColumnsDB = from uc in db.UserColumns where uc.Name == nameOfDGW /*&& uc.LoginUserId == idUser */ orderby uc.ColumnIndex select uc;
        db.UserColumns.RemoveRange(userColumnsDB);
        db.SaveChanges();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "DeleteUserColumn() " + GetInnerException(Ex), "", IdUser);
      }
      return;

    }

    public List<UserColumn> GetUserColumn(string nameOfDGW)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var userColumnsDB = from uc in db.UserColumns where uc.Name == nameOfDGW /* && uc.LoginUserId == IdUser */ orderby uc.ColumnIndex select uc;
        return userColumnsDB.ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetUserColumn() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    #endregion

    public int WriteCall(DateTime datetimeStartCall, int callType, DateTime? dateTimeEndCall)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        Call call = new Call();
        call.DtStartCall = datetimeStartCall;
        call.DtEndCall = dateTimeEndCall;
        call.LoginUserId = IdUser;
        call.CallType = callType;
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
    public int WriteIncident(string note, int subTypeIncidentId, DateTime datetimeIncident, int regionId, string place, bool nasledekSmrti, bool dokonane, bool pokusPriprava, int PocetObeti)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        Likoincident incident = new Likoincident();
        incident.Note = note;
        incident.SubTypeIncidentEid = subTypeIncidentId;
        incident.DtIncident = datetimeIncident;
        incident.RegionId = regionId;
        incident.Place = place;
        incident.NasledekSmrti = nasledekSmrti;
        incident.Dokonane = dokonane;
        incident.PokusPriprava = pokusPriprava;
        incident.PocetPoskozenych = PocetObeti;
        db.Likoincidents.Add(incident);
        db.SaveChanges();

        return incident.LikoincidentId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "WriteIncident() " + GetInnerException(Ex), "", IdUser);
      }
      return -1;

    }
    public int WriteIntervence(DateTime datetimeStartIntervence, DateTime datetimeEndIntervence, int callId, int incidentId, string note, int value, int NrObetemPoskozenym, int NrPozustalymBlizkym, int NrOstatnimOsobam, int InterventId)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        Likointervence intervence = new Likointervence()
        {
          Note = note,
          DtStartIntervence = datetimeStartIntervence,
          DtEndIntervence = datetimeEndIntervence,
          CallId = callId,
          LikoincidentId = incidentId,
          ObetemPoskozenym = NrObetemPoskozenym,
          PozustalymBlizkym = NrPozustalymBlizkym,
          Ostatnim = NrOstatnimOsobam,
          Poradi = db.Likointervences.Where(x => x.LikoincidentId == incidentId).Count() + 1,
          InterventId = InterventId
        };
        db.Likointervences.Add(intervence);
        db.SaveChanges();

        return intervence.LikointervenceId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "WriteIntervence() " + GetInnerException(Ex), "", IdUser);
      }
      return -1;
    }


    #region Read Enums
    public List<ESex> GetSex(bool isReadAll = false)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from s in db.ESexes select s;
        if (isReadAll)
          rows.Where(x => x.DtDeleted == null);
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSex() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<ENick> GetNick()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var nick = from n in db.ENicks select n;
        return nick.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetNick() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    // NAčte číselník pro statistiku (seskupování po dne, týdnech, měsících)
    public List<EGrouping> GetGrouping()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var group = from g in db.EGroupings select g;
        return group.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetGrouping() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public int AddNick(string nick)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        ENick newRow = new ENick();
        newRow.Text = nick;
        db.ENicks.Add(newRow);
        db.SaveChanges();
        return newRow.NickId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "AddNick() " + GetInnerException(Ex), "", IdUser);
      }
      return -1;

    }

    public List<ETypeParty> GetTypeParty(bool isReadAll = false)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from tp in db.ETypeParties select tp;
        if (isReadAll)
          rows.Where(x => x.DtDeleted == null);
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetTypeParty() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<EDruhIntervence> GetDruhIntervence()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from di in db.EDruhIntervences select di;
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetDruhIntervence() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<EEndOfSpeech> GetEndOfSpeech()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from es in db.EEndOfSpeeches select es;
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetEndOfSpeech() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<ESubEndOfSpeech> GetSubEndOfSpeech()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from ess in db.ESubEndOfSpeeches.Include(x => x.EndOfSpeech) select ess;
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSubEndOfSpeech() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<EClientCurrentStatus> GetClientCurrentStatus()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from ccs in db.EClientCurrentStatuses select ccs;
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetClientCurrentStatus() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<ESubClientCurrentStatus> GetSubClientCurrentStatus()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from ess in db.ESubClientCurrentStatuses.Include(x => x.ClientCurrentStatus) select ess;
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSubClientCurrentStatus() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<EContactTopic> GetContactTopic()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from r in db.EContactTopics select r;
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetContactTopic() " + GetInnerException(Ex), "", IdUser);
      }
      return null;

    }
    public List<ESubContactTopic> GetSubContactTopic()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from ess in db.ESubContactTopics.Include(x => x.ContactTopic) select ess;
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSubContactTopic() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<EContactType> GetContactType()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from r in db.EContactTypes select r;
        rows.Where(x => x.DtDeleted == null);
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetContactType() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<EAge> GetContactAge()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from r in db.EAges select r;
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetContactAge() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<EClientFrom> GetClientFrom()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from r in db.EClientFroms select r;
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetClientFrom() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<ETypeService> GetTypeService()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from r in db.ETypeServices select r;
        return rows.AsNoTracking().ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetTypeService() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    #endregion

    public int AddParticipantObsolete(Likoparticipant newRow)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        db.Likoparticipants.Add(newRow);
        db.SaveChanges();
        return newRow.LikoparticipantId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "AddParticipant() " + GetInnerException(Ex), "", IdUser);
      }
      return -1;
    }

    // vsichni participants musí být z jedné intervence
    // Pokud přidáváš tak všechny id = 0. Takže najde jen jeden id k přidání. Ale to nevadí, protože zase si je později všechny najde
    public void UpdateParticipants(int LikointervenceId, List<Likoparticipant> participantsList)
    {

      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var oldList = GetLikoParticipants(LikointervenceId, 2).Select(x => x.LikoparticipantId).ToList();
        var toDelete = oldList.Except(participantsList.Select(x => x.LikoparticipantId)).ToList();
        var toAdd = participantsList.Select(x => x.LikoparticipantId).Except(oldList).ToList();
        var delRows = from r in db.Likoparticipants where toDelete.Contains(r.LikoparticipantId) select r;
        if (delRows.Count() > 0)
        {
          db.Likoparticipants.RemoveRange(delRows);
        }
        foreach (var row in participantsList.Where(x => toAdd.Contains(x.LikoparticipantId)))
        {
          row.LikointervenceId = LikointervenceId;
          db.Likoparticipants.Add(row);
        }
        db.SaveChanges();
        foreach (var newRow in participantsList)
        {
          var oldRow = db.Likoparticipants.Where(x => x.LikoparticipantId == newRow.LikoparticipantId).First();
          var entry = db.Entry(oldRow);
          entry.CurrentValues.SetValues(newRow);
        }
        db.SaveChanges();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UpdateParticipants() " + GetInnerException(Ex), "", IdUser);
      }
    }


    public List<WLikoparticipant> GeWLIKOParticipant(bool isDeepRead)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        return (from par in db.WLikoparticipants select par).ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLIKOParticipant() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public List<WLikocall> GetWLikoCalls()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        return (from par in db.WLikocalls orderby par.DtStartCall select par).ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetWLikoCalls() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<WCall> GetWCalls()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        return (from par in db.WCalls orderby par.DtStartCall select par).ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetWCalls() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public List<WLpk> GetWLPK()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        return (from par in db.WLpks select par).ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetWLPK() " + GetInnerException(Ex), "", IdUser);
      }
      return null;

    }

    public List<Lpk> GetLPK(int LpkId = -1)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var lpk = from l in db.Lpks orderby l.Lpkid select l;
        if (LpkId > 0)
        {
          lpk = (IOrderedQueryable<Lpk>)lpk.Where(x => x.Lpkid == LpkId);
        }
        return lpk.ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLPK() " + GetInnerException(Ex), "", IdUser);
      }
      return null;

    }


    public List<WLikoincident> GetWLIKOIncident()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        return (from par in db.WLikoincidents orderby par.DtIncident select par).ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetWLIKOIncident() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public List<WLikointervence> GetWLIKOIntervence()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        return (from par in db.WLikointervences orderby par.DtStartIntervence select par).ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetWLIKOIntervence() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public List<WLikoall> GeWtLIKOAll(bool v)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        return (from par in db.WLikoalls orderby par.DtIncident select par).ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GeWtLIKOAll() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public Likointervence GetLikoIntervence(int likoIntervenceId)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        return (from par in db.Likointervences where par.LikointervenceId == likoIntervenceId select par).FirstOrDefault();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLIKOIntervence(" + likoIntervenceId.ToString() + ") " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public Call GetCall(int id)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var row = db.Calls.Include(u => u.LoginUser).Where(x => x.CallId == id);
        row = row.Where(x => x.CallId == id);
        return row.FirstOrDefault();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLikoCall(" + id.ToString() + ") " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public Likoincident GetLikoIncident(int Id)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        return (from par in db.Likoincidents where par.LikoincidentId == Id select par).FirstOrDefault();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLikoIncident(" + Id.ToString() + ") " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }
    public List<Likoparticipant> GetLikoParticipants(int id, int TypeSearch)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var row = from r in db.Likoparticipants select r;
        if (TypeSearch == 1)
          row = row.Where(x => x.LikoparticipantId == id);
        else if (TypeSearch == 2)
          row = row.Where(x => x.LikointervenceId == id);
        return row.ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLikoParticipants(" + id.ToString() + ") " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    // Nevrací systémové účty (-1,-5), ale jen manuálně vytvořené
    public List<LoginUser> GetLoginUser()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var row = from r in db.LoginUsers.Include("LoginAccessUsers") where r.LoginUserId > 0 select r;
        return row.ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLoginUser() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public List<LoginAccess> GetLoginAccess()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from r in db.LoginAccesses select r;
        return rows.ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLoginAccess() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public int GetIncidentNextId()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        int maxId = db.Likoincidents.Max(x => x.LikoincidentId);
        return maxId + 1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetIncidentNextId() " + GetInnerException(Ex), "", IdUser);
      }
      return 0;
    }

    public bool UpdateCall(int callId, DateTime datetimeStartCall, DateTime? datetimeEndCall = null)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var oneCall = db.Calls.Where(x => x.CallId == callId).First();
        oneCall.DtStartCall = datetimeStartCall;
        if (datetimeEndCall != null)
          oneCall.DtEndCall = datetimeEndCall;
        db.SaveChanges();
        return true;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UpdateCall() " + GetInnerException(Ex), "", IdUser);
      }
      return false;

    }
    public bool UpdateIntervence(int likoIntervenceId, DateTime datetimeStartIntervence, DateTime datetimeEndIntervence, int NrObetemPoskozenym, int NrPozustalymBlizkym, int NrOstatnimOsobam, string note, int InterventId)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var oneIntervence = db.Likointervences.Where(x => x.LikointervenceId == likoIntervenceId).First();
        oneIntervence.DtStartIntervence = datetimeStartIntervence;
        oneIntervence.DtEndIntervence = datetimeEndIntervence;
        oneIntervence.Note = note;
        oneIntervence.ObetemPoskozenym = NrObetemPoskozenym;
        oneIntervence.PozustalymBlizkym = NrPozustalymBlizkym;
        oneIntervence.Ostatnim = NrOstatnimOsobam;
        oneIntervence.InterventId = InterventId;
        db.SaveChanges();
        return true;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UpdateIntervence() " + GetInnerException(Ex), "", IdUser);
      }
      return false;
    }

    public bool UpdateIncident(int likoincidentId, DateTime datetimeIncident, int subTypeIncidentId, int regionId, string note, string place, int pocetObeti, bool isDokonane, bool nasledekSmrti, bool pokusPriprava)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var oneIncident = db.Likoincidents.Where(x => x.LikoincidentId == likoincidentId).First();
        oneIncident.DtIncident = datetimeIncident;
        oneIncident.SubTypeIncidentEid = subTypeIncidentId;
        oneIncident.RegionId = regionId;
        oneIncident.Note = note;
        oneIncident.Place = place;
        oneIncident.PocetPoskozenych = pocetObeti;
        oneIncident.NasledekSmrti = nasledekSmrti;
        oneIncident.PokusPriprava = pokusPriprava;
        oneIncident.Dokonane = isDokonane;
        db.SaveChanges();
        return true;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UpdateIncident() " + GetInnerException(Ex), "", IdUser);
      }
      return false;
    }

    public void SaveChanges()
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        db.SaveChanges();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "SaveChanges() " + GetInnerException(Ex), "", IdUser);
      }

    }

    #region Add Delete Update Enum (UniversalModify)


    public int UniversalModifySex(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      ESex row = new ESex();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.ESexes.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.ESexes.Where(x => x.SexId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.ESexes.Where(x => x.SexId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.ESexes.Where(x => x.SexId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifySex() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "Sex " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : ""), IdUser);

        return row?.SexId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifySex() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifyTypeParty(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      ETypeParty row = new ETypeParty();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.ETypeParties.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.ETypeParties.Where(x => x.TypePartyId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.ETypeParties.Where(x => x.TypePartyId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.ETypeParties.Where(x => x.TypePartyId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyTypeParty() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "TypeParty " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : ""), IdUser);
        return row?.TypePartyId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyTypeParty() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifyDruhIntervence(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      EDruhIntervence row = new EDruhIntervence();
      try
      {
        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.EDruhIntervences.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.EDruhIntervences.Where(x => x.DruhIntervenceId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.EDruhIntervences.Where(x => x.DruhIntervenceId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.EDruhIntervences.Where(x => x.DruhIntervenceId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyDruhIntervence() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "DruhIntervence " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : ""), IdUser);
        return row?.DruhIntervenceId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyDruhIntervence() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;

    }

    public int UniversalModifySubTypeIncident(eModifyRow modifyRow, int id, string text, string kategorie)
    {
      sErr = "";
      string oldText = "";
      string oldText2 = "";
      Evitel2DB db = new Evitel2DB();
      ESubTypeIncident row = new ESubTypeIncident();
      try
      {
        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              row.Kategorie = kategorie;
              db.ESubTypeIncidents.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.ESubTypeIncidents.Where(x => x.SubTypeIncidentId == id).First();
              oldText = row.Text;
              oldText2 = row.Kategorie;
              row.Text = text;
              row.Kategorie = kategorie;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.ESubTypeIncidents.Where(x => x.SubTypeIncidentId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.ESubTypeIncidents.Where(x => x.SubTypeIncidentId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifySubTypeIncident() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "SubTypeIncidentId " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : "") + " Kategorie:" + kategorie + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText2 : ""), IdUser);
        return row?.SubTypeIncidentId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifySubTypeIncident() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;

    }

    public int UniversalModifyRegion(eModifyRow modifyRow, int id, string name, string shortName, string name2)
    {
      sErr = "";
      string oldText = "";
      string oldText2 = "";
      string oldText3 = "";
      Evitel2DB db = new Evitel2DB();
      Region row = new Region();
      try
      {
        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Name = name;
              row.ShortName = shortName;
              row.Name2 = name2;
              db.Regions.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.Regions.Where(x => x.RegionId == id).First();
              oldText = row.Name;
              oldText2 = row.ShortName;
              oldText3 = row.Name2;
              row.Name = name;
              row.ShortName = shortName;
              row.Name2 = name2;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyRegion() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "SubTypeIncidentId " + modifyRow.ToString() + "id = " + id.ToString(), name + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : "") + " ShortName:" + shortName + ((modifyRow == eModifyRow.modifyRow) ? "/" + oldText2 : ""), IdUser);
        return row?.RegionId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyRegion() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;

    }

    public int UniversalModifyNick(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      ENick row = new ENick();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.ENicks.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.ENicks.Where(x => x.NickId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.ENicks.Where(x => x.NickId == id).First();
              db.ENicks.Remove(row);
              break;
            }
          case eModifyRow.undeleteRow:
            {
              throw new NotImplementedException();
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyNick() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "Nick " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : ""), IdUser);

        return row?.NickId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyNick() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifyEndOfSpeech(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      EEndOfSpeech row = new EEndOfSpeech();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.EEndOfSpeeches.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.EEndOfSpeeches.Where(x => x.EndOfSpeechId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.EEndOfSpeeches.Where(x => x.EndOfSpeechId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.EEndOfSpeeches.Where(x => x.EndOfSpeechId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyEndOfSpeech() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifyEndOfSpeech " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : ""), IdUser);

        return row?.EndOfSpeechId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyEndOfSpeech() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifySubEndOfSpeech(eModifyRow modifyRow, int id, string text, int endOfSpeechId)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      ESubEndOfSpeech row = new ESubEndOfSpeech();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              row.EndOfSpeechId = endOfSpeechId;
              db.ESubEndOfSpeeches.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.ESubEndOfSpeeches.Where(x => x.SubEndOfSpeechId == id).First();
              oldText = row.Text;
              row.EndOfSpeechId = endOfSpeechId;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.ESubEndOfSpeeches.Where(x => x.SubEndOfSpeechId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.ESubEndOfSpeeches.Where(x => x.SubEndOfSpeechId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifySubEndOfSpeech() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifySubEndOfSpeech " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : ""), IdUser);

        return row?.SubEndOfSpeechId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifySubEndOfSpeech() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifySubClientCurrentStatus(eModifyRow modifyRow, int id, string text, int ClientCurrentStatusId)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      ESubClientCurrentStatus row = new ESubClientCurrentStatus();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              row.ClientCurrentStatusId = ClientCurrentStatusId;
              db.ESubClientCurrentStatuses.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.ESubClientCurrentStatuses.Where(x => x.SubClientCurrentStatusId == id).First();
              oldText = row.Text;
              row.ClientCurrentStatusId = ClientCurrentStatusId;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.ESubClientCurrentStatuses.Where(x => x.SubClientCurrentStatusId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.ESubClientCurrentStatuses.Where(x => x.SubClientCurrentStatusId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifySubClientCurrentStatus() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifySubClientCurrentStatus " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : ""), IdUser);

        return row?.SubClientCurrentStatusId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifySubClientCurrentStatus() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifyClientCurrentStatus(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      EClientCurrentStatus row = new EClientCurrentStatus();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.EClientCurrentStatuses.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.EClientCurrentStatuses.Where(x => x.ClientCurrentStatusId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.EClientCurrentStatuses.Where(x => x.ClientCurrentStatusId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.EClientCurrentStatuses.Where(x => x.ClientCurrentStatusId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyClientCurrentStatus() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifyClientCurrentStatus " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : ""), IdUser);

        return row?.ClientCurrentStatusId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyClientCurrentStatus() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifyContactTopic(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      EContactTopic row = new EContactTopic();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.EContactTopics.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.EContactTopics.Where(x => x.ContactTopicId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.EContactTopics.Where(x => x.ContactTopicId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.EContactTopics.Where(x => x.ContactTopicId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyContactTopic() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifyContactTopic " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? " <= " + oldText : ""), IdUser);
        return row.ContactTopicId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyContactTopic() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifySubContactTopic(eModifyRow modifyRow, int id, string text, int idContactTopic)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      ESubContactTopic row = new ESubContactTopic();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              row.ContactTopicId = idContactTopic;
              db.ESubContactTopics.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.ESubContactTopics.Where(x => x.SubContactTopicId == id).First();
              oldText = row.Text;
              row.ContactTopicId = idContactTopic;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.ESubContactTopics.Where(x => x.SubContactTopicId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.ESubContactTopics.Where(x => x.SubContactTopicId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifySubContactTopic() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifySubContactTopic " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "<=" + oldText : ""), IdUser);

        return row.SubContactTopicId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifySubContactTopic() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifyAge(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      EAge row = new EAge();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.EAges.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.EAges.Where(x => x.AgeId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.EAges.Where(x => x.AgeId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.EAges.Where(x => x.AgeId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyAge() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifyAge " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? " <= " + oldText : ""), IdUser);
        return row.AgeId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyAge() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifyContactType(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      EContactType row = new EContactType();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.EContactTypes.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.EContactTypes.Where(x => x.ContactTypeId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.EContactTypes.Where(x => x.ContactTypeId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.EContactTypes.Where(x => x.ContactTypeId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyContactType() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifyContactType " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? " <= " + oldText : ""), IdUser);
        return row.ContactTypeId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyContactType() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifyTypeService(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      ETypeService row = new ETypeService();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.ETypeServices.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.ETypeServices.Where(x => x.TypeServiceId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.ETypeServices.Where(x => x.TypeServiceId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.ETypeServices.Where(x => x.TypeServiceId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyTypeService() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifyTypeService " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? " <= " + oldText : ""), IdUser);
        return row.TypeServiceId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyTypeService() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    public int UniversalModifyClientFrom(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2DB db = new Evitel2DB();
      EClientFrom row = new EClientFrom();
      try
      {

        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              row.Text = text;
              db.EClientFroms.Add(row);
              break;
            }
          case eModifyRow.modifyRow:
            {
              row = db.EClientFroms.Where(x => x.ClientFromId == id).First();
              oldText = row.Text;
              row.Text = text;
              break;
            }
          case eModifyRow.deleteRow:
            {
              row = db.EClientFroms.Where(x => x.ClientFromId == id).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              row = db.EClientFroms.Where(x => x.ClientFromId == id).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyClientFrom() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifyClientFrom " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? " <= " + oldText : ""), IdUser);
        return row.ClientFromId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyClientFrom() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;
    }

    #endregion



    public Intervent GetIntervent(int id)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var rows = from r in db.Intervents where r.InterventId == id select r;
        return rows.First();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetIntervent() " + GetInnerException(Ex), "", IdUser);
      }
      return null;

    }

    public int UniversalModifyIntervent(eModifyRow modifyRow, Intervent oneRow)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();

      var entry = db.Entry(oneRow);
      entry.CurrentValues.SetValues(oneRow);
      try
      {
        switch (modifyRow)
        {
          case eModifyRow.addRow:
            {
              db.Intervents.Add(oneRow);
              break;
            }
          case eModifyRow.modifyRow:
            {
              var row = db.Intervents.Where(x => x.InterventId == oneRow.InterventId).First();
              var entry1 = db.Entry(row);
              entry1.CurrentValues.SetValues(oneRow);
              break;
            }
          case eModifyRow.deleteRow:
            {
              var row = db.Intervents.Where(x => x.InterventId == oneRow.InterventId).First();
              row.DtDeleted = DateTime.Now;
              break;
            }
          case eModifyRow.undeleteRow:
            {
              var row = db.Intervents.Where(x => x.InterventId == oneRow.InterventId).First();
              row.DtDeleted = null;
              break;
            }
          default:
            new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyIntervent() Bad enum ModifyRow", modifyRow.ToString(), IdUser);
            break;
        }
        Console.WriteLine(db.ChangeTracker.DebugView.LongView);
        db.ChangeTracker.DetectChanges();
        Console.WriteLine(db.ChangeTracker.DebugView.LongView);
        db.SaveChanges();
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifyIntervent " + modifyRow.ToString() + "id = " + oneRow.InterventId.ToString(), "", IdUser);
        return oneRow?.InterventId ?? 0;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyIntervent() " + GetInnerException(Ex), oneRow?.InterventId.ToString(), IdUser);
      }
      return -1;
    }

    public List<int> GetLPKClientCurrentStatus(int LPKId)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var ids = from r in db.LpkclientCurrentStatuses where r.Lpkid == LPKId select r.LpksubClientCurrentStatusEid ?? 0;
        return ids.ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLPKClientCurrentStatus() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public void SetLPKClientCurrentStatus(int LPKId, List<int> newList)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var oldList = GetLPKClientCurrentStatus(LPKId);
        var toDelete = oldList.Except(newList).ToList();
        var toAdd = newList.Except(oldList).ToList();
        var delRows = from r in db.LpkclientCurrentStatuses where r.Lpkid == LPKId && toDelete.Contains(r.LpksubClientCurrentStatusEid ?? 0) select r;
        if (delRows.Count() > 0)
        {
          db.LpkclientCurrentStatuses.RemoveRange(delRows);
        }
        foreach (int id in toAdd)
        {
          LpkclientCurrentStatus newRow = new LpkclientCurrentStatus();
          newRow.Lpkid = LPKId;
          newRow.LpksubClientCurrentStatusEid = id;
          db.LpkclientCurrentStatuses.Add(newRow);
        }
        db.SaveChanges();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "SetLPKClientCurrentStatus() " + GetInnerException(Ex), "", IdUser);
      }
    }

    public List<int> GetLPKContactTopic(int LPKId)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var ids = from r in db.LpksubContactTopics where r.Lpkid == LPKId select r.LpksubContactTopicEid ?? 0;
        return ids.ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLPKContactTopic() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public void SetLPKContactTopic(int LPKId, List<int> newList)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var oldList = GetLPKContactTopic(LPKId);
        var toDelete = oldList.Except(newList).ToList();
        var toAdd = newList.Except(oldList).ToList();
        var delRows = from r in db.LpksubContactTopics where r.Lpkid == LPKId && toDelete.Contains(r.LpksubContactTopicEid ?? 0) select r;
        if (delRows.Count() > 0)
        {
          db.LpksubContactTopics.RemoveRange(delRows);
        }
        foreach (int id in toAdd)
        {
          LpksubContactTopic newRow = new LpksubContactTopic();
          newRow.Lpkid = LPKId;
          newRow.LpksubContactTopicEid = id;
          db.LpksubContactTopics.Add(newRow);
        }
        db.SaveChanges();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "SetLPKcontactTopic() " + GetInnerException(Ex), "", IdUser);
      }
    }

    public List<int> GetLPKEndOfSpeech(int LPKId)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var ids = from r in db.LpksubEndOfSpeeches where r.Lpkid == LPKId select r.LpksubEndOfSpeechEid ?? 0;
        return ids.ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLPKEndOfSpeech() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public void SetLPKEndOfSpeech(int LPKId, List<int> newList)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var oldList = GetLPKEndOfSpeech(LPKId);
        var toDelete = oldList.Except(newList).ToList();
        var toAdd = newList.Except(oldList).ToList();
        var delRows = from r in db.LpksubEndOfSpeeches where r.Lpkid == LPKId && toDelete.Contains(r.LpksubEndOfSpeechEid ?? 0) select r;
        if (delRows.Count() > 0)
        {
          db.LpksubEndOfSpeeches.RemoveRange(delRows);
        }
        foreach (int id in toAdd)
        {
          LpksubEndOfSpeech newRow = new LpksubEndOfSpeech();
          newRow.Lpkid = LPKId;
          newRow.LpksubEndOfSpeechEid = id;
          db.LpksubEndOfSpeeches.Add(newRow);
        }
        db.SaveChanges();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "SetLPKEndOfSpeech() " + GetInnerException(Ex), "", IdUser);
      }
    }


    public int WriteRowLPK(Lpk row)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        db.Lpks.Add(row);
        db.SaveChanges();
        return row.Lpkid;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "WriteRowLPK() " + GetInnerException(Ex), "", IdUser);
      }
      return -1;
    }

    public int UpdateLPK(Lpk lpkRow)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();

      try
      {
        var row = db.Lpks.Where(x => x.Lpkid == lpkRow.Lpkid).First();
        var entry = db.Entry(row);
        entry.CurrentValues.SetValues(lpkRow);

        var x1 = db.ChangeTracker.DebugView.LongView;
        db.ChangeTracker.DetectChanges();
        var x2 = db.ChangeTracker.DebugView.LongView;
        db.SaveChanges();
        return lpkRow.Lpkid;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UpdateLPK() " + GetInnerException(Ex), lpkRow.Lpkid.ToString(), IdUser);
      }
      return -1;

    }

    public Lpk GetLastNickFromLPK(string nick)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var r = from lpk in db.Lpks where lpk.Nick == nick orderby lpk.Lpkid descending select lpk;
        return r.FirstOrDefault();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetLastNick() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public int DeleteLPKRow(int lPKId)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var lpkRows = from lpk in db.Lpks where lpk.Lpkid == lPKId select lpk;
        if (!lpkRows.Any())
          return -1;
        var lpkRow = lpkRows.First();
        var callRow = from call in db.Calls where call.CallId == lpkRow.CallId select call;
        var clientCurrentStatusRows = from clientCurrentStatus in db.LpkclientCurrentStatuses where clientCurrentStatus.Lpkid == lPKId select clientCurrentStatus;
        var subContactTopicRows = from contactTopic in db.LpksubContactTopics where contactTopic.Lpkid == lPKId select contactTopic;
        var endOfSpeechRows = from endOfSpeech in db.LpksubEndOfSpeeches where endOfSpeech.Lpkid == lPKId select endOfSpeech;
        db.LpkclientCurrentStatuses.RemoveRange(clientCurrentStatusRows);
        db.LpksubContactTopics.RemoveRange(subContactTopicRows);
        db.LpksubEndOfSpeeches.RemoveRange(endOfSpeechRows);
        db.Lpks.Remove(lpkRow);
        db.Calls.RemoveRange(callRow);
        db.SaveChanges();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "DeleteLPKRow() " + GetInnerException(Ex), "", IdUser);
        return 0;
      }
      return 1;

    }

    public int DeleteSkiRow(int IntervenceId)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var intervenceRow = (from par in db.Likointervences where par.LikointervenceId == IntervenceId select par).First();
        if (intervenceRow == null)
        {
          sErr = "Neexistuje intervence id = " + IntervenceId.ToString();
          return -1;
        }
        var incidentRow = (from par in db.Likoincidents where par.LikoincidentId == intervenceRow.LikoincidentId select par).First();
        var intervences = (from par in db.Likointervences where par.LikoincidentId == intervenceRow.LikoincidentId select par);
        var callRow = from call in db.Calls where call.CallId == intervenceRow.CallId select call;
        var participants = from par in db.Likoparticipants where par.LikointervenceId == intervenceRow.LikointervenceId select par;
        bool isDeleteIncident = (intervences.Count() == 1);
        db.Likoparticipants.RemoveRange(participants);
        db.SaveChanges();

        db.Calls.RemoveRange(callRow);
        db.Likointervences.Remove(intervenceRow);
        if (isDeleteIncident)
          db.Likoincidents.Remove(incidentRow);
        db.SaveChanges();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "DeleteSkiRow() " + GetInnerException(Ex), "", IdUser);
        return 0;
      }
      return 1;

    }

    public int DeleteCallRow(int callId)
    {
      sErr = "";
      Evitel2DB db = new Evitel2DB();
      try
      {
        var row = (from par in db.Calls where par.CallId == callId select par).First();
        if (row == null)
        {
          sErr = "Neexistuje Call id = " + callId.ToString();
          return -1;
        }
        db.Calls.Remove(row);
        db.SaveChanges();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "DeleteCallRow() " + GetInnerException(Ex), "", IdUser);
        return 0;
      }
      return 1;
    }
  }
}

