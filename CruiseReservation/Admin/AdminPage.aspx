<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="CruiseReservation.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Administration</h1>
    <hr />
    <h3>Add Tour:</h3>
    <table>
        <tr>
            <td><asp:Label ID="LabelAddCruise" runat="server">Cruise:</asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownAddCruises" runat="server" ItemType="CruiseReservation.Models.Cruise" SelectMethod="GetCruises" DataTextField="CruiseName" DataValueField="CruiseID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddName" runat="server">Name:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="AddTourName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Tour name required." ControlToValidate="AddTourName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddDescription" runat="server">Description:</asp:Label></td>
            <td><asp:TextBox ID="AddTourDescription" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server" Text="* Description required." ControlToValidate="AddTourDescription" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddPrice" runat="server">Price:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddTourPrice" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Price required." ControlToValidate="AddTourPrice" SetFocusOnError="true" Display="Dynamic" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Must be a valid price without &." ControlToValidate="AddTourPrice" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[09]?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddImageFile" runat="server">Image File:</asp:Label></td>
            <td>
                <asp:FileUpload ID="TourImage" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="* Image path required." ControlToValidate="TourImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <p></p>
    <p></p>
    <asp:Button ID="AddTourButton" runat="server" Text="Add tour" OnClick="AddTourButton_Click"  CausesValidation="true"/>
    <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>
    <p></p>
    <h3>Remove Tour:</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="LabelRemoveTour" runat="server">Tour:</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownRemoveTour" runat="server" ItemType="CruiseReservation.Models.Tour" SelectMethod="GetTours" AppendDataBoundItems="true" DataTextField="TourName" DataValueField="TourID"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <p></p>
    <asp:Button ID="RemoveTourButton" runat="server" Text="Remove Tour" OnClick="RemoveTourButton_Click" CausesValidation="false" />
    <asp:Label ID="LabelRemoveStatus" runat="server" Text=""></asp:Label>
</asp:Content>
