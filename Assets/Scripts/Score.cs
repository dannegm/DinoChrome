using UnityEngine;
using System.Collections;

using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Score : MonoBehaviour {

	private int key = 0;
	private int _hi = 0;

	public int Points;
	public int Hi {
		get { return _hi ^ key; }
		set {
			key = Random.Range(0, int.MaxValue);
			_hi = value ^ key;
		}
	}

	public Transform GameOverText;
	public Transform Dino;
	public AudioController sound;

	private DinoController Dinoco;
	private Animator Animtr;

	public bool isGameOver = false;
	private bool cacheGO = true;

	private float ActualTime = 0f;
	private float ATime = 0f;

	private float cacheDinoSpeed = 0;


	// Badges
	
	private bool DinoBaby = false;
	private bool DinoYoung = false;
	private bool DinoExpert = false;
	private bool DinoMaster = false;
	private bool DinoBoss = false;

	void Awake () {
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();

		//Badges
		
		DinoBaby = PlayerPrefs.GetInt ("dino_baby", 0) != 1 ? false : true;
		DinoYoung = PlayerPrefs.GetInt ("dino_young", 0) != 1 ? false : true;
		DinoExpert = PlayerPrefs.GetInt ("dino_expert", 0) != 1 ? false : true;
		DinoMaster = PlayerPrefs.GetInt ("dino_master", 0) != 1 ? false : true;
		DinoBoss = PlayerPrefs.GetInt ("dino_boss", 0) != 1 ? false : true;
	}

	void Start () {
		Hi = PlayerPrefs.GetInt ("hi", 0);
		Points = 0;
		GameOverText.position = new Vector3 (0, 2.198273f, -200);
		isGameOver = false;
		ActualTime = Time.time;
		
		Animtr = Dino.GetComponent<Animator> ();
		Dinoco = Dino.GetComponent<DinoController> ();

		cacheDinoSpeed = Dinoco.Speed;

		// ResetPrefs ();

		((PlayGamesPlatform) Social.Active).Authenticate((bool success) => {}, true);
	}

	public void GameOver () {
		if (Points > Hi) {
			Hi = Points;
			PlayerPrefs.SetInt ("hi", Points);

			Social.ReportScore(Hi, "CgkIycGb8cMBEAIQBg", (bool success) => {});
		}
		Dinoco.Speed = cacheDinoSpeed;

		GameOverText.position = new Vector3 (0, 2.198273f, 0);
		isGameOver = true;
		sound.Jump.Stop();
		sound.Up.Stop();
		Time.timeScale = 0;
	}

	void Update () {
		ATime = Time.time - ActualTime;
		if (!isGameOver && Points < 25001) {
			Points = (int)(ATime * (Dinoco.Speed / 2));
		}

		if (isGameOver) {
			if (Utils.DaTouch() == "ReloadButton") {
				isGameOver = false;
				cacheGO = false;
				Points = 0;
			}
		}

		if (!isGameOver && !cacheGO) {
			cacheGO = true;
			GameOverText.position = new Vector3 (0, 2.198273f, -200);
			isGameOver = false;
			Animtr.SetBool("isDead", false);
			ActualTime = Time.time;
			Time.timeScale = 1;
		}

		// Badges

		// Baby - 100 puntos o más
		if (!DinoBaby && Points > 100) {
			DinoBaby = true;
			PlayerPrefs.SetInt("dino_baby", 1);
			Social.ReportProgress("CgkIycGb8cMBEAIQAQ", 100.0, (bool success) => {});
		}
		// Young - 500 puntos o más
		if (!DinoYoung && Points > 500) {
			DinoYoung = true;
			PlayerPrefs.SetInt("dino_young", 1);
			Social.ReportProgress("CgkIycGb8cMBEAIQAg", 100.0, (bool success) => {});
		}

		// Expert - 2,500 o más
		if (!DinoExpert && Points > 2500) {
			DinoExpert = true;
			PlayerPrefs.SetInt("dino_expert", 1);
			Social.ReportProgress("CgkIycGb8cMBEAIQAw", 100.0, (bool success) => {});
		}

		// Master - 10,000 o más
		if (!DinoMaster && Points > 10000) {
			DinoMaster = true;
			PlayerPrefs.SetInt("dino_master", 1);
			Social.ReportProgress("CgkIycGb8cMBEAIQBA", 100.0, (bool success) => {});
		}

		// F**K Boss - 25,000 o más
		if (!DinoBoss && Points > 25000) {
			DinoBoss = true;
			PlayerPrefs.SetInt("dino_boss", 1);
			Social.ReportProgress("CgkIycGb8cMBEAIQBQ", 100.0, (bool success) => {});
		}
	}

	void ResetPrefs () {
		PlayerPrefs.SetInt("hi", 0);
		PlayerPrefs.SetInt("dino_baby", 0);
		PlayerPrefs.SetInt("dino_young", 0);
		PlayerPrefs.SetInt("dino_expert", 0);
		PlayerPrefs.SetInt("dino_master", 0);
		PlayerPrefs.SetInt("dino_boss", 0);
	}
}
