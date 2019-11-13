Public Class CreateDynamicForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CreateDynamicControls()
        End If
    End Sub

    Public Function CustomFields() As DataTable
        Dim dt As DataTable = New DataTable()
        dt = New DataTable()
        dt.Columns.Add("FieldName", GetType(String))
        dt.Columns.Add("FieldType", GetType(String))
        dt.Columns.Add("FieldValue", GetType(String))

        dt.Rows.Add("FirstName", "TextBox", String.Empty)
        dt.Rows.Add("LastName", "TextBox", String.Empty)
        dt.Rows.Add("IsActive", "Checkbox", String.Empty)
        dt.Rows.Add("State", "DropdownList", String.Empty)
        dt.Rows.Add("City", "TextBox", String.Empty)
        dt.Rows.Add("Zip", "TextBox", String.Empty)
        dt.Rows.Add("Gender", "RadioButton", String.Empty)
        dt.Rows.Add("Job", "DropdownList", String.Empty)

        Return dt
    End Function

    Public Sub CreateDynamicControls()
        Dim dt As DataTable = New DataTable()
        dt = CustomFields()

        If dt.Rows.Count > 0 Then

            For i As Int32 = 0 To dt.Rows.Count - 1
                Dim tr As HtmlGenericControl = New HtmlGenericControl("tr")
                Dim td As HtmlGenericControl = New HtmlGenericControl("td")
                Dim td1 As HtmlGenericControl = New HtmlGenericControl("td")
                Dim FieldName As String = Convert.ToString(dt.Rows(i)("FieldName"))
                Dim FieldType As String = Convert.ToString(dt.Rows(i)("FieldType"))
                Dim FieldValue As String = Convert.ToString(dt.Rows(i)("FieldValue"))
                Dim lbcustomename As Label = New Label()
                lbcustomename.ID = "lb" & FieldName
                lbcustomename.Text = FieldName
                td.Controls.Add(lbcustomename)
                tr.Controls.Add(td)

                If FieldType.ToLower().Trim() = "textbox" Then
                    Dim txtcustombox As TextBox = New TextBox()
                    txtcustombox.ID = "txt" & FieldName
                    txtcustombox.Text = FieldValue
                    td1.Controls.Add(txtcustombox)
                ElseIf FieldType.ToLower().Trim() = "checkbox" Then
                    Dim chkbox As CheckBox = New CheckBox()
                    chkbox.ID = "chk" & FieldName

                    If FieldValue = "1" Then
                        chkbox.Checked = True
                    Else
                        chkbox.Checked = False
                    End If

                    td1.Controls.Add(chkbox)
                ElseIf FieldType.ToLower().Trim() = "radiobutton" Then
                    Dim rbnlst As RadioButtonList = New RadioButtonList()
                    rbnlst.ID = "rbnlst" & FieldName
                    rbnlst.Items.Add(New ListItem("Male", "1"))
                    rbnlst.Items.Add(New ListItem("Female", "2"))

                    If FieldValue <> String.Empty Then
                        rbnlst.SelectedValue = FieldValue
                    Else
                        rbnlst.SelectedValue = "1"
                    End If

                    rbnlst.RepeatDirection = RepeatDirection.Horizontal
                    td1.Controls.Add(rbnlst)
                ElseIf FieldType.ToLower().Trim() = "dropdownlist" Then
                    Dim ddllst As DropDownList = New DropDownList()
                    ddllst.ID = "ddl" & FieldName
                    ddllst.Items.Add(New ListItem("Select", "0"))

                    If FieldName.ToLower().Trim() = "state" Then
                        ddllst.Items.Add(New ListItem("Alabama", "AL"))
                        ddllst.Items.Add(New ListItem("Alaska", "AK"))
                        ddllst.Items.Add(New ListItem("Arizona", "AZ"))
                        ddllst.Items.Add(New ListItem("California", "CA"))
                        ddllst.Items.Add(New ListItem("New York", "NY"))
                    ElseIf FieldName.ToLower().Trim() = "job" Then
                        ddllst.Items.Add(New ListItem("Developer", "1"))
                        ddllst.Items.Add(New ListItem("Tester", "2"))
                    End If

                    If FieldValue <> String.Empty Then
                        ddllst.SelectedValue = FieldValue
                    Else
                        ddllst.SelectedValue = "0"
                    End If

                    td1.Controls.Add(ddllst)
                End If

                tr.Controls.Add(td1)
                placeholder.Controls.Add(tr)

                If i = dt.Rows.Count - 1 Then
                    tr = New HtmlGenericControl("tr")
                    td = New HtmlGenericControl("td")
                    'Dim btnSubmit As Button = New Button()
                    'btnSubmit.ID = "btnSubmit"
                    'btnSubmit.Click += btnsubmit_Click
                    'btnSubmit.OnClientClick = "return ValidateForm();"
                    'btnSubmit.Text = "Submit"
                    'td.Controls.Add(btnSubmit)
                    td.Attributes.Add("Colspan", "2")
                    td.Attributes.Add("style", "text-align:center;")
                    tr.Controls.Add(td)
                    placeholder.Controls.Add(tr)
                End If
            Next
        End If
    End Sub

    Public Sub Save()
        Dim dtFormValues As DataTable = New DataTable()
        dtFormValues.Columns.Add("FormId", GetType(Int32))
        dtFormValues.Columns.Add("FieldName", GetType(String))
        dtFormValues.Columns.Add("Value", GetType(String))
        Dim dt As DataTable = New DataTable()
        dt = CustomFields()

        If dt.Rows.Count > 0 Then

            For i As Int32 = 0 To dt.Rows.Count - 1
                Dim FieldName As String = Convert.ToString(dt.Rows(i)("FieldName"))
                Dim FieldType As String = Convert.ToString(dt.Rows(i)("FieldType"))
                dtFormValues.NewRow()

                If FieldType.ToLower().Trim() = "textbox" Then
                    Dim txtbox As TextBox = CType(placeholder.FindControl("txt" & FieldName), TextBox)

                    If txtbox IsNot Nothing Then
                        dtFormValues.Rows.Add(ClientID, FieldName, txtbox.Text)
                    End If
                ElseIf FieldType.ToLower().Trim() = "checkbox" Then
                    Dim checkbox As CheckBox = CType(placeholder.FindControl("chk" & FieldName), CheckBox)

                    If checkbox IsNot Nothing Then
                        dtFormValues.Rows.Add(ClientID, FieldName, If(checkbox.Checked, "1", "0"))
                    End If
                ElseIf FieldType.ToLower().Trim() = "radiobutton" Then
                    Dim radiobuttonlist As RadioButtonList = CType(placeholder.FindControl("rbnlst" & FieldName), RadioButtonList)

                    If radiobuttonlist IsNot Nothing Then
                        dtFormValues.Rows.Add(ClientID, FieldName, radiobuttonlist.SelectedValue)
                    End If
                ElseIf FieldType.ToLower().Trim() = "dropdownlist" Then
                    Dim dropdownlist As DropDownList = CType(placeholder.FindControl("ddl" & FieldName), DropDownList)

                    If dropdownlist IsNot Nothing Then
                        dtFormValues.Rows.Add(ClientID, FieldName, dropdownlist.SelectedValue)
                    End If
                End If
            Next
        End If
    End Sub

    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs)
        Save()
    End Sub
End Class