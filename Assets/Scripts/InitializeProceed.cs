﻿using UnityEngine;
using System.Collections;

public class InitializeProceed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("Proceed",1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
