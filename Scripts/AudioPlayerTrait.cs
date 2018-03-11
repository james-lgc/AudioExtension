using UnityEngine;
using System.Collections;
using System;
using DSA.Extensions.Base;

namespace DSA.Extensions.Audio
{
	[RequireComponent(typeof(AudioSource))]
	//Controls playing of audio clips, allows for multiple collections of clips per object
	//eg. Player footstep collection, player jump sound collection, etc
	public abstract class AudioPlayerTrait : TraitBase, IOrderable, IUseable
	{
		public override ExtensionEnum.Extension Extension { get { return ExtensionEnum.Extension.Audio; } }

		[SerializeField] protected AudioCollection[] collection;
		protected AudioSource thisSource;
		public int ID { get; protected set; }

		private void Awake()
		{
			thisSource = GetComponent<AudioSource>();
		}

		public void Use()
		{
			thisSource.Play();
		}
	}
}