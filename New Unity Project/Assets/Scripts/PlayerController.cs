using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 25f;

    public GameController gameController;

    private Rigidbody rigidBody;
    private LineRenderer lr;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        lr = GameObject.FindGameObjectWithTag("Line").GetComponent<LineRenderer>();
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
        lr.SetPosition(0, new Vector3(0, transform.position.y, 0));
        lr.SetPosition(1, transform.position);

        if (transform.position.y < -10)
        {
            gameController.PlayerDied();
            Respawn();
            return;
        }
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

    public void Respawn()
    {
        transform.position = new Vector3(0, 2, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Enemy"))
        {
            collision.collider.attachedRigidbody.gameObject.SetActive(false);
            Respawn();
            gameController.PlayerDied();
        }
    }
}
