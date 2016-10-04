using UnityEngine;
using System.Collections.Generic;

public class BoardController : MonoBehaviour {

	public GameObject board;
	public KeyCode backKeyCode = KeyCode.UpArrow;
	public KeyCode forwardKeyCode = KeyCode.DownArrow;
	public KeyCode leftKeyCode = KeyCode.LeftArrow;
	public KeyCode rightKeyCode = KeyCode.RightArrow;
	public float speed = 1f;
    public Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        rigidBody.AddTorque(transform.up * speed * horizontal);
	}
}
