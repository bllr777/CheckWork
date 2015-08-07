<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LotteryNavigationControl.ascx.cs" Inherits="AstonTech.Lottery.Web.UserControls.LotteryNavigationControl" %>

<div class="LotteryNavigationContainer BorderRadius BorderRadiusTop">
    <div class="FloatLeft">
        <asp:DropDownList runat="server" 
            ID="LotterySelectList" 
            CssClass="SmallText"  
            DataTextField="GameName"
            DataValueField="LotteryGameId"            
            OnSelectedIndexChanged="LotterySelectList_Selected"
            AutoPostBack="true" />
           
    </div>
    <div class="FloatRight SmallPadding">
        <asp:ListView runat="server" ID="LotteryNavigationList" ItemPlaceholderID="LotteryNavigationPlaceholder">
            <LayoutTemplate>
                <ul>
                    <asp:PlaceHolder runat="server" ID="LotteryNavigationPlaceholder" />
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat="server" ID="LotteryNavigationLink" NavigateUrl='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>'>
                        <%# Eval("Text") %>

                    </asp:HyperLink>   
                </li>
            </ItemTemplate>
         </asp:ListView>
    </div>
</div>