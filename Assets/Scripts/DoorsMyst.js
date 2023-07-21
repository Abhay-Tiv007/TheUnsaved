#pragma strict
import UnityStandardAssets.CrossPlatformInput;

var lev:String;
var obj:GameObject;
var level:float;
var fadeIn:GameObject;
private var canGO:boolean;

function Start () {
	if(!PlayerPrefs.HasKey("Volume"))
		PlayerPrefs.SetFloat("Volume",1.0f);
	if(PlayerPrefs.HasKey("Volume")){
		if(PlayerPrefs.GetFloat("Volume")>=level)
			canGO=true;
		else
			canGO=false;
	}else
		canGO=false;
}

function Update () {

}

function OnTriggerEnter2D(coll:Collider2D){
	if(coll.CompareTag("Player")){
		obj.SetActive(true);
	}
}

function OnTriggerExit2D(coll:Collider2D){
	if(coll.CompareTag("Player")){
		obj.SetActive(false);
	}
}

function OnTriggerStay2D(coll:Collider2D){
	if(coll.CompareTag("Player")){
		if(CrossPlatformInputManager.GetButtonDown("Interact")&&canGO){
			coll.gameObject.SendMessage("Freeze",SendMessageOptions.RequireReceiver);
			var obje:GameObject =Instantiate(fadeIn,Camera.main.transform.position,Quaternion.identity);
			obje.transform.parent=Camera.main.transform;
			obje.transform.localPosition=Vector3.zero+Vector3(0,0,10);
			obj.SetActive(false);
			yield WaitForSeconds(2.0f);
			PlayerPrefs.SetString("NextLoad",lev);
			PlayerPrefs.Save();
			Application.LoadLevel("LoadingScreen");
		}
	}
}