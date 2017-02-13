using UnityEngine;
using System.Collections;

public class PlayPause : MonoBehaviour {

	// EStado del juego
	public bool Pause = false;
	// Iconos del estado del juego
	public Material IconPlay;
	public Material IconPause;

	// Cache para evitar más de un tap
	private float TimeToTap = 0.5f;
	private float LastTap;
	private bool cacheTap = false;

	// Creamos cache de la escala de tiempo
	private float TimeScale = 1;

	// Se ejecuta cada fotograma, es por eso que tantos cache por el código
	void Update () {
		float ActualTime = Time.unscaledTime;

		// Si no está pausado
		if (!cacheTap && !Pause) {
			transform.GetComponent<Renderer>().material = IconPause;
			cacheTap = true;
			// Reanudamos el tiempo
			Time.timeScale = TimeScale;
		// Si está pausado
		} else if (cacheTap && Pause) {
			transform.GetComponent<Renderer>().material = IconPlay;
			cacheTap = false;
			// Almacenamos la escala de tiempo actual
			TimeScale = Time.timeScale;
			// Reducimos el tiempo a 0
			Time.timeScale = 0;
		}

		// Si se hace click en el boton contenedor
		if (Utils.DaTouch () == transform.name) {
			if (LastTap < ActualTime) {
				LastTap = ActualTime + TimeToTap;
				// Invertimos estado del juego
				Pause = !Pause;
			}
		}
	}
}
