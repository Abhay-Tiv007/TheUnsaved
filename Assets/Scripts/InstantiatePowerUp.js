#pragma strict
import UnityEngine.UI;

var bar:Image;
var timeCollect:GameObject;

private var currentTime:float;
private var started:boolean;
private var totalLength:float;

function Start () {
	currentTime=0.0f;
	bar.gameObject.SetActive(false);
}

function Update () {
	if(bar==null)
		return;
	if(currentTime<=totalLength&&started){
		currentTime+=Time.deltaTime;
		//bar.localScale.x=((totalLength-currentTime)/totalLength);
		bar.fillAmount=((totalLength-currentTime)/totalLength);
	}else{
		currentTime=0.0f;
		//bar.localScale.x=0;
		started=false;
	}
}

function StartPowerUp(time:float){
	started=true;
	bar.gameObject.SetActive(true);
	Destroy(bar.gameObject,time);
	Instantiate(timeCollect,timeCollect.transform.position,timeCollect.transform.rotation);
	totalLength=time;
}