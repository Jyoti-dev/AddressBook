Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindEmployee()
        End If
    End Sub

    Private Sub ClearControls()
        hfAddEdit.Value = "ADD"
        btnSave.Text = "ADD"
        lblHeading.Text = "Add AddressBook Details"
        hfAddEditId.Value = "0"
        hfDeleteId.Value = "0"
        txtEmail.Text = String.Empty
        txtName.Text = String.Empty
        txtMobileNo.Text = String.Empty
    End Sub

    Private Sub BindEmployee()
        Dim query As String = "SELECT * FROM Booketails"
        Dim cmd As SqlCommand = New SqlCommand(query)
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim sda As SqlDataAdapter = New SqlDataAdapter()
        cmd.Connection = con
        sda.SelectCommand = cmd
        Dim ds As DataSet = New DataSet()
        sda.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()
        BootstrapCollapsExpand()
    End Sub

    Private Sub BootstrapCollapsExpand()
        If Me.GridView1.Rows.Count > 0 Then
            GridView1.HeaderRow.Cells(1).Attributes("data-class") = "expand"
            GridView1.HeaderRow.Cells(0).Attributes("data-hide") = "phone"
            GridView1.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            GridView1.HeaderRow.Cells(3).Attributes("data-hide") = "phone"
            GridView1.HeaderRow.Cells(4).Attributes("data-hide") = "expand"
            GridView1.HeaderRow.Cells(5).Attributes("data-hide") = "expand"
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Protected Sub Edit(ByVal sender As Object, ByVal e As EventArgs)
        lblHeading.Text = "Update AddressBook Details"
        hfAddEditId.Value = (TryCast(sender, Button)).CommandArgument
        txtName.Text = (TryCast((TryCast(sender, Button)).NamingContainer, GridViewRow)).Cells(1).Text
        txtEmail.Text = (TryCast((TryCast(sender, Button)).NamingContainer, GridViewRow)).Cells(2).Text
        txtMobileNo.Text = (TryCast((TryCast(sender, Button)).NamingContainer, GridViewRow)).Cells(3).Text
        btnSave.Text = "Update"
        BootstrapCollapsExpand()
        mpeAddUpdateAddressBook.Show()
    End Sub

    Protected Sub Add(ByVal sender As Object, ByVal e As EventArgs)
        ClearControls()
        BootstrapCollapsExpand()
        mpeAddUpdateAddressBook.Show()
    End Sub

    Protected Sub Save(ByVal sender As Object, ByVal e As EventArgs)
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim employeeId As Integer = Convert.ToInt32(hfAddEditId.Value)
        Dim query As String = String.Empty

        If employeeId > 0 Then
            query = "UPDATE Booketails SET Name = @Name, Email = @Email, MobileNo = @MobileNo WHERE Id = @Id"
        Else
            query = "INSERT INTO Booketails(Name, Email, MobileNo) VALUES(@Name, @Email, @MobileNo)"
        End If

        Dim cmd As SqlCommand = New SqlCommand(query)

        If employeeId > 0 Then
            cmd.Parameters.AddWithValue("@Id", employeeId)
        End If

        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim())
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
        cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text)
        cmd.Connection = con
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        BindEmployee()
        mpeAddUpdateAddressBook.Hide()
        ClearControls()
    End Sub

    Protected Sub Delete(ByVal sender As Object, ByVal e As EventArgs)
        hfDeleteId.Value = (TryCast(sender, Button)).CommandArgument
        BootstrapCollapsExpand()
        mpeDeleteAddressBook.Show()
    End Sub

    Protected Sub Yes(ByVal sender As Object, ByVal e As EventArgs)
        Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim Bookid As Integer = Convert.ToInt32(hfDeleteId.Value)
        Dim cmd As SqlCommand = New SqlCommand("DELETE FROM Booketails WHERE Id = @Id")
        cmd.Parameters.AddWithValue("@Id", Bookid)
        cmd.Connection = con
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        BindEmployee()
        mpeDeleteAddressBook.Hide()
        ClearControls()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class