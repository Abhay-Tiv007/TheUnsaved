using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Enemy : MonoBehaviour {

	public float MaxSpeed;
	public float MaxDis;

	[Space(15)]
	public Transform bulletEjector;
	public GameObject bullet;
	public Vector2 ejectionForce;

	[Space(15)]
	public float restDelay=2.0f;
	public int bullets;
	public AudioSource ads;
	public AudioClip[] ac;


	[Space(15)]
	public int health=100;
	public GameObject healthBar;
	public GameObject[] onDeath;

	private Animator Anim;  
	private Rigidbody2D rb2D;

	private bool isShooting;
	private bool isAwake;

	private int bulletCount;
	private bool bulletsEmpty;
	private bool isAlive;
	private int curHealth;

	private GameObject player;
	// Use this for initialization
	private void Awake(){
		isAlive=true;
		Anim = GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
		player=GameObject.FindGameObjectWithTag("Player");
		isShooting=false;
		bulletCount=bullets;
		bulletsEmpty=false;
	}

	void Start () {
		curHealth=health;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(!isAlive)
			return;
		if(!isAwake)
			return;
		if(player.GetComponent<Platformer2DUserControl>().fridged==true)
			return;
		if(health<=0){
			isAlive=false;
			return;
		}
		//Enemy Rotation
		if((player.transform.position.x-transform.position.x)<0){
			Vector3 ea=transform.localEulerAngles;
			ea.y=180;
			transform.localEulerAngles=ea;
		}else{
			Vector3 ea=transform.localEulerAngles;
			ea.y=0;
			transform.localEulerAngles=ea;
		}
		//print (Mathf .Abs (player.transform.position.x-transform.position.x));



		//Enemy Shooting
		if(bulletsEmpty)
			return;
		if(bulletCount>0){
			if((Mathf .Abs (player.transform.position.x-transform.position.x))<MaxDis&&!isShooting){
				isShooting=true;
				Anim.SetBool("Shoot", isShooting);
				bulletCount--;
			}
		}else{
			if(isShooting==false){
				bulletsEmpty=true;
				StartCoroutine(DelayT());
			}
		}
		/*Anim.SetFloat("RunSpeed", 2.0f*(Mathf.Sign (Input.GetAxis("Horizontal"))));
		rb2D.velocity = new Vector2(Input.GetAxis("Horizontal")*MaxSpeed, rb2D.velocity.y);
		if(Input.GetAxis("Horizontal")!=0.0)
			Anim.SetBool("Run", true);
		else if(Mathf.Abs(Input.GetAxis("Horizontal"))==0.0)
			Anim.SetBool("Run", false);
		if(Input.GetButtonDown("Fire1")){
			Anim.SetBool("Shoot", true);
		}else if(Input.GetButtonUp("Fire1")){
			Anim.SetBool("Shoot", false);
		}*/
	}

	void OnTriggerEnter2D(Collider2D col){
		if(!isAlive)
			return;
		if(col.CompareTag("Player")){
			isAwake=true;
			healthBar.SetActive(true);
			Destroy(transform.FindChild("RangeColliders").gameObject);
		}
	}
	 
	/*void OnTriggerExit(Collider2D col){
		if(col.CompareTag("Player"))
			isAwake=false;
	}*/

	public void EjectBullet(){
		if(!isAlive)
			return;
		ads.clip=ac[0];
		ads.Play();
		GameObject nb=(GameObject)GameObject.Instantiate(bullet,bulletEjector.position,bulletEjector.rotation);
		nb.GetComponent<Rigidbody2D>().AddForce(nb.transform.right*ejectionForce.magnitude,ForceMode2D.Impulse);
	}

	public void StopShooting(){
		if(!isAlive)
			return;
		isShooting=false;
		Anim.SetBool("Shoot", isShooting);
		//print ("aye here");
	}

	public void ApplyDamage(int count){
		if(curHealth<=0){
			curHealth=0;
			Die();
			return;
		}
		if(count>=curHealth){
			curHealth=0;
			Die();
		}else{
			curHealth-=count;
		}
		healthBar.transform.Find("Green").localScale=new Vector3(curHealth/(health*1.0f),healthBar.transform.Find("Green").localScale.y,healthBar.transform.Find("Green").localScale.z);
	}

	void Die(){
		Destroy(healthBar);
		Anim.SetBool("Died",true);
		if(transform.FindChild("BodyCollider")!=null)
		Destroy(transform.FindChild("BodyCollider").gameObject);
		//Spawn On Death
		for(int i=0;i<onDeath.Length;i++){
			onDeath[i].SetActive(true);
			//Instantiate(onDeath[i],onDeath[i].transform.position,onDeath[i].transform.rotation);
		}
		Destroy(gameObject,2.0f);
	}

	public IEnumerator DelayT(){
		if(bulletsEmpty){
			StopShooting();
			yield return new WaitForSeconds(restDelay);
			bulletCount=bullets;
			bulletsEmpty=false;
		}
	}
}
