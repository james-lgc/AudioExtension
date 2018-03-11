using UnityEngine;
using System.Collections;
using DSA.Extensions.Base;

namespace DSA.Extensions.Audio
{
	[System.Serializable]
	//Contains a serialized array of AudioClips, which can be assigned in the Inspector
	public class AudioCollection : INestable<AudioClip>
	{
		[SerializeField] private AudioClip[] clips;

		public AudioClip[] GetArray()
		{
			return clips;
		}
	}
}