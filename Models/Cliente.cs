using System.ComponentModel.DataAnnotations;


namespace ApiClientes.Models;

public class Cliente

   
{
    // 1. Atributo existente
    public int Id { get; set; }

    // 2. Atributo existente
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; } = string.Empty;

    // 3. Atributo existente
    [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres")]
    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "O formato do email é inválido")]
    public string Email { get; set; } = string.Empty;

    // 4. Atributo existente (com correção na mensagem de erro)
    [StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF deve ter entre 11 e 14 caracteres")]
    [Required(ErrorMessage = "O CPF é obrigatório")]
    public string Cpf { get; set; } = string.Empty;

    // 5. Atributo existente (com correção na mensagem de erro)
    [StringLength(15, MinimumLength = 10, ErrorMessage = "O telefone deve ter entre 10 e 15 caracteres")]
    [Required(ErrorMessage = "O telefone é obrigatório")]
    public string Telefone { get; set; } = string.Empty;

    // 6. Novo atributo: Data de Nascimento
    [DataType(DataType.Date)]
    public DateTime? DataNascimento { get; set; }

    // 7. Novo atributo: Data de Cadastro
    [Required(ErrorMessage = "A data de cadastro é obrigatória")]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    // 8. Novo atributo: Endereço (Logradouro)
    [StringLength(200, ErrorMessage = "O endereço deve ter no máximo 200 caracteres")]
    public string Logradouro { get; set; } = string.Empty;
    
    // 9. Novo atributo: Status do Cliente
    public bool Ativo { get; set; } = true;
}