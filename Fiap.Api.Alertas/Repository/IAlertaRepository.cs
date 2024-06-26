using Fiap.Api.Alertas.Models;

namespace Fiap.Api.Alertas.Repository
{
    public interface IAlertaRepository
    {
        List<AlertaModel> GetAll();
        IEnumerable<AlertaModel> GetAll(int page, int size);
        AlertaModel GetById(long id);
        void Add(AlertaModel alerta);
        void Update(AlertaModel alerta);
        void Delete(AlertaModel alerta);
    }
}
