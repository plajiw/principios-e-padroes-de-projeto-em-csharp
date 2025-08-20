using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAlunos
{
    public class Aluno
    {
        private string _nome;
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nome = value;
                }
            }
        }

        public int Matricula { get; init; }

        private DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set
            {
                if (value < DateTime.Now)
                {
                    _dataNascimento = value;
                }
            }
        }

        public int Idade
        {
            get
            {
                var hoje = DateTime.Today;
                var idade = hoje.Year - DataNascimento.Year;
                return idade;
            }
        }

        public Aluno(string nome, int matricula, DateTime dataNascimento)
        {
            Nome = nome;
            Matricula = matricula;
            DataNascimento = dataNascimento;
        }
    }
}