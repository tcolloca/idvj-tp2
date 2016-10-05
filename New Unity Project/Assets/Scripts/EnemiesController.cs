﻿using UnityEngine;
using System.Collections;

public class EnemiesController : MonoBehaviour {

	public float spawnFrequency = 2;
	public GameObjectsPooler enemiesPooler; 

	private float time = 0f;
	private float lastCreationTime = 0;
    private string boardTag = "Board";
    private float boardWidth;
    private GameObject player;

    // Use this for initialization
    void Start () {
        GameObject board = GameObject.FindGameObjectWithTag(boardTag);
        Bounds boardBounds = board.GetComponent<MeshFilter>().mesh.bounds;
        boardWidth = board.transform.localScale.x * boardBounds.size.x * 0.5f;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		lastCreationTime += Time.deltaTime;
		if (lastCreationTime > spawnFrequency) {
			lastCreationTime = 0;
            if (spawnFrequency > 0.46f)
            {
                spawnFrequency = spawnFrequency - 0.2f;
            }
            if (EnemyController.speed < 17f)
            {
                EnemyController.speed = EnemyController.speed + 0.4f;
            }
            GameObject enemy = enemiesPooler.getObject ();
			if (enemy == null) return;
            Vector3 newPos = new Vector3(Random.Range(-boardWidth, boardWidth), 1.5f, Random.Range(-boardWidth, boardWidth));
            while ((newPos - player.transform.position).magnitude < 10f)
            {
                newPos = new Vector3(Random.Range(-boardWidth, boardWidth), 1.5f, Random.Range(-boardWidth, boardWidth));
            }

            enemy.transform.position = newPos;
            enemy.SetActive (true);

            Vector3 playerPosition = player.transform.position;
            enemy.GetComponent<EnemyController>().SetPlayerPosition(playerPosition);
        }
	}
}
