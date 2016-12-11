<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TourDetails.aspx.cs" Inherits="CruiseReservation.TourDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetails" runat="server" ItemType="CruiseReservation.Models.Tour" SelectMethod="GetTours" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#: Item.TourName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#: Item.ImagePath %>" style="border:solid; height:300px" alt="<%#: Item.TourName %>"/>
                    </td>
                    <td>&nbsp</td>
                    <td style="vertical-align:top; text-align:left;">
                        <b>Description:</b><br />&nbsp;<%#: Item.Decription %>
                        <br />
                        <span>
                            <b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %>
                        </span>
                        <br />
                        <span><b>Tour Number</b>&nbsp;<%#: Item.TourID %></span>
                        <br />
                        <a href="/AddToCart.aspx?tourID=<%#: Item.TourID %>">
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
