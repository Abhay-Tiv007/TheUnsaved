using UnityEngine;
using System.Collections;

public class MagicAbilityPlayer : MonoBehaviour {


	public string tag;
	public string message;
	public GameObject onDestroy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag(tag)){
			col.gameObject.SendMessage(message,SendMessageOptions.RequireReceiver);
			if(onDestroy!=null)
				onDestroy.SetActive(true);
			Destroy(gameObject);
		}
	}
}
