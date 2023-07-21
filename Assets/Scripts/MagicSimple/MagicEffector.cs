using UnityEngine;
using System.Collections;

public class MagicEffector : MonoBehaviour {

	public int minPower;
	public int maxPower;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		//print (coll.gameObject.name);
		if(coll==null)
			return;
		coll.BroadcastMessage("ApplyDamage",(int)Random.Range(minPower,maxPower),SendMessageOptions.DontRequireReceiver);
	}
}
