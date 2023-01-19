using EvitelLib2.Common;
using EvitelLib2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NPOI.POIFS.FileSystem;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


// Toto je třeba zapsat do OnConfiguration
/*
 var connectionString = ConfigurationManager.ConnectionStrings["DBEvitel2"].ConnectionString;
 optionsBuilder.UseSqlServer(connectionString);
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

    public bool UpdateLoginUser(LoginUser user)
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
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

        var wIntervents = from i in db.WIntervents select i;
        if (RegionId != null)
          wIntervents = wIntervents.Where(x => x.RegionId == RegionId);
        if (Name.Length > 0)
          wIntervents = wIntervents.Where(x => x.Name.Contains(Name) || x.SurName.Contains(Name));
        if (Contact.Length > 0)
          wIntervents = wIntervents.Where(x => x.PrivatePhone.Contains(Name) || x.Phone.Contains(Name) || x.MobilPhone.Contains(Name) || x.Email.Contains(Name));
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
    public List<ESubTypeIncident> GetSubTypeIncident()
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
      try
      {
        var subTypeIncident = from e in db.ESubTypeIncidents orderby e.TypeIncidentId select e;
        return subTypeIncident.ToList();
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
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();
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

    public int WriteIncident(string note, int subTypeIncidentId, DateTime datetimeIncident, int regionId, string place, bool nasledekSmrti, bool dokonane, bool pokusPriprava, int PocetObeti)
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();
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

    public List<ESex> GetSex()
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
      try
      {
        var sex = from s in db.ESexes select s;
        return sex.ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetSex() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public int AddSex(ESex sexRow)
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
      try
      {
        db.ESexes.Add(sexRow);
        db.SaveChanges();
        return sexRow.SexId;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "AddSex() " + GetInnerException(Ex), "", IdUser);
      }
      return -1;
    }


    public List<ETypeParty> GetTypeParty()
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
      try
      {
        var typeParty = from tp in db.ETypeParties select tp;
        return typeParty.ToList();
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
      Evitel2Context db = new Evitel2Context();
      try
      {
        var druhIntervence = from di in db.EDruhIntervences select di;
        return druhIntervence.ToList();
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "GetDruhIntervence() " + GetInnerException(Ex), "", IdUser);
      }
      return null;
    }

    public int AddParticipant(Likoparticipant newRow)
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
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

    public List<WLikoparticipant> GeWtLIKOParticipant(bool isDeepRead)
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();
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

    public List<WLikoincident> GetWLIKOIncident()
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();
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

    public Likointervence GetLikoIntervence(int likoIntervenceId)
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
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
    public Call GetLikoCall(int id)
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();
      try
      {
        var row = from r in db.Likoparticipants select r;
        if (TypeSearch == 1)
          row = row.Where(x => x.LikoparticipantId == id);
        else
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
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();
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

    public bool UpdateCall(int callId, DateTime datetimeStartCall)
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
      try
      {
        var oneCall = db.Calls.Where(x => x.CallId == callId).First();
        oneCall.DtStartCall = datetimeStartCall;
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
    public bool UpdateIntervence(int likoIntervenceId, DateTime datetimeStartIntervence, DateTime datetimeEndIntervence, int NrObetemPoskozenym, int NrPozustalymBlizkym, int NrOstatnimOsobam, string note)
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
      try
      {
        var oneIntervence = db.Likointervences.Where(x => x.LikointervenceId == likoIntervenceId).First();
        oneIntervence.DtStartIntervence = datetimeStartIntervence;
        oneIntervence.DtEndIntervence = datetimeEndIntervence;
        oneIntervence.Note = note;
        oneIntervence.ObetemPoskozenym = NrObetemPoskozenym;
        oneIntervence.PozustalymBlizkym = NrPozustalymBlizkym;
        oneIntervence.Ostatnim = NrOstatnimOsobam;
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
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();
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

    public int UniversalModifySex(eModifyRow modifyRow, int id, string text)
    {
      sErr = "";
      string oldText = "";
      Evitel2Context db = new Evitel2Context();
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
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "Sex " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "/" + oldText : ""), IdUser);

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
      Evitel2Context db = new Evitel2Context();
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
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "TypeParty " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "/" + oldText : ""), IdUser);
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
      Evitel2Context db = new Evitel2Context();
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
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "DruhIntervence " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "/" + oldText : ""), IdUser);
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
      Evitel2Context db = new Evitel2Context();
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
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "SubTypeIncidentId " + modifyRow.ToString() + "id = " + id.ToString(), text + ((modifyRow == eModifyRow.modifyRow) ? "/" + oldText : "") + " Kategorie:" + kategorie + ((modifyRow == eModifyRow.modifyRow) ? "/" + oldText2 : ""), IdUser);
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
      Evitel2Context db = new Evitel2Context();
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
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "SubTypeIncidentId " + modifyRow.ToString() + "id = " + id.ToString(), name + ((modifyRow == eModifyRow.modifyRow) ? "/" + oldText : "") + " ShortName:" + shortName + ((modifyRow == eModifyRow.modifyRow) ? "/" + oldText2 : ""), IdUser);
        return row?.RegionId ?? -1;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyRegion() " + GetInnerException(Ex), id.ToString(), IdUser);
      }
      return -1;

    }

    public Intervent GetIntervent(int id)
    {
      sErr = "";
      Evitel2Context db = new Evitel2Context();
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
      Evitel2Context db = new Evitel2Context();

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
        new CEventLog(eEventCode.e1DBChange, eEventSubCode.e2CodeBook, "UniversalModifyIntervent " + modifyRow.ToString() + "id = " + oneRow.InterventId.ToString(),"", IdUser);
        return oneRow?.InterventId ?? 0;
      }
      catch (Exception Ex)
      {
        sErr = GetInnerException(Ex);
        new CEventLog(eEventCode.e1Message, eEventSubCode.e2Error, "UniversalModifyIntervent() " + GetInnerException(Ex), oneRow?.InterventId.ToString(), IdUser);
      }
      return -1;
    }
  }
}

