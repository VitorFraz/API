﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

//Antes de criar a API, instalar o pacote de NuGet: NewtonSoft.Json

//HttpClient: Usado para fazer requisições http, como GET, POST, PUT, DELETE.

//GetAsync: Metodo assincrono usado para fazer requisição Get

//ReadAsStringAsync: Lê a resposta de API como uma string.

//JsonConvert.DeserializeObject: Usado para converter o Json da resposta em um Objeto C#

//Quando voce marca um método como async, o compilador permite o uso do await dentro dele, que é a palavra chave que indica onde o codigo deve esperar por umaoperação assincrona.

//quando usa o VOID: ele não retorna nehum valor, ele apenas executa a ação de imprimir os dados, sempre depende de algum recurso para exibir algo. EX: Console.Write

namespace API
{
    class Program
    {
        static async Task Main(string[] args)
        {
        //Criação da instância do HTTPCLIENT
        HttpClient client = new HttpClient();

            //Define a URL do API
            string apiUrl = "https://economia.awesomeapi.com.br/last/eur-brl";

            try
            {
                // Enviar uma requisição GET para a API
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                
                // Verificar se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Ler o conteúdo da resposta como uma string
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    //Converter para JSON para um objeto C#
                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonResult);
                    Console.WriteLine("Resposta da API: ");

                    //Exibir o resultado
                    Console.WriteLine(jsonResult);

                    //foreach (var produto in jsonObject) 
                    //{
                    //    Console.WriteLine($"\nNome: {produto.EURBRL.name}");
                    //}
                }
                else
                {
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                // Fechar o HTTPClient
                client.Dispose();
            }
        }
    }
}
