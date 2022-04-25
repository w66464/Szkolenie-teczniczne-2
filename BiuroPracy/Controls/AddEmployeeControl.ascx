<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEmployeeControl.ascx.cs" Inherits="BiuroPracy.Controls.AddEmployeeControl" %>

<div class="form-group">
    <label class="control-label col-sm-2">Email:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Password:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtPassword" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Imie:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtName" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Nazwisko:</label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtSurName" class="form-control" runat="server"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Data urodzenia:</label>
    <div class="col-sm-10">
        <asp:Calendar ID="calendarDateOfBirth" runat="server"></asp:Calendar>
    </div>
</div>
<div class="form-group">
    <label class="control-label col-sm-2">Zawod:</label>
    <div class="col-sm-10">
        <asp:DropDownList ID="ddlProfession" class="form-control" runat="server">
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label class="control-label col-sm-2">Umowa o prace:</label>
        <div class="col-sm-10">
            <asp:DropDownList ID="ddlContractOfEmployment" class="form-control" runat="server">
            </asp:DropDownList>
        </div>
    </div>
</div>

