using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goBack : MonoBehaviour {

	public GameObject gameUI;

	public void backToGame(){

		gameUI.SetActive (true);
		FindObjectOfType<Credits> ().back ();
	}

}
