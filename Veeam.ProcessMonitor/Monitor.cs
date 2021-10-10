using System;
using System.Diagnostics;
using System.Threading;

namespace Veeam.ProcessMonitor
{
	public class Monitor
	{		
		private readonly DateTime _completionTime;
		private readonly Process[] _processes;
		private readonly ParametersMonitor _parameters;

		public Monitor(ParametersMonitor parameters)
		{
			_parameters = parameters;
			_processes = Process.GetProcessesByName(_parameters.NameProcess);
			_completionTime = _processes[0].StartTime.AddMinutes(_parameters.TimeOfLive);	
		}

		public void MonitoringProcess()
		{
			while(!_processes[0].HasExited)
			{
				if(DateTime.Now >= _completionTime)
					_processes[0].Kill();

				if(!_processes[0].HasExited)
					Thread.Sleep((int)(_parameters.CheckFrequency * 60000));
			}
			_processes[0].Dispose();
		}
	}
}
