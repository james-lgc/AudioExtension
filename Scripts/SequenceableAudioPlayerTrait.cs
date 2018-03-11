using UnityEngine;
using DSA.Extensions.Base;

namespace DSA.Extensions.Audio
{
	[AddComponentMenu("Trait/Audio/(Sequenceable) Audio Player Trait")]
	[System.Serializable]
	//concrete implementation of AudioPlayerTrait
	//can be called from trait base via CallInSequence
	public class SequenceableAudioPlayerTrait : AudioPlayerTrait, ISequenceable
	{
		//Plays a random clip from the selected AudioCollection
		public void CallInSequence(int index = 0)
		{
			if (collection.Length == 0)
			{
				Debug.Log(gameObject.name + " has no sounds assigned.");
				return;
			}
			ID = index;
			try
			{
				thisSource.clip = collection[index].GetArray()[UnityEngine.Random.Range(0, collection[index].GetArray().Length)];
			}
			catch (UnityException e) { Debug.Log(e.ToString()); }
			Use();
		}
	}
}