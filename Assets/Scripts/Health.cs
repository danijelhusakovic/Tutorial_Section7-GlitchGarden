using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;

	public void DealDamage(float damage){
		health -= damage;
		if(health <= 0f){
			// trigger death animation
			DestroyObject (); // using a method so we can call it from the AnimatOR :)
		}
	}

	// if we had Death animation, first it would play, and the the Animator would call the below function.
	public void DestroyObject(){
		Destroy (gameObject); // Destroy (this); would destroy just the Health component
	}
}
