using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cityStats : MonoBehaviour {

	public float money;
	public float dayCounter = 0;

	public float population = 0;
	public float availableJobs = 0;
	public int averageIncome = 20000;

	public float taxRate = 0;
	public float servicesSpending = 0;
	public float happiness = 50;


	public GameObject taxSlider;
	public GameObject taxlevel;
	public GameObject servicesSlider;
	public GameObject servicesLevel;



	public GameObject overallProfit;
	public float profit = 0;
	public float percEmployed = 0;
	public float workingPopulation;
	public float overallIncome;
	public float overallIncomeTax;
	public float overallExpenses;

	public GameObject budgetpanel;

	public GameObject happinessUI;
	public GameObject popUI;
	public GameObject emprateUI;


	public bool runOnce = false;
	void Start() {
		taxRate = 10;
		servicesSpending = 200;
	}


	void Update() {

		if(happiness <= 30) {

			population -= 0.1f * Time.deltaTime;
		}

		if(happiness >= 60) {
			population += 0.1f * Time.deltaTime;

		}


		if(runOnce) {
		if(GetComponent<UIfeatures>().day == 1) {
			money += profit;
				runOnce = false;
		}
		}

		if(GetComponent<UIfeatures>().day == 2) {

			runOnce = true;
		}


		if(population > 0) {
			if(availableJobs <= population) {
		percEmployed = availableJobs / population;
			}
			else {
				percEmployed = 1;
			}

		workingPopulation = population * percEmployed;
		overallIncome = workingPopulation * averageIncome;
		overallIncomeTax = overallIncome * (taxRate / 100);
			profit = overallIncomeTax - servicesSpending;
		}
		else {
			percEmployed = 0;
			workingPopulation = 0;
			overallIncome = 0;
			overallIncomeTax = 0;
			profit = 0 - servicesSpending;
		}
		overallProfit.GetComponent<Text> ().text = "£" + profit;

		happinessUI.GetComponent<Text> ().text = "Happiness: " + (int)happiness; 
		popUI.GetComponent<Text> ().text = "Population: " + (int)population; 
		emprateUI.GetComponent<Text> ().text = "Employment Rate: " + (int)(percEmployed * 100) + "%"; 

	}


	public void ChangeTaxRate() {
		taxRate = taxSlider.GetComponent<Slider>().value;
		taxlevel.GetComponent<Text> ().text = taxRate + "%";
	}


	public void ChangeHealthRate() {
		servicesSpending = servicesSlider.GetComponent<Slider>().value;
		servicesLevel.GetComponent<Text> ().text =  "£" + servicesSpending;
	}



	public void OpenBudget() {
		budgetpanel.SetActive(true);
	}

	public void CloseBudget() {
		budgetpanel.SetActive(false);
	}
}
