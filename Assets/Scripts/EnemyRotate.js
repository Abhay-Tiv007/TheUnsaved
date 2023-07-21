#pragma strict

var velocity:Vector3;

function Start () {

}

function Update () {
	transform.Rotate(velocity*Time.deltaTime);
}