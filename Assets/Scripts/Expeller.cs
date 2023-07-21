using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Expeller : MonoBehaviour {

	public GameObject pref;
	public Transform shot;
	public float force;
	public float delay;
	public bool enem;
	public Transform exp;

	private float curr;
	// Use this for initialization
	void Start () {
		curr=Time.timeSinceLevelLoad+10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player=GameObject.FindGameObjectWithTag("Player");
		if(player.GetComponent<Platformer2DUserControl>().fridged)
			return;
		RaycastHit2D hit=Physics2D.Linecast(exp.position, player.transform.position);
		if(enem){
			exp.transform.LookAt(player.transform);
		}
		if (!hit.collider.CompareTag("Player")&&enem)
			return;
		if(curr<Time.timeSinceLevelLoad){
			GameObject tosh=Instantiate(pref,shot.transform.position,Quaternion.identity) as GameObject;
			tosh.GetComponent<Rigidbody2D>().AddForce(shot.forward*force,ForceMode2D.Impulse);
			tosh.transform.parent=null;
			curr=Time.timeSinceLevelLoad+delay;
		}
	}
}
