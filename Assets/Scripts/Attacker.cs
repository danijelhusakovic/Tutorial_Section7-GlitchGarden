﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
	}


	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget){
			animator.SetBool ("isAttacking", false);
		}
	}

	void OnTriggerEnter2D (){

	}

	public void SetSpeed(float speed){
		currentSpeed = speed;
	}

	// called from the animator at time of actual blow
	public void StrikeCurrentTarget(float damage){
		if(currentTarget){
			Health targetHealth = currentTarget.GetComponent<Health>();
			if(targetHealth){
				targetHealth.DealDamage(damage);
			}
		}
	}

	public void Attack(GameObject go){
		currentTarget = go;
	}

}
