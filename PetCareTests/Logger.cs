using log4net;

namespace PetCareTests
{
	public class Logger
	{
		public static readonly ILog Log = LogManager.GetLogger(nameof(Logger));
	}
}