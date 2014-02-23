/** 
 * @author: Céline Bensoussan
 * @date: February 3rd, 2014
 * COMP531 - Modern Computer Games
 * Assignment 1
**/

using UnityEngine;
using System.Collections;

public class TableTrigger : MonoBehaviour {

	//Variables
	public GameObject displayMessage;
	public GameObject tool;
	public GameObject toolParent;	
	private TextMesh tm;
	private bool closeEnough;

	// Use this for initialization
	void Start () {
		tm = displayMessage.GetComponent<TextMesh>();	
		closeEnough = false;			
	}

	void OnTriggerEnter(Collider other){
		closeEnough = true;
	}
	
	void OnTriggerExit(Collider other){
		closeEnough = false;		
	}

	public bool dropObject(){
		if (closeEnough ==true) {
			tool.transform.parent = toolParent.transform;
			tool.transform.localPosition=new Vector3(0,0,0);
			tool.transform.localEulerAngles = new Vector3(0,0,0);
			return true;		
		} else {
			tm.text =  "The floor is dirty, \n you don't want to drop it here!\n(press C to hide message)";
			return false;
		}
	}
}
