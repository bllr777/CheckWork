<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewStateOn.aspx.cs" Inherits="AstonTech.Lottery.Web.LotterySection.ViewStateOn" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../LotteryStyle.css" rel="stylesheet" />
    <title>PowerBall</title>
</head>
<body>
    <div id="wrapper">
        <div id="header">
            <img class="power" src="../Images/pb.png" />
            <img class="trees" src="../Images/top-banner-blue-birch-trees.png" />
            <div class="logo">
            <img src="../Images/site_logo.png" />
            </div>
        </div>

        


        <div id="content">
        <img class="pbheader" src="../Images/PB-Header.jpg" />

          <p>  This is a test with ViewState= true <asp:Label runat="server" ID="TestingPage" /> </p>
        
            <form id="form1" runat="server">
                <div>
                    <table>
                         <tr>
                            <td>Game</td>
                            <td>
                                <asp:DropDownList runat="server" ID="Games" >
                                <asp:ListItem Text="(Select Game)" Value="0" />
                                <asp:ListItem Text="Powerball" Value="PB" />
                                <asp:ListItem Text="Mega Millions" Value="MegaMillions" />
                                <asp:ListItem Text="Gopher 5" Value="G5" />
                                <asp:ListItem Text="Northstar Cash" Value="NC" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Drawing Date</td>
                            <td>
                                <asp:TextBox runat="server" ID="DrawingDate" TextMode="Date"/> &nbsp;(mm/dd/yyy)</td>
                        </tr>
                        <tr>
                            <td>Jackpot Amount</td>
                            <td>
                                <asp:TextBox runat="server" ID="PrizeAmount" MaxLength="50" /></td>
                        </tr>
                        <tr>
                            <td>Cash Option Amount</td>
                            <td>
                                <asp:TextBox runat="server" ID="CashOptionAmount" MaxLength="50" /></td>
                        </tr>
                        <tr>
                            <td>Multiplier</td>
                            <td>
                                <asp:TextBox runat="server" ID="Multiplier" MaxLength="50" /></td>
                        </tr>
                      
                    </table>
                    <br />
                    <br />
                    <asp:Button runat="server" Text="Save" />
                    <asp:Button runat="server" Text="Event Unhandled" />
                    <br />
                    <br />
                    <div> Copyright 2014 Minnesotta Lottery</div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
