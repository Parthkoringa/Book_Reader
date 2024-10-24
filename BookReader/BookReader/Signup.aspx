<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="BookReader.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up - Book Reader</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f5f5f5;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        form {
            width: 100%;
            max-width: 400px;
            background-color: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            color: #333;
        }

        input[type="text"], input[type="password"] {
            width: 95%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
        }

        .error-message {
            color: red;
            font-size: 12px;
            margin-bottom: 10px;
        }

        button {
            width: 100%;
            color: white;
            padding: 10px;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
        }

        button:hover {
            background-color: #45a049;
        }

        .signup-link {
            text-align: center;
            margin-top: 10px;
            font-size: 14px;
        }

        .signup-link a {
            color: #007BFF;
            text-decoration: none;
        }

        .signup-link a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

            <h2>Create Account</h2>
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Enter your username"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is Required" CssClass="error-message" SetFocusOnError="True"></asp:RequiredFieldValidator>

            <br />
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" placeholder="Create a password"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is Required" CssClass="error-message" SetFocusOnError="True"></asp:RequiredFieldValidator>

            <br />

            <asp:Label ID="lblConfirmpass" runat="server" Text="Confirm Pass"></asp:Label>
            <asp:TextBox ID="txtConfirmpass" runat="server" TextMode="Password" placeholder="Enter confirm Password"></asp:TextBox>
            <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmpass" ErrorMessage="Both password doesn't match" ForeColor="Red" SetFocusOnError="True" CssClass="error-message"></asp:CompareValidator>
            <br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirmpass" ErrorMessage="Confirm password is required" ForeColor="Red" CssClass="error-message"></asp:RequiredFieldValidator>

            <br />
            <asp:Button ID="btnSignup" runat="server" OnClick="btnSignup_Click" Text="Sign Up" />

            <div class="link">
                Already have an account? 
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Login.aspx" CausesValidation="False">Log in</asp:LinkButton>
            </div>


    </form>
</body>
</html>
