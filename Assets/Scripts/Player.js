#pragma strict
import UnityEngine.UI;
import UnityStandardAssets.ImageEffects;
import UnityEngine.Audio;


var disableActivities:boolean;
var cc:ColorCorrectionCurves;
var mb:MotionBlur;
var score:int;
var limit:int;
var text:Text;
var sctext:Text;
var starAnim:Animation;
var scoreAnim:Animation;
var scoredParticle:GameObject;
var healthScoredParticle:GameObject;
var health:GameObject;
var healthParent:Transform;
var origin:float;
var lifes:int;
var slowTimeDuration:float;
var levelName:String;
var delay:float;
var def:UnityEngine.RuntimeAnimatorController;
var deathAnim:UnityEngine.RuntimeAnimatorController;
var lifeDelay:float;
var overlay:ScreenOverlay;
var cchange:CameraView;
var myMixer:AudioMixer;

//Pause-Unpause
var canv:GameObject;
var control:GameObject;
var pausemenu:GameObject;
var store:GameObject;



var secScoredParticle:GameObject;


var magicEmitter:GameObject;
var magicsource:AudioSource;
var magicclips:AudioClip[];



//Checkpoint
var respawnBG:GameObject;
var DiedBG:GameObject;
public var currCheckpoint:int;
var Checkpoints:Transform[];
//var CheckpointPos:Transform;
var respawnPosition:Vector3;
private var respawned:boolean;

private var lifeContainer:GameObject[];
private var loseHealth:boolean;
private var paused:boolean;
private var storeOn:boolean;

//Magic
private var m_Anim:Animator;
private var doingMagic:boolean;
private var canMagic:boolean;

//GlowFade
private var ren:Color;
private var col:float;
private var sin:float;

//SecScore
private var secScore:int;


function Start () {
	secScore=0;
	Cursor.visible = false;
	Cursor.lockState = CursorLockMode.Locked;
	lifeContainer=new GameObject[lifes];
	Time.timeScale=0.9;
	//cc.saturation=1.0f;
	mb.blurAmount=0.0f;
	SetHealth();
	currCheckpoint=0;
	respawned=false;
	canMagic=false;
	m_Anim = GetComponent.<Animator>();
	respawnPosition=transform.position;
	//pausemenu.SetActive(false);
	DisableStore();
	UnPause();
	
	col=1.0;
	sin=-1;
	ren=gameObject.GetComponent.<SpriteRenderer>().color;
	DisableMagic();
}

function SetHealth(){
	var i:int;
	if(lifeContainer==null)
		return;
	for(i=0;i<(lifeContainer.Length);i++){
		Destroy(lifeContainer[i]);
	}
	lifeContainer=new GameObject[lifes];
	for(i=0;i<lifes;i++){
		//var heart:GameObject=Instantiate(health,new Vector3(origin+(i*30),health.transform.position.y,0),Quaternion.identity);
		lifeContainer[i]=Instantiate(health,new Vector3(origin+(i*14),health.transform.position.y,0),Quaternion.identity);
		lifeContainer[i].transform.SetParent(healthParent);
	}
}

function EnableCanMagic(){
	canMagic=true;
}

function DieBy(){
	PlayerDie();
}

function PlayerDie(){
	if(lifes<0||loseHealth)
		return;
	lifes--;
	loseHealth=true;
	mb.blurAmount=0.0f;
	if(lifes<=0){
		var obj:GameObject =Instantiate(DiedBG,Camera.main.transform.position,Quaternion.identity);
			obj.transform.parent=Camera.main.transform;
			obj.transform.localPosition=Vector3.zero+Vector3(0,0,10);
		DisableMagic();
		gameObject.SendMessage("PlayerDied",SendMessageOptions.RequireReceiver);
		GetComponent.<Animator>().runtimeAnimatorController=deathAnim;
		SetHealth();
		gameObject.SendMessage("PlayAnim",1,SendMessageOptions.RequireReceiver);
		yield WaitForSeconds(delay);
		Application.LoadLevel(levelName);
	}else{
		gameObject.SendMessage("PlayAnim",3,SendMessageOptions.RequireReceiver);
		SetHealth();
	}
	yield WaitForSeconds(lifeDelay);
	loseHealth=false;
}

function Respawn(){
	mb.blurAmount=0.0f;
	CrossPlatformInputManager.ResetInputAxes();
	//GetComponent.<Animator>().runtimeAnimatorController=def;
	if(lifes<0||loseHealth||respawned)
		return;
		respawned=true;
		//lifes--;
		PlayerDie();
		if(lifes!=0){
			SetHealth();
			var obj:GameObject =Instantiate(respawnBG,Camera.main.transform.position,Quaternion.identity);
			obj.transform.parent=Camera.main.transform;
			obj.transform.localPosition=Vector3.zero+Vector3(0,0,10);
			transform.position=respawnPosition;
			respawned=false;
		}
}

function GetScore(){
	return score;
}

function Update () {
	
	if(disableActivities)
		return;
	//print(Application.loadedLevel);
	if(Input.GetButtonDown("Cancel")&&!paused&&(!Application.loadedLevelName.Equals("levelBG")))
		Pause();
	else if(Input.GetButtonDown("Cancel")&&paused)
		UnPause();
	//if(Input.GetButtonDown("Store")&&!storeOn&&!paused&&(!Application.loadedLevelName.Equals("levelBG")))
		//EnableStore();
	//else if(Input.GetButtonDown("Store")&&storeOn)
		//DisableStore();
	//text.text="SCore : "+score+" / "+limit;
	
	if(gameObject.GetComponent.<Platformer2DUserControl>().fridged!=true){
		if((Input.GetButtonDown("Fire1")&&!doingMagic)&&canMagic){
			StartSimpleMagic();
		}
		if(Input.GetButtonUp("CamChange")){}
		//cchange.Change();
	}
	
	
	text.text=score+" / "+limit;
	sctext.text=""+secScore;
	if(loseHealth){
		if(col>=1.0)
			sin=-1;
		else if(col<=0.0)
			sin=1;
		col+=(sin*Time.deltaTime*2);
		ren.a=col;
		gameObject.GetComponent.<SpriteRenderer>().color=ren;
		overlay.intensity=col;
	}else{
		if(lifes!=1)
			overlay.intensity=0;
		if(lifes<=1)
			overlay.intensity=0.5;
		ren.a=1;
		gameObject.GetComponent.<SpriteRenderer>().color=ren;
	}
}

function OnTriggerEnter2D(coll:Collider2D){
	
	
	//Main Score
	if(coll.CompareTag("Score")){
		score=score+1;
		starAnim.Play();
		gameObject.SendMessage("PlayAnim",2,SendMessageOptions.RequireReceiver);
		Instantiate(scoredParticle,coll.gameObject.transform.position,Quaternion.identity);
		Destroy(coll.gameObject);
	}
	
	//Secondary Score
	if(coll.CompareTag("SecScore")){
		gameObject.SendMessage("UpdateStore",SendMessageOptions.RequireReceiver);
		secScore=secScore+1;
		if(secScore>=50){
			secScore=secScore-50;
			lifes+=1;
			SetHealth();
		}
		Destroy(coll.gameObject);
		scoreAnim.Play();
		gameObject.SendMessage("PlayAnim",0,SendMessageOptions.RequireReceiver);
		Instantiate(secScoredParticle,coll.gameObject.transform.position,secScoredParticle.transform.rotation);
		
	}
	if(coll.CompareTag("Health")){
		gameObject.SendMessage("UpdateStore",SendMessageOptions.RequireReceiver);
		lifes+=1;
		SetHealth();
		Instantiate(healthScoredParticle,coll.gameObject.transform.position,Quaternion.identity);
		Destroy(coll.gameObject);
	}
	if(coll.CompareTag("CheckPoint")){
		respawnPosition=coll.transform.position;//Checkpoints[currCheckpoint].position;
		//currCheckpoint++;
		Destroy(coll.gameObject);
	}
	
	if(gameObject.GetComponent.<Platformer2DUserControl>().fridged==true)
		return;
	if(coll.CompareTag("UnderGround")){
		if(coll.gameObject.GetComponent.<AudioSource>()!=null&&!coll.gameObject.GetComponent.<AudioSource>().isPlaying){
			coll.gameObject.GetComponent.<AudioSource>().Play();
			
		}
		gameObject.SendMessage("PlayAnim",1,SendMessageOptions.RequireReceiver);
		//lifes=1;
		//PlayerDie();
		Respawn();
	}
}

function IncrementHealth(){
	lifes+=1;
	SetHealth();
}

function WithdrawCoins(amount:int){
	if(amount>secScore)
		return;
	secScore=secScore-amount;
}

function OnTriggerStay2D(coll:Collider2D){
	if(coll.CompareTag("UnderGround")){
		if(coll.gameObject.GetComponent.<AudioSource>()!=null&&!coll.gameObject.GetComponent.<AudioSource>().isPlaying)
			//coll.gameObject.GetComponent.<AudioSource>().Play();
		//lifes=1;
		//PlayerDie();
		Respawn();
	}
}

function Pause(){
	//Time.timeScale=0;
	if(gameObject.GetComponent.<Platformer2DUserControl>().fridged==true||storeOn)
		return;
	gameObject.SendMessage("Freeze",SendMessageOptions.RequireReceiver);
	Cursor.visible = true;
	Cursor.lockState = CursorLockMode.None;
	canv.SetActive(false);
	control.SetActive(false);
	pausemenu.SetActive(true);
	//yield WaitForSeconds(1.0f);
	Time.timeScale=0.0f;
	paused=true;
}

function UnPause(){
	//GameObject.Find("PauseMenu").SendMessage("SetVolume",SendMessageOptions.RequireReceiver);
	Cursor.visible = false;
	Cursor.lockState = CursorLockMode.Locked;
	canv.SetActive(true);
	control.SetActive(true);
	pausemenu.SetActive(false);
	paused=false;
	Time.timeScale=0.9f;
	Input.ResetInputAxes();
	gameObject.SendMessage("UnFreeze",SendMessageOptions.RequireReceiver);
	//Time.timeScale=1;
}

function EnableStore(){
	//Time.timeScale=0;
	if(gameObject.GetComponent.<Platformer2DUserControl>().fridged==true)
		return;
	gameObject.SendMessage("Freeze",SendMessageOptions.RequireReceiver);
	Cursor.visible = true;
	Cursor.lockState = CursorLockMode.None;
	canv.SetActive(false);
	control.SetActive(false);
	pausemenu.SetActive(false);
	store.SetActive(true);
	gameObject.SendMessage("UpdateStore",SendMessageOptions.RequireReceiver);
	storeOn=true;
}

function DisableStore(){
	
	Cursor.visible = false;
	Cursor.lockState = CursorLockMode.Locked;
	canv.SetActive(true);
	control.SetActive(true);
	pausemenu.SetActive(false);
	store.SetActive(false);
	storeOn=false;
	Input.ResetInputAxes();
	gameObject.SendMessage("UnFreeze",SendMessageOptions.RequireReceiver);
	//Time.timeScale=1;
}


function TimeSlow(){
	var vol:float;var b:boolean=myMixer.GetFloat("VolumeMain",vol);
	Time.timeScale=0.4;
	myMixer.SetFloat("VolumeMain",-80.0f);
	//cc.saturation=0.1f;
	mb.blurAmount=0.50f;
	gameObject.SendMessage("StartPowerUp",slowTimeDuration,SendMessageOptions.RequireReceiver);
	yield WaitForSeconds(slowTimeDuration);
	Time.timeScale=0.9;
	myMixer.SetFloat("VolumeMain",vol);
	mb.blurAmount=0.0f;
	//cc.saturation=1.0f;
	
	
}

function StartSimpleMagic(){
	m_Anim.SetBool("isMagic",true);
	magicsource.clip=magicclips[0];
	magicsource.Play();
	doingMagic=true;
}

function StopSimpleMagic(){
	DisableMagic();
	m_Anim.SetBool("isMagic",false);
	magicsource.Stop();
	doingMagic=false;
}

function EnableMagic(){
	magicEmitter.SetActive(true);
	gameObject.SendMessage("PlayAnim",4,SendMessageOptions.RequireReceiver);
}

function DisableMagic(){
	magicEmitter.SetActive(false);
}

//Store Only//
function GiveDetails(){
	gameObject.SendMessage("SetCoins",secScore,SendMessageOptions.RequireReceiver);
	gameObject.SendMessage("SetHealth",lifes,SendMessageOptions.RequireReceiver);
}
















