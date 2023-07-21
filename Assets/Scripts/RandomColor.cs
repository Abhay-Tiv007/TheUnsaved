using UnityEngine;
using System.Collections;

public class RandomColor : MonoBehaviour {

	public Camera mc;
	public Vector3 color;
	private Vector3 rcol;
	private Vector3 sign;
	// Use this for initialization
	void Start () {
		sign=new Vector3(1,1,1);
	}
	
	// Update is called once per frame
	void Update () {
		rcol.x+=color.x*Time.deltaTime*sign.x;
		rcol.y+=color.y*Time.deltaTime*sign.y;
		rcol.z+=color.z*Time.deltaTime*sign.z;
		if(rcol.x>1.0f){
			//rcol.x=0.0f;
			sign.x=-sign.x;
		}else if(rcol.x<0.0f){
			//rcol.x=0.0f;
			sign.x=-sign.x;
		}

		if(rcol.y>1.0f){
			//rcol.y=0.0f;
			sign.y=-sign.y;
		}else if(rcol.y<0.0f){
			//rcol.y=0.0f;
			sign.y=-sign.y;
		}

		if(rcol.z>1.0f){
			//rcol.z=0.0f;
			sign.z=-sign.z;
		}else if(rcol.z<0.0f){
			//rcol.z=0.0f;
			sign.z=-sign.z;
		}		
		mc.backgroundColor=new Color(rcol.x,rcol.y,rcol.z);
		//mc.backgroundColor.g=rcol.y;
		//mc.backgroundColor.b=rcol.z;
	}
}
