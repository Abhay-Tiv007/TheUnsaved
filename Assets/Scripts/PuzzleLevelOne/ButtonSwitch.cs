using UnityEngine;
using System.Collections;

public class ButtonSwitch : MonoBehaviour {


	public bool isleft;
	public AnimationClip left;
	public AnimationClip right;
	public GameObject on;
	public GameObject off;
	public Animation anim;
	public float onPitch;
	public float offPitch;

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
			StartCoroutine(DelayTime());
			if(isleft){
				anim.clip=left;
				anim.Play();
				isleft=!isleft;
			}else{
				anim.clip=right;
				anim.Play();
				isleft=!isleft;
			}
		}
	}

	void ButtonOff(){
		on.SetActive(false);
		off.SetActive(true);
		ass.pitch=offPitch;
		ass.Play();
	}

	void ButtonOn(){
		on.SetActive(true);
		off.SetActive(false);
		ass.pitch=onPitch;
		ass.Play();
	}

	IEnumerator DelayTime(){
		yield return new WaitForSeconds(11.0f);
		isMoving=false;
		ButtonOn();
	}
}
