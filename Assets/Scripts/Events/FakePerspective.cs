using UnityEngine;
using System.Collections;

public class FakePerspective : MonoBehaviour {

	public Vector2 speed;
	public Transform boundLeft;
	public Transform boundRight;
	public Transform boundUp;
	public Transform boundDown;
	private Vector3 initPos;
	private Vector2 totalDis;
	private Vector2 disFrac;
	private Vector2 midPoint;
	private Transform Player;
	private Vector3 finalPos;
	// Use this for initialization
	void Start () {
		initPos=transform.localPosition;
		totalDis.x=(boundRight.position.x-boundLeft.position.x)/2;
		midPoint.x=(boundLeft.position.x+boundRight.position.x)/2;
		totalDis.y=(boundUp.position.y-boundDown.position.y)/2;
		midPoint.y=(boundUp.position.y+boundDown.position.y)/2;
		Player=GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.position.x<boundLeft.position.x||Player.position.x>boundRight.position.x||Player.position.y<boundDown.position.y||Player.position.y>boundUp.position.y)
			return;
			disFrac.x=(Player.position.x-midPoint.x)/totalDis.x;
			disFrac.y=(Player.position.y-midPoint.y)/totalDis.y;
			finalPos=new Vector3(initPos.x+(disFrac.x*-speed.x),initPos.y+(disFrac.y*speed.y),initPos.z);
			transform.localPosition=finalPos;
	}
}
