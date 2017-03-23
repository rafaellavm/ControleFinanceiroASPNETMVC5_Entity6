using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class FinancasContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        //A motivmentacao tem uma chave estrangeira para o usuario. Precisamos mapear essa chave dentro do Entity
        //Precisaremos sobrescrever o método onModelCreate
        //customiza o mapeamento pelo Entity
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //HHasRequired(m => m.Usuario): isso diz que a movimentação tem um usuário obrigatoriamente
            modelBuilder.Entity<Movimentacao>().HasRequired(m => m.Usuario);
        }
    }
}