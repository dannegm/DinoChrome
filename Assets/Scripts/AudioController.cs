using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	private AudioSource[] audios;
	public AudioSource Jump;
	public AudioSource Wrong;
	public AudioSource Up;

	void Start () {
		audios = GetComponents<AudioSource> ();
		
		Jump = audios [0];
		Wrong = audios [1];
		Up = audios [2];
	}
}
