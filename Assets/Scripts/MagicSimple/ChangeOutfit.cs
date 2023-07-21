using UnityEngine;
using System.Collections;




public class ChangeOutfit : MonoBehaviour {
	public RuntimeAnimatorController newAnimController;
	public string tagg;
	public GameObject target;
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.CompareTag(tagg)){
			target.GetComponent<Animator>().runtimeAnimatorController=newAnimController;
			Destroy(gameObject);
		}
	}

}
