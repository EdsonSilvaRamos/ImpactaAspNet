<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Create.aspx.cs" inherits="Pessoal.WebForms.Tarefas.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Nova Tarefa</h1>
    <hr />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <table>
        <tr>
            <td>Nome</td>
            <td>
                <asp:TextBox ID="nomeTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nome é obrigatório" CssClass="text-danger" ControlToValidate="nomeTextBox" Text="(!)"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Prioridade</td>
            <td>
                <asp:DropDownList ID="prioridadeDropDownList" DataSourceID="prioridadeObjectDataSource" AppendDataBoundItems="true" runat="server">
                    <asp:ListItem Text="Selecione" Value="0" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Selecione a prioridade" ControlToValidate="prioridadeDropDownList" CssClass="text-danger" InitialValue="0">(!)</asp:RequiredFieldValidator>
                <asp:ObjectDataSource ID="prioridadeObjectDataSource" runat="server" SelectMethod="ObterPrioridades" TypeName="Pessoal.WebForms.Tarefas.Create" />
            </td>
        </tr>
        <tr>
            <td style="width: 89px">Concluida</td>
            <td>
                <asp:CheckBox Text="" ID="concluidaCheckBox" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 89px">Observações</td>
            <td>
                <asp:TextBox TextMode="MultiLine" ID="observacoesTextBox" Rows="5" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button Text="Gravar" ID="gravarButton" runat="server" OnClick="gravarButton_Click" />
</asp:Content>
