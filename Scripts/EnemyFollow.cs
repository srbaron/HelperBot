using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : StateMachineBehaviour {
    private Transform playerPos;
    public float moveSpeed = 6f;
	private Animator anim;

	override public void OnStateEnter(Animator anim, AnimatorStateInfo stateInfo, int layerIndex) {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
	}

	override public void OnStateUpdate (Animator anim, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (anim.GetBool ("isFollowing")) {
			if (Input.GetKeyDown (KeyCode.F)) {
				anim.SetBool ("isFollowing", false);
			} 
			if (!anim.GetBool ("inPlayerZone")) {
				if (anim.GetBool ("canMove")) {
					anim.transform.position = Vector3.MoveTowards (anim.transform.position, new Vector3 (playerPos.position.x, anim.transform.position.y, playerPos.position.z),
						moveSpeed * Time.deltaTime /** ma.getSpeedModifier()*/);
				}
			}
		} else {
			if(Input.GetKeyDown(KeyCode.F)){
				anim.SetBool("isFollowing",true);
			}
		}
	}



	/*
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}*/

	// OnStateMove is called before OnStateMove is called on any state inside this state machine
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called before OnStateIK is called on any state inside this state machine
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMachineEnter is called when entering a statemachine via its Entry Node
	//override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
	//
	//}

	// OnStateMachineExit is called when exiting a statemachine via its Exit Node
	//override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
	//
	//}


}