using System;
using UnityEngine;
using DSA.Extensions.Base;

namespace DSA.Extensions.Audio
{
	//Audio Settings Canvas
	public class AudioCanvas : ClickableCanvas, ISettable<Func<string, float>, Action<string, float>>
	{
		public override ExtensionEnum.Extension Extension { get { return ExtensionEnum.Extension.Audio; } }

		//UI Sliders to control volumes
		[SerializeField] private AudioSlider[] sliders;

		//On Initialize, send func and action to sliders
		public override void Initialize()
		{
			base.Initialize();
		}

		//Initialize sliders every time data is displayed
		public override void DisplayData()
		{
			for (int i = 0; i < sliders.Length; i++)
			{
				sliders[i].Initialize();
			}
		}

		//pass manager volume handling to sliders
		public void Set(Func<string, float> sentItem1, Action<string, float> sentItem2)
		{
			for (int i = 0; i < sliders.Length; i++)
			{
				sliders[i].ReceiveFunction = sentItem1;
				sliders[i].SendAction = sentItem2;
			}
		}
	}
}