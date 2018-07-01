﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using Vixen.Module;
using VixenModules.App.ColorGradients;
using VixenModules.App.Curves;
using VixenModules.Effect.Effect;
using ZedGraph;

namespace VixenModules.Effect.CountDown
{
	[DataContract]
	[KnownType(typeof (SerializableFont))]
	public class CountDownData : EffectTypeModuleData
	{
		public CountDownData()
		{
			Colors = new List<ColorGradient>{new ColorGradient(Color.Red)};
			Direction = CountDownDirection.None;
			Speed = 1;
			Fade = true;
			XOffsetCurve = new Curve(new PointPairList(new[] { 0.0, 100.0 }, new[] { 50.0, 50.0 }));
			YOffsetCurve = new Curve(new PointPairList(new[] { 0.0, 100.0 }, new[] { 50.0, 50.0 }));
			AngleCurve = new Curve(new PointPairList(new[] { 0.0, 100.0 }, new[] { 0.0, 100.0 }));
			FontScaleCurve = new Curve(new PointPairList(new[] { 0.0, 100.0 }, new[] { 100.0, 100.0 }));
			CenterStop = false;
			GradientMode = GradientMode.AcrossElement;
			Orientation=StringOrientation.Vertical;
			Font = new SerializableFont(new Font("Arial", 20));
			LevelCurve = new Curve(CurveType.Flat100);
			TimeFormat = TimeFormat.Minutes;
			CountDownInterval = 1;
			CountDownMode = CountDownMode.None;
			TimeVisibleLength = 750;
			CountDownType = CountDownType.Effect;
			CountDownFade = CountDownFade.InOut;
			DirectionPerWord = false;
			RepeatText = false;
			CountDownDuration = CountDownDuration.AutoFit;
			MarkTimeFreeze = true;
			SequenceTime = 60;
		}

		[DataMember]
		public List<ColorGradient> Colors { get; set; }

		[DataMember]
		public Curve LevelCurve { get; set; }

		[DataMember]
		public CountDownDirection Direction { get; set; }

		[DataMember]
		public TimeFormat TimeFormat { get; set; }

		[DataMember]
		public int CountDownInterval { get; set; }

		[DataMember]
		public int SequenceTime { get; set; }

		[DataMember]
		public int Speed { get; set; }

		[DataMember]
		public bool CenterStop { get; set; }

		[DataMember]
		public bool Fade { get; set; }

		[DataMember]
		public GradientMode GradientMode { get; set; }

		[DataMember]
		public TimeFormat TextMode { get; set; }

		[DataMember]
		public Curve YOffsetCurve { get; set; }

		[DataMember]
		public Curve XOffsetCurve { get; set; }

		[DataMember]
		public Curve FontScaleCurve { get; set; }

		[DataMember]
		public Curve AngleCurve { get; set; }

		[DataMember]
		public SerializableFont Font { get; set; }

		[DataMember]
		public StringOrientation Orientation { get; set; }

		[DataMember]
		public Guid MarkCollectionId { get; set; }

		[DataMember]
		public CountDownMode CountDownMode { get; set; }

		[DataMember]
		public int TimeVisibleLength { get; set; }

		[DataMember]
		public CountDownType CountDownType { get; set; }

		[DataMember]
		public CountDownFade CountDownFade { get; set; }
		
		[DataMember]
		public bool DirectionPerWord { get; set; }

		[DataMember]
		public bool RepeatText { get; set; }

		[DataMember]
		public CountDownDuration CountDownDuration { get; set; }

		[DataMember]
		public bool MarkTimeFreeze { get; set; }

		protected override EffectTypeModuleData CreateInstanceForClone()
		{
			CountDownData result = new CountDownData
			{
				Colors = Colors.ToList(),
				Direction = Direction,
				Speed = Speed,
				CenterStop = CenterStop,
				Orientation = Orientation,
				YOffsetCurve = new Curve(YOffsetCurve),
				XOffsetCurve = new Curve(XOffsetCurve),
				AngleCurve = new Curve(AngleCurve),
				GradientMode = GradientMode,
				Font = new SerializableFont(Font.FontValue),
				LevelCurve = LevelCurve,
				FontScaleCurve = new Curve(FontScaleCurve),
				TimeFormat = TimeFormat,
				CountDownInterval = CountDownInterval,
				Fade = Fade,
				CountDownMode = CountDownMode,
				MarkCollectionId = MarkCollectionId,
				TimeVisibleLength = TimeVisibleLength,
				CountDownType = CountDownType,
				CountDownFade = CountDownFade,
				DirectionPerWord = DirectionPerWord,
				RepeatText = RepeatText,
				CountDownDuration = CountDownDuration,
				MarkTimeFreeze = MarkTimeFreeze,
				SequenceTime = SequenceTime
			};
			return result;
		}
	}
}
