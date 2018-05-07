using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {
	
	private Animator animator;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		attacker = GetComponent<Attacker>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		GameObject go = collider.gameObject;
		
		// Leave the method if not colliding with a Defender
		if(!go.GetComponent<Defender>()){
			return;
		}
			animator.SetBool("isAttacking", true);
			attacker.Attack(go);
		}
}
