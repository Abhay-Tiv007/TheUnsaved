using UnityEngine;
using System.Collections;

public class RandomAnim : MonoBehaviour {

	public float time;
	public int animCount;
	public AnimationClip[] ac;
	private float ranTime;
	private int ranAnim;
	private Animation anim;
	// Use this for initialization
	void Start () {
		anim=gameObject.GetComponent<Animation>();
		anim.Stop ();
		ranTime=Random.Range(0,time);
		ranAnim=Mathf.RoundToInt(Random.Range(0,animCount));
		StartCoroutine(delay());
		anim.clip=ac[ranAnim];

	}
	
	// Update is called once per frame
	IEnumerator delay(){
		yield return new WaitForSeconds (ranTime);
		anim.Play();
	}
}
