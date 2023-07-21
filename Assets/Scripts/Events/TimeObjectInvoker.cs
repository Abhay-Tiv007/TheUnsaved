using UnityEngine;
using System.Collections;

public class TimeObjectInvoker : MonoBehaviour {
	public float delay;
	public GameObject target;
	private float thresholdTime;
	// Use this for initialization
	void Start () {
		thresholdTime=Time.timeSinceLevelLoad+delay;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeSinceLevelLoad>thresholdTime&&!target.activeInHierarchy){
			target.SetActive(true);
		}
	}
}
