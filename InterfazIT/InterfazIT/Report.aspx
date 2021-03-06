<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="InterfazIT.Report" %>

<!DOCTYPE html>

<link href="https://fonts.googleapis.com/css2?family=Poppins&display=swap" rel="stylesheet"/>
<link href="fonts/StylesReport.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="flex-container">
        <form id="form1" runat="server">
        <div class="input-container">
            <asp:Label ID="lblTitulo" runat="server" Text="Ingrese su datos para el Informe"/>
            <br/>
            <br/>
            <div class="container"> 
                <asp:Label ID="lblName" runat="server" Text="Nombre: "/>
            <br />
            <asp:TextBox ID="txtName" runat="server"  class="inputs"/> 
            <br />
            <asp:Label ID="lblLastName" runat="server" Text="Apellido: "/>
            <br />
            <asp:TextBox ID="txtLastName" runat="server"  class="inputs"/>
            <br />
            <asp:Label ID="lbllocacion" runat="server" Text="Seleccione su locacion actual: " />
            <br/>
             <asp:DropDownList ID="CmbLocacion" runat="server" class ="inputs">
                 <asp:ListItem>Ecuador</asp:ListItem>
             </asp:DropDownList>
             <br />
             <asp:Label ID="lblRazon" runat="server" Text="Ingrese la razon de su firma: " />
             <br/>             
             <asp:TextBox ID ="txtRazon" runat="server" class="inputs" />
             <br /><br />
            <asp:Button ID="btnLlenar" runat="server" text="Llenar Informe" OnClick="btnLlenar_Click" class="submit-btn"/>
            </div>
        </div>
    </form>
    </div>  
</body>
</html>
