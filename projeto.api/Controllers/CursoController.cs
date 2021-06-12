﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projeto.api.Models.Cursos;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace projeto.api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]

    public class CursoController : ControllerBase
    {
        /// <summary>
        /// Este serviço permite cadastrar curso para o usuário autenticado.
        /// </summary>
        /// <param name="cursoViewModelInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar o curso!")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno")]
        [HttpPost]
        [Route("")]

        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", cursoViewModelInput);
        }

        /// <summary>
        /// Este serviço permite obter todos os cursos ativos do usuário.
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos!")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno")]
        [HttpGet]
        [Route("")]

        public async Task<IActionResult> Get()
        {
            var cursos = new List<CursoViewModelOutput>();

            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

            cursos.Add(new CursoViewModelOutput()
            {
                Login = codigoUsuario.ToString(),
                Descricao = "Teste - Descrição",
                Nome = "Teste - Nome"

            });

            return Ok(cursos);
        }
    }
}
