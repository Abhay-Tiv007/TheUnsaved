using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets._2D;


public class CameraEffectsScript : MonoBehaviour {
	
	public Animation anim;
	public AnimationClip[] a;

	private float f;
	// Use this for initialization

	void Start(){
		f=0.0f;
	}

	public void PlayAnim (int c) {
		anim.clip=a[c];
		GameObject.Find("Main Camera").GetComponent<MotionBlur>().blurAmount=0.0f;
		anim.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<Platformer2DUserControl>().fridged==true)
			return;
		if(GameObject.Find("Main Camera")==null)
			return;
		if(GameObject.Find("Main Camera").GetComponent<MotionBlur>().blurAmount>0.0f){
			//print ("hi there");
		
		f+=Time.deltaTime;
		if(f>4.0f)
			GameObject.Find("Main Camera").GetComponent<MotionBlur>().blurAmount=0.0f;
			f=0.0f;
		}
	}
}                                                                                                                                                                                                                                                                                                                                                                                                                                                        