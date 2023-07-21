using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingLevel : MonoBehaviour {
		
	public string levelName;
	public RectTransform loadImage;
	public float maxWidth;

	private AsyncOperation async;
	private Rect temp;
	//private float p;


	void Start(){
		levelName=PlayerPrefs.GetString("NextLoad");
		StartCoroutine( LoadLevelA());
	}

	void Awake(){
		temp=loadImage.rect;
		Application.targetFrameRate = 30;
	}



	IEnumerator LoadLevelA() {
		yield return null;
		async = Application.LoadLevelAsync(levelName);
		async.allowSceneActivation=false;
		while(!async.isDone) {
			float p=Mathf.Clamp01(async.progress/0.9f);
			print("loading progress: " + p);
			temp.width=maxWidth*p;
			loadImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal ,temp.width);
			if(async.progress>=0.9f)
				async.allowSceneActivation=true;
			yield return null;
		}
		//yield return async;
		Debug.Log("Loading complete");
	}

	void Update(){
		//print (async.progress);
		/*temp.width=maxWidth*p;
		//loadImage.rect=temp;
		loadImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal ,temp.width);
		if(async.progress>0.9f)
			async.allowSceneActivation=true;*/
	}
}
