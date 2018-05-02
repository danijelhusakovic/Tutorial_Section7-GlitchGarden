using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;
	
	void Start(){
		if(autoLoadNextLevelAfter == 0){
			Debug.Log("Level auto load disabled");
		} else {
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	void Update (){
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			LoadNextLevel();
		}
	}

	public void LoadLevel(string name){
		Debug.Log("LoadLevel method entered for " + name);
		Application.LoadLevel(name);
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void QuitRequest(){
		Debug.Log("Quit requested!");
		Application.Quit();
	}
}
