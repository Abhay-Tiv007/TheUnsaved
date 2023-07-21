#pragma strict

var player:Transform;
var height:double=0.0;

function Start () {

}

function Update () {
gameObject.transform.position.x=player.position.x;
gameObject.transform.position.y=player.position.y+height;

}