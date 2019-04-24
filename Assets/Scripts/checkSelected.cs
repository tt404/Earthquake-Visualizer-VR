using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkSelected : MonoBehaviour {
    public GameObject[] countries;
    public Toggle[] togs;
	public bool prevMonth2TogState;

	public Toggle rotateTog, month2Tog, compressTog;
	public Slider magnitudeFilter, compressAmount;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < countries.Length; i++) countries[i].SetActive(false);
		magnitudeFilter.onValueChanged.AddListener(delegate { updateMagnitude(); });
		compressTog.onValueChanged.AddListener(delegate { setCompress(); });
		compressAmount.onValueChanged.AddListener(delegate { updateCompress(); });
	}
	
	// Update is called once per frame
	void Update () {
		// Turn on.
		if(prevMonth2TogState == false && month2Tog.isOn == true) for (int i = 0; i < countries.Length; i++) countries[i].transform.Find("Renderer").GetComponent<EarthquakeLoader>().DisplayEarthquakeData(new System.DateTime(2018,10,1));

		// Turn off.
		else if(prevMonth2TogState == true && month2Tog.isOn == false) for (int i = 0; i < countries.Length; i++) countries[i].transform.Find("Renderer").GetComponent<EarthquakeLoader>().DisplayEarthquakeData(new System.DateTime(2014, 12, 1));

		for (int i = 0; i < togs.Length; i++)
		{			
			if (togs[i].isOn) countries[i].SetActive(true);
			else countries[i].SetActive(false);
		}

		prevMonth2TogState = month2Tog.isOn;
	}

	public void setCompress()
	{
		for (int i = 0; i < countries.Length; i++) countries[i].transform.Find("Renderer").GetComponent<EarthquakeLoader>().SetCompress(compressTog.isOn);
	}

	public void updateCompress()
	{
		for (int i = 0; i < countries.Length; i++) countries[i].transform.Find("Renderer").GetComponent<EarthquakeLoader>().UpdateCompress(compressAmount.value);
	}

	public void updateMagnitude()
	{
		for (int i = 0; i < countries.Length; i++) countries[i].transform.Find("Renderer").GetComponent<EarthquakeLoader>().SetMagnitudeFilter(magnitudeFilter.value);
	}

    public void rotate()
    {
        if (rotateTog.isOn) for (int i = 0; i < countries.Length; i++) countries[i].transform.Rotate(-90, 0, 0);
        else for (int i = 0; i < countries.Length; i++) countries[i].transform.Rotate(90, 0, 0);
    }
}
