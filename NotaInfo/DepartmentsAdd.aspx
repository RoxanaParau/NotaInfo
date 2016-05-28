<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentsAdd.aspx.cs" Inherits="NotaInfo.DepartmentsAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
       <h2>Departments</h2> 
    <asp:ObjectDataSource ID="DepartmentsObjectDataSource" runat="server"  
        TypeName="NotaInfo.BLL.UniversityBL" DataObjectTypeName="NotaInfo.DAL.Department"  
        InsertMethod="InsertDepartment" 
        OnInserted="DepartmentsObjectDataSource_Inserted">
    </asp:ObjectDataSource> 
    <asp:DetailsView ID="DepartmentsDetailsView" runat="server"  
        DataSourceID="DepartmentsObjectDataSource" AutoGenerateRows="False" 
        DefaultMode="Insert"> 
        <Fields> 
            <asp:DynamicField DataField="Name" HeaderText="Name" /> 
            <asp:DynamicField DataField="Budget" HeaderText="Budget" /> 
            <asp:DynamicField  DataField="StartDate" HeaderText="Start Date" /> 
            <asp:CommandField ShowInsertButton="True" /> 
        </Fields> 
    </asp:DetailsView> 
   <asp:ValidationSummary ID="DepartmentsValidationSummary" runat="server"  
        ShowSummary="true" DisplayMode="BulletList" style="color: Red"  />
</asp:Content>
