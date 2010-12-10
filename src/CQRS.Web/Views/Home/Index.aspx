<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CQRS.Web.Models.HomeIndexViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table>
        <tr>
            <th>Account Number</th>
            <th colspan="2"></th>
        </tr>
    <% foreach (var account in Model.BankAccounts) { %>
        <tr>
            <td><%= account.AccountNumber %></td>
            <td><%= Html.ActionLink("Edit", "Edit", new { id = account.BankAccountId }) %></td>
            <td><%= Html.ActionLink("View Transactions", "Index", "Transactions", new { id = account.BankAccountId }, null) %></td>
        </tr>
    <% } %>
    </table>

    <p>
        <%= Html.ActionLink("Add new account", "Add") %>
    </p>

</asp:Content>
