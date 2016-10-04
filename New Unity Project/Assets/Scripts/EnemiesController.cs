using UnityEngine;
using System.Collections;

public class EnemiesController : MonoBehaviour {

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
		if ((int)time % 5 == 0 && lastCreationTime > 3) {
			//lastCreationTime = 0;
			//GameObject enemy = enemiesPooler.getObject ();
			//enemy.SetActive (true);
		}
	}
}
