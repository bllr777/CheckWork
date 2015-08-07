<%@ Page Title="Maintenance" Language="C#" Theme="Main" MasterPageFile="~/MasterPages/Site2column.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AstonTech.Lottery.Web.Maintenance.Default" %>

<%@ Register TagPrefix="CustomAstonTech" TagName="LotteryMaintenanceNavigation" Src="~/UserControls/LotteryMaintenanceNavigationControl.ascx" %>
<%@ Register Src="~/UserControls/MessageBrokenRulesConrtrol.ascx" TagPrefix="CustomAstonTech" TagName="MessageArea" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="HiddenLotteryGameId" Value="0" />
    <div id="form">
        <CustomAstonTech:LotteryMaintenanceNavigation runat="server" ID="CustomLotteryMaintenanceNavigation" />
        <CustomAstonTech:MessageArea runat="server" ID="CustomMessageArea" Visible="false" />

        <div id="content">
         
            <div class="SectionMessageArea SmallText">
                <label class="Required">*</label>
                = Required Field
            </div>
            <table>
                <tr>
                    <td>
                        <label class="Required">Game Name*:</label></td>
                    <td>
                        <asp:DropDownList runat="server"
                            ID="GameList"
                            DataTextField="GameAbbreviation"
                            DataValueField="LotteryGameId"
                            OnSelectedIndexChanged="GameList_Selected"
                            AutoPostBack="true" /></td>
                </tr>
                <tr runat="server" id="GameNameRow" visible="false">
                    <td>
                        <label class="Required">Lookup Value*:</label></td>
                    <td>
                        <asp:TextBox runat="server" ID="GameValueField" /></td>
                </tr>
            </table>
            <div class="Containerbar">
                <asp:Button runat="server" Text="Add Lookup Value" ID="SaveButton" OnClick="Page_Load" Visible="false" />
                <span class="FloatRight">
                    <asp:Button runat="server"
                        ID="CancelButton"
                        Text="Cancel"
                        OnClick="Cancel_Click"
                        Visible="false" /></span>
            </div>
            <br />

            <asp:Repeater runat="server" ID="LookupList" OnItemDataBound="LookupList_OnItemDataBound">
                <HeaderTemplate>
                    <table class="ListStyle BorderRadiusAll">
                        <tr>
                            <th>&nbsp;</th>
                            <th>Lookup Value</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="CenterText">
                            <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="GameAbbrev_Command" CommandName="Edit" />
                            <asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedLeft" OnCommand="GameAbbrev_Command" CommandName="Delete" />
                        </td>
                        <td class="CenterText"><%# Eval("GameAbbreviation") %></td>
                    </tr>
                    </ItemTemplate>
                    <alternatingitemtemplate>
                           <tr>
                           <td class="ListStyleAlternate CenterText">
                                     <asp:LinkButton runat="server" ID="EditButton1" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="GameAbbrev_Command" CommandName="Edit" />
                               <asp:LinkButton runat="server" ID="DeleteButton1" Text="Delete" CssClass="Button ButtonRoundedLeft" OnCommand="GameAbbrev_Command" CommandName="Delete" />
                           </td>
                           <td class="ListStyleAlternate CenterText"><%# Eval("GameAbbreviation") %></td>
                       </tr>
                   </alternatingitemtemplate>
                    <footertemplate>
                            </table>
                       </footertemplate>

                       </asp:Repeater>
           </div>
                  </div>     


</asp:Content>
