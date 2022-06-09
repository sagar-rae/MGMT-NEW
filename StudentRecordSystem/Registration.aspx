<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StudentRecordSystem.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server" class="border border-2 p-5 mt-5 " style="width: 800px; margin: auto">
        <div class="container">
            <div class="row ">
                <h3 class="display-5">Registration</h3>
                <p>@Datetime.Now</p>
                <hr />
                <div class="row">
                    <div class="col-md-3">
                        <label>Student Id</label>
                        <input type="text" class="form-control" placeholder="Student Id" autocomplete="off" runat="server" id="StdId" />
                    </div>

                    <div class="col-md-3" style="margin-left:241px;">
                        <label>Upload image</label>
                        <asp:FileUpload runat="server" ID="fileUploadId" />
                    </div>
                </div>

                <div class="col-md-5 ">
                    <label>Full Name</label>
                    <input type="text" placeholder="Enter your full name" class="form-control" runat="server" id="FnameId" />
                    <label>Email</label>
                    <input type="text" placeholder="Enter your email" class="form-control" runat="server" id="EmailId" />
                    <label>Father's Name</label>
                    <input type="text" placeholder="Enter your Father's name" class="form-control" runat="server" id="FatherId" />
                    <label>Course</label>
                   
                    <br />
                    <asp:DropDownList CssClass="col-md-4 col-form-label rounded rounded-3" AutoPostBack="true" runat="server" ID="DrpListId"></asp:DropDownList>
                    
                   
                </div>

                <div class="col-md-5  ms-auto">
                    <label>Phone Number</label>
                    <input type="text" placeholder="Enter your number" class="form-control" runat="server" id="PhNumId" />
                    <label>Address</label>
                    <input type="text" placeholder="Enter your address" class="form-control" runat="server" id="AddressId" />
                    <label>Mother's Name</label>
                    <input type="text" placeholder="Enter your Mother's Name" class="form-control" runat="server" id="MotherId" />
                    <label>Date of Birth</label>
                    <input type="date" class="form-control" runat="server" id="DOBId" />
                </div>
            </div>
            <div class="row">
                <asp:Button Text="Submit" CssClass="btn btn-outline-danger col-md-2 mt-3 ms-auto m-3" runat="server" OnClick="Submit_Click" />
            </div>
        </div>
    </form>


</asp:Content>
