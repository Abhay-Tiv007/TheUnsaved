#pragma strict

var levelName:String;
var delay:float;
var deathAnim:UnityEngine. RuntimeAnimatorController;
private var gaddam:boolean;

function Start () {
	
}

function Update () {

}

function OnTriggerEnter2D(coll:Collider2D){
	if(gaddam)
		return;
	if(coll.CompareTag("Death")){
		if(coll.gameObject.GetComponent.<AudioSource>()!=null)
			coll.gameObject.GetComponent.<AudioSource>().Play();
		gaddam=true;
		Die();
		yield WaitForSeconds(0.50f);
		gaddam=false;
	}
}

function Die(){
	gameObject.SendMessage("PlayerDie",SendMessageOptions.RequireReceiver);
	//GetComponent.<Animator>().runtimeAnimatorController=deathAnim;
	//yield WaitForSeconds(delay);
	//Application.LoadLevel(levelName);
}