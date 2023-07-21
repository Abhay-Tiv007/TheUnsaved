using UnityEngine;
using System.Collections;

public class FirstStore : MonoBehaviour {

	public PlayerRef p;
	public GameObject dispTut;
	private bool b;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(p.GetCoins()>50)
			return;
		p.FetchDetails();
		if(p.GetCoins()==50&&!b){
			b=true;
			dispTut.SetActive(true);
			Destroy (gameObject,5.0f);
		}
	}


}
