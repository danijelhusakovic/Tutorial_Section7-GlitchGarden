using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;

	private GameObject projectileParent;
	private Animator animator;
	private EnemySpawner myLaneSpawner;

	void Start(){

		animator = GetComponent<Animator> ();

		projectileParent = GameObject.Find("Projectiles");

		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}

		SetMyLaneSpawner ();
	}

	void Update(){
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	// look through all spawners and set myLaneSpawner if found
	void SetMyLaneSpawner(){
		EnemySpawner[] EnemySpawnerArray = GameObject.FindObjectsOfType<EnemySpawner> ();
		foreach(EnemySpawner enemySpawner in EnemySpawnerArray){
			if(enemySpawner.transform.position.y == transform.position.y){
				myLaneSpawner = enemySpawner;
				return;
			}
		}
		Debug.LogError (name + ": can't find spawner for my lane.");
	}

	bool IsAttackerAheadInLane(){
		// Exit if no attackers in lane
		if(myLaneSpawner.transform.childCount <= 0){
			return false;
		} 

		foreach(Transform attacker in myLaneSpawner.transform){
			if(attacker.transform.position.x >= transform.position.x){
				return true; // found at least one attacker to the right of shooter. done with this method. exit.
			}
		}

		//attackers are in lane, but behind the defender/shooter
		return false;

	}


	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

}
