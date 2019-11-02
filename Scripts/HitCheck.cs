using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitCheck : MonoBehaviour {
	HitData hitValues;
	Rigidbody meRB;
	Rigidbody themRB;
	PlayerMovement dir;
	public string hitTag;
	Animator anim;
	DamageSetGet meDam;
	DamageSetGet themDam;

	void Awake(){
		meDam = this.GetComponentInParent<DamageSetGet>();
		meRB = this.GetComponentInParent<Rigidbody> ();
		anim = this.GetComponentInParent<Animator> ();
	}
		

	void OnTriggerEnter ( Collider other) {
		if (other.tag == hitTag&&meDam.justHit==false) {
			hitValues = other.GetComponent<HitData> ();
			dir = other.GetComponentInParent<PlayerMovement> ();
			themDam = other.GetComponentInParent<DamageSetGet> ();
			themRB = other.GetComponentInParent<Rigidbody> ();
			Debug.Log ("Current rotation:" + themRB.rotation);
			if (dir.facingRight) {
				meRB.velocity = new Vector3 (hitValues.knockback * Mathf.Cos (hitValues.launchAngle * Mathf.PI / 180), hitValues.knockback * Mathf.Sin (hitValues.launchAngle * Mathf.PI / 180), 0)*Mathf.Pow(2,meDam.currentDamage/100);
			} else {
				meRB.velocity = new Vector3 (-hitValues.knockback * Mathf.Cos (hitValues.launchAngle * Mathf.PI / 180), hitValues.knockback * Mathf.Sin (hitValues.launchAngle * Mathf.PI / 180), 0)*Mathf.Pow(2,meDam.currentDamage/100);
			}
			meDam.justHit = true;
			themDam.consecutiveHits++;
			anim.SetTrigger ("hurt");
			meDam.currentDamage += hitValues.damageAmount;
			Debug.Log(this.name+"Hit for damage: "+hitValues.damageAmount+"\nCurrent damage: "+meDam.currentDamage);
		}

	}

}
