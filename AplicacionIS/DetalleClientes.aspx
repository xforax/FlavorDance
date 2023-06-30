<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/masterCruds.Master" AutoEventWireup="true" CodeBehind="DetalleClientes.aspx.cs" Inherits="AplicacionIS.DetalleClientes" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Seleccione cliente:"></asp:Label>
    <asp:DropDownList ID="listaUsers" runat="server" DataSourceID="SqlDataSource51" DataTextField="nombre_completo" DataValueField="id_usuario" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource51" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select cli.id_usuario,CONCAT(us.nombre,' ',us.apellido) nombre_completo from cliente cli JOIN
				usuario us ON(cli.id_usuario = us.id)"></asp:SqlDataSource>
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" 
        ClientIDMode="AutoID" 
        HighlightBackgroundColor="" 
        InternalBorderColor="204, 204, 204" 
        InternalBorderStyle="Solid" 
        InternalBorderWidth="1px" 
        LinkActiveColor="" 
        LinkActiveHoverColor="" 
        LinkDisabledColor="" 
        PrimaryButtonBackgroundColor="" 
        PrimaryButtonForegroundColor="" 
        PrimaryButtonHoverBackgroundColor="" 
        PrimaryButtonHoverForegroundColor="" 
        SecondaryButtonBackgroundColor="" 
        SecondaryButtonForegroundColor="" 
        SecondaryButtonHoverBackgroundColor="" 
        SecondaryButtonHoverForegroundColor="" 
        SplitterBackColor="" ToolbarDividerColor="" 
        ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" 
        ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" 
        ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" 
        ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" 
        ToolBarItemPressedBorderColor="51, 102, 153" 
        ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" 
        ToolBarItemPressedHoverBackColor="153, 187, 226" Width="1174px"
        >
        <LocalReport ReportPath="ReporteClientes.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
</rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="AplicacionIS.DsTableAdapters.ObtenerInformacionEstudianteTableAdapter">
        <SelectParameters>
            <asp:ControlParameter ControlID="listaUsers" Name="id_cliente" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
