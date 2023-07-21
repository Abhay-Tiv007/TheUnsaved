using UnityEngine;
using System.Collections;

public class TimeObjectsInvoker : MonoBehaviour {
	public float[] delay;
	public GameObject[] target;
	private float[] thresholdTime;
	private int c;
	// Use this for initialization
	void Start () {
		c=0;
		thresholdTime=new float[delay.Length];
		for(int i=0;i<delay.Length;i++)
			thresholdTime[i]=Time.timeSinceLevelLoad+delay[i];
	}
	
	// Update is called once per frame
	void Update () {
		if(c>=delay.Length)
			return;
		if(Time.timeSinceLevelLoad>thresholdTime[c]&&!target[c].activeInHierarchy){
			target[c].SetActive(true);
			c++;
		}
	}
}
