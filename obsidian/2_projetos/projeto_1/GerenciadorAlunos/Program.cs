using GerenciadorAlunos;

Aluno aluno = new("Pablo", 1, new DateTime(2003, 07, 15));

Console.WriteLine(aluno.Nome);
Console.WriteLine(aluno.Matricula);
Console.WriteLine(aluno.Idade);

Console.ReadKey();