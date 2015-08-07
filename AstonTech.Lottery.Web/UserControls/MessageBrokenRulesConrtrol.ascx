<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBrokenRulesConrtrol.ascx.cs" Inherits="AstonTech.Lottery.Web.UserControls.MessageBrokenRulesConrtrol" %>
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