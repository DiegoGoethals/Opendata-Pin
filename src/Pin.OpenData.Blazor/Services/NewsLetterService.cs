namespace Pin.OpenData.Blazor.Services
{
	public class NewsLetterService : INewsLetterService
	{
		private static bool _isSubscribed;

		public NewsLetterService()
		{
			_isSubscribed = false;
		}

		public bool IsSubscribed()
		{
			return _isSubscribed;
		}

		public void Subscribe()
		{
			_isSubscribed = true;
		}
	}
}
