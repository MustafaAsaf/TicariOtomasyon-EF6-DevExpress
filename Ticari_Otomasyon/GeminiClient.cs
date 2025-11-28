using DevExpress.XtraPrinting.Native.WebClientUIControl;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ticari_Otomasyon
{
    /// <summary>
    /// Google Gemini REST API istemcisi.
    /// Basit bir metin girdisine karşılık tek bir metin cevabı döndürür.
    /// </summary>
    public class GeminiClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private readonly string _apiKey;
        private readonly string _baseUrl;
        private readonly string _model;

        public GeminiClient()
        {
            _apiKey = ConfigurationManager.AppSettings["Gemini:ApiKey"];
            _baseUrl = ConfigurationManager.AppSettings["Gemini:BaseUrl"] ??
                       "https://generativelanguage.googleapis.com/v1beta";
            _model = ConfigurationManager.AppSettings["Gemini:Model"] ?? "gemini-1.5-flash";

            if (string.IsNullOrWhiteSpace(_apiKey))
            {
                throw new InvalidOperationException("Gemini:ApiKey App.config içinde tanımlı değil.");
            }
        }

        public async Task<string> GetInsightsAsync(string prompt, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                throw new ArgumentException("Prompt boş olamaz.", nameof(prompt));
            }

            var url = $"{_baseUrl}/models/{_model}:generateContent?key={_apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var json = JsonConvert.SerializeObject(requestBody);
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = content;
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false))
                {
                    var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException(
                            $"Gemini API hatası ({(int)response.StatusCode}): {responseContent}");
                    }

                    var parsed = JsonConvert.DeserializeObject<GeminiResponse>(responseContent);
                    var text = parsed?.candidates?
                        .FirstOrDefault()?
                        .content?
                        .parts?
                        .FirstOrDefault()?
                        .text;

                    return text ?? string.Empty;
                }
            }
        }

        private class GeminiResponse
        {
            public GeminiCandidate[] candidates { get; set; }
        }

        private class GeminiCandidate
        {
            public GeminiContent content { get; set; }
        }

        private class GeminiContent
        {
            public GeminiPart[] parts { get; set; }
        }

        private class GeminiPart
        {
            public string text { get; set; }
        }
    }
}


