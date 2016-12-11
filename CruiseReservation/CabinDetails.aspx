<%@ Page Title="Cabin Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CabinDetails.aspx.cs" Inherits="CruiseReservation.CabinDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="cabinDetail" runat="server" ItemType="CruiseReservation.Models.Cabin" SelectMethod="GetCabinDetail" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.CabinType %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#: Item.ImageDesc %>" style="border:solid; height:300px" alt="<%#: Item.CabinType %>"/>
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align:left;">
                        <b>Description:</b><br /><%#: Item.Description %>
                        <br /><br />
                        <span>
                            <b>Price:</b>&nbsp;<%#: string.Format ("{0:c}", Item.CabinPrice) %>
                        </span>
                        <br /><br />
                         <a href="/AddToCart.aspx?tourID=<%#: Item.CabinID %>">
                                    <span class="TourListItem">
                                        <b>Add toCart</b>
                                    </span>
                                </a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
