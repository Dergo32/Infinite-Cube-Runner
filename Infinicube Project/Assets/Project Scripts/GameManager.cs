using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;


	public float restartDelay = 1f;	//time to wait before restarting game

	public GameObject gameOverUI;

	void FixedUpdate(){
	
		if (Input.GetKey("j")) {	//j to restart

			SceneManager.LoadScene (SceneManager.GetActiveScene().name);	//restarts game by reloading active scene
		}
	
	}

	public void GameOver(){

		if (gameHasEnded == false) {	//game only ends once
		
			gameHasEnded = true;
			Debug.Log("Game Over");
			Invoke ("Restart", restartDelay);	//restarts game after time delay
		}

	}

	public void Restart(){

		gameOverUI.SetActive (true);	//displays instructions for player (function may be used by other scripts)

	}

	public void hide(){
	
		gameOverUI.SetActive (false);	//used by other scripts
	
	}

}