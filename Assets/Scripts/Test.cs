using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

		void OnGUI () {
				GUI.Label (new Rect(16,16,200,40), Application.systemLanguage.ToString());
		}
}
