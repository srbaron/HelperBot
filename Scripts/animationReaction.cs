using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationReaction : MonoBehaviour {
	Animator anim;
	Rigidbody rb;
	PlayerMovement what;
	DamageSetGet dam;
	public GameObject jabBox;
	public GameObject nairBox;
	public GameObject fairBox;
	public GameObject bairBox;
	public GameObject dairBox;
	public GameObject ftiltBox;
	public GameObject dtiltBox;
	public GameObject utiltBox;
	public GameObject uairBox;
	public GameObject specBox;

    public int failedHits = 0;
    public int successfulHits = 0;
    public int timesHit = 0;


	void Awake(){
		anim = GetComponent<Animator> ();
		rb = this.GetComponent<Rigidbody> ();
		what = this.GetComponent<PlayerMovement> ();
		dam = this.GetComponent<DamageSetGet> ();
	}

	void Update(){
		if (this.gameObject.name == "PC") {
			PCActions ();
		} else {

		}
	}

	void PCActions(){

		if (anim.GetBool("onGround")) {
			if (what.canMove ) {
				if ((Input.GetKeyDown (KeyCode.J) || Input.GetButtonDown (buttonName: "AButton")) && anim.GetBool("Crouching")==false) {
					Debug.Log ("jumpanim");
					anim.SetTrigger ("Jump");
					anim.SetBool ("Running", false);
					anim.ResetTrigger ("Nair");
					anim.ResetTrigger ("Punch");
					anim.SetBool("onGround",false);
				} else if (rb.velocity.x > 4) {
					anim.SetBool ("Running", true);
					anim.ResetTrigger ("Nair");
					anim.ResetTrigger ("Punch");
					NairOff ();
					BairOff ();
					FairOff ();
					DairOff ();
					SpecOff ();
					JabOff ();
					FtiltOff ();
					UtiltOff ();
					DtiltOff ();
				} else if (rb.velocity.x < -4) {
					anim.SetBool ("Running", true);
					anim.ResetTrigger ("Nair");
					anim.ResetTrigger ("Punch");
					NairOff ();
					BairOff ();
					FairOff ();
					DairOff ();
					SpecOff ();
					JabOff ();
					FtiltOff ();
					UtiltOff ();
					DtiltOff ();
				} 
				else {
					anim.ResetTrigger ("Jump");
					anim.ResetTrigger ("Nair");
					anim.ResetTrigger ("Bair");
					anim.ResetTrigger ("Fair");
					anim.SetBool ("Running", false);
					anim.ResetTrigger ("Special");
					anim.ResetTrigger ("Punch");
					anim.ResetTrigger ("Dair");
					anim.ResetTrigger ("Uair");
					NairOff ();
					BairOff ();
					FairOff ();
					DairOff ();
					SpecOff ();
					JabOff ();
					FtiltOff ();
					UtiltOff ();
					DtiltOff ();
				}

				if (Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown (buttonName: "BButton")) {
					if(anim.GetBool("Crouching")){
						anim.SetTrigger ("Dtilt");
					}
					else if(Input.GetKey(KeyCode.W)|| Input.GetAxis(axisName: "LStickV")>0.5){
						anim.SetTrigger("Utilt");
					}
					else if(Input.GetKey(KeyCode.D)|| Input.GetAxis(axisName: "LStickH")>0.5){
						//if (what.facingFront) {
						anim.SetTrigger ("Ftilt");
						rb.velocity=Vector3.zero;
						//}
					}
					else if(Input.GetKey(KeyCode.A)|| Input.GetAxis(axisName: "LStickH")>0.5){
						//if (what.facingFront == false) {
						anim.SetTrigger ("Ftilt");
						rb.velocity=Vector3.zero;
						//}
					}
					else{
						anim.SetTrigger ("Punch");
					}
				}
				if(Input.GetKeyDown(KeyCode.K)|| Input.GetButtonDown(buttonName:"XButton")){
					anim.SetTrigger ("Special");
					anim.ResetTrigger ("Nair");
					anim.ResetTrigger ("Bair");
					anim.ResetTrigger ("Dair");
					anim.ResetTrigger ("Fair");
					anim.ResetTrigger ("Uair");
				}
			}
		} 
		else {
			anim.ResetTrigger ("Nair");
			anim.ResetTrigger ("Bair");
			anim.ResetTrigger ("Fair");
			anim.ResetTrigger ("Dair");
			anim.SetBool ("Running", false);
			if (what.canMove) {
				if ((Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown (buttonName: "BButton"))) {

					if (Input.GetKey (KeyCode.A) || Input.GetAxis (axisName: "LStickH") < -0.5) {
						if (what.facingRight) {
							anim.SetTrigger ("Bair");
						} else {
							anim.SetTrigger ("Fair");
						}
					} else if (Input.GetKey (KeyCode.D) || Input.GetAxis (axisName: "LStickH") > 0.5) {
						if (what.facingRight) {
							anim.SetTrigger ("Fair");
						} else {
							anim.SetTrigger ("Bair");
						}
					} else if (Input.GetKey (KeyCode.W) || Input.GetAxis (axisName: "LStickV") > 0.5) {
						anim.SetTrigger ("Uair");
					} else if (Input.GetKey (KeyCode.S) || Input.GetAxis (axisName: "LStickV") < -0.5) {
						anim.SetTrigger ("Dair");
					} else {
						anim.SetTrigger ("Nair");
					} 
				}
				else if(Input.GetKeyDown(KeyCode.K)|| Input.GetButtonDown(buttonName:"XButton")){
					anim.SetTrigger ("Special");
				}
			}
		}
	}

	public void StartMove(){
		what.canMove = true;
	}
	public void StopMove(){
		what.canMove = false;
	}
	public void JabOn(){
		jabBox.SetActive (true);
	}

	public void JabOff(){
		jabBox.SetActive (false);
	}

	public void NairOn(){
		nairBox.SetActive (true);
	}
	public void NairOff(){
		nairBox.SetActive (false);
	}


	public void FairOn(){
		fairBox.SetActive (true);
	}
	public void FairOff(){
		fairBox.SetActive (false);
	}

	public void BairOn(){
		bairBox.SetActive (true);
	}
	public void BairOff(){
		bairBox.SetActive (false);
	}

	public void DairOn(){
		dairBox.SetActive (true);
	}
	public void DairOff(){
		dairBox.SetActive (false);
	}
	public void FtiltOn(){
		ftiltBox.SetActive (true);
	}
	public void FtiltOff(){
		ftiltBox.SetActive (false);
	}
	public void DtiltOn(){
		dtiltBox.SetActive (true);
	}
	public void DtiltOff(){
		dtiltBox.SetActive (false);
	}
	public void UtiltOn(){
		utiltBox.SetActive (true);
	}
	public void UtiltOff(){
		utiltBox.SetActive (false);
	}
	public void UairOn(){
		uairBox.SetActive (true);
	}
	public void UairOff(){
		uairBox.SetActive (false);
	}

	public void ResetAll(){
		UtiltOff ();
		DtiltOff ();
		NairOff ();
		JabOff ();
	}
	public void SpecOn(){
		specBox.SetActive (true);
		anim.SetBool ("CanSpecial", false);
		rb.velocity = rb.velocity * 0.1f;

		if (what.facingRight) {
			rb.AddForce (new Vector3 (100, 1000, 0));
		} else {
			rb.AddForce (new Vector3 (-100, 1000, 0));
		}

	}
	public void SpecOff(){
		specBox.SetActive (false);
	}
	public void HitOn(){
		dam.justHit = false;
	}
}
