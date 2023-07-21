#pragma strict

var extent:Vector2;
var speed:Vector2;
var direction:Vector2;
private var upLimit:Vector2;
private var lowLimit:Vector2;
private var move:Vector3;

function Start () {
	upLimit.x=transform.position.x+extent.x;//extent at +x-axis
	upLimit.y=transform.position.y+extent.y;//extent at +y-axis
	lowLimit.x=transform.position.x-extent.x;//extent at -x-axis
	lowLimit.y=transform.position.y-extent.y;//extent at -y-axis
}

function Update () {
	if(transform.position.x>upLimit.x)//Upper limit has reached
		direction.x=-1;
	else if(transform.position.x<lowLimit.x)//Lower limit has reached
		direction.x=1;
	if(transform.position.y>upLimit.y)//Upper limit has reached
		direction.y=-1;
	else if(transform.position.y<lowLimit.y)//Lower limit has reached
		direction.y=1;
	move=Vector3(speed.x*direction.x,speed.y*direction.y,0)*Time.deltaTime;//Move vector
	transform.Translate(move);//translates our game object using move vector
}