using UnityEngine;
using System.Collections;

public class DinoController : MonoBehaviour {

	// Objeto con el controlador del juego
	public Score score;
	// Controlador de audio
	public AudioController sound;

	// Tiempo de espera para el siguiente brinco
	public float TimeToJump = 0.5f;
	// Fuerza del salto
	public float JumpForce = 5f;
	// Velocidad del Dino
	public float Speed = 0.5f;
	// Límite de velocidad
	public float SpeedLimit = 45f;

	// Objeto que comprueba que esté en el suelo
	public Transform CompFloor;
	// Radio para comprobar que toca el suelo
	public float CompRadio = 0.07f;
	// Objetos que se relacionan con el suelo
	public LayerMask MaskFloor;
	// Comrpeuba si está en el suelo
	private bool onFloor;

	// Cache del mismo objeto, no se instancia cada FPS sino solamente al inicio
	private Transform Dino;
	// Cache del último salto
	private float LastJump;

	// Control de animaciones
	public Animator Animtr;

	// Se ejecuta en el primer FPS
	void Awake () {
		// Almacenamos a Dino en cache
		Dino = transform;
		// Obtenemos el control de animaciones relacionadas a Dino
		Animtr = Dino.GetComponent<Animator> ();
	}

	// Se ejecuta cada cambio de FPS
	void FixedUpdate () {
		// Comprueba si está en el suelo
		/*
		 * A travez del objeto de comprobación y del radio especifico, si está cerca de los objetos dentro de "suelo"
		 * Regresa true si toca el suelo, false si no
		 */
		onFloor = Physics2D.OverlapCircle (CompFloor.position, CompRadio, MaskFloor);
	}

	// Se ejecuta cada FPS
	void Update () {
		float ActualTime = Time.time;

		// Aumetnamos velocidad hasta que llegamos al límite
		if (Speed < SpeedLimit) {
			Speed = Speed + Time.deltaTime;
		}

		// Si no está en el suelo, le decimos al Animator que está brincando
		if (!onFloor) {
			Animtr.SetBool ("isJump", true);
		// Si está en el suelo, le decimos al Animator que no está brincando
		} else {
			Animtr.SetBool("isJump", false);
		}
	
		// Si se pulsa la tecla "space" o se toca en la pantalla sobre el boton del área segura
		if (Input.GetKey(KeyCode.Space) || Utils.DaTouch() == "TapSafeArea") {
			// Si el tiempo actual es mayor al tiempo del último brinco
			if (LastJump < ActualTime) {
				// Guardamos info del último brinco
				LastJump = ActualTime + TimeToJump;
				// Agregamos fuerza a su cuerpo físico. Un espacio bidimensional, aplicamos fuerza hacia arriba * la fuerza previamente establecida
				Dino.rigidbody2D.AddForce(Vector2.up * JumpForce);
				// Ejecutamos sonido de salto
				sound.Jump.Play();
			}
		}
	}

	// Si colisiona...
	void OnTriggerEnter2D(Collider2D other) {
		// Con un cactus
		if (other.tag == "cactus") {
			// Le decimos al Animator que no está brincando y que está muerto
			Animtr.SetBool("isJump", false);
			Animtr.SetBool("isDead", true);

			// Ejecutamos sonido de loser
			sound.Wrong.Play();
			// Ejecutamos GameOver en el control del juego
			score.GameOver();
		}
	}
}
