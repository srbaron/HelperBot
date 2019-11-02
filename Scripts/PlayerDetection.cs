using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour {
	public GameObject player=null;
	float playerDist;
	public float distCap=2;
	Animator thisAnim;
	Animator otherAnim;
	public bool facingRight=true;
	PlayerMovement pmov;
	public float speedFactor=1f;
	private Rigidbody rb;
	MachineAverage ma;
	DamageSetGet dam;

	// Use this for initialization
	void Start () {
		thisAnim = this.GetComponent<Animator> ();
		pmov = player.GetComponent<PlayerMovement> ();
		rb = this.GetComponent<Rigidbody> ();
		otherAnim = player.GetComponent<Animator> ();
		ma = player.GetComponent<MachineAverage> ();
		dam = this.GetComponent<DamageSetGet> ();
	}


	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "StageBase") {
			thisAnim.SetBool("onGround",true);
		}
	}
	void OnCollisionExit(Collision col){
		if (col.gameObject.name == "StageBase") {
			thisAnim.SetBool("onGround",false);
		}
	}
	// Update is called once per frame
	void Update () {

		playerDist = Vector3.Distance (this.transform.position, player.transform.position);

		Turnaround ();

		if (Mathf.Abs (this.transform.position.x - player.transform.position.x) <= distCap) {
			thisAnim.SetBool ("inPlayerZone", true);
			//Debug.Log ("In mah zone");
			if (thisAnim.GetBool("canMove")==true) {
				if (otherAnim.GetBool("onGround")) {
					if(ma.jumpiness>2) {
						thisAnim.SetTrigger ("Dtilt");
					}
					else{
					thisAnim.SetTrigger ("Punch");
					//anim.speed =anim.speed*speedFactor;
					}
				}
				if (!otherAnim.GetBool("onGround")) {
					if (thisAnim.GetBool ("onGround")) {
					
						if (player.transform.position.y > this.transform.position.y) {

							if (ma.jumpiness > 4) {
								thisAnim.SetTrigger ("Jump");
								rb.AddForce (new Vector3 (0, 500, 0));
								thisAnim.SetBool ("onGround", false);
							}
							if (ma.jumpiness <= 4 && ma.jumpiness > 2) {
								thisAnim.SetTrigger ("Utilt");
							}
							if (ma.jumpiness <= 2) {
								thisAnim.SetTrigger ("Dtilt");
							}


						} 
					} else {
						thisAnim.SetTrigger ("Nair");
					}
				} 
			}
		}else {
			thisAnim.SetBool ("inPlayerZone", false);
			//Debug.Log ("outta the zone");
		} 
	}

	void Turnaround(){
		if(this.transform.position.x<player.transform.position.x){
			if (!facingRight) {
				this.transform.Rotate (new Vector3 (0, 180, 0));
				facingRight=true;
			}
		}
		if(this.transform.position.x>player.transform.position.x){
			if (facingRight) {
				this.transform.Rotate (new Vector3 (0, -180, 0));
				facingRight=false;
			}
		}
	}


	void StartMove(){
		thisAnim.SetBool ("canMove", true);
	}

	void StopMove(){
		thisAnim.SetBool ("canMove", false);
	}

}


