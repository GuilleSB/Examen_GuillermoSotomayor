<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMantenimientoEstudiante.aspx.cs" Inherits="Examen_GuillermoSotomayor.frmMantenimientoEstudiante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2>Mantenimiento de estudiantes</h2>
        <asp:TextBox ID="accions" runat="server" Visible="false"></asp:TextBox>
        <div class="form-group">
            <asp:Label CssClass="form-label" runat="server" Text="Código"></asp:Label>
            <asp:TextBox ID="tx_codigo" CssClass="form-control" runat="server" readonly="true" />
            <asp:Button ID="btConsultar" CssClass="btn btn-primary" runat="server" Text="Consultar" OnClick="btConsultar_Click" />
        </div>

        <div class="form-group">
            <asp:Label CssClass="form-label" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="tx_Nombre" CssClass="form-control" runat="server"  />
        </div>
        <div class="form-group">
            <asp:Label CssClass="form-label" runat="server" Text="Nota 1"></asp:Label>
            <asp:TextBox ID="tx_Nota1" CssClass="form-control" runat="server"  />
        </div>
        <div class="form-group">
            <asp:Label CssClass="form-label" runat="server" Text="Nota 2"></asp:Label>
            <asp:TextBox ID="tx_Nota2" CssClass="form-control" runat="server"  />
        </div>
        <div class="form-group">
            <asp:Label CssClass="form-label" runat="server" Text="Nota proyecto"></asp:Label>
            <asp:TextBox ID="tx_NotaProyecto" CssClass="form-control" runat="server"  />
        </div>
        <div class="form-group">
            <asp:Button CssClass="btn btn-primary" Text="Agregar" ID="btAgregar" runat="server" OnClick="btAgregar_Click" />
            <asp:Button CssClass="btn btn-warning" Text="Editar" ID="btEditar" runat="server" OnClick="btEditar_Click" />
            <asp:Button CssClass="btn btn-danger" Text="Eliminar" ID="btEliminar" runat="server" OnClick="btEliminar_Click" />
        
            <asp:Button CssClass="" Text="Confirmar" ID="btConfirmar" runat="server" OnClick="btConfirmar_Click" />
            <asp:Button CssClass="btn btn-secondary" Text="Cancelar" ID="btCancelar" runat="server" OnClick="btCancelar_Click" />

        </div>
        
    <br />

             <asp:Label ID="lblError" CssClass="alert alert-danger" runat="server" Text=""></asp:Label>
</asp:Content>
