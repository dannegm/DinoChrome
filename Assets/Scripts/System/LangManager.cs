using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using SmartLocalization;

public class LangManager : MonoBehaviour {
	
	[Header("Settings")]
	public SystemLanguage DefaultLang = SystemLanguage.English;

	[Header("Events")]
	public UnityEvent OnChangeLanguage;

	private LanguageManager lm;
	public SystemLanguage SelfLang;

	// Use this for initialization
	void Start () {
		lm = LanguageManager.Instance;
		lm.OnChangeLanguage += FonChangeLanguage;
		
		string strLang = PlayerPrefs.GetString ("language", "none");
		SelfLang = strLang == "none" ? Application.systemLanguage : str2sl (strLang);
		SwitchLang (SelfLang);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UISelectLang (int intLang) {
		switch (intLang) {
			case 0:
				SelectLang(SystemLanguage.English);
				break;
			case 1:
				SelectLang(SystemLanguage.French);
				break;
			case 2:
				SelectLang(SystemLanguage.Portuguese);
				break;
			case 3:
				SelectLang(SystemLanguage.Russian);
				break;
			case 4:
				SelectLang(SystemLanguage.Spanish);
				break;
			default:
				SelectLang(SystemLanguage.English);
				break;
		}
	}
	
	public void SelectLang (SystemLanguage lang) {
		PlayerPrefs.SetString ("language", lang.ToString ());
		SelfLang = lang;
		SwitchLang (lang);
	}

	public SystemLanguage str2sl (string lang) {
		switch (lang) {
			case "English":
				return SystemLanguage.English;
				break;
			case "French":
				return SystemLanguage.French;
				break;
			case "Portuguese":
				return SystemLanguage.Portuguese;
				break;
			case "Russian":
				return SystemLanguage.Russian;
				break;
			case "Spanish":
				return SystemLanguage.Spanish;
				break;
			default:
				return SystemLanguage.English;
				break;
		}
	}

	void SwitchLang (SystemLanguage lang) {
		switch (lang) {
			case SystemLanguage.English:
				lm.ChangeLanguage ("en");
				break;
			case SystemLanguage.French:
				lm.ChangeLanguage ("fr");
				break;
			case SystemLanguage.Portuguese:
				lm.ChangeLanguage ("pt");
				break;
			case SystemLanguage.Russian:
				lm.ChangeLanguage ("ru");
				break;
			case SystemLanguage.Spanish:
				lm.ChangeLanguage ("es");
				break;
			default:
				lm.ChangeLanguage ("en");
				break;
		}
	}

	void OnDestroy () {
		if (LanguageManager.HasInstance) {
			lm.OnChangeLanguage -= FonChangeLanguage;
		}
	}

	void FonChangeLanguage (LanguageManager thisLanguageManager) {
		OnChangeLanguage.Invoke ();
	}
}
