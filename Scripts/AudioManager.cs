using UnityEngine;
using UnityEngine.Audio;
using DSA.Extensions.Base;

namespace DSA.Extensions.Audio
{
	//Managers audio levels in game
	//May later be extended to manage in-game music
	public class AudioManager : ClickableCanvasedManagerBase<AudioCanvas>
	{
		public override ExtensionEnum.Extension Extension { get { return ExtensionEnum.Extension.Audio; } }

		[SerializeField] protected AudioMixer audioMixer;

		//On Initialize, pass action and func to canvas
		public override void Initialize()
		{
			//pass volume control methods to canvas
			canvas.Set(GetMixerLevel, SetMixerLevel);
			//default canvas initialization
			base.Initialize();
			//make canvas cancellable by key press
			uiController.CancelAction = EndProcess;
		}

		//Returns the current volume level of a given mixer group
		private float GetMixerLevel(string groupName)
		{
			float level;
			audioMixer.GetFloat(groupName, out level);
			return level;
		}

		//Sets the volume level of a given mixer group
		private void SetMixerLevel(string groupName, float level)
		{
			audioMixer.SetFloat(groupName, level);
		}
	}
}