using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {
	public string Action;
	public bool Quit = false;
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!Quit) {
				Application.LoadLevel (Action);
			} else {
				Application.Quit ();
			}
		}
	}
}
