using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gooey : MonoBehaviour {
	public GameObject PC=null;
	public GameObject BG=null;
	DamageSetGet pcdam;
	DamageSetGet bgdam;

	void Awake(){
		pcdam = PC.GetComponent<DamageSetGet> ();
		bgdam = BG.GetComponent<DamageSetGet> ();
	}

	void OnGUI(){
		GUI.Box (new Rect (10, 10, 100, 100), ""+pcdam.currentDamage);
		GUI.Box (new Rect (390, 10, 100, 100), ""+bgdam.currentDamage);
	}
	void Update(){

	}
}
