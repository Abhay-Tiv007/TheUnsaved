using UnityEngine;
using System.Collections;

public class ObstaclesScript : MonoBehaviour {


	public int health=100;
	private int curHealth;
	public GameObject[] onDeath;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
	}

	void Die(){
		//Spawn On Death
		for(int i=0;i<onDeath.Length;i++){
			onDeath[i].SetActive(true);
			//Instantiate(onDeath[i],onDeath[i].transform.position,onDeath[i].transform.rotation);
		}
		Destroy(gameObject,2.0f);
	}
}
