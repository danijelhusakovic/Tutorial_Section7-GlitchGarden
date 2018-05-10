using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

	public enum Status 	{ SUCCESS, FAILURE};

	private Text starText;
	private int NumberOfStars;

	void Start(){
		starText = GetComponent<Text>();
		NumberOfStars = 100;
		UpdateDisplay ();
	}

	public void AddStars(int amount){
		NumberOfStars += amount;
		UpdateDisplay ();
	}

	public Status UseStars(int amount){
		if (NumberOfStars >= amount) {
			NumberOfStars -= amount;

			if (NumberOfStars < 0) {
				NumberOfStars = 0;
			}

			UpdateDisplay ();
			return Status.SUCCESS;
		}

		return Status.FAILURE;

	}

	private void UpdateDisplay(){
		starText.text = NumberOfStars.ToString ();
	}

}
