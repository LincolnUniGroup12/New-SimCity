using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cityHall : MonoBehaviour {


	public GameObject scripts;

	// Use this for initialization
	void Start () {
		GameObject scripts = GameObject.Find("_Scripts");
		scripts.GetComponent<cityStats>().happiness += 6;
	}
	

}
