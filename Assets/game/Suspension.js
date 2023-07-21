#pragma strict
var original:float;
var suspensionDistance:float;
var colRadius:float;

function Start () {
	original=transform.position.y;
}

function Update () {
	var distance:float;
	var hit: RaycastHit2D = Physics2D.Raycast(transform.position, -Vector2.up,suspensionDistance);
	if (hit.collider != null) {
		distance = hit.point.y - transform.position.y;
		print(distance);
	}else {
		distance=0.0f;
	}
	transform.position.y+=(distance+colRadius);
}