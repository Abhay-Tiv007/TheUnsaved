#pragma strict

var upLimit:double=0.0;
var downLimit:double=0.0;
var moveSpeed:double=0.0;
var direction:double=1.0;
function Start () {

}

function Update () {
if(gameObject.transform.position.y>=upLimit)
	direction=-1.0;
else if(gameObject.transform.position.y<downLimit)
	direction=1.0;
transform.Translate(Vector3(0, moveSpeed*direction,0)* Time.deltaTime);

}