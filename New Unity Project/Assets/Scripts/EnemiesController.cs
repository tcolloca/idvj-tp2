using UnityEngine;
using System.Collections;

public class EnemiesController : MonoBehaviour {

	public float spawnFrequency = 20;
	public GameObjectsPooler enemiesPooler; 

	private float time = 0f;
	private float lastCreationTime = 0;
    private string boardTag = "Board";
    private float boardWidth;

    // Use this for initialization
    void Start () {
        GameObject board = GameObject.FindGameObjectWithTag(boardTag);
        Bounds boardBounds = board.GetComponent<MeshFilter>().mesh.bounds;
        boardWidth = board.transform.localScale.x * boardBounds.size.x * 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		lastCreationTime += Time.deltaTime;
		if ((int)time % spawnFrequency == 0 && lastCreationTime > spawnFrequency) {
			lastCreationTime = 0;
			GameObject enemy = enemiesPooler.getObject ();
			if (enemy == null) return;
            float yPos = 1.5f;
            float xPos = Random.Range(-boardWidth, boardWidth);
            float zPos = Random.Range(-boardWidth, boardWidth);

            enemy.transform.position = new Vector3(xPos, yPos, zPos);
            enemy.SetActive (true);
		}
	}
}
