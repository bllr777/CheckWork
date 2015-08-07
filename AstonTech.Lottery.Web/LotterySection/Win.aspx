<%@ Page Language="C#" MasterPageFile="~/MasterPages/Site2column.Master" AutoEventWireup="true" Theme="Main" CodeBehind="Win.aspx.cs" Inherits="AstonTech.Lottery.Web.LotterySection.Win" EnableViewState="true" %>
<%@ Register Src="~/UserControls/LotteryNavigationControl.ascx" TagPrefix="CustomLottery" TagName="LotteryNavigation" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
      <div id="form">
     <CustomLottery:LotteryNavigation runat="server" ID="CustomLotteryNavigation" />
          <div id="content">
          <asp:Panel runat="server" ID="PageMessageArea" CssClass="PageMessage BorderRadiusAll" Visible="false">
                <asp:Label runat="server" ID="PageMessage" />
            </asp:Panel>
          <div>
                            <table>
                               
                                <tr>
                                    <td>Win</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Win1" MaxLength="150" /></td>
                                </tr>
                                <tr>
                                    <td>Odd</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Odd" MaxLength="150" /></td>
                                </tr>
                                <tr>
                                    <td>Match</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="Match" MaxLength="150" /></td>
                                </tr>

                           </table>
                <br />
                <br />
                <div class="Containerbar">
                    <asp:Button runat="server" Text="Add Win" ID="SaveButton" OnClick="Save_Click" />
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