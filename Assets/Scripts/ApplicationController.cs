using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplicationController : MonoBehaviour {

	public string ActualView = "home.about";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetActualView (string view) {
		ActualView = view;
	}

	public void LoadScene (string scene) {
		ActualView = "home.loading";
		StartCoroutine (LoadNewScene(scene));
	}

	IEnumerator LoadNewScene (string scene) {
		AsyncOperation async = SceneManager.LoadSceneAsync (scene);
		while (!async.isDone) {
			yield return null;
		}
	}
		
	public void OpenURL (string url) {
		Application.OpenURL (url);
	}
}
