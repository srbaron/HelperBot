using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerV2 : MonoBehaviour {
	[SerializeField]
	public AudioClip[] stepClips;
	public AudioClip[] swingClips;
	public AudioClip[] hitClips;
	private AudioSource source;

	private void Awake () {
		source = GetComponent<AudioSource> ();
	}

	private void Step(){
		AudioClip clip = GetRandomStep ();
		source.PlayOneShot (clip);
	}

	private void Swing(){
		AudioClip clip = GetRandomSwing ();
		source.PlayOneShot (clip);
	}

	private void Hit(){
		AudioClip clip = GetRandomHit ();
		source.PlayOneShot (clip);
	}



	private AudioClip GetRandomStep()
	{
		return stepClips[UnityEngine.Random.Range(0, stepClips.Length)];
	}

	private AudioClip GetRandomSwing()
	{
		return swingClips[UnityEngine.Random.Range(0, swingClips.Length)];
	}

	private AudioClip GetRandomHit()
	{
		return hitClips[UnityEngine.Random.Range(0, hitClips.Length)];
	}
}
