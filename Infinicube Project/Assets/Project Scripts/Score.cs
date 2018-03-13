using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Transform player;	//get player position
	public Text scoreText;		//reference score text

	// Update is called once per frame
	void Update () {
		scoreText.text = player.position.z.ToString("0");	//sets score to distance along z axis with no decimal points
	}
}
