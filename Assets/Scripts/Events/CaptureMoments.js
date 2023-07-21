#pragma strict

private var dt : System.DateTime;


var ratio:int;
function Start () {

}

function Update () {
	if(Input.GetKeyDown("h"))
		ButtonPressed();
}

function ButtonPressed(){
	dt=System.DateTime.Now;
	var co:String=""+dt.Day+dt.Month+dt.Year+dt.Hour+dt.Minute+dt.Second;
	Application.CaptureScreenshot("E://FeedBackScreenshot/Screen"+co+".png",ratio);
}
