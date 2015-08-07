<%@ Page Language="C#" MasterPageFile="~/MasterPages/Site2column.Master" AutoEventWireup="true" Theme="Main" CodeBehind="WinningNumber.aspx.cs" Inherits="AstonTech.Lottery.Web.LotterySection.WinningNumber" EnableViewState="true" %>

<%@ Register Src="~/UserControls/LotteryNavigationControl.ascx" TagPrefix="CustomLottery" TagName="LotteryNavigation" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="LotteryGameId" Value="0" />
    <div id="form">
        <CustomLottery:LotteryNavigation runat="server" ID="CustomLotteryNavigation" />
        <div id="content">
            <asp:Panel runat="server" ID="PageMessageArea" CssClass="PageMessage BorderRadiusAll" Visible="false">
                <asp:Label runat="server" ID="PageMessage" />
            </asp:Panel>
            <div>
                <table>

                    <tr>
                        <td>
                            <label>Winning Number/Multiplier</label></td>
                        <td>
                            <asp:TextBox runat="server" Columns="1" ID="Number" MaxLength="2" /></td>
                    </tr>

                      <tr>
                        <td>
                            <label>Drawing Date</label></td>
                        <td>
                            <asp:DropDownList runat="server" ID="DrawingList" DataTextField="DrawingDate" DataValueField="LotteryDrawingId" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Ball Type</label></td>
                        <td>
                            <asp:DropDownList runat="server" ID="BallList" DataTextField="BallType" DataValueField="DrawingTypeId" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:Repeater runat="server" ID="NumberList" OnItemDataBound="NumberList_OnItemDataBound">
                    <HeaderTemplate>
                        <table class="ListStyle BorderRadiusAll" width="100%">
                            <tr>
                                <th>&nbsp;</th>
                                <th>Winning Number</th>
                                <th>Ball Type</th>

                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="center">
                                <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="DrawingButton_Command" CommandName="Edit" /><asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="DrawingButton_Command" CommandName="Delete" />
                            </td>
                            <td align="center"><%#Eval("DrawingNumberValue") %></td>
                            <td align="center"><%#Eval("BallType") %></td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr>
                            <td class="ListStyleAlternate" align="center">
                                <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="DrawingButton_Command" CommandName="Edit" /><asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="DrawingButton_Command" CommandName="Delete" />
                            </td>
                            <td class="ListStyleAlternate" align="center"><%#Eval("DrawingNumberValue") %></td>
                            <td class="ListStyleAlternate" align="center"><%#Eval("BallType") %></td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
                <br />
                <div class="Containerbar">
                    <asp:Button runat="server" Text="Add Info" ID="SaveButton" OnClick="Save_Click" />
                </div>
                <br />
                <br />

            </div>

        </div>
</asp:Content>
