<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="InterfazIT.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitulo" runat="server" Text="Ingrese su datos para el Informe" />
            <br/><br/>
            <asp:Label ID="lblName" runat="server" Text="Nombre: " />
            <asp:TextBox ID="txtName" runat="server"/>
            <br />
            <asp:Label ID="lblLastName" runat="server" Text="Apellido: "/>
            <asp:TextBox ID="txtLastName" runat="server"/>
            <br /><br />
            <asp:Label ID ="lblData" runat="server" Text="Ingrese los datos siguientes datos:" />
             <br /><br/>
             <asp:Label ID="lbllocacion" runat="server" Text="Seleccione su locacion actual: " />
             <asp:DropDownList ID="CmbLocacion" runat="server">
                 <asp:ListItem>Ecuador</asp:ListItem>
             </asp:DropDownList>
             <br />
             <!--<asp:Label ID="lblInfo" runat="server" Text="Ingrese un medio de contacto: " />
             <asp:TextBox ID ="txtInfo" runat="server" />
             <br />-->
             <asp:Label ID="lblRazon" runat="server" Text="Ingrese la razon de su firma: " />
             <asp:TextBox ID ="txtRazon" runat="server" />
             <br /><br />
            <asp:Button ID="btnLlenar" runat="server" text="Llenar Informe" OnClick="btnLlenar_Click" />
            <!--<asp:Button ID="btnRedFirmar" runat="server" Text="Firmar Documento" OnClick="btnRedFirmar_Click" />-->
        </div>
    </form>
</body>
</html>
