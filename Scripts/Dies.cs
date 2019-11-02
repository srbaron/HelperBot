using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dies : MonoBehaviour {
	private Vector3 posi;
	Rigidbody rb;
	DamageSetGet hit;
	// Use this for initialization
	void Awake () {
		posi = this.transform.position;
		rb = this.GetComponent<Rigidbody>();
		hit = this.GetComponentInChildren<DamageSetGet> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "DeathBox"){
			this.transform.position = posi;
			rb.velocity = Vector3.zero;
			hit.currentDamage = 0;
			}
	}
}
