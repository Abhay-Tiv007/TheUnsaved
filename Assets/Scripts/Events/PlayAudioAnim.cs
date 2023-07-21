using UnityEngine;
using System.Collections;

public class PlayAudioAnim : MonoBehaviour {

	private AudioSource asrc;
	// Use this for initialization
	void Start () {
		asrc=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void PlayAudio(){
		asrc.Play();
	}
	
	void StopAudio(){
		asrc.Stop();
	}
}
