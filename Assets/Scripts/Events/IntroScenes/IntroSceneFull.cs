using UnityEngine;
using System.Collections;

public class IntroSceneFull : MonoBehaviour {

	public float Delay=4.0f;
	public GameObject toPopUp;
	public GameObject[] toEnableOne;
	public GameObject[] toDisableOne;
	public GameObject[] toEnableSecond;
	public GameObject[] toDisableSecond;
	public GameObject[] toDisableThird;
	public GameObject skip;
	private float timeSince;
	private int c=0;
	// Use this for initialization
	void Start () {
		timeSince=Delay;
	}
	
	// Update is called once per frame
	void Update () {
		int i;
		if(!skip.activeSelf&&timeSince<Time.timeSinceLevelLoad)
			skip.SetActive(true);
		else if(skip.activeSelf&&timeSince>Time.timeSinceLevelLoad)
			skip.SetActive(false);
		if(timeSince<Time.timeSinceLevelLoad&&(Input.GetButtonUp("Submit")||Input.GetButtonUp("Interact"))){
			if(c==0){
				for(i=0;i<toDisableOne.Length;i++){
					toDisableOne[i].SetActive(false);
				}
				for(i=0;i<toEnableOne.Length;i++){
					toEnableOne[i].SetActive(true);
				}
				timeSince=Time.timeSinceLevelLoad+Delay;
				c++;
			}else if(c==1){
				for(i=0;i<toDisableSecond.Length;i++){
					toDisableSecond[i].SetActive(false);
				}
				for(i=0;i<toEnableSecond.Length;i++){
					toEnableSecond[i].SetActive(true);
				}
				timeSince=Time.timeSinceLevelLoad+Delay;
				c++;
			}else if(c==2){
				for(i=0;i<toDisableThird.Length;i++){
					toDisableThird[i].SetActive(false);
				}
					toPopUp.SetActive(true);
					c++;
					StartCoroutine(delayLevelLoad());
			}
		}
	}
	
	IEnumerator delayLevelLoad(){
		yield return new WaitForSeconds(2.0f);
		PlayerPrefs.SetString("NextLoad","levelBG");

		PlayerPrefs.Save();
		Application.LoadLevel("LoadingScreen");
	}
}
