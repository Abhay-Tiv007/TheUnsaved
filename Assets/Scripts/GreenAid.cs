using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;


public class GreenAid : MonoBehaviour {
	public Transform explosionPrefab;
	public float force;
	public Platformer2DUserControl pu;
	public Vector3 rotat;

	void Start(){
		pu=GameObject.FindGameObjectWithTag("Player").GetComponent<Platformer2DUserControl>();
		//print(transform.forward);
		//print(force);
		//print(pu.getCurr());
		Rigidbody2D rb=GetComponent<Rigidbody2D>();
		Vector3 forc;
		if(transform.parent!=null)
			forc=transform.parent.right*force;
		else
			forc=transform.right*force;
		//rb.AddForce(forc,ForceMode2D.Impulse);
		Destroy(gameObject,5.0f);
	}

	void FixedUpdate(){
		//GetComponent<Rigidbody2D>().AddForce(transform.forward*force,ForceMode2D.Impulse);
		transform.Rotate(rotat*Time.deltaTime);
	}
	void OnCollisionEnter2D(Collision2D collision) {
		ContactPoint2D contact = collision.contacts[0];
		
		// Rotate the object so that the y-axis faces along the normal of the surface
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		Instantiate(explosionPrefab, pos, rot);
		transform.GetChild(0).gameObject.SetActive(true);
		transform.GetChild(0).parent=null;
		Destroy(gameObject);
	}
}
