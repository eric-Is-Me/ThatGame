using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Transform Path;
    public Transform Pillar;

	//Creates new objects in front of player model on trigger
	void OnTriggerEnter(Collider Player){
		Vector3 pos = new Vector3(1, 0, 9);
		var playerZ = GameObject.Find ("Player").transform.position.z;
		Vector3 finalPos = pos + new Vector3 (0, 0, playerZ);
		Instantiate (Path, finalPos, Quaternion.identity);

        Vector3 randPos = new Vector3(Random.Range(-3.0f, 1.0f), 1, Random.Range(playerZ, playerZ + 9.0f));
        Instantiate(Pillar, randPos, Quaternion.identity);
    }
}
