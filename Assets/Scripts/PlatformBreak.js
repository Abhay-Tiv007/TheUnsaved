#pragma strict

var state:boolean;
var delay:float;
var ddelay:float;
var curr:GameObject;
var nex:GameObject;
var tagg:String;
var respawnObject:GameObject;
private var landed:boolean;

function Start () {

}

function Update () {

}

function OnTriggerEnter2D(coll:Collider2D){
	if(coll.CompareTag(tagg)){
		if(!landed){
			Break();
		}
	}
}

function Break(){
	landed=true;
	yield WaitForSeconds(delay);
	curr.SetActive(state);
	nex.SetActive(!state);
	Instantiate(respawnObject,transform.position,Quaternion.identity);
	yield WaitForSeconds(ddelay);
	Destroy(nex);
	//Destroy(transform.parent.gameObject,10.0f);
}