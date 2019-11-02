using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 6.0f;
	public float rotSpeed = 100.0f;
	public float fallTransition=0.5f;
	Rigidbody rb;
	Animator anim;
	public bool facingRight=true;
	public bool canMove=true;
	string thisName;
	PlayerDetection pd;
	DamageSetGet dam;
	MachineAverage ma;
	//public float time = 0f;
	//public bool canMoveSideways = true;

	void Awake(){
		rb = this.GetComponent<Rigidbody> ();
		anim = this.GetComponent<Animator> ();
		Physics.gravity = new Vector3 (0,-20,0);
		canMove = true;
		thisName = this.gameObject.name;
		pd = this.GetComponent<PlayerDetection> ();
		dam = this.GetComponent<DamageSetGet> ();
		ma = this.GetComponent<MachineAverage> ();
	}

	void Update(){
		if (this.gameObject.name=="PC"){
			Movement ();
		}
		if (this.gameObject.name == "BG") {
			this.facingRight = pd.facingRight;
		}
	}


	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "StageBase") {
			anim.SetBool("onGround",true);
			anim.SetBool ("CanSpecial", true);
		}
	}
	void OnCollisionExit(Collision col){
		if (col.gameObject.name == "StageBase") {
			anim.SetBool ("onGround", false);
		}
	}

	void Movement(){
		if ((Input.GetKeyDown (KeyCode.J) ||Input.GetButtonDown(buttonName:"AButton")) && anim.GetBool("onGround") && canMove && anim.GetBool("Crouching")==false) {
			//Debug.Log ("upp");
			rb.AddForce (new Vector3(0,500,0));
			ma.timeBtwnJumps=ma.currentJumpTime;
			ma.jumps++;
			ma.jumpiness+=1;
			ma.currentJumpTime = 0;
			anim.SetTrigger ("Jump");
			anim.SetBool("onGround", false);
			anim.SetBool ("Crouching", false);
		}

		if ((Input.GetKey (KeyCode.A) || Input.GetAxis(axisName:"LStickH")<-0.5) && canMove && anim.GetBool("Crouching")==false) {
				//Debug.Log ("left");
			if (anim.GetBool("onGround")) {
				rb.velocity =new Vector3 (-moveSpeed, rb.velocity.y, rb.velocity.z);
			} else {
				rb.velocity+=new Vector3((-6-rb.velocity.x)/10,0,0);
			}

			if (anim.GetBool("onGround") && facingRight) {
				facingRight = false;
				this.transform.Rotate (new Vector3 (0, 180, 0));
			}
		}

		else if ((Input.GetKey (KeyCode.D) || Input.GetAxis(axisName:"LStickH")>0.5)  && canMove && anim.GetBool("Crouching")==false) {
				//Debug.Log ("right");
			if (anim.GetBool("onGround")) {
				rb.velocity = new Vector3 (moveSpeed, rb.velocity.y, rb.velocity.z);
			} else {
				rb.velocity+=new Vector3((6-rb.velocity.x)/10,0,0);
			}

			if (anim.GetBool("onGround") && !facingRight) {
				facingRight = true;
				this.transform.Rotate (new Vector3 (0, -180, 0));
			}
		}

		if ((Input.GetKey (KeyCode.S) || Input.GetAxis (axisName: "LStickV") < -0.5) && canMove && anim.GetBool("onGround")) {
			//Debug.Log ("bruh");
			anim.SetBool ("Crouching", true);
		} else {
			anim.SetBool ("Crouching", false);
		}
			

	}

}
