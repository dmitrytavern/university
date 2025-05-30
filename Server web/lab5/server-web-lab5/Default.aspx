<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="server_web_lab5.Default" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:TextBox ID="txtSearch" runat="server" Placeholder="Пошук по назві"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Пошук" OnClick="btnSearch_Click" />
    <br /><br />
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_POT" 
                  OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField DataField="ID_POT" HeaderText="Код" ReadOnly="True" />
            <asp:BoundField DataField="NAME_POT" HeaderText="Назва" />
            <asp:BoundField DataField="ADRES_POT" HeaderText="Адреса" />
            <asp:BoundField DataField="Tel" HeaderText="Телефон" />
            <asp:BoundField DataField="Bank" HeaderText="Банк" />
            <asp:BoundField DataField="RAS_POT" HeaderText="Рахунок" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>

    <hr />

    <asp:TextBox ID="txtName" runat="server" Placeholder="Назва"></asp:TextBox>
    <asp:TextBox ID="txtAddress" runat="server" Placeholder="Адреса"></asp:TextBox>
    <asp:TextBox ID="txtPhone" runat="server" Placeholder="Телефон"></asp:TextBox>
    <asp:TextBox ID="txtBank" runat="server" Placeholder="Банк"></asp:TextBox>
    <asp:TextBox ID="txtAccount" runat="server" Placeholder="Рахунок"></asp:TextBox>
    <asp:Button ID="btnAdd" runat="server" Text="Додати" OnClick="btnAdd_Click" />
</asp:Content>