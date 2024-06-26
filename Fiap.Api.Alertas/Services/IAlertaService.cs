using Fiap.Api.Alertas.Models;

namespace Fiap.Api.Alertas.Services
{
    public interface IAlertaService
    {
        IEnumerable<AlertaModel> ListarAlertas();
        IEnumerable<AlertaModel> ListarAlertas(int pagina = 0, int tamanho = 10);
        AlertaModel ObterAlertaPorId(long id);
        void CriarAlerta(AlertaModel alerta);
        void AtualizarAlerta(AlertaModel alerta);
        void DeletarAlerta(long id);
    }
}
