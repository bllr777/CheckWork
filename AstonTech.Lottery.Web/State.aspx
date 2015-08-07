<%@ Page Language="C#" MasterPageFile="~/MasterPages/Site2column.Master" AutoEventWireup="true" Theme="Main" CodeBehind="State.aspx.cs" Inherits="AstonTech.Lottery.Web.LotterySection.State" EnableViewState="true" %>
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
                                    <td>State Name</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="StateName" MaxLength="50" /></td>
                                </tr>
                                <tr>
                                    <td>State Abbreviation</td>
                                    <td>
                                        <asp:TextBox runat="server" ID="StateAbbreviation" MaxLength="50" /></td>
                                </tr>
                                

                            </table>
                            <br />
                            <br />
                            <asp:Button runat="server" Text="Save" OnClick="Save_Click" />

                            <br />
                            <br />

                        </div>
          </div>
        </div>
</asp:Content>
