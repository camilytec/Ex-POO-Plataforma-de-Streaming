# Relatório de UML, testes e entrega

**Responsável:** Ana Clara Rodrigues de Souza  
**Projeto:** Plataforma de Streaming — Programação Orientada a Objetos

## 1. Escopo

A parte da Pessoa 4 compreende o diagrama das cinco classes, a implementação do programa de testes, a organização dos arquivos e a conferência dos entregáveis. A base utilizada foi a solução do Visual Studio existente no arquivo enviado. As implementações de `Filme`, `Serie`, `Playlist`, `Usuario` e `Plataforma` foram mantidas sem alterações.

O arquivo `Program.cs`, anteriormente vazio, foi preenchido com testes independentes. Cada cenário possui dados próprios e captura falhas para que os demais cenários ainda sejam executados. As comparações verificam resultados e estados; não se limitam a imprimir exemplos no console.

Não foi localizado um enunciado completo no material fornecido. Assim, a rastreabilidade abaixo se refere às atividades informadas e à implementação recebida.

## 2. Diagrama UML

O diagrama apresenta cinco classes de domínio. A classe técnica `Program`, usada somente para executar testes, não foi incluída nessa contagem.

| Classe | Estado representado | Operações representadas, além do construtor |
| --- | --- | --- |
| Filme | Título, gênero, duração e estado de reprodução | Reproduzir, Pausar e GetDuracao |
| Serie | Título, gênero, episódios por temporada e episódios assistidos | ReproduzirEpisodio, MarcarComoAssistido e ListarEpisodios |
| Playlist | Nome e lista de títulos | AdicionarMidia, RemoverMidia e ListarMidias |
| Usuario | Nome, playlists, favoritos e histórico | CriarPlaylist, Favoritar, Historico e RegistrarReproducao |
| Plataforma | Catálogo de títulos | BuscarConteudo, RecomendarPara e Top10 |

**Associação:** `Usuario` mantém uma coleção de `Playlist`. O diagrama mostra um usuário associado a zero ou mais playlists. No outro extremo, uma playlist pode estar associada a zero ou um usuário: o construtor público de `Playlist` também permite criar uma lista isolada, enquanto `CriarPlaylist` a associa ao usuário que a criou.

**Dependência:** `Plataforma` recebe um `Usuario` em `RecomendarPara` e consulta seu histórico. Ela não guarda uma coleção de usuários, portanto a relação foi representada como dependência por parâmetro.

**Referências por texto:** `Playlist.midias`, `Plataforma.catalogo`, favoritos e histórico armazenam `string`. Por isso, não foram inventadas associações estruturais diretas dessas coleções com `Filme` e `Serie`. O `Program.cs` realiza a integração entre os objetos, os títulos e os registros retornados pela reprodução.

**Visibilidade:** `+` indica público e `−` indica privado. Propriedades automáticas são mostradas com `get; private set;`. Os construtores não possuem tipo de retorno. `Usuario` tem quatro métodos públicos no código recebido; o UML preserva essa assinatura.

## 3. Cenários e rastreabilidade

| ID | Atividade atendida | Verificações realizadas | Resultado |
| --- | --- | --- | --- |
| CT-01 | Testar reprodução de filme | Estado inicial, duração, texto do registro, início, pausa e pausa repetida | 6 verificações aprovadas |
| CT-02 | Testar reprodução de episódio | Cópia das temporadas, registro, marcação automática/manual, repetição, temporadas/episódios inválidos e cópia da listagem | 12 verificações aprovadas |
| CT-03 | Criar e utilizar playlist | Nome do usuário e da lista, lista vazia, adição, duplicação, entradas vazias, remoção existente/inexistente e cópia defensiva | 7 verificações aprovadas |
| CT-04 | Integrar reprodução e histórico | Lista do usuário com filme e série, ordem dos registros, episódio inválido, entradas vazias, reprodução repetida e cópia defensiva | 5 verificações aprovadas |
| CT-05 | Buscar conteúdo | Busca parcial e com caixa diferente, ausência, nulo, vazio, espaços e proteção do catálogo | 6 verificações aprovadas |
| CT-06 | Recomendar conteúdo | Usuário sem histórico, exclusão de assistidos, limite de três, catálogo todo assistido, usuário nulo e catálogo vazio | 5 verificações aprovadas |
| CT-07 | Conferir Top 10 | Catálogo com 12 títulos, limite de dez, ordem, cópias defensivas e catálogos com dois/zero títulos | 6 verificações aprovadas |
| CT-08 | Exercitar favoritos | Chamada com título válido, repetido, nulo, vazio e espaços sem exceção | Chamada aprovada; sem verificação da coleção |
| **Total** | **8 cenários** | **47 verificações automáticas, mais o cenário de chamada de favoritos** | **0 cenários reprovados** |

## 4. Resultado da execução

Os seis arquivos C# foram compilados com o Roslyn do SDK .NET 8.0.427, usando referências .NET 8 e a opção de tratar avisos como erros. A execução ocorreu no runtime .NET 8.0.33. A saída real consta em `Resultado_Execucao.txt`.

```text
Cenários aprovados: 8
Cenários reprovados: 0
Verificações aprovadas: 47
```

O projeto original tem como destino .NET Framework 4.7.2 e foi preservado. Não foi executada compilação dessa solução em Windows/Visual Studio. O projeto portátil incluído usa o mesmo código-fonte para facilitar reprodução dos testes em .NET 8.

## 5. Características e limites encontrados

1. **Histórico exige registro explícito.** `Filme.Reproduzir()` e `Serie.ReproduzirEpisodio()` retornam o texto de registro; o programa chama `Usuario.RegistrarReproducao(...)`. Um episódio inexistente retorna `null`, que o usuário ignora.
2. **Favoritos sem consulta pública.** A coleção é privada e não há método para listar favoritos. Foram exercitadas as chamadas públicas, mas quantidade, duplicatas e conteúdo salvo não foram certificados em execução. Uma consulta pública dependeria de ajuste pela responsável pela classe.
3. **Top 10 por ordem do catálogo.** `Top10()` devolve até os dez primeiros títulos. Não há contagem de visualizações, portanto não há ranking de popularidade nesta versão.
4. **Recomendações por ocorrência de texto.** A plataforma busca o título dentro do registro do histórico, sem diferenciar maiúsculas. Títulos contidos em outros títulos podem gerar exclusões indevidas. O teste cobre títulos distintos e o contrato atual; não comprova recomendação personalizada por gênero.
5. **Coleções de títulos.** Playlists e catálogo não validam a existência de objetos de mídia; são coleções textuais. Os construtores também não implementam validação geral de domínio, como duração positiva, nomes obrigatórios ou catálogo nulo.
6. **Sem persistência.** Dados existem em memória durante a execução. Persistência não aparece entre as tarefas informadas.

Esses limites não foram corrigidos nas classes das colegas para manter o escopo da parte da Ana. Caso o enunciado exija comportamentos diferentes, os responsáveis precisam adequar as respectivas classes e os testes devem ser atualizados.

## 6. Conferência dos entregáveis

- [x] Cinco classes de domínio presentes no projeto.
- [x] Classes das colegas preservadas em relação à solução organizada recebida.
- [x] Namespace único nos seis arquivos do projeto: `Plataforma_de_Streaming`.
- [x] Um único ponto de entrada `Main`.
- [x] Métodos e parâmetros do Program compatíveis com as classes recebidas.
- [x] Diagrama com membros e relações existentes no código.
- [x] Diagrama em PNG, SVG e fonte PlantUML.
- [x] Programa compilado sem avisos nem erros na validação com .NET 8.
- [x] Oito cenários executados, 47 verificações aprovadas e nenhuma falha.
- [x] Registro da execução incluído.
- [x] Instruções de execução e integração incluídas.
- [x] Arquivos duplicados e inválidos da raiz do ZIP de origem excluídos do pacote organizado.
- [x] Saídas temporárias de compilação e executáveis excluídos do pacote.
- [ ] Comparar a entrega com o enunciado completo do professor, que não consta no material fornecido.
- [ ] Executar a solução original no Visual Studio/Windows caso esse seja o ambiente exigido para avaliação.
