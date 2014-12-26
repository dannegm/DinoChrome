using UnityEngine;
using System.Collections;

public class PlayPause : MonoBehaviour {

	public bool Pause = false;
	public Material IconPlay;
	public Material IconPause;
	
	private float TimeToTap = 0.5f;
	private float LastTap;
	private bool cacheTap = false;

	void Update () {
		float ActualTime = Time.time;
		
		if (!cacheTap && !Pause) {
			transform.renderer.material = IconPause;
			cacheTap = true;
		} else if (cacheTap && Pause) {
			transform.renderer.material = IconPlay;
			cacheTap = false;
		}
		
		if (Utils.DaTouch () == transform.name) {
			if (LastTap < ActualTime) {
				LastTap = ActualTime + TimeToTap;
				Pause = !Pause;
			}
		}
	}
}
