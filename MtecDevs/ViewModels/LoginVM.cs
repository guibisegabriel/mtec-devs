using System.ComponentModel.DataAnnotations;

namespace MtecDevs.ViewModels;

public class LoginVM
{   
    [Display(Name = "Email ou Nome de Usuário", Prompt ="Informe seu Email ou Nome de Usuário")]
    [Required(ErrorMessage ="Por favor, informe seu email ou nome de usuario")]
    public string Email {get; set;}

    [Display(Name ="Informe sua senha", Prompt ="Informe sua senha")]
    [Required(ErrorMessage ="Por favor, informe sua senha")]
    [DataType(DataType.Password)]
    public string Senha {get; set;}

    [Display(Name ="Manter Conectado!")]
    public bool Lembrar {get; set;} = false;
    public string UrlRetorno {get; set;}

}
