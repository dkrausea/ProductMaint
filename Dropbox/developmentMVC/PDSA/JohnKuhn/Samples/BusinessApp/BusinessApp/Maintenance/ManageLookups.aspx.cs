using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessApp.BusinessLayer.LookupTables;

namespace BusinessApp.Maintenance
{
   public partial class ManageLookups : Page, ILookupValueEntry
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!this.IsPostBack)
         {
            this.RefreshGrid = true;
            this.BindTableDropDown();
         }
      }

      private void BindTableDropDown()
      {
         LookupTableManager manager = new LookupTableManager();
         ddlReferenceTables.DataTextField = "Value";
         ddlReferenceTables.DataValueField = "Key";
         ddlReferenceTables.DataSource = manager.GetTables();
         ddlReferenceTables.DataBind();
         ddlReferenceTables.Items.Insert(0, new ListItem("[Select One]", string.Empty));
      }

      protected void btnSave_Click(object sender, EventArgs e)
      {
         LookupTableManager manager = new LookupTableManager();
         manager.Save(this);
         this.RefreshGrid = true;
         mEditPanel.Visible = false;
         mButtonPanel.Visible = false;
         mFilterPanel.Visible = true;
      }

      protected void btnCancel_Click(object sender, EventArgs e)
      {
         mEditPanel.Visible = false;
         mButtonPanel.Visible = false;
         mFilterPanel.Visible = true;
      }

      protected void lnkRefresh_Click(object sender, EventArgs e)
      {
         this.TableName = ddlReferenceTables.SelectedValue;
         this.RefreshGrid = true;
      }

      protected void lnkAdd_Click(object sender, EventArgs e)
      {
         LookupTableManager manager = new LookupTableManager();
         manager.Add(this);
         mEditPanel.Visible = true;
         mButtonPanel.Visible = true;
         mFilterPanel.Visible = false;
      }

      protected void lnkFilterReset_Click(object sender, EventArgs e)
      {
         ddlReferenceTables.SelectedValue = string.Empty;
      }

      protected void mGridView_RowCommand(object sender, GridViewCommandEventArgs e)
      {
         LookupTableManager manager = new LookupTableManager();

         this.PrimaryKey = Convert.ToInt32(e.CommandArgument);

         if (e.CommandName == "select")
         {
            manager.Edit(this);
            mEditPanel.Visible = true;
            mButtonPanel.Visible = true;
            mFilterPanel.Visible = false;
         }
         else if (e.CommandName == "remove")
         {
            manager.Delete(this.TableName, this.PrimaryKey);
            this.RefreshGrid = true;
         }
      }

      protected void mObjectDataSource_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
      {
         ((LookupTableManager)e.ObjectInstance).SetFilters(this.TableName);
      }

      public bool RefreshGrid { get; set; }

      private void BindGrid()
      {
         mGridView.SelectedIndex = -1;
         mGridView.PageIndex = 0;
         mGridView.DataSourceID = mObjectDataSource.ID;
      }

      protected override void OnPreRender(EventArgs e)
      {
         base.OnPreRender(e);
         if (this.RefreshGrid) this.BindGrid();
      }

      #region ViewState Properties

      private const string VS_KEY_IS_NEW_ENTRY = "VS_KEY_IS_NEW_ENTRY";

      public bool IsNewEntry
      {
         get
         {
            if (ViewState[VS_KEY_IS_NEW_ENTRY] == null) ViewState[VS_KEY_IS_NEW_ENTRY] = false;
            return (bool)ViewState[VS_KEY_IS_NEW_ENTRY];
         }
         set
         {
            ViewState[VS_KEY_IS_NEW_ENTRY] = value;
         }
      }

      private const string VS_KEY_PRIMARY_KEY = "VS_KEY_PRIMARY_KEY";

      public int PrimaryKey
      {
         get
         {
            if (ViewState[VS_KEY_PRIMARY_KEY] == null) ViewState[VS_KEY_PRIMARY_KEY] = -1;
            return Convert.ToInt32(ViewState[VS_KEY_PRIMARY_KEY]);
         }
         set
         {
            ViewState[VS_KEY_PRIMARY_KEY] = value;
         }
      }

      private const string VS_KEY_CONCURRENCY = "VS_KEY_CONCURRENCY";

      public short ConcurrencyValue
      {
         get
         {
            if (ViewState[VS_KEY_CONCURRENCY] == null) ViewState[VS_KEY_CONCURRENCY] = -1;
            return Convert.ToInt16(ViewState[VS_KEY_CONCURRENCY]);
         }
         set
         {
            ViewState[VS_KEY_CONCURRENCY] = value;
         }
      }

      private const string VS_KEY_TABLE = "VS_KEY_TABLE";

      public string TableName
      {
         get
         {
            if (ViewState[VS_KEY_TABLE] == null) ViewState[VS_KEY_TABLE] = string.Empty;
            return ViewState[VS_KEY_TABLE].ToString();
         }
         set
         {
            ViewState[VS_KEY_TABLE] = value;
         }
      }

      public string ErrorMessageStyle
      {
         get { return "error"; }
      }

      public string NormalMessageStyle
      {
         get { return "message"; }
      }

      #endregion

      #region ILookupValueEntry Implementation

      public string CodeValue
      {
         get
         {
            return txtCode.Text;
         }
         set
         {
            txtCode.Text = value;
         }
      }

      public string DisplayValue
      {
         get
         {
            return txtDisplay.Text;
         }
         set
         {
            txtDisplay.Text = value;
         }
      }

      public string ValueDescription
      {
         get
         {
            return txtDescription.Text;
         }
         set
         {
            txtDescription.Text = value;
         }
      }

      public string DisplayOrder
      {
         get
         {
            return txtDisplayOrder.Text;
         }
         set
         {
            txtDisplayOrder.Text = value;
         }
      }

      public bool IsActive
      {
         get
         {
            return chkActive.Checked;
         }
         set
         {
            chkActive.Checked = value;
         }
      }

      public string LoginName
      {
         get
         {
            return Page.User.Identity.Name;
         }
      }

      #endregion
   }
}