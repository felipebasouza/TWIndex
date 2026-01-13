using Refit;
using TwIndex.Core.Models;

namespace TwIndex.Core.Services
{
    public interface IRestApi
    {
        [Post("/busca")]
        Task<Resultado> Request([Body] List<string> palavras);
    }

    public static class EndPoints
    {
        public const string BaseUrl = "https://sua-api.com";
    }
}
