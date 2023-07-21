#pragma strict

import UnityStandardAssets._2D;

var follow:Camera2DFollow;
var focus:Transform;
var delay:float;
var damp:float;
var noDamp:float;
var target:Transform;
var toEnable:GameObject[];
var toDisable:GameObject[];
private var player:Transform;

function Start () {
	//player=GameObject.FindGameObjectWithTag("Player").transform;
}

function Update () {
	if(Input.GetButtonDown("Interact"))
		TutorialDisable();
}

function OnTriggerEnter2D(coll:Collider2D){
	if(coll.CompareTag("Player")){
		player=coll.transform;
		TutorialEnable();
		//yield WaitForSeconds(delay);
		//TutorialDisable();
	}
}

function TutorialEnable(){
	Input.ResetInputAxes();
	player.gameObject.SendMessage("Freeze",SendMessageOptions.RequireReceiver);
	follow.damping=damp;
	follow.target=focus;
	//Destroy(gameObject,delay);
}

function TutorialDisable(){
	if(player==null)
		return;
	var i:int;
	player.gameObject.SendMessage("UnFreeze",SendMessageOptions.RequireReceiver);
	follow.damping=noDamp;
	follow.target=player.FindChild("Target");
	for(i=0;i<toEnable.Length;i++){
		toEnable[i].SetActive(true);
	}
	for(i=0;i<toDisable.Length;i++){
		toDisable[i].SetActive(false);
	}
	Destroy(gameObject);
}


