/**
 * @author: Céline Bensoussan
 * @date: February 3rd, 2014
 * COMP521 - Modern Computer Games
 * Assignment 1
**/

using UnityEngine;
using System.Collections;

public class CanonBall : MonoBehaviour {

	public GameObject canonball;
	
	// Update is called once per frame
	void Update () {

		//Instantiate a projectile on pressing Fire
		if(Input.GetButtonUp("Fire1")) {
			GameObject projectile = (GameObject) Instantiate(canonball, GameObject.Find("projectile_startpoint").transform.position, Quaternion.identity);
			projectile.tag = "projectile";
			projectile.rigidbody.AddForce(transform.forward * 1000);//cannon's x axis
		}
	}
}
