# TrabalhoEMC0101

Projeto desenvolvido para a faculdade na disciplina `EMC0101`.

## Visao geral

Este repositório contem um aplicativo mobile feito com Xamarin.Forms, com projetos para:

- Android
- iOS
- camada compartilhada em C#

## Objetivo do projeto

O app combina dois fluxos principais:

- conversao entre numero binario e decimal
- consulta de dados em um canal do ThingSpeak

Tambem existe uma tela para configurar a URL usada na consulta remota.

## Estrutura

- `TrabalhoEMC0101/TrabalhoEMC0101.sln`
  solucao principal.
- `TrabalhoEMC0101/TrabalhoEMC0101/TrabalhoEMC0101`
  projeto compartilhado com views, viewmodels, models e camada de requisicao HTTP.
- `TrabalhoEMC0101/TrabalhoEMC0101/TrabalhoEMC0101.Android`
  projeto Android.
- `TrabalhoEMC0101/TrabalhoEMC0101/TrabalhoEMC0101.iOS`
  projeto iOS.

## Arquitetura

O projeto segue uma estrutura simples baseada em:

- `Views/`
  telas XAML como `MasterPage` e `ConfigurarURL`
- `ViewModels/`
  logica de interface, comandos e bind de propriedades
- `Models/`
  modelos de dados e regras de conversao/consulta
- `Pacote/`
  camada de acesso HTTP e parse da resposta

## Fluxo principal

- `App.xaml.cs` inicia a aplicacao com `NavigationPage(new MasterPage())`
- `MasterPage` define `MasterPageVM` como `BindingContext`
- `MasterPageVM`:
  - faz a conversao binario/decimal
  - busca o ultimo valor remoto no ThingSpeak
  - abre a tela de configuracao de URL

## Integracao remota

O projeto consome por padrao um endpoint do ThingSpeak em:

`https://api.thingspeak.com/channels/1259078/feeds.json?...`

Essa chamada fica em `Pacote/HttpRequest.cs`, e a interpretacao dos dados fica em `Models/thingspeak.cs`.

## Observacao

Este projeto foi feito para a faculdade, com foco academico e demonstrativo.
