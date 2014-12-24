using UnityEngine;
using System.Collections;

public class SpawnClouds : MonoBehaviour {

	public Transform CloudPrefab;
	public float HeightRange;
	public float Time2Spawn;
	
	public Score score;
	public DinoController Dino;
	public Transform Point2Destroy;

	private float LastTime = 0;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float ActualTime = Time.time;

		if (ActualTime > LastTime) {
			float RandTime = Random.Range (0, Time2Spawn);
			LastTime += RandTime;

			float RandHeight = Random.Range (-HeightRange, HeightRange);
			Transform tCloud = Instantiate(CloudPrefab, new Vector3(transform.position.x, transform.position.y + RandHeight, transform.position.z), transform.rotation) as Transform;
			CloudController tcCloud = tCloud.GetComponent<CloudController>();

			tcCloud.Dino = Dino;
			tcCloud.Point2Destroy = Point2Destroy;
			tcCloud.score = score;
		}
	}
}
