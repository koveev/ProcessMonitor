
namespace ProcessMonitor
{
	public class ParametersMonitor
	{
		public string NameProcess { get; private set; }
		public double TimeOfLive { get; private set; }
		public double CheckFrequency { get; private set; }

		public ParametersMonitor(
			string nameProcess, 
			double timeOfLive, 
			double checkFrequency)
		{
			NameProcess = nameProcess;
			TimeOfLive = timeOfLive;
			CheckFrequency = checkFrequency;

		}
	}
}
