using Fiap.Api.Alertas.Data;
using Fiap.Api.Alertas.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Alertas.Repository
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly DatabaseContext _context;

        public AlertaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<AlertaModel> GetAll()
        {
            return _context.Alertas.ToList();
        }

        public IEnumerable<AlertaModel> GetAll(int page, int size)
        {
            return _context.Alertas
                            .Skip((page - 1) * page)
                            .Take(size)
                            .AsNoTracking()
                            .ToList();
        }

        public AlertaModel GetById(long id) => _context.Alertas.Find(id);

        public void Add(AlertaModel alerta)
        {
            _context.Alertas.Add(alerta);
            _context.SaveChanges();
        }

        public void Update(AlertaModel alerta)
        {
            _context.Update(alerta);
            _context.SaveChanges();
        }

        public void Delete(AlertaModel alerta)
        {
            _context.Alertas.Remove(alerta);
            _context.SaveChanges();
        }
    }
}
