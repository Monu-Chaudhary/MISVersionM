using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MIS_VersionM.BLL;
using MIS_VersionM.ATT;

namespace MIS_VersionM
{
    public partial class EmployeeReg : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadEmployeeDetail();
            }
        }

         protected void loadEmployeeDetail()
         {
             BLLEmployee objbllRelType = new BLLEmployee(); ;
             GridView1.DataSource = objbllRelType.GetEmployee(1);
             GridView1.DataBind();
         }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridView1.SelectedRow;
            txtEmpID.Text = gr.Cells[0].Text;
            TextBox0.Text = gr.Cells[1].Text;
            TextBox1.Text = gr.Cells[2].Text;
            TextBox2.Text = gr.Cells[3].Text;
            TextBox3.Text = gr.Cells[4].Text;
            lblAction.Text = "E";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "";
            BLLEmployee objbllEmployee = new BLLEmployee();
            ATTEmployee objEmployee = new ATTEmployee();
            objEmployee.EmpID = int.Parse(txtEmpID.Text.ToString());
            objEmployee.EmpName = TextBox0.Text;
            objEmployee.EmpEmail = TextBox1.Text;
            objEmployee.EmpAddress = TextBox2.Text;
            objEmployee.EmpPhone = TextBox3.Text;

            if (lblAction.Text == "E")
            {
                objEmployee.Action = "E";
            }
            else
            {
                objEmployee.Action = "A";
            }

            msg = objbllEmployee.SaveEmployee(objEmployee);
            lblmsg.Text = msg;

            txtEmpID.Text = "";
            TextBox0.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            lblmsg.Text = "";
            lblAction.Text = "";
            lblStatusMessage.Text = "";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string msg = "";
            Object key = GridView1.DataKeys[e.RowIndex].Value;
            BLLEmployee objbllEmployee = new BLLEmployee();
            msg = objbllEmployee.DeleteEmployee(int.Parse(key.ToString()));
            lblmsg.Text = msg;
        }
    }
}