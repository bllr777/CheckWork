<%@ Page Title="" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/Site2column.Master" AutoEventWireup="true" CodeBehind="Drawing.aspx.cs" Inherits="AstonTech.Lottery.Web.LotterySection.Drawing" %>

<%@ Register Src="~/UserControls/LotteryNavigationControl.ascx" TagPrefix="CustomLottery" TagName="LotteryNavigation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="LotteryGameId" Value="0" />


    <div id="form">
        <CustomLottery:LotteryNavigation runat="server" ID="CustomLotteryNavigation" />
        <div id="content">

                <asp:Panel runat="server" ID="PageMessageArea" CssClass="PageMessage BorderRadiusAll" Visible="false">
                <asp:Label runat="server" ID="PageMessage" />
                <asp:ListView runat="server" ID="MessageList" ItemPlaceholderID="MessageListPlaceholder">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="MessageListPlaceholder" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li><%#Eval("PropertyName") %>: <%#Eval("Message") %></li>
                    </ItemTemplate>
                </asp:ListView>
            </asp:Panel>

            <table>

                <tr>
                    <td>
                        <label>Drawing Date</label></td>
                    <td>
                        <asp:TextBox runat="server" ID="DrawingDate" Maxlength="50" />
                        &nbsp;(mm/dd/yyy)</td>
                </tr>
                <tr>
                    <td>
                        <label>Jackpot Amount</label></td>
                    <td>
                        <asp:TextBox runat="server" ID="PrizeAmount" MaxLength="50" /></td>
                </tr>


            </table>


            <br />
            <br />
            <asp:Repeater runat="server" ID="DrawingList" OnItemDataBound="DrawingList_OnItemDataBound" >
                <HeaderTemplate>
                    <table class="ListStyle BorderRadiusAll" width="100%">
                        <tr>
                            <th>&nbsp;</th>
                            <th>Drawing Date</th>
                            <th>Prize Amount</th>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="DrawingButton_Command" CommandName="Edit" /><asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="DrawingButton_Command" CommandName="Delete" />
                        </td>
                        <td align="center"><%#Eval("DrawingDate") %></td>
                        <td align="center"><%#Eval("PrizeAmount") %></td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr>
                        <td class="ListStyleAlternate" align="center">
                            <asp:LinkButton runat="server" ID="EditButton" Text="Edit" CssClass="Button ButtonRoundedLeft" OnCommand="DrawingButton_Command" CommandName="Edit" /><asp:LinkButton runat="server" ID="DeleteButton" Text="Delete" CssClass="Button ButtonRoundedRight" OnCommand="DrawingButton_Command" CommandName="Delete" />
                        </td>
                        <td class="ListStyleAlternate" align="center"><%#Eval("DrawingDate") %></td>
                        <td class="ListStyleAlternate" align="center"><%#Eval("PrizeAmount") %></td>
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
