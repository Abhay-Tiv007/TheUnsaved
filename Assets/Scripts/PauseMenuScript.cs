using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	public AudioMixer myMixer;
	public Slider mySlider;
	// Use this for initialization
	void Start () {
		SetVolume();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetVolume(){
		myMixer.SetFloat("VolumeMain",mySlider.value);
	}

	public void LoadLevel(string lev){
		Time.timeScale=1;
		Application.LoadLevel(lev);
	}
}
