using EvitelLib2;
using EvitelLib2.Common;
using EvitelLib2.Model;
using EvitelLib2.Repository;
using System.Configuration;

namespace xUnitTestEvitel2
{
  public class UnitTest1
  {
    [Fact]
    public void Test1()
    {
      double actual = 1;
      double actual2 = 2;
      Assert.Equal(actual2, actual, 2);

    }

    [Fact]
    public void PassingTest()
    {
      Assert.Equal(4, Add(2, 2));
    }

    [Fact]
    public void FailingTest()
    {
      Assert.Equal(5, Add(2, 2));
    }

    int Add(int x, int y)
    {
      return x + y;
    }

    [Fact]
    public void DB()
    {
      string path = Directory.GetCurrentDirectory();
      string? applicationName = ConfigurationManager.AppSettings["AppName"];
      CRepositoryDB db = new CRepositoryDB(-1);
      var a = db.GetNick();
    }

    [Fact]
    public void testa()
    {
      Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      if (config.AppSettings.Settings["AppName"] != null)
      {
        config.AppSettings.Settings.Remove("AppName");
      }
      config.AppSettings.Settings.Add("AppName", "kuk");
      config.Save(ConfigurationSaveMode.Modified, true);
      ConfigurationManager.RefreshSection("appSettings");
    }

    [Fact]
    public void WriteToEventLog()
    {
      new CEventLog(eEventCode.e1Message, eEventSubCode.e2Debug, "Message From Test", "123456789", -1);

    }


  }
}