<%@ Page Title="Cabins" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CabinList.aspx.cs" Inherits="CruiseReservation.CabinList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="cabinList" runat="server" DataKeyNames="CabinID" GroupItemCount="4" ItemType="CruiseReservation.Models.Cabin" SelectMethod="GetCabins">
                <EmptyDataTemplate>
                    <table>
                        <tr>
                            <td>No data was returned. </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
               <EmptyItemTemplate>
                   </td>
               </EmptyItemTemplate>
                <GroupTemplate>
                    <table>
                        <tr id="itemPlaceholderContainer" runat="server">
                            <td id="itemPlaceholder" runat="server"></td>
                        </tr>
                    </table>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="/CabinDetails.aspx?cabinID=<%#:Item.CabinID %>">
                                        <img src="/Catalog/Images/<%#: Item.ImagePath %>" width="300" height="250" style="border:solid" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="/CabinDetails.aspx?cabinID<%#: Item.CabinID %>">
                                        <span>
                                            <%#:Item.CabinType %>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Price:</b><%#: String.Format("{0:c}", Item.CabinPrice) %>
                                    </span>
                                    <br />
                                    <a href="/cabinDetails.aspx?CabinID=<%#: Item.CabinID %>">
                                    <span class="TourListItem">
                                        <b>View cabin Description</b>
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
                                    <table id="groupPlaceholderContainer" runat="server" style="width:120%">
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
