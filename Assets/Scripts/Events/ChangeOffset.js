#pragma strict

var displacementX:float;
var displacementY:float;
var randomDisplacement:boolean;

function Start () {

}

function Update () {
	if(randomDisplacement){
		GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", Vector2(GetComponent.<Renderer>().material.GetTextureOffset("_MainTex").x+Random.value/10,GetComponent.<Renderer>().material.GetTextureOffset("_MainTex").y+Random.value/10));
	}else{
		GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", Vector2(GetComponent.<Renderer>().material.GetTextureOffset("_MainTex").x+displacementX,GetComponent.<Renderer>().material.GetTextureOffset("_MainTex").y+displacementY));
	}
}