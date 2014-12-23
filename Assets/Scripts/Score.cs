using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int Hi;
	public int Points;
	public Transform GameOverText;
	public Transform Dino;

	private DinoController Dinoco;
	private Animator Animtr;

	public bool isGameOver = false;
	private bool cacheGO = true;

	private float ActualTime = 0f;
	private float ATime = 0f;

	void Start () {
		Hi = PlayerPrefs.GetInt ("hi", 0);
		Points = 0;
		GameOverText.position = new Vector3 (0, 2.198273f, -200);
		isGameOver = false;
		ActualTime = Time.time;
	}
	
	// Update is called once per frame
	public void GameOver () {
		if (Points > Hi) {
			PlayerPrefs.SetInt("hi", Points);
		}

		Time.timeScale = 0;
		GameOverText.position = new Vector3 (0, 2.198273f, 0);
		isGameOver = true;
		
		Animtr = Dino.GetComponent<Animator> ();
		Dinoco = Dino.GetComponent<DinoController> ();
	}

	void Update () {
		ATime = (Time.time - ActualTime);
		Points = (int) (ATime * (Dinoco.Speed / 2));


		if (isGameOver) {
			if (Input.GetMouseButtonDown (0) || Input.GetKey(KeyCode.Space) ||Input.touchCount > 0) {
				isGameOver = false;
				cacheGO = false;
			}
		}

		if (!isGameOver && !cacheGO) {
			cacheGO = true;

			GameOverText.position = new Vector3 (0, 2.198273f, -200);
			isGameOver = false;
			Points = 0;
			Animtr.SetBool("isDead", false);
			ActualTime = Time.time;
			Time.timeScale = 1;
		}
	}
}
