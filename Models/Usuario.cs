using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CRUDsimples.Models
{
    public class Usuario
    {
        // Propriedades
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string NomeCompleto => $"{Nome} {Sobrenome}";

        public string Email { get; set; }

        public string Profissao { get; set; }

        public string DataCadastro => DateTime.Now.ToString("dd/MM/yyyy");

        private static List<Usuario> listagem = new List<Usuario>();

        public static IQueryable<Usuario> Listagem { get { return listagem.AsQueryable(); } }

        // Construtor
        static Usuario()
        {
            // Memory database
            Usuario.listagem.Add(
                new Usuario { Id = 1, Nome = "Fulano", Sobrenome = "Silva", Email = "FulanoSilva@teste.com", Profissao = "Arquiteto de Sistemas II" });
            Usuario.listagem.Add(
                new Usuario { Id = 2, Nome = "Beltrano", Sobrenome = "Oliveira", Email = "BeltranoOliveira@teste.com", Profissao = "DBA" });
            Usuario.listagem.Add(     
                new Usuario { Id = 3, Nome = "Sicrano", Sobrenome = "Santos", Email = "SicranoSantos@teste.com", Profissao = "Arquiteto de Sistemas I" });
            Usuario.listagem.Add(
                new Usuario { Id = 4, Nome = "Jorge", Sobrenome = "Pinto", Email = "JorgePinto@teste.com",  Profissao = "Desenvolvedor Front-End" });
            Usuario.listagem.Add(
                new Usuario { Id = 5, Nome = "Paulo", Sobrenome = "Silva", Email = "PauloSilvateste.com",  Profissao = "Desenvolvedor Back-End" });
            Usuario.listagem.Add(
                new Usuario { Id = 6, Nome = "Maria", Sobrenome = "Penha", Email = "MariaPenha@teste.com", Profissao = "Desenvolvedor Full-Stack" });
            Usuario.listagem.Add(
                new Usuario { Id = 7, Nome = "José", Sobrenome = "Penha", Email = "JosePenha@teste.com",  Profissao = "BDA I" });
            Usuario.listagem.Add(
                new Usuario { Id = 8, Nome = "Ana", Sobrenome = "Camargo", Email = "AnaCamargo@teste.com",  Profissao = "Arquiteto de Sistemas III" });
            Usuario.listagem.Add(
                new Usuario { Id = 9, Nome = "Pedro", Sobrenome = "Pinto", Email = "PedroPinto@teste.com", Profissao = "Engenheiro de Dados I" });
            Usuario.listagem.Add(
                new Usuario { Id = 10, Nome = "Joana", Sobrenome = "Souza", Email = "JoanaSouza@teste.com", Profissao = "Analista de Dados II" });
            Usuario.listagem.Add(
                new Usuario { Id = 11, Nome = "Beltrana", Sobrenome = "Oliveira", Email = "BeltranaOliveira@teste.com", Profissao = "Agilista III" });
            Usuario.listagem.Add(
                new Usuario { Id = 12, Nome = "Sicrana", Sobrenome = "Santos", Email = "SicranaSantos@teste.com", Profissao = "UX" });
        }

        // Metodos
        public static void Salvar(Usuario usuarioRequest)
        {
            Usuario usuarioResponse = Usuario.listagem.Find(user => user.Id == usuarioRequest.Id);

            if (usuarioResponse != null)
            {
                usuarioResponse.Nome = usuarioRequest.Nome;
                usuarioResponse.Sobrenome = usuarioRequest.Sobrenome;
                usuarioResponse.Email = usuarioRequest.Email;
                usuarioResponse.Profissao = usuarioRequest.Profissao;
            }
            else
            {
                usuarioRequest.Id = Usuario.listagem.Max(user => user.Id) + 1;
                Usuario.listagem.Add(usuarioRequest);
            }
        }

        public static void Excluir(int id)
        {
            Usuario usuario = Usuario.listagem.Find(user => user.Id == id);

            if (usuario != null)
            {
                Usuario.listagem.Remove(usuario);
            }
        }
    }
}
