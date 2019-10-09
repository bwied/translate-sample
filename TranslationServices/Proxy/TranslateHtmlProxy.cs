﻿using System.Net.Http;
using HttpRequestUtility;
using Config = TranslationServices.TranslationServices.TranslateParameters;

namespace TranslationServices.Proxy
{
    internal class TranslateHtmlProxy : TranslateProxy
    {
        public TranslateHtmlProxy(HttpClient client, string[] languages, string requestBody, string from, TranslationServiceHttpRequestDto request = null) 
            : base(client, languages, requestBody, from, request)
        {
            if (request != null) return;

            Request.Parameters.Add($"{Config.TextTypeKey}={Config.TextTypeHtml}");
        }
    }
}