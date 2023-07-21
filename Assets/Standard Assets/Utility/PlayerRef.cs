using UnityEngine;
using System.Collections;

public class PlayerRef : MonoBehaviour {
	private int coins;
	private int healthCount;
	// Use this for initialization
	void Start () {
		FetchDetails();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateStore(){
		if(GameObject.Find("Store")!=null){
			if(GameObject.Find("Store").activeInHierarchy)
				GameObject.Find("Store").SendMessage("UpdateStoreUI",SendMessageOptions.RequireReceiver);
		}
	}

	public void FetchDetails(){
		gameObject.SendMessage("GiveDetails",SendMessageOptions.RequireReceiver);
	}

	void SetCoins(int amount){
		coins=amount;
	}

	public int GetCoins(){
		return coins;
	}

	void SetHealth(int amount){
		healthCount=amount;
	}
	
	public int GetHealth(){
		return healthCount;
	}
	






}
