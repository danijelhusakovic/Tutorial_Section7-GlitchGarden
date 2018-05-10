using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
		
	public Camera myCamera;

	private GameObject defenderParent;
	private StarDisplay starDisplay;

	void Start(){
		defenderParent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		if(!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
	}

	void OnMouseDown() {
		Vector2 rawPosition = CalculateWorldPointOfMouseClick ();
		Vector2 snappedPosition = SnapToGrid (rawPosition);
		GameObject defender = Button.selectedDefender;


		int defenderCost = defender.GetComponent<Defender> ().starCost;
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (snappedPosition, defender);
		} else {
			Debug.Log ("Insufficient stars");
		}
	}

	void SpawnDefender(Vector2 snappedPosition, GameObject defender){
		Quaternion zeroRotation = Quaternion.identity;
		GameObject newDefender = Instantiate (defender, snappedPosition, zeroRotation) as GameObject;
		newDefender.transform.parent = defenderParent.transform;

	}


	Vector2 SnapToGrid (Vector2 decimalWorldPosition){
		float rawX, rawY;
		int newX, newY;

		rawX = decimalWorldPosition.x;
		rawY = decimalWorldPosition.y;

		newX = Mathf.RoundToInt (rawX);
		newY = Mathf.RoundToInt (rawY);
		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}
}
