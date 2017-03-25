using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;

namespace Financas
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //inicializando a conexão
            //Nome: onde eu quero guardar o login
            //Usuarios: tabela
            //true: cria automaticamente as tabelas no bando de dados
            WebSecurity.InitializeDatabaseConnection("FinancasContext", "Usuarios","Id", "Nome", true);
        }
    }
}
