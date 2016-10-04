using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = 1f;

	private string playerTag = "Player";
	private string boardTag = "Board";
	private GameObject player;
	private GameObject board;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		board = GameObject.FindGameObjectWithTag (boardTag);
		player = GameObject.FindGameObjectWithTag (playerTag);
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        rigidBody.velocity = direction * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.Equals (board)) {
			Vector3 direction = player.transform.position - transform.position;
			//rigidBody.velocity = direction * speed;
		}
	}
}
