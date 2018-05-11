<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="GiphyUI.NewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-info">
                    <div class="panel-heading">
                        <h3 class="panel-title ">New User Info</h3>
                    </div>
                    <div class="panel-body">                        
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" MaxLength="20" placeholder="First Name"></asp:TextBox>                                                                        
                                    <div class="form-group has-error">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="*First Name required" SetFocusOnError="true" Display="Dynamic" CssClass="form-group has-error control-label" for="inputError"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="*Invalid Username" ValidationExpression="^[a-zA-Z_]{3,20}$" SetFocusOnError="true" Display="Dynamic"  CssClass="form-group has-error control-label" for="inputError"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" MaxLength="20" placeholder="Last Name"></asp:TextBox>                                    
                                    <div class="form-group has-error">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="*Last Name required" SetFocusOnError="true" Display="Dynamic" CssClass="form-group has-error control-label" for="inputError"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLastName" ErrorMessage="*Invalid Last name" ValidationExpression="^[a-zA-Z_]{3,20}$" SetFocusOnError="true" Display="Dynamic"  CssClass="form-group has-error control-label" for="inputError"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="50" placeholder="Email" TextMode="Email"></asp:TextBox>                                    
                                    <div class="form-group has-error">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Email required" SetFocusOnError="true" Display="Dynamic" CssClass="form-group has-error control-label" for="inputError"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="true" Display="Dynamic"  CssClass="form-group has-error control-label" for="inputError"></asp:RegularExpressionValidator>
                                    </div>
                                </div>                                
                                <div class="form-group">
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" MaxLength="20" placeholder="username"></asp:TextBox>                                    
                                    <div class="form-group has-error">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserName" ErrorMessage="*Username required" SetFocusOnError="true" Display="Dynamic" CssClass="form-group has-error control-label" for="inputError"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtUserName" ErrorMessage="*Invalid username" ValidationExpression="^[a-zA-Z0-9_]{8,16}$" SetFocusOnError="true" Display="Dynamic"  CssClass="form-group has-error control-label" for="inputError"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" MaxLength="20" TextMode="Password" placeholder="Enter password"></asp:TextBox>                                    
                                    <div class="form-group has-error">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" ErrorMessage="*Password required" SetFocusOnError="true" Display="Dynamic" CssClass="form-group has-error control-label" for="inputError"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPassword" ErrorMessage="*Password must be between 8 to 16 characters. You must use 1 upper case letter, 1 lower case letter, 1 number, and 1 special character." ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@#$!%*~^()_+?&])[A-Za-z\d$@#$!%*~^()_+?&]{8,16}" SetFocusOnError="true" Display="Dynamic"  CssClass="form-group has-error control-label" for="inputError"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPassword2" runat="server" CssClass="form-control" MaxLength="20" TextMode="Password" placeholder="Re-enter password"></asp:TextBox>                                    
                                    <div class="form-group has-error">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPassword2" ErrorMessage="*Re-enter Password required" SetFocusOnError="true" Display="Dynamic" CssClass="form-group has-error control-label" for="inputError"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidatorPasswords" runat="server" ControlToValidate="txtPassword2" ControlToCompare="txtpassword"  Operator="Equal" ErrorMessage="*Password must match" SetFocusOnError="true" Display="Dynamic" CssClass="form-group has-error control-label" for="inputError"></asp:CompareValidator>
                                    </div>
                                </div>
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-lg btn-info btn-block" Text="Sign Up"  OnClick="btnSubmit_Click"/>
                                <div class="form-group has-error">
                                    <asp:Label ID="lblMsg" runat="server"  CssClass="form-group has-error control-label"></asp:Label>
                                </div>
                                
                            </fieldset>                             
                            <fieldset class="text-center">
                                <asp:HyperLink ID="hplnCancel" runat="server" Text="< Go Back" CssClass="panel-body" NavigateUrl="~/login.aspx"  ></asp:HyperLink>
                            </fieldset>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
