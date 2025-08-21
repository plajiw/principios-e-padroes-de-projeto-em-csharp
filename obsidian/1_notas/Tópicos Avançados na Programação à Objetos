## Herança em Programação Orientada a Objetos

A **herança** é um dos pilares fundamentais da Programação Orientada a Objetos (POO), permitindo que uma classe (chamada **classe derivada** ou **subclasse**) herde membros (atributos, propriedades, métodos) de outra classe (chamada **classe base** ou **superclasse**). Esse mecanismo promove reutilização de código, organização hierárquica e polimorfismo, mas requer cuidado para evitar problemas como acoplamento excessivo ou comportamento inesperado. Esta seção explora a herança em C#, abordando os conceitos mencionados na sua anotação, incluindo classes base e derivadas, modificadores de acesso (`public`, `protected`, `private`), métodos e propriedades virtuais, `override`, ocultação de métodos, e os riscos de usar `var` em instanciação.

---

### Conceitos Fundamentais

### Classe Base e Classe Derivada
- **Classe Base**: A classe da qual outras classes herdam. Define membros (atributos, propriedades, métodos) que podem ser reutilizados ou estendidos pelas classes derivadas.
- **Classe Derivada**: Uma classe que herda de uma classe base, podendo adicionar novos membros ou modificar o comportamento herdado. Em C#, a herança é indicada pela sintaxe `:`. Exemplo:
  ```csharp
  public class Ingrediente { // Classe base
      public string Nome { get; set; }
  }

  public class Queijo : Ingrediente { // Classe derivada
      public string Tipo { get; set; }
  }
  ```

### Herança e Polimorfismo
A herança permite que objetos de classes derivadas sejam tratados como instâncias da classe base, habilitando **polimorfismo**. Isso significa que uma variável do tipo da classe base pode referenciar objetos de classes derivadas, mas o comportamento depende do tipo real do objeto (especialmente com métodos virtuais).

**Exemplo**:
```csharp
Ingrediente ingrediente = new Queijo(); // Variável do tipo base referenciando uma classe derivada
```

---

## Modificadores de Acesso
Os modificadores de acesso controlam a visibilidade dos membros de uma classe. Eles são cruciais na herança para definir o que pode ser acessado ou modificado pelas classes derivadas.

- **public**: O membro é acessível de qualquer lugar.
- **protected**: O membro é acessível na classe base e nas classes derivadas, mas não externamente.
- **private**: O membro é acessível apenas dentro da própria classe.
- **protected internal**: Acessível nas classes derivadas e no mesmo assembly.
- **private protected**: Acessível apenas nas classes derivadas dentro do mesmo assembly.

**Exemplo**:
```csharp
public class Ingrediente {
    private string _id = Guid.NewGuid().ToString(); // Apenas a classe base acessa
    protected string Categoria { get; set; } // Acessível na classe base e derivadas
    public string Nome { get; set; } // Acessível de qualquer lugar
}

public class Queijo : Ingrediente {
    public Queijo(string nome, string tipo) {
        Nome = nome; // OK: Nome é público
        Categoria = "Laticínio"; // OK: Categoria é protegida
        // _id = "123"; // ERRO: _id é privado
    }
}
```

---

## Métodos e Propriedades Virtuais
Para permitir que uma classe derivada modifique o comportamento de um método ou propriedade da classe base, usamos o modificador `virtual`. A classe derivada pode então **sobrescrever** o membro usando a palavra-chave `override`.

- **virtual**: Indica que o método ou propriedade pode ser sobrescrito por classes derivadas.
- **override**: Usado na classe derivada para fornecer uma nova implementação do membro virtual.

**Exemplo**:
```csharp
public class Ingrediente {
    public virtual string Nome { get => "Ingrediente Genérico"; } // Propriedade virtual
    public virtual string Descrever() => $"Nome: {Nome}";
}

public class Queijo : Ingrediente {
    public override string Nome { get => "Cheddar"; } // Sobrescreve a propriedade
    public override string Descrever() => $"Queijo: {Nome}";
}

public class Molho : Ingrediente {
    public override string Nome { get => "Molho de Tomate"; }
    public override string Descrever() => $"Molho: {Nome}";
}
```

**Uso**:
```csharp
Ingrediente ingrediente1 = new Queijo();
Ingrediente ingrediente2 = new Molho();
Console.WriteLine(ingrediente1.Descrever()); // Saída: Queijo: Cheddar
Console.WriteLine(ingrediente2.Descrever()); // Saída: Molho: Molho de Tomate
```

**Análise**:
- A propriedade `Nome` e o método `Descrever` são marcados como `virtual` na classe base, permitindo que as classes derivadas (`Queijo` e `Molho`) os sobrescrevam com implementações específicas.
- O mecanismo de C# verifica o **tipo real do objeto** (não o tipo da variável) para chamar a implementação correta, um comportamento conhecido como **polimorfismo dinâmico**.

---

## Ocultação de Métodos (Shadowing)
A **ocultação** ocorre quando uma classe derivada define um membro com o mesmo nome de um membro da classe base, mas sem usar `override`. Isso faz com que o membro da classe base seja "escondido" (shadowed), e a escolha do método depende do tipo da variável, não do tipo real do objeto. Para indicar ocultação intencional, usa-se o modificador `new`.

**Exemplo de Ocultação**:
```csharp
public class Ingrediente {
    public string Nome { get => "Ingrediente Genérico"; }
}

public class Queijo : Ingrediente {
    public new string Nome { get => "Cheddar"; } // Oculta a propriedade da classe base
}
```

**Uso**:
```csharp
Ingrediente ingrediente = new Queijo();
Queijo queijo = new Queijo();
Console.WriteLine(ingrediente.Nome); // Saída: Ingrediente Genérico
Console.WriteLine(queijo.Nome); // Saída: Cheddar
```

**Análise**:
- Como `Nome` não é `virtual` na classe base, a propriedade `Nome` em `Queijo` **oculta** a da classe base, em vez de sobrescrevê-la.
- O comportamento depende do tipo da variável (`Ingrediente` ou `Queijo`), não do tipo real do objeto (`Queijo`). Isso pode levar a resultados inesperados, então a ocultação deve ser evitada, exceto em casos específicos.

**Boa Prática**: Prefira métodos/propriedades virtuais com `override` para polimorfismo. Use `new` apenas quando a ocultação for intencional e bem documentada.

---

## Riscos de Usar `var` na Instanciação
Em C#, a palavra-chave `var` faz o compilador inferir o tipo da variável com base na expressão à direita. Embora útil, seu uso em contextos de herança pode causar confusão, especialmente com polimorfismo.

**Risco**:
Quando usamos `var`, o tipo inferido é o tipo da expressão, não necessariamente o tipo real do objeto. Isso pode levar a chamadas de métodos/propriedades da classe base (em vez da derivada) se os membros não forem virtuais.

**Exemplo**:
```csharp
public class Ingrediente {
    public string Nome { get => "Ingrediente Genérico"; } // Não virtual
}

public class Queijo : Ingrediente {
    public new string Nome { get => "Cheddar"; } // Oculta a propriedade
}

var ingrediente = new Queijo(); // Tipo inferido: Queijo
Ingrediente ingredienteBase = new Queijo(); // Tipo explícito: Ingrediente

Console.WriteLine(ingrediente.Nome); // Saída: Cheddar
Console.WriteLine(ingredienteBase.Nome); // Saída: Ingrediente Genérico
```

**Análise**:
- Com `var ingrediente = new Queijo()`, o tipo inferido é `Queijo`, então a propriedade `Nome` da classe derivada é chamada.
- Com `Ingrediente ingredienteBase = new Queijo()`, o tipo é `Ingrediente`, então a propriedade da classe base é chamada, pois `Nome` não é virtual.
- **Risco**: Se o desenvolvedor espera comportamento polimórfico (chamar a implementação de `Queijo`), mas usa uma variável do tipo base sem membros virtuais, o resultado será inesperado.

**Recomendação**:
- Use `var` quando o tipo for óbvio e não houver risco de ambiguidade.
- Prefira tipos explícitos (e.g., `Ingrediente` ou `Queijo`) em contextos polimórficos para clareza.
- Sempre use `virtual`/`override` para membros que devem suportar polimorfismo.

---

## Polimorfismo com Listas de Objetos
A herança permite tratar objetos de classes derivadas como se fossem da classe base, o que é especialmente útil em coleções como listas. Isso possibilita manipular diferentes tipos de objetos de forma uniforme, desde que compartilhem uma interface comum (membros públicos ou protegidos da classe base).

**Exemplo: Lista de Ingredientes**:
```csharp
public class Ingrediente {
    public virtual string Nome { get => "Ingrediente Genérico"; }
    public virtual string Descrever() => $"Nome: {Nome}";
}

public class Queijo : Ingrediente {
    public override string Nome { get => "Cheddar"; }
    public override string Descrever() => $"Queijo: {Nome}";
}

public class Molho : Ingrediente {
    public override string Nome { get => "Molho de Tomate"; }
    public override string Descrever() => $"Molho: {Nome}";
}

public class Pizza {
    private List<Ingrediente> _ingredientes = new List<Ingrediente>();

    public void AdicionarIngrediente(Ingrediente ingrediente) {
        _ingredientes.Add(ingrediente);
    }

    public void ListarIngredientes() {
        foreach (var ingrediente in _ingredientes) {
            Console.WriteLine(ingrediente.Descrever());
        }
    }
}
```

**Uso**:
```csharp
Pizza pizza = new Pizza();
pizza.AdicionarIngrediente(new Queijo());
pizza.AdicionarIngrediente(new Molho());
pizza.AdicionarIngrediente(new Ingrediente());
pizza.ListarIngredientes();
// Saída:
// Queijo: Cheddar
// Molho: Molho de Tomate
// Nome: Ingrediente Genérico
```

**Análise**:
- A lista `_ingredientes` é do tipo `List<Ingrediente>`, mas pode armazenar objetos de `Queijo`, `Molho` ou `Ingrediente`, pois todos são compatíveis com o tipo `Ingrediente`.
- Como `Nome` e `Descrever` são virtuais, o C# chama as implementações das classes derivadas, mesmo que a variável de loop seja do tipo `Ingrediente`. Isso é polimorfismo dinâmico.

**Cenário sem Override**:
Se uma classe derivada não sobrescrever um membro virtual, a implementação da classe base é usada.

**Exemplo Modificado**:
```csharp
public class Tomate : Ingrediente {
    // Não sobrescreve Nome, usa a implementação da classe base
    public override string Descrever() => $"Tomate: {Nome}";
}

Pizza pizza = new Pizza();
pizza.AdicionarIngrediente(new Tomate());
pizza.ListarIngredientes(); // Saída: Tomate: Ingrediente Genérico
```

**Análise**: Como `Tomate` não sobrescreve `Nome`, a propriedade da classe base (`Ingrediente`) é usada, resultando em "Ingrediente Genérico".

---

## Mecanismo Interno do C# (Resolução de Chamadas)
O comportamento de chamadas de métodos/propriedades em C# depende de:
1. **Tipo da variável**: Determina quais membros estão disponíveis (a "interface" visível).
2. **Tipo real do objeto**: Determina qual implementação será chamada para membros virtuais.
3. **Virtualidade**: Métodos/propriedades marcados como `virtual` permitem polimorfismo; os não virtuais usam o tipo da variável.

**Passo a Passo do C#**:
- **Membro não virtual**: O compilador escolhe a implementação com base no tipo da variável, ignorando o tipo real do objeto.
- **Membro virtual**: O runtime verifica o tipo real do objeto e chama a implementação mais específica (definida por `override` na classe derivada). Isso é feito via **tabela de métodos virtuais (vtable)** no CLR (Common Language Runtime).

**Exemplo**:
```csharp
Ingrediente ingrediente = new Queijo();
Console.WriteLine(ingrediente.Nome); // Saída: Cheddar (Nome é virtual, chama a implementação de Queijo)
```

---

## Boas Práticas e Cuidados
- **Use `virtual`/`override` para polimorfismo**: Sempre marque membros como `virtual` na classe base se espera que classes derivadas os modifiquem.
- **Evite ocultação (`new`)**: A ocultação pode causar confusão, pois o comportamento depende do tipo da variável. Prefira `override` para consistência.
- **Seja explícito com tipos em herança**: Evite `var` em cenários polimórficos para garantir clareza sobre o tipo esperado.
- **Mantenha interfaces coesas**: A classe base deve definir uma interface clara (membros públicos/protegidos) que todas as classes derivadas sigam.
- **Evite herança profunda**: Hierarquias complexas aumentam o acoplamento e dificultam a manutenção. Considere interfaces ou composição em vez de herança excessiva.
