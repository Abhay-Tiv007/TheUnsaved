using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MainStore : MonoBehaviour {

	public Text secScoreText;
	public Text healthText;
	[Space(15)]
	public int[] optionsValue;
	public GameObject[] enabledOptions;
	public GameObject[] disabledOptions;

	private GameObject player;
	private PlayerRef main;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player");
		main=player.GetComponent<PlayerRef>();
		UpdateStoreUI();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void UpdateStoreUI(){
		if(main==null)
			return;
		main.FetchDetails();
		secScoreText.text=""+main.GetCoins();
		healthText.text=""+main.GetHealth();
		UpdateOptions();
	}

	void UpdateOptions(){
		//Health Check
		if(main.GetCoins()>=optionsValue[0]&&disabledOptions[0].activeInHierarchy){
			disabledOptions[0].SetActive(false);
			enabledOptions[0].SetActive(true);
		}else if(main.GetCoins()<optionsValue[0]&&!disabledOptions[0].activeInHierarchy){
			enabledOptions[0].SetActive(false);
			disabledOptions[0].SetActive(true);
		}
	}
	

	public void BuyHealth(){
		main.FetchDetails();
		if(main.GetCoins()>=50){
			player.SendMessage("WithdrawCoins",50,SendMessageOptions.RequireReceiver);
			player.SendMessage("IncrementHealth",SendMessageOptions.RequireReceiver);
			UpdateStoreUI();
		}
	}


}
