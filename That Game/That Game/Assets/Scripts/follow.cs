﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 4.9f);
	}

	// Update is called once per frame
	void Update () {

	}
}