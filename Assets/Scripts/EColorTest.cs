using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EColorTest : MonoBehaviour
{
    public Button button1, button2;
    // Use this for initialization
    void Start()
    {
        button1.onClick.AddListener(() => depthClick());
        button2.onClick.AddListener(() => magClick());
    }

    //Applies color on all Child objects based on the value depth, change the value on the childobject inspector
    void depthClick()
    {
        Transform child = this.transform.Find("Renderer");
        List<EarthquakeLoader.EarthquakeInfo> values = child.GetComponent<EarthquakeLoader>().EarthquakeInfoList;
        List<GameObject> EarthquakeObjects = child.GetComponent<EarthquakeLoader>().EarthquakeGameObjects;
        for (int i = 0; i < EarthquakeObjects.Count; i++)
        {
            if (values[i].depth < 10)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (values[i].depth < 20)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (values[i].depth < 30)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.cyan;
            }
			else if (values[i].depth < 40)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.cyan;
            }
			else if (values[i].depth < 50)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.green;
            }
			else if (values[i].depth < 60)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.green;
            }
			else if (values[i].depth < 70)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.yellow;
            }
			else if (values[i].depth < 80)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.yellow;
            }
			else if (values[i].depth < 90)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.red;
            }
			else if (values[i].depth < 100)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.red;
            }
			else
			{
				EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.black;
			}
        }
    }

    //Applies color on all Child objects based on the value magnitude, change the value on the childobject inspector
    void magClick()
    {
        Transform child = this.transform.Find("Renderer");
        List<EarthquakeLoader.EarthquakeInfo> values = child.GetComponent<EarthquakeLoader>().EarthquakeInfoList;
        List<GameObject> EarthquakeObjects = child.GetComponent<EarthquakeLoader>().EarthquakeGameObjects;
        for (int i = 0; i < EarthquakeObjects.Count; i++)
        {
            if (values[i].magnitude < 1)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (values[i].magnitude < 2)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.blue;
            }
			else if (values[i].magnitude < 3)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.cyan;
            }
			else if (values[i].magnitude < 4)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.cyan;
            }
			else if (values[i].magnitude < 5)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.green;
            }
			else if (values[i].magnitude < 6)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.green;
            }
			else if (values[i].magnitude < 7)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.yellow;
            }
			else if (values[i].magnitude < 8)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.yellow;
            }
			else if (values[i].magnitude < 9)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.red;
            }
			else if (values[i].magnitude < 10)
            {
                EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.red;
            }
			else
			{
				EarthquakeObjects[i].transform.Find("Render").GetComponent<Renderer>().material.color = Color.black;
			}
        }
    }
}
