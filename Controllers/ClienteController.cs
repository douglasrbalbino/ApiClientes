using ApiClientes.Data;
using ApiClientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _ClienteContext;

        public ClienteController(AppDbContext context)
        {
            _ClienteContext = context;
        }

        [HttpGet]
           
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _ClienteContext.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _ClienteContext.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound(new { message = "Cliente não encontrado" });
            }
            return Ok(cliente);
        }

        [HttpPost]

        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ClienteContext.Clientes.AddAsync(cliente);
            await _ClienteContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest(new { message = "ID do cliente não corresponde" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingCliente = await _ClienteContext.Clientes.FindAsync(id);
            if (existingCliente == null)
            {
                return NotFound(new { message = "Cliente não encontrado" });
            }
            // Atualiza os campos do cliente existente
            existingCliente.Nome = cliente.Nome;
            existingCliente.Email = cliente.Email;
            existingCliente.Telefone = cliente.Telefone;
            existingCliente.DataNascimento = cliente.DataNascimento;
            existingCliente.DataCadastro = cliente.DataCadastro;
            _ClienteContext.Clientes.Update(existingCliente);
            await _ClienteContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _ClienteContext.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound(new { message = "Cliente não encontrado" });
            }
            _ClienteContext.Clientes.Remove(cliente);
            await _ClienteContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
