using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	Vector3 initialPosition;
	float moveSpeed=2;
	public GameObject[] targets=null;
	Vector3 averagePosition;
	Vector3 vectorSum;
	Vector3 targetPos;

	// Use this for initialization
	void Start () {
		AveragePoint (targets);
		initialPosition = this.transform.position-averagePosition;
	}
	
	// Update is called once per frame
	void Update () {
		AveragePoint (targets);
		targetPos = averagePosition + initialPosition;
		this.transform.position=Vector3.MoveTowards(this.transform.position ,targetPos,Vector3.Magnitude(this.transform.position-targetPos)*Time.deltaTime*Time.deltaTime*1000);
	}



	void AveragePoint(GameObject[] targets){
		foreach (GameObject item in targets) {
			vectorSum += item.transform.position;
		}
		averagePosition = vectorSum / targets.Length;
		vectorSum = Vector3.zero;
	}
}

