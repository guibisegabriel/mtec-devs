using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MtecDevs.Models;
namespace MtecDevs.Data;

public class NewBaseType
{
}

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        // Popular dos dados de Tipos de Dev
        #region Popular dados TipoDev
        List<TipoDev> tipoDevs = new() {
            new TipoDev() {
                Id = 1,
                Nome = "FullStack"
            },
            new TipoDev() {
                Id = 2,
                Nome = "FrontEnd"
            },
            new TipoDev() {
                Id = 3,
                Nome = "BackEnd"
            },
            new TipoDev() {
                Id = 4,
                Nome = "Design"
            },
            new TipoDev() {
                Id = 5,
                Nome = "Jogos"
            }
        };
        builder.Entity<TipoDev>().HasData(tipoDevs);
        #endregion
    
        // Popular dados do perfil dos usuarios
        #region Popular dados Perfis de Usuário
        List<IdentityRole> perfis = new() {
            new IdentityRole() {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR",
            },
            new IdentityRole() {
                Id = Guid.NewGuid().ToString(),
                Name = "Moderador",
                NormalizedName = "MODERADOR",
            },
            new IdentityRole() {
                Id = Guid.NewGuid().ToString(),
                Name = "Usuário",
                NormalizedName = "USUÁRIO",
            } 
        };
        builder.Entity<IdentityRole>().HasData(perfis);    
        #endregion
    
        //Popular dados de Usuario
        #region Popular dados de Usuário
        //lista de IdentityUser
        List<IdentityUser> users = new() {
            new IdentityUser() {
                Id = Guid.NewGuid().ToString(),
                UserName = "Guilherme Bispo",
                NormalizedUserName = "GUILHERME BISPO",
                Email = "guilherme19.b07@gmail.com",
                NormalizedEmail = "GUILHERME19.B07@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
            }
        };
         //criptografar a senha do IdentityUser
         foreach (var user in users)
        {
            PasswordHasher<IdentityUser> password = new();
            user.PasswordHash = password.HashPassword(user, "@Etec123");
        }
        builder.Entity<IdentityUser>().HasData(users);
        #endregion

        //criar o usuario
        #region Criação de usuário
        List<Usuario> usuarios = new();{
            Usuario usuario = new Usuario() {
                UserId = users[0].Id,
                Nome = "Guilherme Bispo",
                DataNascimento = DateTime.Parse("19/09/2006"),
                TipoDevId = 3
            };
        };
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion
        
        //Definir o perfil do Usuario Criado
        #region Definir perfil do Usuario
        List<IdentityUserRole<string>> userRoles = new(){
            new IdentityUserRole<string>(){
                UserId = users[0].Id,
                RoleId = perfis[0].Id
            }
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}
