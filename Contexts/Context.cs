using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotec.Contexts
{
    //Classe que terá as informações do Banco de Dados
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        //OnConfiguring -> Possui a configuração da conexao com o Banco de Dados

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            // colocar as informações d banco

            // as configurações existem?
            if (!optionsBuilder.IsConfigured)
            {
                //A string de conexao do Bando de Dados
                //Data Source -> Nome do servidor do Banco de Dados
                //Intial Catalog -> Nome do Banco de Dados
                optionsBuilder.UseSqlServer(@"
                Data Source= NOTE26-S28\\SQLEXPRESS02;
                Initial Catalog=Bibliotec_mvc;
                User Id=sa;
                Password=123;
                TrustServerCertificate = true
                ");
            }

        }

        //As refeerncias das nossas tabelas no Banco de Dados
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<LivroCategoria> LivroCategoria { get; set; }
        public DbSet<LivroReserva> LivroReserva { get; set; }
    }
}