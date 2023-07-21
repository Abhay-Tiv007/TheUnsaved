#pragma strict

function OnTriggerEnter2D(coll:Collider2D){
	if(coll.CompareTag("Player")){
		coll.gameObject.SendMessage("TimeSlow",SendMessageOptions.RequireReceiver);
		Destroy(gameObject);
	}

}

function Update () {

}