﻿using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) {
			Application.LoadLevel("_Scene_0");
		}
	}
}
