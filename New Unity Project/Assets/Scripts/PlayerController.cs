using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float gravity = 7f;
    public float speed = 25f;

    private Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxis("Vertical");
        Vector3 toCenter = -rigidBody.position.normalized;
        toCenter.z = 0;

        rigidBody.AddForce(toCenter * speed * vertical);
        rigidBody.AddForce(new Vector3(0, 0, -gravity));
    }
}
