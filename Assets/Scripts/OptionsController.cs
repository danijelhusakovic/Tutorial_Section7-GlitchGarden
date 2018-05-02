using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {
	
	public Slider volumeSlider;
	public  LevelManager levelManager;
	
	private MusicManager musicManager;
	
	void Start() {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		Debug.Log(musicManager);
	}
}
