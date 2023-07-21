#pragma strict

private var ren:Color;
private var col:float;
private var sin:float;

function Start () {
	col=1.0;
	sin=-1;
	ren=gameObject.GetComponent.<SpriteRenderer>().color;
}

function Update () {
	if(col>=1.0)
		sin=-1;
	else if(col<=0.7)
		sin=1;
	col+=(sin*Time.deltaTime/2);
	ren.r=ren.g=ren.b=col;
	gameObject.GetComponent.<SpriteRenderer>().color=ren;
}