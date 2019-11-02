using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineAverage : MonoBehaviour {
	public float currentJumpTime=0;
	public float timeBtwnJumps=0;
	public float jumps;
	public float jumpiness=1f;

	void Start () {
        
	}
	
	void Update () {
		currentJumpTime += Time.deltaTime;
		jumpiness = (jumpiness)*Mathf.Pow(1.2f,-timeBtwnJumps/100);
		//Debug.Log ("The guy is this jumpy:" +jumpiness);
		//Debug.Log ("This many jumps:"+jumps);
	}


}
