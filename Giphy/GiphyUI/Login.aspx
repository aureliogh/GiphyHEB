<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GiphyUI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-success">
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body">                        
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" MaxLength="20" placeholder="username"></asp:TextBox>                                                                                                    
                                    <div class="form-group has-error">
                                        <asp:RequiredFieldValidator ID="ReqFldValidator1" runat="server" ControlToValidate="txtUserName" Text="*Username Required"  Display="Static"  CssClass="control-label" for="inputError"></asp:RequiredFieldValidator>                                
                                    </div>                                
                                </div>
                            </fieldset>     
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" MaxLength="20" TextMode="Password" placeholder="password"></asp:TextBox>                                    
                                </div>
                                <div class="form-group has-error">
                                    <asp:RequiredFieldValidator ID="ReqFldValidator2" runat="server" ControlToValidate="txtPassword" Text="*Password Required"  Display="Static"  CssClass="alert-danger" ></asp:RequiredFieldValidator>
                                </div>
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-lg btn-success btn-block" Text="Login" OnClick="btnSubmit_Click" />                                                                
                                <div class="form-group has-error">
                                    <asp:Label ID="lblMsg" runat="server"  CssClass="form-group has-error control-label"></asp:Label>
                                </div>
                            </fieldset>
                            <fieldset class="text-center">
                                Not a Member yet? <asp:HyperLink ID="hplnNewUser" runat="server" Text="Sign Up" CssClass="panel-body" NavigateUrl="~/newUser.aspx" ></asp:HyperLink>
                            </fieldset>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
