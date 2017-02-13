using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class RoundedCorners : MonoBehaviour {
	
	[ContextMenuItem("ReDraw", "ResizeCorners")]
	[Header("Settings")]
	public int Radius = 8;

	[Header("Corners")]
	public RectTransform TopLeftCorner;
	public RectTransform TopRightCorner;
	public RectTransform BottomLeftCorner;
	public RectTransform BottomRightCorner;

	private int cacheRadius = 8;

	// Use this for initialization
	void Awake () {
		ResizeCorners ();
	}

	void Start () {
		ResizeCorners ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cacheRadius != Radius) {
			ResizeCorners ();
			cacheRadius = Radius;
		}
	}

	void ResizeCorners () {
		Vector2 newSize = new Vector2 (Radius, Radius);
		TopLeftCorner.sizeDelta = newSize;
		TopRightCorner.sizeDelta = newSize;
		BottomLeftCorner.sizeDelta = newSize;
		BottomRightCorner.sizeDelta = newSize;
	}
}
