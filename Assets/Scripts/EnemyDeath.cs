using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

	public GameObject[] slo;
	public bool[] slob;
	public GameObject childObj;

	private bool isAlive;
	private EnemyHealth healthy;
	// Use this for initialization
	void Start () {
		healthy = GetComponent<EnemyHealth>();
		isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isAlive&&healthy.health<=0)
			DieMan();
	}

	void DieMan(){
		for(int i=0;i<slo.Length;i++)
			slo[i].SetActive(slob[i]);
		Instantiate(childObj ,transform.position,childObj.transform.rotation);
		Destroy(gameObject,0.2f);
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.CompareTag("UnderGround")){
			DieMan();
		}
	}
}
