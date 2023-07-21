using UnityEngine;
using System.Collections;

public class PlayAnimationsOn : MonoBehaviour {


	public Animation anim;
	public AnimationClip[] a;
	
	private float f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAnim (int c) {
		anim.clip=a[c];
		anim.Play();
	}


}
