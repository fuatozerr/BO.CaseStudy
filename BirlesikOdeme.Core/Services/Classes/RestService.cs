using BirlesikOdeme.Core.Entities.Payment;
using BirlesikOdeme.Core.Entities.Security;
using BirlesikOdeme.Core.Exceptions;
using BirlesikOdeme.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Services.Classes
{
    public class RestService : IRestService
    {
        private readonly string SecurityUrl;
        private readonly string PaymentUrl;
        private readonly IConfiguration _configuration;


        public RestService(IConfiguration configuration)
        {
            _configuration = configuration;
            SecurityUrl = _configuration["BirlesikOdemeUrl:SecurityUrl"];
            PaymentUrl =  _configuration["BirlesikOdemeUrl:PaymentUrl"];
        }

        public async Task<SecurityResponseModel> Login()
        {
            try
            {
                var client = new RestClient(SecurityUrl);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonSerializer.Serialize(new SecurityRequestModel());
                var response = await client.PostAsync<SecurityResponseModel>(request);
                return response;
            }
            catch (Exception)
            {

                throw new BirlesikOdemeException("Birleşik Ödeme servisiyle bağlantı yapılamadı.");
            }
        }

        public async Task<PaymentResponseModel> Sales(SalesModel salesModel)
        {
            var customer = await Login();
            string hash = PaymentHash(new PaymentHash());
            try
            {
                var client = new RestClient(SecurityUrl);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization ", "bearer " +customer.result.token);
                var paymentRequst = new PaymentRequestModel();
                paymentRequst.cardNumber = salesModel.KartNumarasi;
                paymentRequst.expiryDateMonth = salesModel.KartSonKullanmaAyi;
                paymentRequst.expiryDateYear = salesModel.KartSonKullanmaYili;
                paymentRequst.hash = hash;
                var body = JsonSerializer.Serialize(paymentRequst);
                var response = await client.PostAsync<PaymentResponseModel>(request);
                return response;

            }
            catch (Exception)
            {

                throw new BirlesikOdemeException("Birleşik Ödeme servisiyle bağlantı yapılamadı.");
            }


        }

        private static string PaymentHash(PaymentHash request)
         {
             var hashString = $"{request.HashPassword}{request.UserCode}{request.Rnd}{request.txnType}{request.TotalAmount}{request.CustomerId}{request.OrderId}{request.OkUrl}{request.FailUrl}";
             var s512 = SHA512.Create();
             var byteConverter = new UnicodeEncoding();
             var bytes = s512.ComputeHash(byteConverter.GetBytes(hashString));
             var hash = BitConverter.ToString(bytes).Replace("-", "");
             return hash;
         }


    }
}
