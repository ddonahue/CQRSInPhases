<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CQRS.Web.Models.TransactionViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add New Transaction
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add New Transaction</h2>

    <% using (Html.BeginForm())  { %>

        <%= Html.LabelFor(x => x.Amount) %>
        <%= Html.TextBoxFor(x => x.Amount)%><br /><br />

        <%= Html.LabelFor(x => x.TransactionDate) %>
        <%= Html.TextBoxFor(x => x.TransactionDate) %><br /><br />

        <%= Html.LabelFor(x => x.Description) %>
        <%= Html.TextBoxFor(x => x.Description) %><br /><br />

        <input type="submit" id="submitBtn" name="submitBtn" value="Add New Transaction" />
    <% } %>

</asp:Content>
