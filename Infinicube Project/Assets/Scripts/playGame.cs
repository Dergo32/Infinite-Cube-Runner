﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class playGame : MonoBehaviour {

	public void StartGame(){
	
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	
	}

}
