using UnityEngine;

public class followPlayer : MonoBehaviour {

	public Transform player;	//references player object
	public Vector3 offset;	//sets camera further back from object

	// Update is called once per frame
	void Update () {
		transform.position = player.position + offset;	//camera tracks object from a position further back
	}
}
