//using ChurchManager.Application.Shared;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace ChurchManager.Application.Servicos
//{
//    internal static class ViaCepService
//    {
//        public static Task<ViaCepRequestResult> GetEndereco(string cep, CancellationToken cancellationToken)
//        {
//            return Http.Get<ViaCepRequestResult>($"https://viacep.com.br/ws/{cep}/json/", cancellationToken, 5);
//        }

//        public record ViaCepRequestResult
//        (
//            string Cep,
//            string Logradouro,
//            string Bairro,
//            string Localidade,
//            string Uf,
//            string Ibge
//        );
//    }
//}
