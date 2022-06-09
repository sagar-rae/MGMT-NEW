<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddAttendance.aspx.cs" Inherits="StudentRecordSystem.WebForm14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script type="text/javascript">
        function test(val) {
             var jsondata = { id: val };
            $(document).ready(function () {
                $.ajax({
                    url: '<%=ResolveClientUrl("~/AddAttendance.aspx/Attendance")%>',
                    type: 'Post',
                    data: JSON.stringify(jsondata),
                    contentType: 'application/json; charset=utf - 8',
                    dataType: 'json',
                    success: function (responce) {
                        alert(responce.d);
                    },
                    failure: function () {
                        alert('Failed');
                    }
                });
            });         
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="border border-2 mt-5 p-5" style="margin: auto; width: 600px">
        <h5 class="display-5">Attendance</h5>
        <hr />
        <div class="container">
            <div class="row g-1 justify-content-between">
                <div class="col-md-6">
                    <label class="form-label">Select Course:</label>
                    <asp:DropDownList CssClass=" col-md-6 col-form-label-sm rounded rounded-3" AutoPostBack="true" runat="server" ID="DrpListId">
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <label runat="server" class="form-label">Select Subject:</label>
                    <asp:DropDownList CssClass="col-md-6 col-form-label-sm rounded rounded-3" runat="server" ID="SubjectDrop"></asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="mt-2 d-flex align-items-center">
                    <label class="col-md-3">Select Date:</label>
                    <input type="date" runat="server" id="DateId" class=" col-form-label-sm rounded-3" style="margin-left: -15px" />
                </div>
            </div>
          
            <div class="row mt-2 col-md-3">
                <asp:Button runat="server" ID="SubmitId" OnClick="SubmitId_Click" CssClass="btn btn-outline-danger btn-sm" Text="Search" />
            </div>
        </div>
       <div class="mt-5">
             <asp:PlaceHolder runat="server" ID="PlaceholderCourse"></asp:PlaceHolder>
           </div>
    </form>

</asp:Content>
