using UnityEngine;
using System.Collections.Generic;

public class BoardController : MonoBehaviour {

	public GameObject board;
	public KeyCode backKeyCode = KeyCode.UpArrow;
	public KeyCode forwardKeyCode = KeyCode.DownArrow;
	public KeyCode leftKeyCode = KeyCode.LeftArrow;
	public KeyCode rightKeyCode = KeyCode.RightArrow;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		List<Vector3> directions = new List<Vector3>();
		if (Input.GetKey (backKeyCode)) {
			directions.Add(Vector3.right);
		}
		if (Input.GetKey (forwardKeyCode)) {
			directions.Add(Vector3.left);
		}
		if (Input.GetKey (leftKeyCode)) {
			directions.Add(Vector3.forward);
		}
		if (Input.GetKey (rightKeyCode)) {
			directions.Add(Vector3.back);
		}
		foreach (Vector3 direction in directions) {
			transform.Rotate(direction, speed * Time.deltaTime);
		}
//		Vector3 aux = board.transform.position;
//		board.transform.position = aux + direction;
	}
}
