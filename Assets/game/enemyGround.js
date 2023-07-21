#pragma strict

var upLimit:double=0.0;
var downLimit:double=0.0;
var moveSpeed:double=0.0;
var direction:double=1.0;
function Start () {

}

function Update () {
if(gameObject.transform.position.x>=upLimit)
	direction=-1.0;
else if(gameObject.transform.position.x<downLimit)
	direction=1.0;
transform.Translate(Vector3( moveSpeed*direction,0,0)* Time.deltaTime);

}