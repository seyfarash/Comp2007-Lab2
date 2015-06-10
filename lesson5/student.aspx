<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="lesson5.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add Student</h1>
    <h5>All fields required</h5>
    <div>
        <fieldset>
            <label for="txtLastName" class="col-sm-2">Last Name:</label>
            <asp:TextBox ID="txtLastName" runat="server" required MaxLength="50"></asp:TextBox>
        </fieldset>
        <fieldset>
            <label for="txtFirstMidName" class="col-sm-2">First Name:</label>
            <asp:TextBox ID="txtFirstMidName" runat="server" required MaxLength="50"></asp:TextBox>
        </fieldset>
        <fieldset>
            <label for="txtEnrollmentDate" class="col-sm-2">Enrollment Date:</label>
            <asp:TextBox ID="txtEnrollmentDate" runat="server" required TextMode="Date"></asp:TextBox>
            <asp:RangeValidator ID="dateValidate" runat="server" ErrorMessage="Must Be A Date" ControlToValidate="txtEnrollmentDate" CssClass="alert alert-danger" Type="Date" MinimumValue="01/01/2000" MaximumValue="12/31/2999"></asp:RangeValidator>
        </fieldset>
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>
