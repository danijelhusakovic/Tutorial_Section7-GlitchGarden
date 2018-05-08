using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;

	void Start(){
		buttonArray = GameObject.FindObjectsOfType<Button>();
	}

	void OnMouseDown(){

		foreach(Button thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}

		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
		print (selectedDefender);
	}

}
