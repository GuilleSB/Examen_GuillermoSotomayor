<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultarEstudiante.aspx.cs" Inherits="Examen_GuillermoSotomayor.frmConsultarEstudiante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2>Consultar estudiantes</h2>
    <div class="form-group">
            <asp:Label class="form-label" runat="server" Text="Codigo"></asp:Label>
            <asp:TextBox ID="tx_codigo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button CssClass="btn btn-primary" runat="server" Text="Consultar" ID="btConsultar" OnClick="btConsultar_Click" />
        </div>
        <div class="form-group">
            <asp:Label class="form-label" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="tx_Nombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label class="form-label" runat="server" Text="Nota 1"></asp:Label>
            <asp:TextBox ID="tx_Nota1" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label class="form-label" runat="server" Text="Nota 2"></asp:Label>
            <asp:TextBox ID="tx_Nota2" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label class="form-label" runat="server" Text="Nota proyecto"></asp:Label>
            <asp:TextBox ID="tx_NotaProyecto" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label class="form-label" runat="server" Text="Condicion"></asp:Label>
            <asp:TextBox ID="tx_Condicion" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
    <br />

             <asp:Label ID="lblError" CssClass="alert alert-danger" runat="server" Text=""></asp:Label>

</asp:Content>
