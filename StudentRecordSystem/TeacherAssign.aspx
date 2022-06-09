<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TeacherAssign.aspx.cs" Inherits="StudentRecordSystem.WebForm11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="border border-2 mt-5 p-5" style="margin: auto; width: 600px">
        <h3 class="display-5">Assign Teachers</h3>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <label class="form-label">Select Course:</label>
                    <asp:DropDownList CssClass="col-md-4 col-form-label rounded rounded-3" AutoPostBack="true" runat="server" ID="DrpListId"></asp:DropDownList>

                    <div runat="server" id="toHide">
                        <label runat="server" class="form-label">Select Subject:</label>
                        <asp:DropDownList CssClass="col-md-12 col-form-label rounded rounded-3" runat="server" ID="SubjectDrop"></asp:DropDownList>
                         <label runat="server" class="form-label">Select Teacher:</label>
                        <asp:DropDownList CssClass="col-md-12 col-form-label rounded rounded-3" runat="server" ID="TeacherDrop"></asp:DropDownList>
                    </div>
                  
                </div>
                <div class="">
                    <asp:Button runat="server" CssClass="btn btn-outline-danger mt-3" ID="SubmitId" Text="Assign" OnClick="Submit_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>

