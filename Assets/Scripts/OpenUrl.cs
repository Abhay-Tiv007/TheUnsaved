using UnityEngine;
using System.Collections;

public class OpenUrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UrlOpen(string URL){
		Application.OpenURL(URL);
	}
}
