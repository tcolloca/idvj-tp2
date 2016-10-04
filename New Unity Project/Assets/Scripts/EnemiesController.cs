using UnityEngine;
using System.Collections;

public class EnemiesController : MonoBehaviour {

	public float spawnFrequency = 20;
	public GameObjectsPooler enemiesPooler; 

	private float time = 0f;
	private float lastCreationTime = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		lastCreationTime += Time.deltaTime;
		if ((int)time % spawnFrequency == 0 && lastCreationTime > spawnFrequency) {
			lastCreationTime = 0;
			GameObject enemy = enemiesPooler.getObject ();
			if (enemy == null) return;
			enemy.SetActive (true);
		}
	}
}
