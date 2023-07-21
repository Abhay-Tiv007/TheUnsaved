#pragma strict

var on:GameObject;
var off:GameObject;
var tagg:String;
var state:boolean;

function Start () {

}

function Update () {

}

function OnTriggerEnter2D(coll:Collider2D){
	if(coll.CompareTag(tagg)){
		on.SetActive(state);
		off.SetActive(!state);
		Destroy(gameObject);
	}
}