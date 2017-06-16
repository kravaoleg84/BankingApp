using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BankingApp.WEB.ActionResults
{
    public class WrongEnterResult : IHttpActionResult
    {
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            string info = "Entered sum can't be zero or negative.";

            var response = new HttpResponseMessage();
            response.Content = new StringContent(info);

            return Task.FromResult(response);
        }
    }
}