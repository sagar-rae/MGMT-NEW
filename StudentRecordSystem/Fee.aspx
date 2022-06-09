<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Fee.aspx.cs" Inherits="StudentRecordSystem.WebForm17" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="border border-2 mt-5 p-5" style="margin: auto; width: 600px">
        <h3 class="display-5 text-center">Fee Deposit</h3>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-md-6">

                    <label class="form-label">ID:</label>
                    <input type="text" runat="server" id="StdId" class="form-control" />

                    <label class="form-label mt-3 form-label">Select Course:</label>
                    <asp:DropDownList CssClass="col-md-4 col-form-label rounded rounded-3" runat="server" ID="DrpListId"></asp:DropDownList>



                </div>

                <div class="col-md-6">
                    <label class="form-label">Student Name:</label>
                    <input type="text" runat="server" id="NameId" class="form-control" />
                </div>
            </div>

            <hr />
            <div class="row">
                <div class="col-md-6">
                    <label class="form-label">Total Fee:</label>
                    <input type="text" runat="server" id="FeeId" class="form-control" readonly="readonly" value="1000000" />
                    <label class="form-label">Deposit Amount:</label>
                    <input type="text" runat="server" id="DepositId" class="form-control" />
                   
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-md-3">
                    <asp:Button runat="server" ID="SubmitId" OnClick="SubmitId_Click" Text="Submit" CssClass="btn btn-outline-danger btn-block" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
