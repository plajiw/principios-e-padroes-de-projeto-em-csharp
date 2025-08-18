var retangulo = new Retangulo(5, -1);
Console.ReadKey();

public class Retangulo
{
    const int NumeroDeLados = 4;
    private int _altura;
    private int _largura;

    public Retangulo(int altura, int largura)
    {
        _altura = ObterTamanhoOuPadrao(altura, nameof(_altura));
        _largura = ObterTamanhoOuPadrao(largura, nameof(_largura));
    }

    public int ObterLargura() => _largura;

    public void DefinirLargura(int valor)
    {
        if(valor > 0)
        {
            _largura = valor;
        }
    }

    private int ObterTamanhoOuPadrao(int tamanho, string nome)
    {
        const int valorPadrao = 1;
        if (tamanho < 1)
        {
            Console.WriteLine($"O {nome} precisa ser maior que 1.");
            return valorPadrao;
        }
        else
        {
            return tamanho;
        }
    }
}