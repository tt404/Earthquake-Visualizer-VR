using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountryRenderer : MonoBehaviour {

	LineRenderer renderer;
	

	void SetupPoints(Vector3[] points)
	{
		renderer.SetPositions(points);
	}
}
