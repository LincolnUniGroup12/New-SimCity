using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InudstrialStatsController : MonoBehaviour {

    public float JobsProvided = 50;
    public float HappinessGain;
	public float cost;
    private cityStats CityStats;

	// Use this for initialization
	void Start ()
    {
        CityStats = FindObjectOfType<cityStats>();

		GameObject scripts = GameObject.Find("_Scripts");
		scripts.GetComponent<cityStats>().money -= cost;
		scripts.GetComponent<cityStats>().happiness -= 1;

        if (this.gameObject.activeInHierarchy)
        {
            CityStats.availableJobs += JobsProvided;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
    
	}
}
