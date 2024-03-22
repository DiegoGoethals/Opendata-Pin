namespace Pin.OpenData.Blazor.Services
{
	public interface INewsLetterService
	{
		bool IsSubscribed();
		void Subscribe();
	}
}
