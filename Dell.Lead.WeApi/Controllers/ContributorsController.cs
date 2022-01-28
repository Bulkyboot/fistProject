using Dell.Lead.WeApi.Business;
using Dell.Lead.WeApi.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Dell.Lead.WeApi.Controllers
{
    [ApiVersion("1")]
    [Authorize("Bearer")]
    [ApiController]
    [Route("api/v{version:ApiVersion}/contributors")]
    public class ContributorsController : ControllerBase
    {
        private readonly IContributorsBusiness _contributorsBusiness;
        public ContributorsController(IContributorsBusiness contributorsBusiness)
        {
            _contributorsBusiness = contributorsBusiness;
        }
        /// <summary>
        /// List all contributors.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /api/v1/Contributors
        ///   
        ///        {
        ///        "code": 0,
        ///        "name": "string",
        ///        "cpf": 0,
        ///        "date_of_birth": "2022-01-01T16:03:16.910Z",
        ///        "cellfone": 0,
        ///        "gender": "string",
        ///        "address": {
        ///          "code": 0,
        ///          "street": "string",
        ///          "number": 0,
        ///          "district": "string",
        ///          "city": "string",
        ///          "state": "string",
        ///          "cep": "string"
        ///        }
        ///      }
        ///    
        ///
        /// </remarks>
        /// <returns> List contributors</returns>
        /// <response code="200">return list of the contributors</response>
        [HttpGet]
        public ActionResult<List<ContributorsVO>> FindAll()
        {
            var contributors = _contributorsBusiness.FindAll();
            return Ok(contributors);
        }

        /// <summary>
        /// Seacry for contributors.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /api/v1/contributors/CPF
        ///   
        ///        {
        ///        "id": 0,
        ///        "name": "string",
        ///        "cpf": 0,
        ///        "date_of_birth": "2022-01-01T16:03:16.910Z",
        ///        "cellfone": 0,
        ///        "gender": "string",
        ///        "address": {
        ///          "code": 0,
        ///          "street": "string",
        ///          "number": 0,
        ///          "district": "string",
        ///          "city": "string",
        ///          "state": "string",
        ///          "cep": "string"
        ///        }
        ///      }
        ///    
        ///
        /// </remarks>
        /// <param name="cpf">Isuer the cpf for screay Contributors</param>
        /// <returns>Retorna o Contribuidores pesquisado pelo cpf</returns>
        /// <response code="200">Retorna o funcionário pesquisado</response>
        /// <response code="400">Retorna CPF é inválido ou Retorna CPF não cadastrado</response>
        [HttpGet("{cpf}")]
        public ActionResult<ContributorsVO> FindByCpf(long cpf)
        {
                var contributors = _contributorsBusiness.FindByCpf(cpf);
                if(contributors == null) return BadRequest();
                return Ok(contributors);
        }

        /// <summary>
        /// Cadastrar Contribuidores.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /api/v1/employees/
        ///   
        ///        {
        ///        "id": 0,
        ///        "name": "string",
        ///        "cpf": 0,
        ///        "date_of_birth": "2022-01-01T16:03:16.910Z",
        ///        "cellfone": 0,
        ///        "gender": "string",
        ///        "address": {
        ///          "code": 0,
        ///          "street": "string",
        ///          "number": 0,
        ///          "district": "string",
        ///          "city": "string",
        ///          "state": "string",
        ///          "cep": "string"
        ///        }
        ///      }
        ///    
        ///
        /// </remarks>
        /// <returns>Retorna o Contribuidores cadastrado</returns>
        /// <response code="200">Retorna o novo Contribuidores cadastrado</response>
        /// <response code="400">Retorna CPF é inválido ou Retorna CPF não cadastrado</response>
        [HttpPost]
        public ActionResult Create([FromBody] ContributorsVO contributors)
        {
            if (contributors == null) return BadRequest("Funcionário inválido");
                var newContributors = _contributorsBusiness.Create(contributors);
                return Ok(newContributors);
        }

        /// <summary>
        /// Atualizar cadastro do Contribuidores.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT /api/v1/employees/
        ///   
        ///        {
        ///        "id": 0,
        ///        "name": "string",
        ///        "cpf": 0,
        ///        "date_of_birth": "2022-01-01T16:03:16.910Z",
        ///        "cellfone": 0,
        ///        "gender": "string",
        ///        "address": {
        ///          "code": 0,
        ///          "street": "string",
        ///          "number": 0,
        ///          "district": "string",
        ///          "city": "string",
        ///          "state": "string",
        ///          "cep": "string"
        ///        }
        ///      }
        ///    
        ///
        /// </remarks>
        /// <returns>Retorna o Contribuidores com as informações atualizadas</returns>
        /// <response code="200">Retorna o Contribuidores com as informações atualizadas</response>
        /// <response code="400">Retorna CPF é inválido ou Retorna CPF não cadastrado</response>
        [HttpPut]
        public ActionResult Put([FromBody] ContributorsVO contributors)
        {
            if (contributors == null) return BadRequest("Funcionário inválido");
                var changerEmployee = _contributorsBusiness.Update(contributors);
                return Ok(changerEmployee);
            
        }

        /// <summary>
        /// Deleta cadastro do Contribuidores pesquisado pelo cpf.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     DELETE /api/v1/employees/CPF
        ///   
        ///        {
        ///        "id": 0,
        ///        "name": "string",
        ///        "cpf": 0,
        ///        "date_of_birth": "2022-01-01T16:03:16.910Z",
        ///        "cellfone": 0,
        ///        "gender": "string",
        ///        "address": {
        ///          "code": 0,
        ///          "street": "string",
        ///          "number": 0,
        ///          "district": "string",
        ///          "city": "string",
        ///          "state": "string",
        ///          "cep": "string"
        ///        }
        ///      }
        ///    
        ///
        /// </remarks>
        /// <param name="cpf">CPF do Contribuidores que deseja deletar o cadastro</param>
        /// <returns>Retorna que o Contribuidores foi deletado</returns>
        /// <response code="201">Retorna que o cadastro do Contribuidores foi deletado</response>
        /// <response code="400">Retorna CPF é inválido ou Retorna CPF não cadastrado</response>
        [HttpDelete("{cpf}")]
        public ActionResult Delete(long cpf)
        {
                var employee = _contributorsBusiness.FindByCpf(cpf);
                if (employee == null) return BadRequest();
                _contributorsBusiness.Delete(cpf);
                return NoContent();
          
        }
    }
}
