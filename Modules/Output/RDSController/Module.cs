﻿using System.IO.Ports;
using System.Text;
using Vixen.Commands;
using Vixen.Module;
using Vixen.Module.Controller;
using System.Timers;
using System;
using System.IO;
using System.Linq;

namespace VixenModules.Output.RDSController
{
	public class Module : ControllerModuleInstanceBase
	{
		private Data _Data;
		private CommandHandler _commandHandler;
		public Module()
		{
			DataPolicyFactory = new DataPolicyFactory();
			_commandHandler = new CommandHandler();
		}



		public override void UpdateState(int chainIndex, ICommand[] outputStates)
		{
			foreach (var item in outputStates.Where(i => i != null)) {
				var cmd = item as StringCommand;
				if (cmd != null) {
					Console.WriteLine(cmd.CommandValue as string);
				}
			}
		}

		public override bool HasSetup
		{
			get { return true; }
		}

		public override bool Setup()
		{

			using (var setupForm = new SetupForm()) {
				setupForm.ShowDialog();
				return true;
			}

			//	return false;
		}

		public override IModuleDataModel ModuleData
		{
			get { return _Data; }
			set
			{
				_Data = (Data)value;
			}
		}

		public override void Start()
		{
			base.Start();

		}

		public override void Stop()
		{

			base.Stop();
		}

	}
}