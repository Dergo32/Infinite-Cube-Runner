using UnityEngine;

public class Credits : MonoBehaviour {

	public GameObject creditsUI;

	public void credits(){
	
		creditsUI.SetActive (true);
		FindObjectOfType<GameManager> ().hide ();
	}

	public void back(){		//used by other scripts
	
		creditsUI.SetActive (false);
		FindObjectOfType<GameManager> ().Restart ();
	}
}
