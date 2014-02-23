/** 
 * @author: Céline Bensoussan
 * @date: February 3rd, 2014
 * COMP531 - Modern Computer Games
 * Assignment 1
**/

using UnityEngine;
using System.Collections;

public class BarTrigger : MonoBehaviour {

	//Variables
	public GameObject displayMessage;
	public GameObject sMessage;
	
	private TextMesh tm;
	private TextMesh secretMessage;
	private int enterCount;
	
	// Use this for initialization
	void Start () {
		//Initialize variables
		tm = displayMessage.GetComponent<TextMesh>();
		secretMessage = sMessage.GetComponent<TextMesh>();
		enterCount = 0;
	}
	IEnumerator OnTriggerEnter(Collider other){	
		enterCount += 1;

		//If message empty, wrench was not dropped on table
		if(secretMessage.text == ""){
			//If count is 3, player loses
			if(enterCount == 3){
				yield return new WaitForSeconds(1);
				tm.text = "YOU LOST !";	
				Destroy(other.gameObject);
				yield return new WaitForSeconds(2);
				Application.LoadLevel("Outside");
			}
			else{
				yield return new WaitForSeconds(1);
				tm.text = "It is too dark in here,\n you cannot read the message";
				yield return new WaitForSeconds(2);
				tm.text = "";
			}
		}else{ // If message shown, then payer wins 
			yield return new WaitForSeconds(2);
			tm.text = "You figured out how to read the message, \nYOU WON !!! ";
			Destroy(other.gameObject);
			yield return new WaitForSeconds(2);
			Application.LoadLevel("Outside");
		}	
	}
}
