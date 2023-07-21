using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Vector2 limit;
	public float speed;
	public float distance;
	public float distanceThres;

	private Transform player;
	private float dis;
	private Vector2 limits;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player").transform;
		limits.x=transform.position.x-limit.x;
		limits.y=transform.position.x+limit.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x<limits.x||transform.position.x>limits.y)
			return;
		dis=Mathf.Abs(player.position.x-transform.position.x);
		if(dis<distance||dis>distanceThres)
			return;
		transform.Translate(Vector3.right * Time.deltaTime * speed * Mathf.Sign (player.position.x-transform.position.x));
	}
}
