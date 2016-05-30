<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="NotaInfo.Departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Departments</h2>
    Enter any part of the name or leave the box blank to see all names: 
    <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
    &nbsp;<asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
    <asp:ValidationSummary ID="DepartmentsValidationSummary" runat="server"
        ShowSummary="true" DisplayMode="BulletList" Style="color: Red; width: 40em;" />
    <div id="dvGrid" style="padding: 10px; width: 550px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="DepartmentsGridView" runat="server" Width="550px"
                    AutoGenerateColumns="false" Font-Names="Arial"
                    Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                    HeaderStyle-BackColor="green" AllowPaging="true" ShowFooter="true"
                    OnPageIndexChanging="DepartmentsGridView_PageIndexChanging" OnRowEditing="DepartmentsGridView_RowEditing"
                    OnRowUpdating="DepartmentsGridView_RowUpdating" OnRowCancelingEdit="DepartmentsGridView_RowCancelingEdit"
                    PageSize="10">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="DepartmentID">
                            <ItemTemplate>
                                <asp:Label ID="lblDepartmentID" runat="server"
                                    Text='<%# Eval("DepartmentID")%>'></asp:Label>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblDepartmentName" runat="server"
                                    Text='<%# Eval("Name")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDepartmentName" runat="server"
                                    Text='<%# Eval("Name")%>'></asp:TextBox>
                            </EditItemTemplate>
                          
                        </asp:TemplateField>
                         <asp:TemplateField ItemStyle-Width="100px" HeaderText="Start Date">
                            <ItemTemplate>
                                <asp:Label ID="lblStartDate" runat="server"
                                    Text='<%# Eval("StartDate")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Calendar ID="calendarStartDate" runat="server"
                                    Text='<%# Eval("StartDate")%>'></asp:Calendar>
                            </EditItemTemplate>
                          
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRemove" runat="server"
                                    CommandArgument='<%# Eval("DepartmentID")%>'
                                    OnClientClick="return confirm('Do you want to delete?')"
                                    Text="Delete" OnClick="lnkRemove_Click"></asp:LinkButton>
                            </ItemTemplate>
                           
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                    <AlternatingRowStyle BackColor="#C2D69B" />
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DepartmentsGridView" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
