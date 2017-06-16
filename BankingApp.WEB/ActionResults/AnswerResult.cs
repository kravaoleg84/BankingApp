using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BankingApp.WEB.ActionResults
{
    public class AnswerResult : IHttpActionResult
    {
        private string info;
        public AnswerResult(string info)
        {
            this.info = info;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(info);

            return Task.FromResult(response);
        }
    }
}