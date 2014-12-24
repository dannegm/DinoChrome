using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TextGUI : MonoBehaviour {

	public Score score;
	public AudioController sound;
	public GUIStyle ScoreStyle;
	public GUIStyle HIStyle;

	private int ActualScore100 = 100;

	private Rect r_score;
	private Rect r_hi;

	private float wwidth;

	// Use this for initialization
	void Start () {
		wwidth = Screen.width;
		
		float h_label = (wwidth / 100) * 10;
		float w_label = (wwidth / 100) * 50;

		int fontSize = (int) (wwidth / 100) * 4;
		ScoreStyle.fontSize = fontSize;
		HIStyle.fontSize = fontSize;

		r_score = new Rect (wwidth - w_label, 0, w_label, h_label);
		r_hi = new Rect (wwidth - (w_label * 1.5f) , 0, w_label, h_label);
	}

	void OnGUI () {
		if (score.Points > ActualScore100) {
			ActualScore100 += 100;
			sound.Up.Play();
		}

		if (score.isGameOver) {
			ActualScore100 = 100;
		}

		string HI = score.Hi.ToString ("D5");
		string POINTS = score.Points.ToString ("D5");
		
		GUI.Label (r_score, POINTS, ScoreStyle);
		GUI.Label (r_hi, "HI " + HI, HIStyle);
	}
}
