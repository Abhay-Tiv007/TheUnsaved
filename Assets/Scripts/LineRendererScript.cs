using UnityEngine;
using System.Collections;

public class LineRendererScript : MonoBehaviour {

	public Transform[] positions;
	private LineRenderer lr;
	// Use this for initialization
	void Start () {
		lr=GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<positions.Length;i++)
			lr.SetPosition(i,positions[i].position);
	}
}
