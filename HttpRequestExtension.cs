namespace System.Web
{
    /// <summary>
    /// Extension class for HttpRequest
    /// </summary>
    public static class HttpRequestExtension
    {
        /// <summary>
        /// Retrieve the base Url of the application.
        /// </summary>
        /// <param name="request">The callee instance of HttpRequest.</param>
        /// <returns>Returns the base Url of the application. If an error occurs, returns null.</returns>
        public static string GetBaseUrl(this HttpRequest request)
        {
            try
            {
                string baseUrl = null;

                if (request.ApplicationPath != null)
                {
                    var requestUri = request.Url;
                    var index = requestUri.AbsolutePath.ToLowerInvariant().IndexOf(request.ApplicationPath.ToLowerInvariant(), StringComparison.Ordinal);
                    if (index > -1) {
                        baseUrl = requestUri.AbsolutePath.Substring(index, request.ApplicationPath.Length);
                        baseUrl = baseUrl == "/" ? baseUrl : baseUrl + "/";
                    }
                }

                return baseUrl;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}