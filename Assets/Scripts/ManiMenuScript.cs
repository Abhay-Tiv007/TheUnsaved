using UnityEngine;
using System.Collections;

public class ManiMenuScript : MonoBehaviour {


	public GameObject cont;
	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		if(PlayerPrefs.HasKey("Proceed")&&cont!=null)
			cont.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartLevel(){
		Time.timeScale=1;
		Application.LoadLevel(Application.loadedLevelName);
	}

	public void SetLoadLevel(string lev){
		PlayerPrefs.SetString("NextLoad",lev);
		PlayerPrefs.Save();
	}

	public void LoadLevel(string lev){
		Time.timeScale=1;
		StartCoroutine(DelayT());
		Application.LoadLevel(lev);
	}


	public void Leave(float delay){
		StartCoroutine(DelayT());
	}

	public IEnumerator DelayT(){
		yield return new WaitForSeconds(1.0f);
		Application.Quit();
	}
}
