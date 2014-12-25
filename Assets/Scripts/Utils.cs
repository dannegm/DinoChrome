using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {
	public static string DaTouch () {
		if (Input.touchCount > 0 || Input.GetMouseButton (0)) {
			Vector3 pos = Input.mousePosition;
			Touch touch;
			
			if (Input.touchCount > 0) {
				touch = Input.touches [0];
				pos = new Vector3 (touch.position.x, touch.position.y, 0);
			}
			
			Ray touchRay = Camera.main.ScreenPointToRay (pos);
			
			RaycastHit hit = new RaycastHit ();
			if (Physics.Raycast (touchRay, out hit)) {
				Debug.Log ("Touch in " + hit.transform.name);
				return hit.transform.name;
			} else {
				return "none";
			}
		} else {
			return "none";
		}
	}
}
