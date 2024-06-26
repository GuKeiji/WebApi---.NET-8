using Fiap.Api.Alertas.Models;
using Fiap.Api.Alertas.Repository;

namespace Fiap.Api.Alertas.Services
{
    public class AlertaService : IAlertaService
    {
        private readonly IAlertaRepository _repository;

        public AlertaService(IAlertaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AlertaModel> ListarAlertas() => _repository.GetAll();
        public IEnumerable<AlertaModel> ListarAlertas(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina, tamanho);
        }

        public AlertaModel ObterAlertaPorId(long id) => _repository.GetById(id);

        public void CriarAlerta(AlertaModel alerta) => _repository.Add(alerta);

        public void AtualizarAlerta(AlertaModel alerta) => _repository.Update(alerta);

        public void DeletarAlerta(long id)
        {
            var alerta = _repository.GetById(id);
            if (alerta != null)
            {
                _repository.Delete(alerta);
            }
        }
    }
}
