using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int Hi;
	public int Points;
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

	void Start () {
		Hi = PlayerPrefs.GetInt ("hi", 0);
		Points = 0;
		GameOverText.position = new Vector3 (0, 2.198273f, -200);
		isGameOver = false;
		ActualTime = Time.time;
		
		Animtr = Dino.GetComponent<Animator> ();
		Dinoco = Dino.GetComponent<DinoController> ();

		cacheDinoSpeed = Dinoco.Speed;

		//PlayerPrefs.SetInt("hi", 0);
	}
	
	// Update is called once per frame
	public void GameOver () {
		if (Points > Hi) {
			Hi = Points;
			PlayerPrefs.SetInt ("hi", Points);
		}
		Dinoco.Speed = cacheDinoSpeed;

		GameOverText.position = new Vector3 (0, 2.198273f, 0);
		isGameOver = true;
		sound.Jump.Stop();
		sound.Up.Stop();
		Time.timeScale = 0;
	}

	void Update () {
		ATime = (Time.time - ActualTime);
		if (!isGameOver) {
			Points = (int)(ATime * (Dinoco.Speed / 2));
		}

		if (isGameOver) {
			if (Utils.DaTouch().name == "ReloadButton") {
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
	}
}
