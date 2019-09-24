namespace TranslationServices
{
    public class TranslationServiceHttpRequest
    {
        private HttpApiConfigurationDto ConfigurationDto { get; set; }

        public TranslationServiceHttpRequest(HttpApiConfigurationDto configuration)
        {
            ConfigurationDto = configuration;
        }
    }
}