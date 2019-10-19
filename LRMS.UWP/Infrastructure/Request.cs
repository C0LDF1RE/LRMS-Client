using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using System.Text.Json;
using System.Reflection;

namespace LRMS.UWP.Infrastructure
{
    class Request
    {

        //public async Task<HttpResponseMessage> SendJsonRequest(string method, string url, string jsonObject)
        public async Task<string> SendJsonRequest(string method, string url, string jsonObject)
        {
            try
            {
                // 构造请求信息
                HttpRequestMessage request = new HttpRequestMessage();
                // 构造请求方法
                request.Method = new HttpMethod(method.ToUpper());
                // 构造请求路径
                request.RequestUri = new Uri(url);
                // 构造请求内容和类型
                request.Content = new HttpStringContent(jsonObject, UnicodeEncoding.Utf8, "application/json"); ;
                // 构造请求
                HttpClient client = new HttpClient();
                // 发送请求并构造返回信息
                HttpResponseMessage response = await client.SendRequestAsync(request);
                // Make sure the post succeeded, and write out the response.
                response.EnsureSuccessStatusCode();
                string httpResponseBody = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"The body is: {httpResponseBody}");

                return httpResponseBody;
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
                throw ex;
            }

        }

        public async Task Post(string url, string content)
        {
            try
            {
                // Construct the HttpClient and Uri. This endpoint is for test purposes only.
                HttpClient httpClient = new HttpClient();
                Uri uri = new Uri(url);

                // Construct the JSON to post.
                HttpStringContent body = new HttpStringContent(content, UnicodeEncoding.Utf8, "application/json");

                // Post the JSON and wait for a response.
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(uri, body);

                // Make sure the post succeeded, and write out the response.
                httpResponseMessage.EnsureSuccessStatusCode();
                var httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                Debug.WriteLine(httpResponseBody);
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }
        }
    }
}
