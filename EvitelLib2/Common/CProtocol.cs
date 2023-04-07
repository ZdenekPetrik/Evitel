using NPOI.HSSF.Record;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static NPOI.HSSF.Util.HSSFColor;

namespace EvitelLib2.Common
{
  public static class CProtocol
  {
    public static string ProtocolName = "Protocol.pro";
    public static string FullNameProtocol { get { string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); return Path.Combine(docPath, ProtocolName); } }

    public static void Write(string Text) {
      // Set a variable to the Documents path.
      
      using (StreamWriter outputFile = new StreamWriter(FullNameProtocol,true))
      {
          outputFile.WriteLine(DateTime.Now.ToString("dd.MM HH:mm:ss")+" " + Text);
      }
    }

  }
}
