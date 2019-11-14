using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RP.PhotoAlbum.Provider.Feature.Exceptions;

namespace RP.PhotoAlbum.Provider.Feature.Extensions
{
    public static class RestExtensions
    {
        public static async Task<List<T>> RunAsListAsync<T>(this IRestClient client, string resource, Method method = Method.GET)
        {
            var request = new RestRequest(resource, method);
            var taskCompletionSource = new TaskCompletionSource<List<T>>();

            client.ExecuteAsync(request, response =>
            {
                ValidateReponse(response);

                var data = JsonConvert.DeserializeObject<List<T>>(response.Content);

                taskCompletionSource.SetResult(data);
            });

            return await taskCompletionSource.Task;
        }

        private static void ValidateReponse(IRestResponse response)
        {
            if (IsHttpStatusOk((int)response.StatusCode))
            {
                return;
            }

            var exception = CreateException(response);
            throw exception;
        }

        private static bool IsHttpStatusOk(int httpStatusCode)
        {
            return
                200 <= httpStatusCode &&
                httpStatusCode < 300;
        }

        private static Exception CreateException(IRestResponse response)
        {
            var message = $"Unexpected HTTP Response Status: {response.StatusCode}";

            var exception = new HttpResponseException(message)
            {
                RequestUri = response.ResponseUri?.AbsoluteUri,
                ResponseStatusCode = response.StatusCode,
                ResponseContent = response.Content,
            };

            return exception;
        }
    }
}
