using UnityEngine;
using System.Collections;

public class SpawnCactus : MonoBehaviour {

	
	public Transform[] CactusPrefabs;
	public Vector2 Time2Spawn;
	
	public Score score;
	public DinoController Dino;
	public Transform Point2Destroy;
	
	private float LastTime = 0;

	void Update () {
		float ActualTime = Time.time;
		
		if (ActualTime > LastTime) {
			float RandTime = Random.Range (Time2Spawn.y, Time2Spawn.y);
			LastTime += RandTime;
			CreateCactus();
		}
	}

	void CreateCactus () {
		int RandCactus = (int) Random.Range(0,6);
		Transform Cactus = CactusPrefabs[RandCactus];
		
		Transform tClactus = Instantiate(Cactus, transform.position, transform.rotation) as Transform;
		CactusController tcCactus = tClactus.GetComponent<CactusController>();
		
		tcCactus.Dino = Dino;
		tcCactus.Point2Destroy = Point2Destroy;
		tcCactus.score = score;
	}
}
