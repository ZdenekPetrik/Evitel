using System;
using System.Configuration;
using System.Data.SqlClient;
using EvitelLib.Entity;

namespace EvitelLib.Common
{
    public class CEventLog
    {

        public string ConnectionString { get; set; }

        private int _IsConsoleWrite = 0;

        public bool IsConsoleWrite
        {
            get
            {
                return _IsConsoleWrite == 1 || _IsConsoleWrite == 0;
            }
            set
            {
                if (value)
                    _IsConsoleWrite = 1;
                else
                    _IsConsoleWrite = -1;
            }
        }

        private string _applicationName;
        public string ApplicationName
        {
            get
            {
                if (_applicationName == null)
                {
                    _applicationName = ConfigurationManager.AppSettings["AppName"];
                    if (_applicationName == null)
                        _applicationName = "<Unknown>";
                }
                return _applicationName;
            }
            set { _applicationName = value; }
        }

        public int LoginUserId;

        public CEventLog()
        {
            LoginUserId = -1;
        }

        public CEventLog(eEventCode eventCode, eEventSubCode eventSubCode, string Text)
            : this()
        {
            WriteMainEventLog(eventCode, eventSubCode, Text);
        }

        public CEventLog(eEventCode eventCode, eEventSubCode eventSubCode, string Text, string Value)
            : this()
        {
            WriteMainEventLog(eventCode, eventSubCode, Text, Value);
        }

        public CEventLog(eEventCode eventCode, eEventSubCode eventSubCode, string Text, string Value, int LoginUserId)
            : this()
        {
            WriteMainEventLog(eventCode, eventSubCode, Text, Value, LoginUserId);
        }

        public void WriteMainEventLog(string Text)
        {
            WriteMainEventLog(eEventCode.e1Message, eEventSubCode.e2Info, Text);
        }

        public void WriteMainEventLog(eEventCode e1, eEventSubCode e2, string Text)
        {
            WriteMainEventLog(DateTime.Now, e1, e2, Text, "");
        }

        public void WriteMainEventLog(eEventCode e1, eEventSubCode e2, string Text, string Value)
        {
            WriteMainEventLog(DateTime.Now, e1, e2, Text, Value);
        }

        public void WriteMainEventLog(DateTime dtEvent, eEventCode e1, eEventSubCode e2, string Text, string Value)
        {
            WriteMainEventLog(dtEvent, e1, e2, Text, Value, LoginUserId);
        }

        public void WriteMainEventLog(eEventCode e1, eEventSubCode e2, string Text, string Value, int LoginUserId)
        {
            WriteMainEventLog(DateTime.Now, e1, e2, Text, Value, LoginUserId);
        }

        public void WriteMainEventLog(DateTime dtCreate, eEventCode e1, eEventSubCode e2, string Text, string Value, int LoginUserId)
        {
            if (ConnectionString == null)
                ConnectionString = ConfigurationManager.ConnectionStrings["DBEvitel"].ToString();
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                string queryString = "INSERT dbo.MainEventLogs ([dtCreate],[Program],[LoginUserId],[eventType],[eventSubType],[Text],[Value]) VALUES (@dtCreate,@Program,@LoginUserId,@eventType,@eventSubType,@Text,@Value)";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@dtCreate", dtCreate);
                command.Parameters.AddWithValue("@LoginUserId", LoginUserId);
                AddParams(command.Parameters, "@Program", ApplicationName??"", 50);
                command.Parameters.AddWithValue("@eventType", e1);
                command.Parameters.AddWithValue("@eventSubType", e2);
                AddParams(command.Parameters, "@Text", Text??"", 4000);
                AddParams(command.Parameters, "@Value", Value??"", 4000);
                command.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("No able write to DB LOG: " + Ex.Message);
                WriteToErrFile(Ex.Message);
            }
            finally
            {
                if (IsConsoleWrite)
                    Console.WriteLine(" ->EvLog: " + e1.ToString() + "/" + e2.ToString() + ":" + Text + " / " + Value);
                connection.Close();
            }

        }

        private void AddParams(SqlParameterCollection sqlParameterCollection, string Nazev, string Value, int Size)
        {
            if (Value != null && Value.Length > Size)
                Value = Value.Substring(0, Size - 3) + "...";
            sqlParameterCollection.Add(Nazev, System.Data.SqlDbType.NVarChar, Size).Value = Value;
        }


        public void WriteToErrFile(string message)
        {
            Console.WriteLine("No able write to DB LOG: " + message);
            if (IsConsoleWrite)
            {
                using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@"Evitel-EventLog" + DateTime.Now.ToBinary().ToString() + ".err", true))
                    file.WriteLine(DateTime.Now.ToString() + " " + ApplicationName + " ---> " + message);
            }
            else
            {

            }
        }

    }
}

