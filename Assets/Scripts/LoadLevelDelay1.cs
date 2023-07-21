using UnityEngine;
using System.Collections;

public class LoadLevelDelay1 : MonoBehaviour {

	public float del;
	public string lev;

	private float dur;
	// Use this for initialization
	void Start () {
		dur=Time.timeSinceLevelLoad+del;
	}
	
	// Update is called once per frame
	void Update () {
		if(dur<Time.timeSinceLevelLoad)
			Application.LoadLevel(lev);
	}
}
