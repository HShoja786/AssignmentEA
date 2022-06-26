<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="testEA.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Student Registration Page</h3>
            <table>
              <tr>
                  <td>Name</td>
                  <td><asp:TextBox runat="server" ID="txtname" placeholder="Enter Name"></asp:TextBox></td>
              </tr>
                              <tr>
                  <td>Email</td>
                                  <td><asp:TextBox runat="server" ID="txtemail" placeholder="Enter Email"></asp:TextBox></td>
              </tr>
                              <tr>
                  <td>Secion</td>
                                  <td><asp:TextBox runat="server" ID="txtsection" placeholder="Enter Section"></asp:TextBox></td>
              </tr>

            </table>
            <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
            <hr />
            <asp:DataGrid runat="server" ID="dgData" Width="625px"></asp:DataGrid>
        </div>
    </form>
</body>
</html>
