using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;
	public bool freezeRotation;
	public Transform player;	//references player object
	public float forwardForce = 2000f;	//always add f after float and int variables
	public float sidewaysForce = 500f;

	// Use this for initialization
	void Start () {
		rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {	//two methods: update and fixedupdate

		rb.AddForce (0, 0, forwardForce * Time.deltaTime); //Add constant force to move cube forward

		if (Input.GetKey ("d")) {	//force to the right
		
			rb.AddForce (sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey ("a")) {	//force to the left
			rb.AddForce (-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (rb.position.y < -2f) {	//Game ends if player falls off edge
		
			FindObjectOfType<GameManager> ().GameOver ();
		}
	}
}