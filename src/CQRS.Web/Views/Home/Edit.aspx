<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CQRS.Web.Models.AccountViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit Account Name
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Account Name</h2>

    <% using (Html.BeginForm())  { %>

        <%= Html.HiddenFor(x => x.BankAccountId) %>

        <%= Html.LabelFor(x => x.AccountNumber) %>
        <%= Html.TextBoxFor(x => x.AccountNumber) %>

        <input type="submit" id="submitBtn" name="submitBtn" value="Edit Account Name" />
<% } %>

</asp:Content>
