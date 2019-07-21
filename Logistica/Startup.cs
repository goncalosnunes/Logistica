using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using Logistica.Models;

namespace Logistica
{

    // o código desta classe é iniciada uma única vez
    // e apenas no início do projeto
    public partial class Startup
    {

        // funciona como a função 'main' do C
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // executar o método para configurar a aplicação
            iniciaAplicacao();
        }


        /// <summary>
        /// cria, caso não existam, as Roles de suporte à aplicação: Agente, Funcionario, Condutor
        /// cria, nesse caso, também, um utilizador...
        /// </summary>
        private void iniciaAplicacao()
        {

            // identifica a base de dados de serviço à aplicação
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // criar a Role 'Cliente'
            if (!roleManager.RoleExists("Cliente"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Cliente";
                roleManager.Create(role);
            }

            // criar a Role 'Gestor'
            if (!roleManager.RoleExists("Gestor"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Gestor";
                roleManager.Create(role);
            }

            // criar a Role 'Transportador'
            if (!roleManager.RoleExists("Transportador"))
            {
                // não existe a 'role'
                // então, criar essa role
                var role = new IdentityRole();
                role.Name = "Transportador";
                roleManager.Create(role);
            }



            // criar um utilizador 'Funcionario'
            var user = new ApplicationUser();

            user.UserName = "gestor@mail.pt";
            user.Email = "gestor@mail.pt";
            //  user.Nome = "Luís Freitas";
            string userPWD = "password";
            var chkUser = userManager.Create(user, userPWD);

            //Adicionar o Utilizador à respetiva Role-Agente
            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Gestor");
            }

            // criar um utilizador 'Cliente'
            user = new ApplicationUser();

            user.UserName = "cliente@mail.pt";
            user.Email = "cliente@mail.pt";
           // user.Nome = "Luís Freitas";
            userPWD = "password";
            chkUser = userManager.Create(user, userPWD);

            //Adicionar o Utilizador à respetiva Role-Agente
            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Cliente");
            }

            // criar um utilizador 'Transportador'
            user = new ApplicationUser();

            user.UserName = "transportador@mail.pt";
            user.Email = "transportador@mail.pt";
            //  user.Nome = "Luís Freitas";
            userPWD = "password";
            chkUser = userManager.Create(user, userPWD);

            //Adicionar o Utilizador à respetiva Role-Agente
            if (chkUser.Succeeded)
            {
                var result1 = userManager.AddToRole(user.Id, "Transportador");
            }

        }

        // https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97






    }
}
