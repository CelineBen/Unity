/** 
 * @author: Céline Bensoussan
 * @date: February 3rd, 2014
 * COMP531 - Modern Computer Games
 * Assignment 1
**/

using UnityEngine;
using System.Collections;

public class InsideHouseTrigger : MonoBehaviour {

	public GameObject hinge;

	//Prevent player from leaving the house once he entered it
	void OnTriggerExit(){
		Destroy(GameObject.Find ("Open Door Trigger"));
		GameObject.Find ("Block exit").GetComponent<BoxCollider>().isTrigger = false;
		hinge.transform.rotation = Quaternion.identity;	
		Destroy (gameObject);
	}
}
