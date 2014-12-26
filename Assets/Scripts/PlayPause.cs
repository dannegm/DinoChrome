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

	// Se ejecuta cada fotograma, es por eso que tantos cache por el código
	void Update () {
		float ActualTime = Time.time;

		// Si no está pausado
		if (!cacheTap && !Pause) {
			transform.renderer.material = IconPause;
			cacheTap = true;
		// Si está pausado
		} else if (cacheTap && Pause) {
			transform.renderer.material = IconPlay;
			cacheTap = false;
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
