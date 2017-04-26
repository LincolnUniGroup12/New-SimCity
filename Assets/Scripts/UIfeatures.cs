using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIfeatures : MonoBehaviour {


	public GameObject play;
	public GameObject playtext;
	public GameObject date;
	public GameObject ff;


	public GameObject budgetUI;
	public GameObject statsUI;

	public GameObject residentialButton;
	public GameObject commercialButton;
	public GameObject industrialButton;
	public GameObject cityhallButton;

	public GameObject smallButton;
	public GameObject mediumButton;
	public GameObject largeButton;

	public bool zonesShowing = false;
	public bool roadsShowing = false;

	public float dayFloat;
	public int day = 1;
	public int month = 1;
	public int year = 2000;

	public bool paused = true;



	void Start () {
		
	}
	

	void FixedUpdate () {
		dayFloat += Time.deltaTime;
		day = (int)dayFloat;

		date.GetComponent<Text> ().text = "Date: " + day + "/" + month + "/" + year;

		if (month == 2) {
			if (day == 28) {
				month++;
				day = 1;
				dayFloat = 1f;
			}
		}
		if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10) {
			if (day == 31) {
				month++;
				dayFloat = 1f;
				day = 1;
			}
		}
		if (month == 4 || month == 6 || month == 9 || month == 11) {
			if (day == 30) {
				month++;
				day = 1;
				dayFloat = 1f;
			}
		}

		if (month == 12 && day == 32) {
			year++;
			month = 1;
			day = 1;
			dayFloat = 1;
		}
	}


	public void Playpause() {
		if (paused) {

			Time.timeScale = 1f;
			paused = false;
			playtext.GetComponent<Text> ().text = "Pause";
		} else {

			Time.timeScale = 0f;
			paused = true;
			playtext.GetComponent<Text> ().text = "Play";
		}
	}

	public void ff1() {
		Time.timeScale = 3f;
	}

	public void ff2() {
		Time.timeScale = 15f;
	}

	public void OpenBudget() {
		budgetUI.SetActive (true);

		statsUI.SetActive (false);
	}

	public void OpenStats() {
		budgetUI.SetActive (false);

		statsUI.SetActive (true);
	}

	public void OpenCitizens() {
		budgetUI.SetActive (false);

		statsUI.SetActive (false);
	}

	public void OpenZones() {
		if (zonesShowing == false) {
			residentialButton.SetActive (true);
			commercialButton.SetActive (true);
			industrialButton.SetActive (true);
			cityhallButton.SetActive (true);
			zonesShowing = true;
		} else {
			residentialButton.SetActive (false);
			commercialButton.SetActive (false);
			industrialButton.SetActive (false);
			cityhallButton.SetActive (false);
			zonesShowing = false;

		}
	}
	public void ToggleRoads(){
		roadsShowing = !roadsShowing;
		smallButton.SetActive (roadsShowing);
		mediumButton.SetActive (roadsShowing);
		largeButton.SetActive (roadsShowing);
	}


}
