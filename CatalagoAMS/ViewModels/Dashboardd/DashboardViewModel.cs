namespace CatalagoAMS.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        // Estatísticas Gerais
        public int TotalMunicipios { get; set; }
        public int TotalEscolas { get; set; }

        // Listas para exibição
        public List<Escola> UltimasEscolas { get; set; }
        public List<Municipio> UltimosMunicipios { get; set; }

        // Estatísticas Detalhadas
        public Dictionary<string, int> EscolasPorEstado { get; set; }
        public Dictionary<string, int> EscolasPorMunicipio { get; set; }

        // Métricas de Crescimento
        public int EscolasAdicionadasUltimos30Dias { get; set; }
        public int MunicipiosAdicionadosUltimos30Dias { get; set; }

        // Informações de Status
        public int EscolasAtivasTotal { get; set; }
        public int EscolasInativasTotal { get; set; }

        // Dados para Gráficos
        public Dictionary<string, int> EscolasPorMes { get; set; }
        public Dictionary<string, double> MediaEscolasPorMunicipio { get; set; }

        // Filtros Ativos
        public string EstadoSelecionado { get; set; }
        public string MunicipioSelecionado { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        // Informações de Paginação
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int RegistrosPorPagina { get; set; }

        // Construtores
        public DashboardViewModel()
        {
            // Inicializa as listas e dicionários
            UltimasEscolas = new List<Escola>();
            UltimosMunicipios = new List<Municipio>();
            EscolasPorEstado = new Dictionary<string, int>();
            EscolasPorMunicipio = new Dictionary<string, int>();
            EscolasPorMes = new Dictionary<string, int>();
            MediaEscolasPorMunicipio = new Dictionary<string, double>();

            // Define valores padrão
            PaginaAtual = 1;
            RegistrosPorPagina = 10;
            DataInicio = DateTime.Now.AddMonths(-1);
            DataFim = DateTime.Now;
        }

        // Métodos Auxiliares
        public double CalcularMediaEscolasPorMunicipio()
        {
            if (TotalMunicipios == 0) return 0;
            return (double)TotalEscolas / TotalMunicipios;
        }

        public double CalcularPercentualCrescimento()
        {
            if (TotalEscolas == 0) return 0;
            return ((double)EscolasAdicionadasUltimos30Dias / TotalEscolas) * 100;
        }

        public Dictionary<string, string> ObterResumoEstatistico()
        {
            return new Dictionary<string, string>
            {
                { "Total de Escolas", TotalEscolas.ToString() },
                { "Total de Municípios", TotalMunicipios.ToString() },
                { "Média de Escolas por Município", CalcularMediaEscolasPorMunicipio().ToString("F2") },
                { "Crescimento nos Últimos 30 Dias", $"{CalcularPercentualCrescimento():F2}%" }
            };
        }

        // Propriedades Calculadas
        public bool TemFiltrosAtivos =>
            !string.IsNullOrEmpty(EstadoSelecionado) ||
            !string.IsNullOrEmpty(MunicipioSelecionado) ||
            DataInicio.HasValue ||
            DataFim.HasValue;

        public string PeriodoSelecionado =>
            DataInicio.HasValue && DataFim.HasValue
                ? $"{DataInicio.Value:dd/MM/yyyy} - {DataFim.Value:dd/MM/yyyy}"
                : "Todo o período";
    }

}
