using UnityEngine;
using System.Collections;

public class OpenLink : MonoBehaviour {

	public string Link;
	void Update () {
		if (Utils.DaTouch () == transform.name) {
			Application.OpenURL(Link);
		}
	}
}
