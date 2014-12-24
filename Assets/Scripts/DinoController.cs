using UnityEngine;
using System.Collections;

public class DinoController : MonoBehaviour {

	public Score score;
	public AudioController sound;
	public float TimeToJump = 0.5f;
	public float JumpForce = 5f;
	public float Speed = 0.5f;
	public float SpeedLimit = 45f;

	public Transform CompFloor;
	public float CompRadio = 0.07f;
	public LayerMask MaskFloor;
	private bool onFloor;

	private Transform Dino;
	private float LastJump;

	public Animator Animtr;

	void Awake () {
		Dino = transform;
		Animtr = Dino.GetComponent<Animator> ();
	}

	void FixedUpdate () {
		onFloor = Physics2D.OverlapCircle (CompFloor.position, CompRadio, MaskFloor);
	}

	void Update () {
		float ActualTime = Time.time;

		if (Speed < SpeedLimit) {
			Speed = Speed + Time.deltaTime;
		}
	
		// Aquí va el Jump
		if (Input.GetMouseButtonDown (0) || Input.GetKey(KeyCode.Space) ||Input.touchCount > 0) {
			if (LastJump < ActualTime) {
				LastJump = ActualTime + TimeToJump;
				Dino.rigidbody2D.AddForce(Vector2.up * JumpForce);
				sound.Jump.Play();
			}
		}

		if (!onFloor) {
			Animtr.SetBool ("isJump", true);
		} else {
			Animtr.SetBool("isJump", false);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "cactus") {
			Animtr.SetBool("isJump", false);
			Animtr.SetBool("isDead", true);
			
			sound.Wrong.Play();
			score.GameOver();
		}
	}
}
