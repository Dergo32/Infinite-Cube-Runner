using System.Collections;
using System.Collections.Generic;	//required to use lists
using UnityEngine;

public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs;	//array containing game objects used
	private Transform playerTransform;
	private int numTilesOnScreen = 10;	//number of tiles on screen at any time
	private float spawnZ = -75.775820f;		//where to spawn objects on z-axis
	private float tileLength = 75.775820f;	//length of object (use scale values as size, NOT position)

	private List<GameObject> activeTiles;	//list of tiles on screen
	private float safeZone = 152f;	//tiles in safe zone do not get deleted

	private int lastPrefabIndex = 0;

	// Use this for initialization
	private void Start () {

		activeTiles = new List<GameObject> ();	//initalizes list
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < numTilesOnScreen; i++) {
		
			if (i < 2) {
				SpawnTile (0);	//if i is less than 2, spawn prefab with no obstacles
			} else {
				SpawnTile ();	//otherwise, spawn random prefabs that may or may not have obstacles
			}
		
		}	

	}
	
	// Update is called once per frame
	private void Update () {

		if (playerTransform.position.z - safeZone > (spawnZ - numTilesOnScreen * tileLength)) {	//tracks player position along z-axis and spawns tiles as player moves along
		
			SpawnTile ();	//function to spawn tile
			DeleteTile();	//function to delete tiles behind player
		
		}	

	}

	private void SpawnTile(int prefabIndex = -1){			//spawns objects
	
		GameObject go;

		if (prefabIndex == -1) {	//grabs references to objects in tile list
			go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
		}else{
			go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
		}
			
		go.transform.SetParent (transform);					//set object as child of tilemanager
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);	//adds tiles to list for deletion
	}

	private void DeleteTile(){		//deletes tiles
	
		Destroy (activeTiles [0]);	//deletes tiles in list
		activeTiles.RemoveAt (0);	//removes deleted tiles from list
	
	}

	private int RandomPrefabIndex (){	//chooses random prefab by choosing random number
	
		if (tilePrefabs.Length <= 1) {	//safety check
			return 0;
		}
	
		int randomIndex = lastPrefabIndex;

		while (randomIndex == lastPrefabIndex) {

			randomIndex = Random.Range (0, tilePrefabs.Length);	//Get number of random prefab from tile list

		}

		lastPrefabIndex = randomIndex;
		return randomIndex;

	}
}
