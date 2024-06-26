namespace Fiap.Api.Alertas.ViewModel
{
    public class AlertaViewModel
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Risco { get; set; }
        public string Situacao { get; set; }
        public DateTime DataAlerta { get; set; }
    }
}
