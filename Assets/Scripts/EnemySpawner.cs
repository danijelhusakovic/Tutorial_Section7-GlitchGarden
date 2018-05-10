using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in attackerPrefabArray){
			if(isTimeToSpawn(thisAttacker)){
				Spawn (thisAttacker);
			}
		}
	}

	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();

		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by framerate.");
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5; // division by five because there are 5 lanes. so it's seen every
		//n seconds, and not: seen every n seconds per lane. if for lizard it's 5 seconds. there will be one lizard every
		//5 seconds in the ENTIRE playspace!

		return (Random.value < threshold);
	}

	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}

}
