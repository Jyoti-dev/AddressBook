<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="BootstrapAddressBook._Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="uc" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
     <%--<uc:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
         </uc:ToolkitScriptManager>--%>

    <div class="jumbotron">
        <h1>Address Book</h1>        
    </div>

    <div style="padding-top: 20px;">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" CssClass="footable" AutoGenerateColumns="false"
                                Style="max-width: 500px">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="Edit" CommandArgument='<%# Eval("Id") %>'
                                                class="btn btn-primary" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="Delete" CommandArgument='<%# Eval("Id") %>'
                                                class="btn btn-danger" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table class="footable">
                                        <tr style="background-color: #DCE9F9;">
                                            <th class="hidden-xs">
                                                <b>ID</b>
                                            </th>
                                            <th>
                                                <b>Name</b>
                                            </th>
                                            <th class="hidden-xs">
                                                <b>Email</b>
                                            </th>
                                            <th class="hidden-xs">
                                                <b>MobileNo</b>
                                            </th>
                                            <th>
                                                &nbsp;
                                            </th>
                                            <th>
                                                &nbsp;
                                            </th>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="text-align: center;">
                                                <b>No Records Found</b>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnAdd" runat="server" Text="Add New AddressBook" OnClick="Add" class="btn btn-success" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
 
    <%--lnkFake Link Button for mpeAddUpdateAddressBook ModalPopup as TargetControlID--%>
    <asp:LinkButton ID="lnkAdd" runat="server"></asp:LinkButton>
     
    <%--pnlAddUpdateAddressBookDetails Panel With Design--%>
    <asp:Panel ID="pnlAddUpdateAddressBookDetails" runat="server" CssClass="modalPopup"
        Style="display: none;">
        <div style="overflow-y: auto; overflow-x: hidden; max-height: 450px;">
            <div class="modal-header">
                <asp:Label ID="lblHeading" runat="server" CssClass="modal-title"></asp:Label>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-3">
                            <label for="txtName">
                                Name</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Name"
                                Width="150px"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:RequiredFieldValidator ID="rfvName" Display="Dynamic" ErrorMessage="Required"
                                 ValidationGroup="Validate" ControlToValidate="txtName" runat="server" ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-3">
                            <label for="txtEmail">
                                Email</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"
                                Width="150px"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Validate" ControlToValidate="txtEmail"
                             ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                             Display = "Dynamic" ErrorMessage = "Invalid email address" />
                           <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ValidationGroup="Validate" ControlToValidate="txtEmail"
                            ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />
                            
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-3">
                            <label for="txtMobileNo">
                                MobileNo</label>
                        </div>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="MobileNo"
                                Width="150px"></asp:TextBox>                         
                          
                        </div>
                        <div class="col-md-3">
                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ErrorMessage="Required"
                            Display="Dynamic" ForeColor="Red" ValidationGroup="Validate" ControlToValidate="txtMobileNo"></asp:RequiredFieldValidator>
                           <asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number."
                              ValidationExpression="^([0-9]{10})$" ValidationGroup="Validate" ControlToValidate="txtMobileNo" 
                              ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                       
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <div class="row">
                    <div class="col-md-12">
                        <asp:HiddenField ID="hfAddEditId" runat="server" Value="0" />
                        <asp:HiddenField ID="hfAddEdit" runat="server" Value="ADD" />
                        <asp:Button ID="btnSave" runat="server" Text="ADD" OnClick="Save" class="btn btn-success"
                            ValidationGroup="Validate"></asp:Button>
                        <button id="btnCancel" runat="server" class="btn btn-primary">
                            Cancel
                        </button>
                    </div>
                </div>
            </div>
           
        </div>
    </asp:Panel>
 
   
     <%--mpeAddUpdateAddressBook Modal Popup Extender For pnlAddUpdateAddressBookDetails--%>
    <uc:ModalPopupExtender ID="mpeAddUpdateAddressBook" runat="server" PopupControlID="pnlAddUpdateAddressBookDetails"
        TargetControlID="lnkAdd" BehaviorID="mpeAddUpdateAddressBook" CancelControlID="btnCancel"
        BackgroundCssClass="modalBackground"></uc:ModalPopupExtender>
    
 
    <%--lnkFake1 Link Button for mpeDeleteEmployee ModalPopup as TargetControlID--%>
    <asp:LinkButton ID="lnkDel" runat="server"></asp:LinkButton>
 
    <%--pnlDeleteEmployee Panel With Design--%>
    <asp:Panel ID="pnlDeleteAddressBook" runat="server" CssClass="modalPopup" Style="display: none;">
        <div id="Div1" runat="server" class="header">
        </div>
        <div style="overflow-y: auto; overflow-x: hidden; max-height: 450px;">
            <div class="form-group modal-body">
                <div class="row">
                    <div class="col-md-12">
                        Do you Want to delete this record ?
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <div class="row">
                <div class="col-md-12">
                    <asp:HiddenField ID="hfDeleteId" runat="server" Value="0" />
                    <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="Yes" class="btn btn-danger">
                    </asp:Button>
                    <button id="btnNo" runat="server" class="btn btn-default">
                        Cancel
                    </button>
                </div>
            </div>
        </div>
    </asp:Panel>
 
   <%-- mpeDeleteAddressBook Modal Popup Extender For pnlDeleteAddressBook--%>
    <uc:ModalPopupExtender ID="mpeDeleteAddressBook" runat="server" PopupControlID="pnlDeleteAddressBook"
        TargetControlID="lnkDel" BehaviorID="mpeDeleteAddressBook" CancelControlID="btnNo"
        BackgroundCssClass="modalBackground">
    </uc:ModalPopupExtender>
       
</asp:Content>
