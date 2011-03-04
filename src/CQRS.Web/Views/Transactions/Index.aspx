<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CQRS.Web.Models.TransactionsIndexViewModel>" %>
<%@ Import Namespace="System.Linq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Transactions
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Transactions For <%= Model.Account.AccountNumber %>:</h2>

    <table>
        <tr>
            <th>Date</th>
            <th>Description</th>
            <th>Debits</th>
            <th>Credits</th>            
            <th></th>            
        </tr>
        <% foreach (var transaction in Model.Transactions) { %>
            <tr>
                <td><%= transaction.TransactionDate.ToShortDateString() %></td>
                <td><%= transaction.Description %></td>
                <td><%= (transaction.Amount < 0) ? transaction.Amount.ToString("C") : string.Empty%></td>
                <td><%= (transaction.Amount > 0) ? transaction.Amount.ToString("C") : string.Empty%></td>
                <td><%= Html.ActionLink("Edit", "Edit", new { id = transaction.TransactionId } ) %></td>
            </tr>
        <% } %>
        <tr>
            <th colspan="4" style="text-align:right;">Balance: <%= Model.Transactions.Sum(x => x.Amount).ToString("C") %></th>
            <th></th>
        </tr>
    </table>

    <% if (!Model.Account.Locked) { %>
    <p>
        <%=Html.ActionLink("Add transaction", "Add", new {id = Model.Account.BankAccountId})%>
    </p>
    <% } else {%>
        <span class="error">ACCOUNT LOCKED</span>
    <% } %>

</asp:Content>
