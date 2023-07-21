using UnityEngine;
using System.Collections;

public class PortalTeleport : MonoBehaviour {

	public Transform teleportTarget;
	public GameObject button;
	public GameObject[] enableIt;
	public GameObject[] disableIt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D coll){
		if(coll.CompareTag("Player")&&(Input.GetButtonDown("Interact"))){
			GameObject.FindGameObjectWithTag("Player").transform.position= teleportTarget.position;
			int i;
			for(i=0;i<enableIt.Length;i++){
				enableIt[i].SetActive(true);
			}
			for(i=0;i<disableIt.Length;i++){
				disableIt[i].SetActive(false);
			}
			button.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.CompareTag("Player")){
			button.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D coll){
		if(coll.CompareTag("Player")){
			button.SetActive(false);
		}
	}

}
