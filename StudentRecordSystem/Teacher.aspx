<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="StudentRecordSystem.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" class="border border-2 mt-5 p-5" style="margin: auto; width: 800px">
        <h3 class="display-5">Add Teacher</h3>
        <hr />
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <label>Full Name</label>
                    <input type="text" placeholder="Enter your full name" class="form-control" runat="server" required id="FnameId" />
                    <label>Email</label>
                    <input type="text" placeholder="Enter your email" class="form-control" runat="server" id="EmailId" />
                    <label>Phone Number</label>
                    <input type="text" placeholder="Enter your number" class="form-control" runat="server" id="PhNumId" />
                    <label>Address</label>
                    <input type="text" placeholder="Enter your address" class="form-control" runat="server" id="AddressId" />
                    <asp:Button runat="server" ID="InsertBtn" OnClick="Insert_Click" CssClass="btn btn-outline-danger" Text="Insert" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
