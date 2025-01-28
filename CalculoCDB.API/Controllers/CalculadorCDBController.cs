using AutoMapper;
using CalculoCDB.API.ViewModel;
using CalculoCDB.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.API.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class CalculadorCDBController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICalculadorCDBService _calculadorCDBService;        

        public CalculadorCDBController(IMapper mapper, ICalculadorCDBService calculadorCDBService)
        {
            _mapper = mapper;
            _calculadorCDBService = calculadorCDBService;
        }

        [HttpPost]
        [Route("/api/calculador/calcular-cdb")]
        public ResultadoCalculadorCDBViewModel CalcularCdb([FromBody] CalculadorCDBViewModel input)
        {
            var resultadoCdb = _calculadorCDBService.ExecutarCalculoCdb(input.quantidadeMeses, input.valorInicial);
            return _mapper.Map<ResultadoCalculadorCDBViewModel>(resultadoCdb);
        }

    }
}
