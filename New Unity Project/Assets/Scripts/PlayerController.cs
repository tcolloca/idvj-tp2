using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 25f;

    public GameController gameController;

    private Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
    void OnTriggerEnter(Collider collider)
    {
        Rigidbody attachedRigidbody = collider.attachedRigidbody;
        string tag = attachedRigidbody.gameObject.tag;
        if (tag.Equals("Coin"))
        {
            attachedRigidbody.gameObject.SetActive(false);
            gameController.CoinPicked();
        }
    }

	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxis("Vertical");
        Vector3 toCenter = -rigidBody.position;
        float yVel = rigidBody.velocity.y;
        toCenter.y = 0;
        toCenter = toCenter.normalized;

        rigidBody.velocity = toCenter * speed * vertical * Time.deltaTime + new Vector3(0, yVel, 0);

        float horizontal = Input.GetAxis("Horizontal");
        Vector3 tangent = Quaternion.Euler(0, 90, 0) * toCenter;
        rigidBody.velocity += tangent * speed * horizontal * Time.deltaTime;
    }
}
