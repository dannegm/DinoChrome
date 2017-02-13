using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SmartLocalization;

public class UIController : MonoBehaviour {

	[Header("Settings")]
	public LangManager langManager;

	[Header("NoInternet Content")]
	public Text NoInternetTitle;
	public Text NoInternetDescription;


	[Header("Settings Content")]
	public Text SettingsDialogTitle;
	public Text SettingsLangLabel;
	public Dropdown SettingsLangDropdown;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		SettingsLangDropdown.value = sl2int( langManager.SelfLang );
	}

	public int sl2int (SystemLanguage lang) {
		switch (lang) {
			case SystemLanguage.English:
				return 0;
				break;
			case SystemLanguage.French:
				return 1;
				break;
			case SystemLanguage.Portuguese:
				return 2;
				break;
			case SystemLanguage.Russian:
				return 3;
				break;
			case SystemLanguage.Spanish:
				return 4;
				break;
			default:
				return 0;
				break;
		}
	}

	public void SetLang () {
		// NoInternet Content
		NoInternetTitle.text = LanguageManager.Instance.GetTextValue ("UI.NoInternet.Title");
		NoInternetDescription.text = LanguageManager.Instance.GetTextValue ("UI.NoInternet.Description");
			
		// Settings Content
		SettingsDialogTitle.text = LanguageManager.Instance.GetTextValue ("UI.Settings.Dialog.Title");
		SettingsLangLabel.text = LanguageManager.Instance.GetTextValue ("UI.Settings.Lang.Label");
	}
}
