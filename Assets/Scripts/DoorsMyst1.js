#pragma strict
var lev:String;function OnTriggerEnter2D(coll:Collider2D){if(coll.CompareTag("Player")){Application.LoadLevel(lev);}}
