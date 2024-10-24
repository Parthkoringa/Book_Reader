<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Uploadbook.aspx.cs" Inherits="BookReader.Uploadbook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Book</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100%;
        }

        .container {
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
            padding: 30px;
            width: 400px;
            text-align: left;
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
            color: #333;
        }

        label {
            margin-bottom: 5px;
            color: #555;
            display: block;
            font-weight: bold;
        }

        input[type="text"],
        input[type="file"],
        textarea {
            width: 95%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
            transition: border-color 0.3s;
        }

        input[type="text"]:focus,
        textarea:focus {
            border-color: #007BFF;
            outline: none;
        }

        .error-message {
            color: red;
            font-size: 12px;
            margin-bottom: 10px;
        }

        button {
            background-color: #007BFF;
            color: white;
            border: none;
            padding: 10px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            width: 48%;
            transition: background-color 0.3s;
        }

        button:hover {
            background-color: #0056b3;
        }

        .button-container {
            display: flex;
            justify-content: space-between;
            margin-top: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Upload Book</h2>
            <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
            &nbsp;<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RFVTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="Book Title is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Author"></asp:Label>
            &nbsp;<asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RFVAuthor" runat="server" ControlToValidate="txtAuthor" ErrorMessage="Author name is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
            &nbsp;<asp:TextBox ID="txtDescription" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RFVDesc" runat="server" ControlToValidate="txtDescription" ErrorMessage="Book Description is required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Cover Page"></asp:Label>
            &nbsp;<asp:FileUpload ID="coverPage" runat="server" />
            &nbsp;<asp:RequiredFieldValidator ID="RFVCover" runat="server" ControlToValidate="coverPage" ErrorMessage="Please upload cover page" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Book PDF"></asp:Label>
            &nbsp;<asp:FileUpload ID="bookPDf" runat="server" />
            &nbsp;<asp:RequiredFieldValidator ID="RFVBook" runat="server" ControlToValidate="bookPDf" ErrorMessage="Please upload Book PDF" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblMessage" runat="server" Text="Successfully added"></asp:Label>
            <br />
            <div class="button-container">
                <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
                <asp:Button ID="btnHome" runat="server" Text="Home" OnClick="btnHome_Click" CausesValidation="False" />
            </div>
        </div>
    </form>
</body>
</html>

