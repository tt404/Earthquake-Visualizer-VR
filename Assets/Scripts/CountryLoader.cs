using UnityEngine;
using System.Collections;
using GeoJSON;
using System;
using System.Collections.Generic;

public class CountryLoader : MonoBehaviour {

	public TextAsset encodedGeoJSON;
	public GeoJSON.FeatureCollection collection;
	public LineRenderer renderer;
	public String countryName;

	private List<Vector3> Positions = new List<Vector3>();

	// Use this for initialization
	void Start () {
		collection = GeoJSON.GeoJSONObject.Deserialize(encodedGeoJSON.text);
		List<PositionObject> pos = new List<PositionObject>();

		foreach (FeatureObject obj in collection.features)
		{
			string s;
			obj.properties.TryGetValue("ADMIN", out s);
			Debug.Log("test" + s);
			if (s != countryName) continue;

			Debug.Log(s + " " + obj.geometry.PositionCount() + " " + obj.geometry.AllPositions().Count);
			renderer.positionCount = (obj.geometry.PositionCount());

			foreach (PositionObject o in obj.geometry.AllPositions())
			{
				Positions.Add(new Vector3(o.latitude, o.longitude, 0));
			}

		}

		foreach (Vector3 i in Positions)
		{
			Debug.Log(i);
		}

		renderer.SetPositions(Positions.ToArray());

	}

}
