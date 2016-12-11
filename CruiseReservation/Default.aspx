<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CruiseReservation._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <h2>Carnival Corporation is an American-British cruise company and the world's largest travel leisure company .</h2>
    <div id="TitleContent1" style="text-align:center">
            <a runat="server" href="~/">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Catalog/Images/carnival-cruise-ships.jpg" BorderStyle="None" />
            </a>
            <br />
    </div>
</asp:Content>
