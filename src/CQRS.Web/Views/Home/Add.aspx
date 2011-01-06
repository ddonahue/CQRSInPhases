<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CQRS.Web.Models.AccountViewModel>" %>

<asp:Content ID="addTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Add New Account
</asp:Content>

<asp:Content ID="addContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add New Account</h2>

    <% using (Html.BeginForm())  { %>

        <%= Html.LabelFor(x => x.AccountNumber) %>
        <%= Html.TextBoxFor(x => x.AccountNumber) %>

        <%= Html.LabelFor(x => x.EmailAddress) %>
        <%= Html.TextBoxFor(x => x.EmailAddress)%>

        <input type="submit" id="submitBtn" name="submitBtn" value="Add New Account" />
    <% } %>>
    
    
</asp:Content>
