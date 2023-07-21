#pragma strict

var target:movementAI;
var tagg:String;
var state:Vector2;

function Start () {

}

function Update () {

}

function OnTriggerEnter2D(coll:Collider2D){
	if(coll.CompareTag(tagg)){
		target.speed=state;
		Destroy(gameObject);
	}
}