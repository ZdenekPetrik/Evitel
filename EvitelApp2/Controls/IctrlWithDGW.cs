using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvitelApp2.Controls
{
  public  interface IctrlWithDGW
  {
    public void SetColumns();
    public void InitColumns();
    public void RemoveOrders();
    public void RemoveFilters();
    public void Visibility(bool isVisible);

    public DataTable dataTable { get; }
  }
}
