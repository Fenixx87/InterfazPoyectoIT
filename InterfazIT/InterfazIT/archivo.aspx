<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="archivo.aspx.cs" Inherits="InterfazIT.archivo" %>

<%@ Register assembly="DevExpress.Web.Bootstrap.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Bootstrap" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <h4>Seleccione su PDF:</h4>
            <asp:FileUpload id="FileUpload1" runat="server"/>
            <br/>
             <h4>Seleccione su certificado p12:</h4>
            <asp:FileUpload id="FileUpload2" runat="server"/>
             <br/><br/>
            <asp:Button id="btnPDF" Text="Subir Firma" OnClick="UploadButton_Click" runat="server"/>  
             <br/>
            <hr />
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
