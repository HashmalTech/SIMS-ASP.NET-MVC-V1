using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_SIMS;
using BOL_SIMS;

namespace SIMS
{
    public partial class SiteMaster : MasterPage
    {
        private readonly BLLSIMS ss = new BLLSIMS();
        DataTable dtSource = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetLbl();
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    lbllogin.Visible = false;
                    lbllogout.Visible = true;
                    lblusername.Visible = true;
                    lblmenu.Visible = true;
                    TreeView1.Visible = true;
                    TreeView2.Visible = false;
                    lblusername.Text = Session["username"].ToString();
                    dtSource = GetData(Session["username"].ToString());
                    DataTable dt = GetChildData(-1);
                    foreach (DataRow dr in dt.Rows)
                    {
                        TreeNode parentNode = new TreeNode();
                        parentNode.Text = dr["menuname"].ToString();
                        parentNode.Value = dr["menuid"].ToString();
                        parentNode.NavigateUrl = dr["menulink"].ToString();
                        AddNodes(ref parentNode);
                        TreeView1.Nodes.Add(parentNode);
                        TreeView1.CollapseAll();
                    }
                }
                else
                {
                    lbllogout.Visible = false;
                    lbllogin.Visible = true;
                    lblusername.Visible = false;
                    lblmenu.Visible = true;
                    TreeView2.Visible = true;
                    TreeView1.Visible = false;

                }
            }
            else
            {
                Session.Clear();
                Session["username"] = string.Empty;
                Session["userrole"] = string.Empty;
            }
        }
        private void SetLbl()
        {
            lbllogout.Text = "Logout";
            lbllogin.Text = "Login";
            lblmenu.Text = "Menu";
        }
        private void AddNodes(ref TreeNode node)
        {
            DataTable dt = GetChildData(Convert.ToInt32(node.Value));
            foreach (DataRow row in dt.Rows)
            {
                TreeNode childNode = new TreeNode();
                childNode.Value = row["menuid"].ToString();
                childNode.Text = row["menuname"].ToString();
                childNode.NavigateUrl = row["menulink"].ToString();
                AddNodes(ref childNode);
                node.ChildNodes.Add(childNode);
            }
        }
        private DataTable GetChildData(int parentId)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("menuid", typeof(int)),
                new DataColumn("parentid",typeof(int)),
                new DataColumn("menuname"),
                new DataColumn("menulink")});

            foreach (DataRow dr in dtSource.Rows)
            {
                if (dr[1].ToString() != parentId.ToString())
                {
                    continue;
                }
                DataRow row = dt.NewRow();
                row["menuid"] = dr["menuid"];
                row["parentid"] = dr["parentid"];
                row["menuname"] = dr["menuname"];
                row["menulink"] = dr["menulink"];
                dt.Rows.Add(row);
            }

            return dt;
        }
        private DataTable GetData(String un)
        {
            TBL_view_manegerole[] mrole = ss.GetRoles(un);
            DataTable dt = new DataTable();
            dt.Columns.Add("menuid");
            dt.Columns.Add("parentid");
            dt.Columns.Add("menuname");
            dt.Columns.Add("menulink");
            if (mrole.Count() > 0)
            {
                for (int j = 0; j < mrole.Count(); j++)
                {
                    DataRow dr = dt.NewRow();
                    dr["menuid"] = mrole[j].menuid;
                    dr["menuname"] = mrole[j].menuname;
                    dr["parentid"] = mrole[j].parentid;
                    dr["menulink"] = mrole[j].menulink;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}