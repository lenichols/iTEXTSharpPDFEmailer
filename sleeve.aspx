<%@ Page Title="" Debug="false"  Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="sleeve.aspx.cs" Inherits="Sleeve" %>

<asp:Content ID="ContentSleevehead" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" src="https://code.jquery.com/jquery-1.11.3.js"></script>
</asp:Content>
<asp:Content ID="Content252" ContentPlaceHolderID="MainContent" Runat="Server">

	<asp:TextBox TextMode="MultiLine" value="<%= Request.Form.Get("newsig") %>"></asp:TextBox>


</asp:Content>