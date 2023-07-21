#pragma strict

var pos:int[];
private var current:int=0;

function Start () {
	current=0;
}

function Update () {
	
}

function Change() {
	current++;
	if(current>=pos.Length)
		current=0;
	GetComponent.<Camera>().orthographicSize=pos[current];
}