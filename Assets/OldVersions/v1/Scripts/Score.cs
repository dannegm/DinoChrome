// Importando librerías

using UnityEngine;
using System.Collections;

using UnityEngine.SocialPlatforms;

// Clase Score, ahora se usa como el controlador del juego, hereda de MonoBehavior (interfaz)
public class Score : MonoBehaviour {

	// Se almacena una clave para hashear la puntuación y evitar editarla en tiempo de ejecución, HI no se almacena en memoria
	private int key = 0;
	// Valor hasheado de la puntuación más alta
	private int _hi = 0;

	// Se almacenan los puntos por partida
	public int Points;

	// Propiedad que devuelve y desencripta la puntuación más alta
	public int Hi {
		get { return _hi ^ key; }
		set {
			key = Random.Range(0, int.MaxValue);
			_hi = value ^ key;
		}
	}

	// Objeto con el texto "Game Over"
	public Transform GameOverText;
	// Objeto con el Dino
	public Transform Dino;
	// Controlado de audio
	public AudioController sound;

	// Interfaz para Play/Pause
	public PlayPause ppause;
	// Controlador del Dino
	private DinoController Dinoco;
	// Control de animaciones de Dino
	private Animator Animtr;

	// Almacena el estado del juego
	public bool isGameOver = false;
	// Cache para no ejecutar 2 veces
	private bool cacheGO = true;

	// Tiempo del último inicio de la partida
	private float ActualTime = 0f;
	// Tiempo de de la partida
	private float ATime = 0f;

	// Almacena velocidad inicial del dinosaurio
	private float cacheDinoSpeed = 0;


	// Punteros para comprobar logros
	private bool DinoBaby = false;
	private bool DinoYoung = false;
	private bool DinoExpert = false;
	private bool DinoMaster = false;
	private bool DinoBoss = false;

	// Se ejecuta en el primer fotograma
	void Awake () {

		// Comprueba el estado de los logros almacenados en memoria local
		DinoBaby = PlayerPrefs.GetInt ("dino_baby", 0) != 1 ? false : true;
		DinoYoung = PlayerPrefs.GetInt ("dino_young", 0) != 1 ? false : true;
		DinoExpert = PlayerPrefs.GetInt ("dino_expert", 0) != 1 ? false : true;
		DinoMaster = PlayerPrefs.GetInt ("dino_master", 0) != 1 ? false : true;
		DinoBoss = PlayerPrefs.GetInt ("dino_boss", 0) != 1 ? false : true;
	}

	// Se ejecuta al inicio de la aplicación
	void Start () {
		// Obtenemos puntuación más alta
		Hi = PlayerPrefs.GetInt ("hi", 0); // Si no hay una previa, se regresa 0
		// Iniciamos con marcador en 0
		Points = 0;
		// Ocultamos texto "Game Over"
		GameOverText.position = new Vector3 (0, 2.198273f, -200);
		// Actualizamos estado de juego
		isGameOver = false;
		// Almacenamos primera instancia de tiempo
		ActualTime = Time.time;

		// Creamos objetos a partir del Transform Dino
		Animtr = Dino.GetComponent<Animator> ();
		Dinoco = Dino.GetComponent<DinoController> ();

		// Almacenamos velocidad inicial del Dino seteada en su controlador desde el editor
		cacheDinoSpeed = Dinoco.Speed;

		// Descomentar para reiniciar marcadores y logros
		// ResetPrefs ();
	}

	private float UATime = 0;
	private float TTSSound = 0;

	// Metodo cuando el usuario pierde
	public void GameOver () {
		TTSSound = Time.unscaledTime;
		// Detenemos los sonidos
		
		/*
		 * Se supone que esto arregla el bug donde los sonidos se quedan atorados pero no sirve de nada, hay que revisar
		 * */
		sound.Jump.Stop();
		sound.Up.Stop();

		// Si nuestra puntuación es más alta a "la más alta"
		if (Points > Hi) {
			// Actualizamos puntuación más alta
			Hi = Points;
			PlayerPrefs.SetInt ("hi", Points);
		}

		// Reseteamos la velocidad del Dino
		Dinoco.Speed = cacheDinoSpeed;

		// Mostramos texto "Game Over"
		GameOverText.position = new Vector3 (0, 2.198273f, 0);
		// Informamos que se ha perdido
		isGameOver = true;

		// Pausamos el tiempo hasta reiniciar

		/*
		 * Cabe destacar que todo está relacionado con el tiempo (animaciones, gravedad, marcador, sonidos, etc.
		 * */
		Time.timeScale = 0;
	}

	// Puntero para aumentar dificultad
	public float cachePowerUp = 100;

	// Se ejecuta cada fotograma: El tiempo es relativo
	void Update () {
		// Obtenemos duración de la partida actual
		/*
		 * partida actual (ATime) = Tiempo de ejecución - Tiempo de a la hora del inicio de la partida
		 * */
		ATime = Time.time - ActualTime;

		// Si no se ha perdido y si los puntos son menores a 25k
		if (!isGameOver && Points < 25000) {
			// Si no está en pausa
			if (!ppause.Pause) {
				// Si el marcador es más grande al puntero
				if (Points > cachePowerUp) {
					// Aumentamos la velocidad del tiempo 0.005 segundos más
					Time.timeScale += 0.005f;
					// No repetir hasta que se sumen 100 puntos más
					cachePowerUp += 100;
				}

				/*
				 * Los puntos se calculan
				 * Puntos = la velocidad del dino entre dos por el tiempo de la partida
				 * */

				Points = (int)(ATime * (Dinoco.Speed / 2));

				/*
				 * Aquí está el error, a la hora de hacer pausa, el tiempo no se detiene sino no se podría
				 * volver a a reanudar el juego. Por lo tanto, el marcador sigue aumentando dando la posibilidad
				 * de obtener los 25k puntos y los 5 logros
				 */
			}
		}

		// Si ha perdido y...
		if (isGameOver) {
			// Si da Tap en el boton con nombre "ReloadButton"
			if (Utils.DaTouch() == "ReloadButton") {
				// Reinicia el juego
				isGameOver = false;
				cacheGO = false;
				// Reestablece la puntuación
				Points = 0;
			}

			// Han pasado 0.3 segundos
			if ((TTSSound + 0.3f) < Time.unscaledTime) {
				// Detenemos el sonido
				sound.Wrong.Stop();
				Debug.Log("Deten sonido infernal!!");
			}
		}

		// Si se ha reiniciado el juego
		if (!isGameOver && !cacheGO) {
			cacheGO = true;
			// Ocultamos el texto "Game Over"
			GameOverText.position = new Vector3 (0, 2.198273f, -200);
			isGameOver = false;
			// Decimos revivimos al dino
			Animtr.SetBool("isDead", false);
			// Actualizamos el tiempo actual
			ActualTime = Time.time;
			// Reestablecemos la escala de tiempo
			Time.timeScale = 1;
		}

		// Logros
	}

	// Reiniciamos preferencias
	void ResetPrefs () {
		PlayerPrefs.SetInt("hi", 0);
	}
}
