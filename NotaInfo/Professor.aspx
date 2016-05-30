<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Professor.aspx.cs" Inherits="NotaInfo.Professor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Professors</h2>
    Enter any part of the name or leave the box blank to see all names: 
    <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
    &nbsp;<asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" />
    <asp:ValidationSummary ID="ProfessorsValidationSummary" runat="server"
        ShowSummary="true" DisplayMode="BulletList" Style="color: Red; width: 40em;" />
    <div id="dvGrid" style="padding: 10px; width: 550px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="ProfessorsGridView" runat="server" Width="550px"
                    AutoGenerateColumns="false" Font-Names="Arial"
                    Font-Size="11pt" AlternatingRowStyle-BackColor="#C2D69B"
                    HeaderStyle-BackColor="green" AllowPaging="true" ShowFooter="true"
                    OnRowEditing="ProfessorsGridView_RowEditing"
                    OnRowUpdating="ProfessorsGridView_RowUpdating" OnRowCancelingEdit="ProfessorsGridView_RowCancelingEdit"
                    PageSize="10" OnRowDataBound="ProfessorsGridView_RowDataBound">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="ProfessorID">
                            <ItemTemplate>
                                <asp:Label ID="lblProfessorID" runat="server"
                                    Text='<%# Eval("UserID")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="First Name">
                            <ItemTemplate>
                                <asp:Label ID="lblProfessorFirstName" runat="server"
                                    Text='<%# Eval("FirstName")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProfessorFirstName" runat="server"
                                    Text='<%# Eval("FirstName")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewProfFirstName" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label ID="lblProfessorLastName" runat="server"
                                    Text='<%# Eval("LastName")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProfessorLastName" runat="server"
                                    Text='<%# Eval("LastName")%>'></asp:TextBox>
                            </EditItemTemplate>
                              <FooterTemplate>
                                <asp:TextBox ID="txtNewProfLastName" runat="server"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Start Date">
                            <ItemTemplate>
                                <asp:Label ID="lblStartDate" runat="server"
                                    Text='<%# Eval("HireDate")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Calendar ID="calendarStartDate" runat="server"
                                    Text='<%# Eval("HireDate")%>' SelectedDate='<%# Eval("HireDate")%>'></asp:Calendar>
                            </EditItemTemplate>
                              <FooterTemplate>
                                <asp:Calendar ID="cNewProfHireDate" runat="server"></asp:Calendar>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-Width="100px" HeaderText="Labs">
                            <ItemTemplate>
                                <asp:Label ID="lblLabs" runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBoxList ID="chkLabs" runat="server"></asp:CheckBoxList>

                            </EditItemTemplate>
                             <FooterTemplate>
                                <asp:CheckBoxList ID="chkLabsNewProf" runat="server"></asp:CheckBoxList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkRemove" runat="server"
                                    CommandArgument='<%# Eval("UserID")%>'
                                    OnClientClick="return confirm('Do you want to delete?')"
                                    Text="Delete" OnClick="lnkRemove_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"/>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                    <AlternatingRowStyle BackColor="#C2D69B" />
                </asp:GridView>
            
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ProfessorsGridView" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
