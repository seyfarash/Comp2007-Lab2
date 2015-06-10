<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="department.aspx.cs" Inherits="lesson5.department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add Department</h1>
    <h5>All fields required</h5>
    <div>
        <fieldset>
            <label for="txtDepartment" class="col-sm-2">Department:</label>
            <asp:TextBox ID="txtDepartment" runat="server" required MaxLength="50"></asp:TextBox>
        </fieldset>
        <fieldset>
            <label for="txtBudget" class="col-sm-2">Budget:</label>
            <asp:TextBox ID="txtBuget" runat="server" required MaxLength="50"></asp:TextBox>
            <asp:RangeValidator ID="budgetValidate" ControlToValidate="txtBuget" MinimumValue="0" MaximumValue="9999999999" ErrorMessage="Enter Only Positive Numbers Please" runat="server"></asp:RangeValidator>
        </fieldset>
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>

