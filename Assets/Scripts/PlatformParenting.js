#pragma strict

var xAxis:boolean;//platform is moving in x-axis
var yAxis:boolean;//platform is moving in y-axis
var offset:Vector2;//offset vector


function OnTriggerEnter2D(coll:Collider2D){	//this function is called when any game object with collider enters into a triggered collider
	if(coll.CompareTag("Player")){	//checks whether the player had entered the triggered collider of the platform
		offset.x=coll.transform.position.x-transform.position.x;//we will check the offset position of the player with respect to platform
		coll.transform.parent=transform;//parenting the player with platform
	}
}

function OnTriggerStay2D(coll:Collider2D){ //this function is called when any game object with collider remains in a triggered collider
	if(coll.CompareTag("Player")){
		if(Input.GetButtonUp("Horizontal"))//if a player tries to move on a platform the offset will change
			offset.x=coll.transform.position.x-transform.position.x;
		if(Input.GetButton("Jump"))//if player jumps we wil unparent it from platform
			coll.transform.parent=null;
		if(yAxis){
			coll.transform.position.y=transform.position.y+offset.y;
		}else if(xAxis&&!Input.GetButton("Horizontal")){
			coll.transform.position.x=transform.position.x+offset.x;
			coll.transform.position.y=transform.position.y+offset.y;
		}
		
	}
}

function OnTriggerExit2D(coll:Collider2D){//this function is called when any game object with collider exits out of triggered collider
	if(coll.CompareTag("Player")){	
	print("Hi");
		coll.transform.parent=null;
	}
}