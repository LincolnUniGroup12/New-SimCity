using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cityHall : MonoBehaviour {


	public GameObject scripts;

	// Use this for initialization
	void Start () {
		scripts.GetComponent<cityStats>().happiness += 10;
	}
	

}
