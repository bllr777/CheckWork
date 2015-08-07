<%@ Page Language="C#" MasterPageFile="~/MasterPages/Site2column.Master" AutoEventWireup="true" Theme="Main" CodeBehind="LotteryBasic.aspx.cs" Inherits="AstonTech.Lottery.Web.LotterySection.LotteryBasic" EnableViewState="true" %>

<%@ Register Src="~/UserControls/LotteryNavigationControl.ascx" TagPrefix="CustomLottery" TagName="LotteryNavigation" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="LotteryGameId" Value="0" />
    <asp:HiddenField runat="server" ID="LotteryGameDetailId" Value="0" />

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
                
            

            <div>
                
                <div class="SectionMessageArea SmallText"><label class="Required">*</label> = Required Field</div>
                <table>
                    <tr>
                        <td><label class="Required">Game Name*:</label></td>
                        <td>
                            <asp:TextBox runat="server" ID="GameName" MaxLength="50" /></td>

                    </tr>
                    <tr>
                        <td><label class="Required"> Name Abbreviation*:</label></td>
                        <td>
                            <asp:TextBox runat="server" ID="GameNameAbbrev" MaxLength="50" /></td>
                    </tr>
                    <tr>
                        <td><label> To Play: </label></td>
                        <td>
                            <asp:TextBox runat="server" ID="HowToPlay" TextMode="MultiLine" Rows="4" Columns="50" /></td>
                    </tr>
                    <tr>
                        <td><label>Description:</label></td>
                        <td>
                            <asp:TextBox runat="server" ID="GameDescription" TextMode="MultiLine" Rows="4" Columns="50" /></td>
                    </tr>
                    <tr>
                        <td><label> Cost:</label></td>
                        <td>
                            <asp:TextBox runat="server" ID="Cost" MaxLength="50" /></td>
                    </tr>
                </table>
                <br />
                <br />
                <div class="Containerbar">
                    <asp:Button runat="server" Text="Add Game" ID="SaveButton" OnClick="Save_Click" />
                    <span class="FloatRight">
                        <asp:Button runat="server"
                            ID="DeleteButton"
                            Text="Delete Game"
                            OnClick="Delete_Click"
                            Visible="false" /></span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
