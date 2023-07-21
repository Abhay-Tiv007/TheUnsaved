using UnityEngine;
using System.Collections;

public class LoadLevelDelay : MonoBehaviour {

	public float delay;
	public string lev;
	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {
		if(delay<Time.timeSinceLevelLoad)
			Application.LoadLevel(lev);
	}
}
