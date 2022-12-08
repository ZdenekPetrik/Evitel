using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelLib2.Common
{
public class ComboItem
{
    public string Text;
    public string Value;
    public int IValue { get { _ = int.TryParse(Value, out int i); return i; } }
    public ComboItem() { }
    public ComboItem(string Text, string Value) : this() { this.Text = Text; this.Value = Value; }
    public override string ToString()
    {
        return Text;
    }
}

}
