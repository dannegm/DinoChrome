using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	private AudioSource[] audios;
	public AudioSource Jump;
	public AudioSource Wrong;
	public AudioSource Up;

	public bool mute = false;

	void Start () {
		audios = GetComponents<AudioSource> ();
		
		Jump = audios [0];
		Wrong = audios [1];
		Up = audios [2];
	}

	public void ToggleMute () {
		if (!mute) {
			foreach (AudioSource a in audios) {
				a.mute = true;
				mute = true;
			}
		} else {
			foreach (AudioSource a in audios) {
				a.mute = false;
				mute = false;
			}
		}
	}
}
