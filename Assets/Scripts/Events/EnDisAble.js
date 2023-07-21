#pragma strict

var target:GameObject;
var tagg:String;
var state:boolean;

function Start () {

}

function Update () {

}

function OnTriggerEnter2D(coll:Collider2D){
	if(coll.CompareTag(tagg)){
		target.SetActive(state);
		Destroy(gameObject);
	}
}