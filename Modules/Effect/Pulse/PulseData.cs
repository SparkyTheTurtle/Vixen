﻿using System.Runtime.Serialization;
using Vixen.Module;
using VixenModules.App.ColorGradients;
using VixenModules.App.Curves;
using System.Drawing;
using VixenModules.Effect.Effect;

namespace VixenModules.Effect.Pulse
{
	[DataContract]
	public class PulseData : EffectTypeModuleData
	{
		[DataMember]
		public Curve LevelCurve { get; set; }

		[DataMember]
		public ColorGradient ColorGradient { get; set; }

		public PulseData()
		{
			LevelCurve = new Curve();
			ColorGradient = new ColorGradient(Color.White);
		}

		[DataMember]
		public byte Layer { get; set; }

		public override IModuleDataModel Clone()
		{
			PulseData result = new PulseData();
			result.LevelCurve = LevelCurve;
			result.ColorGradient = new ColorGradient(ColorGradient);
			result.Layer = Layer;
			return result;
		}
	}
}