#pragma strict

var p:Player;
var threshold:int;
var level:String;
var levelName:String;
var fadeIn:GameObject;
var lev:float;

function Start () {

}

function Update () {
	
}

function OnTriggerEnter2D(coll:Collider2D){
	if(coll.CompareTag("Player")){
		//print("LevelCompleted"+p.GetScore()+"/"+threshold);
		if(p.score>=threshold){
			fadeIn.SetActive(true);
			coll.gameObject.SendMessage("Freeze",SendMessageOptions.RequireReceiver);
			PlayerPrefs.SetString("NextLoad",levelName);
			if(PlayerPrefs.GetFloat("Volume")<=lev)
				PlayerPrefs.SetFloat("Volume",lev);
			PlayerPrefs.Save();
			Destroy(GetComponent.<BoxCollider2D>());
			yield WaitForSeconds(2.0f);
			Application.LoadLevel(level);
		}
	}
}