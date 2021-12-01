/*
Control building process loading Slider
*/

using UnityEngine;
using UnityEngine.UI;

public class BuildingProgress : MonoBehaviour {

	public Slider buildingProgressSlider; //Connected to Slider Canvas
	private float speed = 20;

	void Start () {
		buildingProgressSlider.maxValue = 100;
		buildingProgressSlider.value = 0;
	}
	
	void Update () {
		if (buildingProgressSlider.value != buildingProgressSlider.maxValue)
			buildingProgressSlider.value += Time.deltaTime * speed;
		else
			Destroy(gameObject);
	}
}
