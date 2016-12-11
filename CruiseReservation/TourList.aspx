﻿<%@ Page Title="Tours" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TourList.aspx.cs" Inherits="CruiseReservation.TourList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
        <hgroup>
            <h2><%: Page.Title %></h2>
        </hgroup>

        <asp:ListView ID="TourList" runat="server" DataKeyNames="TourID" GroupItemCount="4" ItemType="CruiseReservation.Models.Tour" SelectMethod="GetTours">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td/>
            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="ItemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td runat="server">
                    <table>
                        <tr>
                            <td>
                                <a href="TourDetails.aspx?tourID=<%#: Item.TourID %>">
                                    <img src="/Catalog/Images/<%#: Item.ImagePath %>" width="350" height="200" style="border: solid" />
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="TourDetails.aspx?tourID=<%#: Item.TourID %>">
                                    <span>
                                        <%#: Item.TourName %>
                                    </span>
                                </a>
                                <br />
                                <span>
                                    <b>Price: </b><%#: String.Format ("{0:c}", Item.UnitPrice) %>
                                </span>
                                <br />
                                <a href="CabinList.aspx?tourID=<%#: Item.TourID %>">
                                    <span class="TourListCabin">
                                        <b>View Cabin</b>
                                    </span>
                                </a>
                                 <a href="/AddToCart.aspx?tourID=<%#: Item.TourID %>">
                                    <span class="TourListItem">
                                        <b>Add toCart</b>
                                    </span>
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    </p>
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table style="width:100%;">
                    <tbody>
                        <tr>
                            <td>
                                <table  id="groupPlaceholderContainer" runat="server" style="width:120%">
                                    <tr id="groupPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
        </asp:ListView>
      </div>
    </section>
</asp:Content>
