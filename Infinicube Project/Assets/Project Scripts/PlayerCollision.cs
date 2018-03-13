using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement movement;
	public Rigidbody rb;
	public bool freezeRotation;
	public Transform player;

	void OnCollisionEnter(Collision collisionInfo){	//called whenever object collides with another object

		if (collisionInfo.collider.tag == "Obstacle") {	//check for object
			rb.freezeRotation = false;
			movement.enabled = false;
			FindObjectOfType<GameManager> ().GameOver ();	//game ends if player hits object
		}	
	}

}
