using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	
	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	
	void Start(){
		audioSource = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log ("Playing clip: " + thisLevelMusic);
		
		if(thisLevelMusic){ // If there's some music attached
			if(audioSource.clip != thisLevelMusic){  // so it doesn't restart the music if it's the same song (start & options)
				audioSource.clip = thisLevelMusic;
				audioSource.loop = true;
				audioSource.Play();
			}

		}
	}

	public void SetVolume(float volume){
		audioSource.volume = volume;
	}
	
	
}
