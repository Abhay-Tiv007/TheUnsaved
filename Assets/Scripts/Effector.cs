using UnityEngine;
using System.Collections;

public class Effector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll){
		coll.gameObject.SendMessage("DieBy",SendMessageOptions.DontRequireReceiver);
	}

	void Start(){
		Destroy(gameObject,0.35f);
	}
}
