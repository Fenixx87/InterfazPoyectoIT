<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="archivo.aspx.cs" Inherits="InterfazIT.archivo" %>

<%@ Register assembly="DevExpress.Web.Bootstrap.v21.1, Version=21.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Bootstrap" tagprefix="dx" %>

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
            <asp:FileUpload id="FileUpload1" runat="server" CssClass="upload" />
            <br/>
            <h4>Seleccione su certificado p12:</h4>
            <asp:FileUpload id="FileUpload2" runat="server" CssClass="upload"/>
             <!--<br/>
             <h4>Seleccione la imagen de su firma:</h4>
            <asp:FileUpload id="FileUpload3" runat="server" CssClass="upload"/>-->
            <br/><br/>
            <asp:Label ID ="lblData" runat="server" Text="Ingrese los datos siguientes datos:" />
             <br /><br/>
             <asp:Label ID="lbllocacion" runat="server" Text="Seleccione su locacion actual: " />
             <asp:DropDownList ID="CmbLocacion" runat="server" OnSelectedIndexChanged="CmbLocacion_SelectedIndexChanged">
                 <asp:ListItem>Ecuador</asp:ListItem>
             </asp:DropDownList>
             <br />
             <!--<asp:Label ID="lblInfo" runat="server" Text="Ingrese un medio de contacto: " />
             <asp:TextBox ID ="txtInfo" runat="server" />
             <br />-->
             <asp:Label ID="lblRazon" runat="server" Text="Ingrese la razon de su firma: " />
             <asp:TextBox ID ="txtRazon" runat="server" />
             <br /><br />
            <asp:Button ID="btnPDF" Text="Subir Firma" OnClick="UploadButton_Click" runat="server"/>  
             <br/>
            <asp:Label id="UploadStatusLabel" runat="server" />
            <br />            
        </div>
    </form>
</body>
</html>
