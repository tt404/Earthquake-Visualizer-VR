using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorTest : MonoBehaviour {
    public Button button1, button2;
	// Use this for initialization
	void Start () {
        button1.onClick.AddListener(() => depthClick());
        button2.onClick.AddListener(() => magClick());
    }

    //Applies color on all Child objects based on the value depth, change the value on the childobject inspector
    void depthClick()
    {
        Transform child = GetComponentInChildren<Transform>();
        foreach (Transform x in child)
        {
            if (x.gameObject.GetComponent<tempValues>().depth == 1)
            {
                x.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (x.gameObject.GetComponent<tempValues>().depth == 2)
            {
                x.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (x.gameObject.GetComponent<tempValues>().depth == 3)
            {
                x.GetComponent<Renderer>().material.color = Color.cyan;
            }
            if (x.gameObject.GetComponent<tempValues>().depth == 4)
            {
                x.GetComponent<Renderer>().material.color = Color.cyan;
            }
            if (x.gameObject.GetComponent<tempValues>().depth == 5)
            {
                x.GetComponent<Renderer>().material.color = Color.green;
            }
            if (x.gameObject.GetComponent<tempValues>().depth == 6)
            {
                x.GetComponent<Renderer>().material.color = Color.green;
            }
            if (x.gameObject.GetComponent<tempValues>().depth == 7)
            {
                x.GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (x.gameObject.GetComponent<tempValues>().depth == 8)
            {
                x.GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (x.gameObject.GetComponent<tempValues>().depth == 9)
            {
                x.GetComponent<Renderer>().material.color = Color.red;
            }
            if (x.gameObject.GetComponent<tempValues>().depth == 10)
            {
                x.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    //Applies color on all Child objects based on the value magnitude, change the value on the childobject inspector
    void magClick()
    {
        Transform child = GetComponentInChildren<Transform>();
        foreach(Transform x in child)
        {
           if(x.gameObject.GetComponent<tempValues>().magnitude == 1)
            {
                x.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (x.gameObject.GetComponent<tempValues>().magnitude == 2)
            {
                x.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (x.gameObject.GetComponent<tempValues>().magnitude == 3)
            {
                x.GetComponent<Renderer>().material.color = Color.cyan;
            }
            if (x.gameObject.GetComponent<tempValues>().magnitude == 4)
            {
                x.GetComponent<Renderer>().material.color = Color.cyan;
            }
            if (x.gameObject.GetComponent<tempValues>().magnitude == 5)
            {
                x.GetComponent<Renderer>().material.color = Color.green;
            }
            if (x.gameObject.GetComponent<tempValues>().magnitude == 6)
            {
                x.GetComponent<Renderer>().material.color = Color.green;
            }
            if (x.gameObject.GetComponent<tempValues>().magnitude == 7)
            {
                x.GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (x.gameObject.GetComponent<tempValues>().magnitude == 8)
            {
                x.GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (x.gameObject.GetComponent<tempValues>().magnitude == 9)
            {
                x.GetComponent<Renderer>().material.color = Color.red;
            }
            if (x.gameObject.GetComponent<tempValues>().magnitude == 10)
            {
                x.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
