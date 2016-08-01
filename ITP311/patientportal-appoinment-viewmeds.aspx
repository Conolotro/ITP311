<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="patientportal-appoinment-viewmeds.aspx.cs" Inherits="ITP311.patientportal_appoinment_viewmeds" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Medication List:
        <br />
        <asp:Label ID="lblEnMeds" runat="server" Text="Lisinopril (a blood pressure drug)" Visible="False"></asp:Label>
        <br />
        <asp:Button ID="Decrypt" runat="server" Text="btnDecrypt" OnClick="btnDecrypt_Click" />
        <br />
        <asp:Label ID="lblCipher" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="lblShowMeds" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
