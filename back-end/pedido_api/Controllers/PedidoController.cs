using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pedido_api.Dto;
using pedido_api.Entities;
using pedido_api.Repository;

namespace pedido_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        PedidoDBCommunicator communicator = new PedidoDBCommunicator();
        //GET da listagem de todos os produtos
        [HttpGet]
        public ActionResult<PedidoGetDto> Get()
        {
            List<PedidoGetDto> ret = communicator.GetAll();
            if(ret is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }

        // GET de um produto especifico indicado pelo ID
        [HttpGet("{id}")]
        public ActionResult<PedidoGetDto> Get(int id)
        {
            PedidoGetDto ret = communicator.GetPorId(id);
            if (ret is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ret);
            }
        }
        // POST de um produto específico
        [HttpPost]
        public ActionResult<int> PostEspecifico(PedidoPostDto PPost)
        {
            return Ok(communicator.PostEspecifico(PPost));
        }

        // PUT de um produto determinado pelo id
        [HttpPut("{id}")]
        public ActionResult<Boolean> Put(int id, PedidoPutDto PPut)
        {
            PedidoGetDto aux = communicator.GetPorId(id);
            if (aux is null)
            {
                return NotFound();
            }
            else
            {
                aux.NomeProduto = PPut.NomeProduto;
                aux.Valor = PPut.Valor;
                aux.DataVencimento = PPut.DataVencimento;
                return Ok(communicator.PutEspecifico(id, aux));
            }
        }

        // DELETE de um produto específico pelo id
        [HttpDelete("{id}")]
        public ActionResult<Boolean> Delete(int id)
        {
            PedidoGetDto aux = communicator.GetPorId(id);
            if (aux is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(communicator.DeleteEspecifico(id));
            }

        }
    }
}
