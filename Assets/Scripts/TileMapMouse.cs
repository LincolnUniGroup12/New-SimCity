using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(tileMap))]
public class TileMapMouse : MonoBehaviour
{

    tileMap _tileMap;
    public GameObject residential;
    public GameObject commercial;
    public GameObject industrial;
	public GameObject cityhall;
    bool select1;
    bool select2;
    bool select3;
	bool select4;
	int selected;
	public RoadControllerRenderer controller;
    Vector3 currentTileCoord;
    Vector3 currentVisualCoord;

    public GameObject selectionHouse;
    public GameObject selectionCommerce;
    public GameObject selectionIndustrial;
	public GameObject selectionCityhall;

	public bool deleting = false;

    void Start()
    {
        _tileMap = GetComponent<tileMap>();
        selectionHouse.SetActive(false);
        selectionCommerce.SetActive(false);
        selectionIndustrial.SetActive(false);
		selectionCityhall.SetActive (false);
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
		RaycastHit[] hits;
		hits = Physics.RaycastAll (ray, Mathf.Infinity);
		if (GetComponent<Collider> ().Raycast (ray, out hitInfo, Mathf.Infinity)) {
			int x = Mathf.FloorToInt (hitInfo.point.x / _tileMap.tileSize);
			int z = Mathf.FloorToInt (hitInfo.point.z / _tileMap.tileSize);
			// Debug.Log("Tile: " + x + "," + z);

			currentTileCoord.x = x;
			currentTileCoord.z = z;

			currentVisualCoord.x = currentTileCoord.x + 0.5f;
			currentVisualCoord.z = currentTileCoord.z + 0.5f;

       



			if (hits.Length == 2) {

				if (deleting) {
					if (Input.GetMouseButtonDown (0)) {
						Destroy (hitInfo.collider.gameObject);
					}
				}
			} else {
				selectionHouse.transform.position = currentVisualCoord;
				selectionCommerce.transform.position = currentVisualCoord;
				selectionIndustrial.transform.position = currentVisualCoord;
				selectionCityhall.transform.position = currentVisualCoord;
				if (Input.GetMouseButtonDown (0)) {

					Debug.Log ("Tile: " + currentTileCoord.x + "," + currentTileCoord.z);
					if (controller.getRoad (x, z) == 0){
						if (select1) {
							Instantiate (residential, new Vector3 (currentTileCoord.x + 0.5f, 0.0f, currentTileCoord.z + 0.5f), Quaternion.identity);
						} else if (select2) {
							Instantiate (commercial, new Vector3 (currentTileCoord.x + 0.5f, 0.0f, currentTileCoord.z + 0.5f), Quaternion.identity);
						} else if (select3) {
							Instantiate (industrial, new Vector3 (currentTileCoord.x + 0.5f, 0.0f, currentTileCoord.z + 0.5f), Quaternion.identity);
						} else if (select4) {
							Instantiate (cityhall, new Vector3 (currentTileCoord.x + 0.5f, 0.0f, currentTileCoord.z + 0.5f), Quaternion.identity);
						}
					}
					if (selected != -1) {
						controller.setRoad (deleting? 0 : selected, x, z);
					}
				}




	
				if (hitInfo.collider.gameObject.tag == "Building") {
					
				

				} else {
					

			
				}
			}
    

			if (Input.GetKeyDown (KeyCode.Escape)) {
				select1 = false;
				select2 = false;
				select3 = false;
				select4 = false;
				selectionHouse.SetActive (false);
				selectionCommerce.SetActive (false);
				selectionIndustrial.SetActive (false);
				selectionCityhall.SetActive (false);
			}
		}
    }


    public void SelectHouse()
    {
        select1 = true;
        select2 = false;
        select3 = false;
		select4 = false;
		selected = -1;
        selectionHouse.SetActive(true);
        selectionCommerce.SetActive(false);
        selectionIndustrial.SetActive(false);
		selectionCityhall.SetActive (false);
        Debug.Log("House 1 selected");
    }
    public void SelectCommerce()
    {
        select1 = false;
        select2 = true;
        select3 = false;
		select4 = false;
		selected = -1;
        selectionHouse.SetActive(false);
        selectionCommerce.SetActive(true);
        selectionIndustrial.SetActive(false);
		selectionCityhall.SetActive (false);
        Debug.Log("House 2 selected");
    }
    public void SelectIndustrial()
    {
        select1 = false;
        select2 = false;
        select3 = true;
		select4 = false;
		selected = -1;
        selectionHouse.SetActive(false);
        selectionCommerce.SetActive(false);
        selectionIndustrial.SetActive(true);
		selectionCityhall.SetActive (false);
        Debug.Log("House 3 selected");
    }

	public void SelectCityHall()
	{
		select1 = false;
		select2 = false;
		select3 = false;
		select4 = true;
		selected = -1;
		selectionHouse.SetActive(false);
		selectionCommerce.SetActive(false);
		selectionIndustrial.SetActive(false);
		selectionCityhall.SetActive (true);
		Debug.Log("House 3 selected");
	}
	public void SelectSmall(){
		select1 = false;
		select2 = false;
		select3 = false;
		select4 = false;
		selected = 1;
		selectionHouse.SetActive(false);
		selectionCommerce.SetActive(false);
		selectionIndustrial.SetActive(false);
		selectionCityhall.SetActive (false);
	}
	public void SelectMedium(){
		select1 = false;
		select2 = false;
		select3 = false;
		select4 = false;
		selected = 2;
		selectionHouse.SetActive(false);
		selectionCommerce.SetActive(false);
		selectionIndustrial.SetActive(false);
		selectionCityhall.SetActive (false);
	}
	public void SelectLarge(){
		select1 = false;
		select2 = false;
		select3 = false;
		select4 = false;
		selected = 3;
		selectionHouse.SetActive(false);
		selectionCommerce.SetActive(false);
		selectionIndustrial.SetActive(false);
		selectionCityhall.SetActive (false);
	}
}
