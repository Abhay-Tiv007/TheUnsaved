#pragma strict

var extent:Vector2;
var moveSpeed:Vector2;
private var upLimit:Vector2;
private var lowLimit:Vector2;
var direction:Vector2;
 
function Start () {

upLimit.x=transform.position.x+extent.x;
upLimit.y=transform.position.y+extent.y;
lowLimit.x=transform.position.x-extent.x;
lowLimit.y=transform.position.y-extent.y;
}

function Update () {
if(transform.position.y>=upLimit.y)
	direction.y=-1.0;
else if(transform.position.y<lowLimit.y)
	direction.y=1.0;
if(transform.position.x>=upLimit.x)
	direction.x=-1.0;
else if(transform.position.x<lowLimit.x)
	direction.x=1.0;
transform.Translate(Vector3(moveSpeed.x*direction.x, moveSpeed.y*direction.y,0.0f)* Time.deltaTime);
}