<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LotteryMaintenanceNavigationControl.ascx.cs" Inherits="AstonTech.Lottery.Web.UserControls.LotteryMaintenanceNavigationControl" %>

<div class="LotteryNavigationContainer BorderRadius BorderRadiusTop">
    <asp:Label runat="server" ID="UCMessage" />
    <div class="SmallPadding">
        <asp:ListView runat="server" ID="LotteryMaintenanceNavigationList" ItemPlaceholderID="LotteryMaintenanceNavigationPlaceholder">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder runat="server" ID="LotteryMaintenanceNavigationPlaceholder" />
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat="server" ID="LotteryMaintenanceNavigationLink" NavigateUrl='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' ><%# Eval("Text") %>

                    </asp:HyperLink>
                </li>
            </ItemTemplate>
        </asp:ListView>
    </div>
</div>
