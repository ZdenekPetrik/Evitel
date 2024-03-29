﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelApp2.Helper
{
  public class MyColumn
  {
    public string Name { get; set; }
    public string DataPropertyName { get; set; }
    public bool isVisible { get; set; }
    public bool isReadOnly { get; set; }
    public int Type { get; set; }
    public MyColumn()
    {
      isVisible = true;
      isReadOnly = false;
      Type = 1;   // z nedostatku invence 1 = Text, 2 = bool, 3 = Combo, 5=DateTime, 11 = ID, 12 = dtDeteled
    }
    public Type GetMyType()
    {
      switch (Type)
      {
        case 1:
          return typeof(string);
        case 2:
          return typeof(bool);
        case 3:
          return typeof(int);
        case 4:
          return typeof(int);
        case 5:
          return typeof(DateTime);
        case 6:
          return typeof(TimeSpan);
        case 11:
          return typeof(int);
        case 12:
          return typeof(DateTime);
      }
      return typeof(string);
    }
  }
}
