﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Data.Value;
using Vixen.Intent;
using Vixen.Sys;
using Vixen.Module;
using Vixen.Module.Effect;
using Vixen.Sys.Attribute;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace VixenModules.Effect.Nutcracker
{
	public class Nutcracker : EffectModuleInstanceBase
	{
		private NutcrackerModuleData _data;
		private EffectIntents _elementData = null;

        public Nutcracker()
		{
            _data = new NutcrackerModuleData();
		}

		protected override void _PreRender()
		{
			_elementData = new EffectIntents();

			foreach (ElementNode node in TargetNodes) {
				if (node != null)
					RenderNode(node);
			}
		}

		protected override EffectIntents _Render()
		{
            return _elementData;
		}

		public override IModuleDataModel ModuleData
		{
			get 
            {
                _data.NutcrackerData.TargetNodes = TargetNodes;
                return _data; 
            }
            set { _data = value as NutcrackerModuleData; }
		}

		public double IntensityLevel
		{
			get { return 100; }
			set { IsDirty = true; }
		}

		public Color Color
		{
			get { return SystemColors.ActiveBorder; }
			set { IsDirty = true; }
		}

        [Value]
        public NutcrackerData NutcrackerData
        {
            get 
            {
                _data.NutcrackerData.TargetNodes = TargetNodes;
                return _data.NutcrackerData;
            }
            set 
            {
                _data.NutcrackerData = value;
                IsDirty = true;
            }
        }

        private int StringCount
        {
            get
            {
                int childCount = TargetNodes.FirstOrDefault().Children.Count();
                //Console.WriteLine("StringCount:" + childCount);
                //return TargetEffect.TargetNodes.Count();
                return childCount;
            }
        }

		// renders the given node to the internal ElementData dictionary. If the given node is
		// not a element, will recursively descend until we render its elements.
		private void RenderNode(ElementNode node)
		{
            //Console.WriteLine("Nutcracker Node:" + node.Name);
            //bool CW = true;
            Color color;
            int stringCount = StringCount;
            int framesToRender = (int)TimeSpan.TotalMilliseconds / 50;
            NutcrackerEffects effect = new NutcrackerEffects(_data.NutcrackerData);
            //
            // Need to change this!!!!!!!!
            //
            int pixelsPerString = 50;
            effect.InitBuffer(stringCount, pixelsPerString);
            int totalPixels = effect.PixelCount();
            TimeSpan startTime = TimeSpan.Zero;
            TimeSpan ms50 = new TimeSpan(0, 0, 0, 0, 50);

            // Parallel will NOT work here. Nutcracker effects must be run in order
            for (int frameNum = 0; frameNum < framesToRender; frameNum++)
            {
                effect.RenderNextEffect(_data.NutcrackerData.CurrentEffect);
                
                //Stopwatch timer = new Stopwatch(); timer.Start();

                int elementNum = 0;
                int elementCount = node.Count();
                int stringNum = 0;
                int pixelNum = 0;
                foreach (Element element in node)
                {
                    stringNum = stringCount - (elementNum / pixelsPerString);
                    pixelNum = (stringNum * pixelsPerString) - (pixelsPerString - (elementNum % pixelsPerString));
                    color = effect.GetPixel(pixelNum);

                    LightingValue lightingValue = new LightingValue(color, (float)color.A);
                    IIntent intent = new LightingIntent(lightingValue, lightingValue, ms50);
                    _elementData.AddIntentForElement(element.Id, intent, startTime);

                    elementNum++;
                }
                
                //timer.Stop(); Console.WriteLine("Nutcracker Render:" + timer.ElapsedMilliseconds + " Frames:" + framesToRender);

                startTime = startTime.Add(ms50);
            };
		}
	}
}
