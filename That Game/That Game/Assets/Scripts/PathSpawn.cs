using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour {

	//Calls the prefab 'Path'
	public GameObject Path;

	//Creates new paths in front of the player's position once it triggers the spawn collider
	void OnTriggerEnter(Collider Player){
		Vector3 pos = new Vector3(1, 0, 9);
		var playerZ = GameObject.Find ("Player").transform.position.z;
		Vector3 finalPos = pos + new Vector3 (0, 0, playerZ);
		Instantiate (Path, finalPos, Quaternion.identity);
	}
}
