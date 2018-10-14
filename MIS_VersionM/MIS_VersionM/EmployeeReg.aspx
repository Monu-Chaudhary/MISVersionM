<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeReg.aspx.cs" Inherits="MIS_VersionM.EmployeeReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style
        {
            color: #497496;
            white-space: nowrap;
        }
        ::placeholder
        {
            color: #afb4bc;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblStatusMessage" runat="server"></asp:Label>
        <asp:Label ID="lblAction" runat="server"></asp:Label>
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <table class="" style="width:61%;">
        <tr>
            <td class="style">Employee ID</td>
            <td> <asp:TextBox ID="txtEmpID" runat="server"  placeholder="Employee ID"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style">Employee Name</td>
            <td> <asp:TextBox ID="TextBox0" runat="server"  placeholder="Employee Name"  ></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style">Employee Email</td>
            <td> <asp:TextBox ID="TextBox1" runat="server"  placeholder="example@domain.com"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style">Employee Address</td>
            <td> <asp:TextBox ID="TextBox2" runat="server"  placeholder="Employee Address"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style">Employee Phone</td>
            <td> <asp:TextBox ID="TextBox3" runat="server" placeholder="Employee Phone"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnSave" runat="server" Text="Save"  
                    style="background-color:#4CAF50; padding:10px 16px 10px 16px ; border:none; color:White; margin:12px; font-size:medium" 
                    onclick="btnSave_Click"/></td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
            EnableModelValidation="true" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onrowdeleting="GridView1_RowDeleting" DataKeyNames="EmpID">
    <Columns> 
        <asp:BoundField DataField="EmpID" HeaderText="EmpID" Visible="true" />
        <asp:BoundField DataField="EmpName" HeaderText="EmpName" Visible="true" />
        <asp:BoundField DataField="EmpEmail" HeaderText="EmpEmail" Visible="true" />
        <asp:BoundField DataField="EmpAddress" HeaderText="EmpAddress" Visible="true" />
        <asp:BoundField DataField="EmpPhone" HeaderText="EmpPhone" Visible="true" />
        <asp:BoundField DataField="Action" HeaderText="Action" Visible="false"/>
        <asp:CommandField ShowSelectButton="true"/>
        <asp:ButtonField ButtonType="Link" CommandName="Delete" HeaderText="Action" Text="Delete"/>
    </Columns>
    </asp:GridView>
    <%--<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" 
            EnableModelValidation="true" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onrowdeleting="GridView1_RowDeleting">
            </asp:GridView>--%>
    </div>
    
    <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:MIS_VersionMConnectionString %>" 
        SelectCommand="SELECT * FROM [Employee]"></asp:SqlDataSource>--%>
    </form>
</body>
</html>
