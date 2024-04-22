namespace BlazorUI.Services.Base
{
    public class BaseHttpServicecs
    {
        protected IClient _client;

        public BaseHttpServicecs(IClient client)
        {
            _client = client;
        }
    }
}
