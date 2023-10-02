using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MtecDevs.Models;

namespace MtecDevs.Data;

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
                UserName = "Adm",
                NormalizedUserName = "ADM",
                Email = "guilherme19.b07@gmail.com",
                NormalizedEmail = "GUILHERME19.B07@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
            }
        };
        builder.Entity<IdentityUser>().HasData(users);
        //criptografar a senha do IdentityUser

        //Criar a senha

        //definir o perfil do Usuario Criado
        #endregion
    }
}
