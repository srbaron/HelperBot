﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStand : StateMachineBehaviour {
	//public class EnemyStand_Mono : MonoBehaviour{
	private Animator anim;

	public void OnStateEnter(Animator anim) {
	}


	public void OnStateUpdate(Animator anim, AnimatorStateInfo stateInfo, int layerIndex) {
		if (stateInfo.IsName ("EnemyStand")&&anim.gameObject.CompareTag("Player")==false) {
			if (Input.GetKeyDown (KeyCode.F)) {
				anim.SetBool ("isFollowing", true);
			}
		}
	}

	/*
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}*/

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}

