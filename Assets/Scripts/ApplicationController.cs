using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplicationController : MonoBehaviour {

	public string DefaultLang = "es";
	public string ActualView = "home.about";

	public string lang;

	// Use this for initialization
	void Start () {
		lang = PlayerPrefs.GetString ("lang", DefaultLang);
		SetLang (lang);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SetLang (string _lang) {
		lang = _lang;
		PlayerPrefs.SetString ("lang", lang);
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
