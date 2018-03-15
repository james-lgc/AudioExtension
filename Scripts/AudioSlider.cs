using System;
using UnityEngine;
using UnityEngine.UI;
using DSA.Extensions.Base;

namespace DSA.Extensions.Audio
{
	//Controls a specific mixer group volume level
	public class AudioSlider : MonoBehaviour, IDisplayable, IReceivable<string, float>, ISendable<string, float>
	{
		public ExtensionEnum Extension { get { return ExtensionEnum.Audio; } }

		//the specific mixer group this slider controls
		[SerializeField] private string mixerGroupName;
		//the UI slider attached to this
		[SerializeField] private Slider slider;

		//volume level
		private float groupLevel;

		//gets current volume
		public Func<string, float> ReceiveFunction { get; set; }

		//sets volume value
		public Action<string, float> SendAction { get; set; }

		public GameObject ThisGameObject { get { return slider.gameObject; } }

		//while gameobject is enabled, set audio level of mixer group
		private void Update()
		{
			try
			{
				float currentLevel = GetCurrentLevel();
				if (groupLevel != slider.value)
				{
					SendAction(mixerGroupName, slider.value);
				}
			}
			catch (UnityException e) { e.ToString(); }
		}

		//returns the current volume
		private float GetCurrentLevel()
		{
			float currentLevel = ReceiveFunction(mixerGroupName);
			return currentLevel;
		}

		//Store starting level and set slider to current level
		public void Initialize()
		{
			groupLevel = GetCurrentLevel();
			slider.value = groupLevel;
		}

		public void Display(bool isVisible)
		{
			gameObject.SetActive(isVisible);
		}

		//Reset volume to previous state
		public void Clear()
		{
			if (SendAction == null || ReceiveFunction == null) { return; }
			SendAction(mixerGroupName, groupLevel);
		}
	}
}