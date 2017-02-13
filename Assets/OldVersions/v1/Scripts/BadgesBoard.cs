using UnityEngine;
using System.Collections;

using UnityEngine.SocialPlatforms;

public class BadgesBoard : MonoBehaviour {

	public Color ColorActive;
	public Color ColorDisable;

	private float TimeToTap = 0.5f;
	private float LastTap;
	private bool cacheColor = false;
	
	void Update () {
		if (!cacheColor && Social.localUser.authenticated) {
			transform.GetComponent<Renderer>().material.color = ColorActive;
			cacheColor = true;
		} else if (cacheColor && !Social.localUser.authenticated) {
			transform.GetComponent<Renderer>().material.color = ColorDisable;
			cacheColor = false;
		}

		float ActualTime = Time.time;
		if (Utils.DaTouch() == transform.name) {
			if (LastTap < ActualTime) {
				LastTap = ActualTime + TimeToTap;
				Badges();
			}
		}
	}

	void Badges () {
		if (Social.localUser.authenticated) {
		} else {
			Social.localUser.Authenticate((bool success) => {});
		}
	}
}
