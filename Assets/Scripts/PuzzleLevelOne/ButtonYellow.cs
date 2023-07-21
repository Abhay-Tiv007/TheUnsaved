using UnityEngine;
using System.Collections;

public class ButtonYellow : MonoBehaviour {
	

	public GameObject[] on;
	public GameObject[] off;
	
	
	private bool isMoving;
	private AudioSource ass;
	// Use this for initialization
	void Start () {
		ass=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerStay2D(Collider2D coll){
		if(!isMoving&&coll.CompareTag("Player")&&(Input.GetButtonDown("Jump")||Input.GetButtonDown("Submit")||Input.GetButtonDown("Interact"))){
			isMoving=true;
			ButtonOff();
		}
	}
	
	void ButtonOff(){
		ass.Play();
		int i;
		for(i=0;i<on.Length;i++){
			on[i].SetActive(true);
		}
		for(i=0;i<off.Length;i++){
			off[i].SetActive(false);
		}
	}

}
