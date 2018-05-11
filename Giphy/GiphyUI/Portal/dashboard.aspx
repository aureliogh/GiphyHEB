<%@ Page Title="" Language="C#" MasterPageFile="~/Portal/SiteAuthenticated.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="GiphyUI.Portal.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">My Giphies</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-search fa-3x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <div class="form-group has-success">                                            
                                            <asp:TextBox ID="txtSearchGiphy" runat="server" CssClass="form-control" ></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpression" runat="server" ControlToValidate="txtSearchGiphy" ValidationExpression="^[a-zA-Z_]{3,20}$" SetFocusOnError="true" Display="Dynamic"  CssClass="form-group has-error control-label" for="inputError"></asp:RegularExpressionValidator>
                                        </div>
                                        
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                        
                            <div class="panel-footer text-right">
                                <asp:Button id="btnSearchGiphy" runat="server"  class="btn btn-success" Text="Search" OnClick="btnSearchGiphy_Click"/>
                            </div>
                        
                    </div>
                    <!-- /.panel -->
                    <div class="chat-panel panel panel-default">
                        <div class="panel-heading">
                            <i class="fa fa-reorder fa-fw"></i> Giphy Results
                            <div class="btn-group pull-right">
                                
                            </div>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <ul class="chat">
                                <li class="left clearfix">
                                    
                                    <div class="chat-body clearfix">
                                        <div class="header">
                                            <asp:Image ID="ImgGifSample" runat="server" ImageUrl="https://media3.giphy.com/media/8vgw3VstnFlf2/200w.mp4" />
                                            
                                        </div>
                                        <p>
                                            
                                        </p>
                                    </div>
                                </li>
                                
                            </ul>
                        </div>
                        <!-- /.panel-body -->
                        <div class="panel-footer">
                            <div class="input-group">
                                
                            </div>
                        </div>
                        <!-- /.panel-footer -->
                    </div>
                    <!-- /.panel .chat-panel -->
                </div>
                
            </div>
            <!-- /.row -->
    <%--<script type="text/javascript">

        function searchGiphy(searchValue) {
            $.support.cors = true;
            $.ajax({
                url: ('https://api.giphy.com/v1/gifs/search?api_key=zmobwVDG17HzSmJZ7KCXR8BAXjqfBm6N&q={searchkey}&limit=5&offset=0&rating=G&lang=en').replace('{searchkey}', searchValue),
                xhrObj.setRequestHeader("api_key", "zmobwVDG17HzSmJZ7KCXR8BAXjqfBm6N");
                type: 'GET',
                success: function (data, textStatus, xhr) {
                    console.log(JSON.stringify(data));
                    try {                        
                        var var1 = data;
                        
                        if (var1 == null) {

                        }
                        else {

                        }
                        
                    }
                    catch (error) {
                        var1 = ' ';                        
                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    var1 = ' ';
                    
                    console.log(textStatus);
                }
            });            
        }
    </script>--%>
            
</asp:Content>
