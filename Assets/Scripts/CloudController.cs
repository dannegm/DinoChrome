using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {
	
	public Score score;
	public DinoController Dino;
	public Transform Point2Destroy;
	public float Speed = 0.5f;

	void Update () {
		if (!score.isGameOver) {
			transform.Translate ((Vector3.left * Speed) * Time.timeScale);
		}

		if (transform.position.x < Point2Destroy.position.x) {
			Destroy(transform.gameObject);
		}
	}
}
