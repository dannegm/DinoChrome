using UnityEngine;
using System.Collections;

public class ToggleAudio : MonoBehaviour {
	
	public AudioController sounds;
	public Material IconMute;
	public Material IconUnmute;

	private float TimeToTap = 0.5f;
	private float LastTap;
	private bool cacheAudio = false;

	void Update () {
		float ActualTime = Time.time;

		if (!cacheAudio && !sounds.mute) {
			transform.GetComponent<Renderer>().material = IconUnmute;
			cacheAudio = true;
		} else if (cacheAudio && sounds.mute) {
			transform.GetComponent<Renderer>().material = IconMute;
			cacheAudio = false;
		}

		if (Utils.DaTouch () == transform.name) {
			if (LastTap < ActualTime) {
				LastTap = ActualTime + TimeToTap;
				sounds.ToggleMute();
			}
		}
	}
}
