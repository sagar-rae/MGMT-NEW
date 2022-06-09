<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="FeeReceipt.aspx.cs" Inherits="StudentRecordSystem.WebForm18" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://rawgit.com/unconditional/jquery-table2excel/master/src/jquery.table2excel.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#Download').on('click', function (e) {
                e.preventDefault();
                ResultsToTable();
            });

            function ResultsToTable() {
                $("#tableId").table2excel({
                    exclude: ".noExl",
                    name: "Results"
                });
            }
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server" style="width: 800px" class="mx-auto p-5 border border-2">
        <div class="container">
            <div class="row">
                <h2 class="display-3">Fee Receipt</h2>
                <hr />
                <div class="col-md-8">
                    <label class="form-label">Student Reg Id:</label>
                    <input type="text" autocomplete="off" runat="server" id="StdRegId" class="col-md-2 rounded-2" />
                </div>
                <div class="col-md-3">
                    <asp:Button runat="server" ID="SubmitId" Text="Search" CssClass="btn btn-outline-danger btn-block" OnClick="SubmitId_Click" />
                </div>
                <asp:Panel runat="server" ID="PanelId"></asp:Panel>
            </div>
        </div>
    </form>
</asp:Content>
