using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {
	public static bool isTouch () {
		if (Input.touchCount > 0 || Input.GetMouseButton(0)) {
			return true;
		} else {
			return false;
		}
	}

	public static Transform DaTouch () {
		RaycastHit hit = new RaycastHit ();
		if (isTouch()) {
			Vector3 pos = Input.mousePosition;
			Touch touch;
			if (Input.touchCount > 0) {
				touch = Input.touches [0];
				pos = new Vector3 (touch.position.x, touch.position.y, 0);
			}
			Ray touchRay = Camera.main.ScreenPointToRay (pos);
			Physics.Raycast (touchRay, out hit);
		}
		return hit.transform;
	}
	
	public static float Proporcional (float lado1, float lado2, float NuevoLado1) {
		float v1 = (lado2 / lado1) * NuevoLado1;
		v1 = Mathf.Round(v1 * 1f) / 1f;
		return v1;
	}
	public static float isOfPercent (float entero, float porcentaje) {
		return (entero / 100) * porcentaje;
	}
	public static float isPrecentOf (float entero, float extraido) {
		return (extraido / entero) * 100;
	}
	public static float is100pOf (float entero, float porcentaje) {
		return (entero * 100) / porcentaje;
	}
}
