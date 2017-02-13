using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

	[Header("Global App Controller")]
	public ApplicationController appController;


	[Header("Events")]
	
	[Tooltip("View where the attached event will trigger")]
	public string[] ViewActions;

	[Tooltip("Event attached")]
	public Button[] EventsTrigger;

	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Backspace)) {
			if (appController.ActualView.Contains("home.")) {
				Application.Quit ();
			}
				
			for (int x = 0; x < ViewActions.Length; x++) {
				Button.ButtonClickedEvent btnEv = EventsTrigger [x].onClick;
				if (appController.ActualView == ViewActions[x]) {
					Debug.Log (ViewActions[x] + ": Click Event");
					btnEv.Invoke ();
				}
			}
		}
	}
}
