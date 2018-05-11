using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelDuration = 100f;

	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;

	void Start(){
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		FindYouWinLabel ();
		winLabel.SetActive (false);
	}

	void FindYouWinLabel ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Please create 'You Win' object");
		}
	}

	void Update (){
		slider.value = Time.timeSinceLevelLoad / levelDuration;

		bool timeIsUp = (Time.timeSinceLevelLoad >= levelDuration);
		if(timeIsUp && !isEndOfLevel){
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects ();
		isEndOfLevel = true;
		winLabel.SetActive (true);
		audioSource.Play ();
		Invoke ("LoadNextLevel", audioSource.clip.length);
	}

	void DestroyAllTaggedObjects(){
		GameObject[] taggedObjectsArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach(GameObject taggedObject in taggedObjectsArray){
			Destroy (taggedObject.gameObject);
		}
	}

	void LoadNextLevel(){
		levelManager.LoadNextLevel ();
	}
}
