<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreateDynamicForm.aspx.vb" Inherits="BootstrapAddressBook.CreateDynamicForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="tbldynamicform" style="width:55%">
                <tr>
                    <td>
                        <asp:PlaceHolder ID="placeholder" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td>
                        <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server"></ajaxToolkit:AccordionPane>
                        <ajaxToolkit:Accordion ID="Accordion1" runat="server"></ajaxToolkit:Accordion>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
