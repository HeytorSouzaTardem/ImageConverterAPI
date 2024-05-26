## Introdução

Bem-vindo à documentação da API Image Converter! Esta API permite converter imagens base64 e adicionar marcas d'água a elas.

## Uso básico

### Converter imagem e adicionar marca d'água

#### `POST /images`

Este endpoint permite enviar uma imagem base64 junto com os parâmetros necessários para adicionar uma marca d'água a ela.

#### Parâmetros da solicitação

| Nome            | Tipo   | Descrição                                                                      |
|-----------------|--------|--------------------------------------------------------------------------------|
| `Base64Image`   | string | (Obrigatório) A representação base64 da imagem que será processada.            |
| `WatermarkText` | string | (Obrigatório) O texto que será utilizado como marca d'água na imagem.          |
| `TextFont`      | string | (Obrigatório) O tipo de fonte que será utilizado para o texto da marca d'água. |
| `TextSize`      | int    | (Obrigatório) O tamanho da fonte do texto da marca d'água.                     |
| `TextColor`     | string | (Obrigatório) A cor do texto da marca d'água em formato hexadecimal.           |
| `PositionX`     | int    | (Obrigatório) A posição horizontal (em pixels) onde a marca d'água será inserida na imagem. |
| `PositionY`     | int    | (Obrigatório) A posição vertical (em pixels) onde a marca d'água será inserida na imagem.   |


# Exemplo de solicitação

## Requisição

- **Endpoint:** `/images`
- **Método:** `POST`
- **Content-Type:** `application/json`

### Corpo da Requisição

```json
{
  "Base64Image": "base64_da_imagem_aqui",
  "WatermarkText": "Exemplo de Marca d'água",
  "TextFont": "Arial",
  "TextSize": 20,
  "TextColor": "#FF0000",
  "PositionX": 100,
  "PositionY": 100
}

```

## Resposta
Status: 200 OK

A resposta será a imagem codificada em base64 com a marca d'água aplicada.

#### Exemplo de imagem antes da marca d'água: ![image](https://github.com/Digowmarins/ImageConverterAPI/assets/114032897/b8e1b53a-f6ee-4f02-a206-37da4e15ad24)


#### Exemplo de imagem após adicionar a marca d'água: ![image](https://github.com/Digowmarins/ImageConverterAPI/assets/114032897/50b60742-0a0e-44cc-b198-0f61194d506e)


## Exemplo avançado: Criando várias versões da marca d'água

Além de adicionar uma marca d'água simples, você também pode criar várias versões da mesma imagem com diferentes estilos de marca d'água. Abaixo está um exemplo de como você pode fazer isso:

### 1. Escolha uma imagem base

Escolha uma imagem base na qual você deseja aplicar diferentes estilos de marca d'água.

### 2. Defina diferentes estilos de marca d'água

Defina diferentes estilos de marca d'água, incluindo diferentes fontes, tamanhos, cores e posições. Por exemplo:

- Marca d'água 1: Fonte Verdana, tamanho 20, cor black, posição (0, 0)
- Marca d'água 2: Fonte Times New Roman, tamanho 20, cor blue, posição (0, 247)
- Marca d'água 3: Fonte Courier New, tamanho 10, cor red, posição (667, 0)
- Marca d'água 4: Fonte Calibri, tamanho 19, cor purple, posição (601, 245)

### 3. Envie solicitações para adicionar a marca d'água

Envie solicitações para o endpoint `POST /images` para adicionar cada estilo de marca d'água à imagem base, conforme definido anteriormente.

Exemplo utilizando Postman: ![image](https://github.com/Digowmarins/ImageConverterAPI/assets/114032897/6589f2a9-5717-471d-b1e4-455272b96e21)


### 4. Verifique as versões da imagem com marca d'água

Após cada solicitação, verifique as versões da imagem com marca d'água para ver como cada estilo é aplicado à imagem base.

- Imagem Base:
  
![image](https://github.com/Digowmarins/ImageConverterAPI/assets/114032897/7352527e-d79c-4133-b4aa-4ad1574a7c1a)

- Marca d'água 1:
  
![image](https://github.com/Digowmarins/ImageConverterAPI/assets/114032897/bb29aeb8-a09e-4a9f-88bc-6f12a0322c22)

- Marca d'água 2:
  
![image](https://github.com/Digowmarins/ImageConverterAPI/assets/114032897/102250f8-5fa9-4915-994d-14556b0e3918)

- Marca d'água 3:
  
![image](https://github.com/Digowmarins/ImageConverterAPI/assets/114032897/1f719f21-24b8-424b-8cc7-cd75c4183bb6)

- Marca d'água 4:
  
![image](https://github.com/Digowmarins/ImageConverterAPI/assets/114032897/a311ad41-4029-4f6d-92e5-11ffc5cbde5e)


## Possíveis erros

Aqui estão alguns possíveis erros que você pode encontrar ao usar este endpoint:

- **400 Bad Request:** Isso pode ocorrer se os parâmetros da solicitação estiverem ausentes ou se estiverem em um formato incorreto. A mensagem de erro fornecerá detalhes sobre o problema específico encontrado.
- **400 Bad Request:** Isso pode ocorrer se a posição da marca d'água estiver fora dos limites da imagem. A mensagem de erro informará os limites exatos da imagem, garantindo que a posição e o tamanho da marca d'água se encaixem dentro desses limites.
- **400 Bad Request:** Isso pode ocorrer se a string Base64 fornecida não for válida. A mensagem de erro informará que a string Base64 não é válida e sugerirá que o usuário verifique se está corretamente codificada e não contém caracteres inválidos.
- **500 Internal Server Error:** Isso pode ocorrer se houver algum problema interno no servidor ao processar a solicitação. Se isso acontecer, entre em contato com o administrador do sistema para obter assistência.


# Como instalar e executar a API Image Converter localmente

Para começar a utilizar a API Image Converter em seu ambiente local, siga os passos abaixo:

### 1. Clone o repositório do GitHub

Clone o repositório da API Image Converter do GitHub para o seu ambiente local. Você pode fazer isso executando o seguinte comando em seu terminal:

```bash
git clone https://github.com/Digowmarins/ImageConverterAPI.git
```

### 2. Navegue até o diretório do projeto

Após clonar o repositório, navegue até o diretório recém-clonado da API Image Converter:

```bash
cd ImageConverterAPI
```
### 3. Instale as dependências
Certifique-se de ter o .NET SDK instalado em sua máquina. Em seguida, instale as dependências do projeto executando o seguinte comando:

```bash
dotnet restore
```
### 4. Execute a API localmente
Para iniciar a API localmente, execute o seguinte comando:

```bash
dotnet run
```
Isso iniciará o servidor local da API e disponibilizará os endpoints para acesso.

### 5. Teste a API
Você pode testar a API utilizando ferramentas como cURL, Postman ou até mesmo navegadores da web. Por exemplo, você pode fazer uma solicitação POST para o endpoint /images conforme mostrado no exemplo da documentação.
