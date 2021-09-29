<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="archivo.aspx.cs" Inherits="InterfazIT.archivo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<link rel="preconnect" href="https://fonts.googleapis.com"/>
<link rel="preconnect" href="https://fonts.gstatic.com"/>
<link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet"/>
<link href="fonts/styles.css" rel="stylesheet" type="text/css" />
<head runat="server">
    <title></title>
</head>

<body>
    <h1 class="title"> Firma Electrónica</h1>
    <form id="form1" runat="server">
         <div>
            <h4>Seleccione su PDF:</h4>
            <asp:FileUpload id="FileUpload1" runat="server" CssClass="upload"/>
            <br/>
             <h4>Seleccione su certificado p12:</h4>
            <asp:FileUpload id="FileUpload2" runat="server" CssClass="upload"/>
             <br/><br/>
            <asp:Button id="btnPDF" Text="Subir Firma" OnClick="UploadButton_Click" runat="server"/>  
             <br/>
            <asp:Label id="UploadStatusLabel" runat="server"/>
            <%--<h2>Ingreso de PDF</h2>
            <asp:Label id ="lblPDF" runat="server" text="Ingrese su PDF"></asp:Label>
            <asp:TextBox id ="txtPDF" runat="server" ></asp:TextBox>
            <span id="notificationUser" class="hidden color-span">Por favor, rellene este campo.</span>
            <br/>
            <asp:Label ID="lblKey" runat="server" text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtKey" runat="server" Type="password"></asp:TextBox>
            <span id="notificationKey" class="hidden color-span">Por favor, rellene este campo.</span>
            <br />
            <asp:Button ID="btnLeer" runat="server" Text="Ingresar" CssClass="btn-primary" Onclick="btnLeer_Click"/>
            <br />
             <asp:TextBox ID="txtFile" runat="server" Type="file"></asp:TextBox>--%>
        </div>
    </form>
</body>
</html>
