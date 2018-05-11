<%@ Page Title="" Language="C#" MasterPageFile="~/Portal/SiteAuthenticated.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="GiphyUI.Portal.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Categories</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align:right;">       
                            <asp:Button ID="btnAddNew" runat="server" class="btn btn-primary" Text="Add New" />
                            
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                                <thead>
                                    <tr>
                                        <th>Sorting</th>
                                        <th>Category Name</th>
                                        <th>Category Description</th>                                                                                
                                    </tr>
                                </thead>
                                <asp:Repeater ID="rptLineItems" runat="server">                                    
                                    <HeaderTemplate></HeaderTemplate>
                                    <ItemTemplate>
                                        <tbody>
                                            <tr class="odd gradeX">
                                                <td><%# Eval("sorting") %></td>
                                                <td><%# Eval("categoryName") %></td>
                                                <td><%# Eval("categoryDescription") %></td>                                                
                                            </tr>                                    
                                        </tbody>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                            <!-- /.table-responsive -->
                            
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
</asp:Content>
