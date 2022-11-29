using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace EvitelApp2.MyUserControl
{
	[Description("DataGridView that Saves Column Order, Width and Visibility to user.config")]
	public class ucDataGridView : DataGridView
	{
		private string _UniqueString;
		public UserSort mySort;
		public ucDataGridView() : base()
		{
			mySort = new UserSort();
		}

		public ucDataGridView(IContainer container) : this()
		{
			container.Add(this);
		}


		public void SetColumnOrderExt(string UniqueString)
		{
			_UniqueString = UniqueString;
			SetColumnOrder();
		}

		private void SetColumnOrder()
		{
			if (!ucDataGridViewSetting.Default.ColumnOrder.ContainsKey(_UniqueString + "_"+this.Name))
				return;

			List<ColumnOrderItem> columnOrder =
				ucDataGridViewSetting.Default.ColumnOrder[_UniqueString + "_" +this.Name];

			if (columnOrder != null)
			{
				var sorted = columnOrder.OrderBy(i => i.DisplayIndex);
				foreach (var item in sorted)
				{
					this.Columns[item.ColumnIndex].DisplayIndex = item.DisplayIndex;
					this.Columns[item.ColumnIndex].Visible = item.Visible;
					this.Columns[item.ColumnIndex].Width = item.Width;
				}
			}
		}
		//---------------------------------------------------------------------
		private void SaveColumnOrder()
		{
			if (this.AllowUserToOrderColumns)
			{
				List<ColumnOrderItem> columnOrder = new List<ColumnOrderItem>();
				DataGridViewColumnCollection columns = this.Columns;
				for (int i = 0; i < columns.Count; i++)
				{
					columnOrder.Add(new ColumnOrderItem
					{
						ColumnIndex = i,
						DisplayIndex = columns[i].DisplayIndex,
						Visible = columns[i].Visible,
						Width = columns[i].Width
					});
				}

				ucDataGridViewSetting.Default.ColumnOrder[_UniqueString + "_" + this.Name] = columnOrder;
				ucDataGridViewSetting.Default.Save();
			}
		}
		//---------------------------------------------------------------------
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			SetColumnOrder();
		}
		//---------------------------------------------------------------------
		protected override void Dispose(bool disposing)
		{
			SaveColumnOrder();
			base.Dispose(disposing);
		}

        internal void SetColumnOrder(string name)
        {
        }
    }
	//-------------------------------------------------------------------------
	internal sealed class ucDataGridViewSetting : ApplicationSettingsBase
	{
		private static ucDataGridViewSetting _defaultInstace =
			(ucDataGridViewSetting)ApplicationSettingsBase
			.Synchronized(new ucDataGridViewSetting());
		//---------------------------------------------------------------------
		public static ucDataGridViewSetting Default
		{
			get { return _defaultInstace; }
		}
		//---------------------------------------------------------------------
		// Because there can be more than one DGV in the user-application
		// a dictionary is used to save the settings for this DGV.
		// As key the name of the control is used.
		[UserScopedSetting]
		[SettingsSerializeAs(SettingsSerializeAs.Binary)]
		[DefaultSettingValue("")]
		public Dictionary<string, List<ColumnOrderItem>> ColumnOrder
		{
			get { return this["ColumnOrder"] as Dictionary<string, List<ColumnOrderItem>>; }
			set { this["ColumnOrder"] = value; }
		}
	}
	//-------------------------------------------------------------------------
	[Serializable]
	public sealed class ColumnOrderItem
	{
		public int DisplayIndex { get; set; }
		public int Width { get; set; }
		public bool Visible { get; set; }
		public int ColumnIndex { get; set; }
	}
	public sealed class UserSort
	{
		public string ColumnName;
		public ListSortDirection Order = ListSortDirection.Ascending;
		public string OrderString
		{
			get
			{
				if (Order == ListSortDirection.Ascending)
					return " ASC";
				else
					return " DESC";
			}
		}
	}
}