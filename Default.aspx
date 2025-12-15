<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CONGRESO_WB.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta de Asistencias</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body { background-color: #f4f7f6; }
        .card-custom { margin-top: 50px; border: none; box-shadow: 0 4px 6px rgba(0,0,0,0.1); }
        .header-bg { background: linear-gradient(135deg, #0d6efd 0%, #0a58ca 100%); color: white; padding: 20px; border-radius: 5px 5px 0 0; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-9"> <div class="card card-custom">
                        <div class="header-bg text-center">
                            <h3>Estado de tus asistencias en el congreso</h3>
                            <p class="mb-0">Consulta de Asistencia y Cumplimiento</p>
                        </div>
                        <div class="card-body p-4">
                            
                            <div class="row g-2 mb-4">
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg" placeholder="Correo Institucional"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control form-control-lg" placeholder="Matrícula" TextMode="Number"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary btn-lg w-100" OnClick="btnConsultar_Click" />
                                </div>
                            </div>

                            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold d-block text-center mb-3"></asp:Label>

                            <asp:Panel ID="pnlEstadisticas" runat="server" Visible="false" CssClass="row text-center mb-4">
                                <div class="col-4">
                                    <div class="p-3 border rounded bg-light">
                                        <h2 class="text-primary fw-bold"><asp:Label ID="lblTotalInscritos" runat="server"></asp:Label></h2>
                                        <small class="text-muted">Eventos Inscritos</small>
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="p-3 border rounded bg-light">
                                        <h2 class="text-success fw-bold"><asp:Label ID="lblTotalAsistidos" runat="server"></asp:Label></h2>
                                        <small class="text-muted">Asistencias OK</small>
                                    </div>
                                </div>
                                <div class="col-4">
                                    <div class="p-3 border rounded bg-light">
                                        <h2 class="text-info fw-bold"><asp:Label ID="lblPorcentaje" runat="server"></asp:Label>%</h2>
                                        <small class="text-muted">Cumplimiento</small>
                                    </div>
                                </div>
                            </asp:Panel>

                            <div class="table-responsive">
                                <asp:GridView ID="gvAsistencias" runat="server" CssClass="table table-hover align-middle" AutoGenerateColumns="False" GridLines="None" HeaderStyle-CssClass="table-primary">
                                    <Columns>
                                        <asp:BoundField DataField="Evento" HeaderText="Evento" />
                                        <asp:BoundField DataField="Lugar" HeaderText="Ubicación" />
                                        
                                        <asp:TemplateField HeaderText="Estado">
                                            <ItemTemplate>
                                                <%# Convert.ToInt32(Eval("TotalAsistencias")) > 0 
                                                    ? "<span class='badge bg-success'>Completado</span>" 
                                                    : "<span class='badge bg-danger bg-opacity-75'>Pendiente</span>" %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div class="alert alert-warning text-center mt-3">
                                            No encontramos registros con esa combinación de Correo y Matrícula.
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>