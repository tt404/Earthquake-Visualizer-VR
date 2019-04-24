using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class EarthquakeLoader : MonoBehaviour {
	public struct EarthquakeInfo {
		public float latitude;
		public float longitude;
		public DateTime time;
		public float magnitude;
		public float depth;

		public EarthquakeInfo(DateTime time, float latitude, float longitude, float depth, float magnitude)
		{
			this.time = time;
			this.latitude = latitude;
			this.longitude = longitude;
			this.depth = depth;
			this.magnitude = magnitude;
		}
	}

	public GameObject EarthquakeGameObject;

	public TextAsset EarthquakeData;
	public List<GameObject> EarthquakeGameObjects = new List<GameObject>();
	public List<EarthquakeInfo> EarthquakeInfoList = new List<EarthquakeInfo>();

	// Use this for initialization
	void Start ()
	{
		GenerateEarthquakeList();
		DisplayEarthquakeData(new DateTime(2014, 12, 1));
	}

	void GenerateEarthquakeList()
	{
		string[,] grid = SplitCsvGrid(EarthquakeData.text);

		for (int y = 1; y < grid.GetUpperBound(1)-1; y++)
		{
			DateTime t;
			DateTime.TryParse(grid[0, y], out t);
			if(t == null) t = new DateTime(1, 1, 1);

			EarthquakeInfoList.Add(new EarthquakeInfo(t, float.Parse(grid[1, y]), float.Parse(grid[2, y]), float.Parse(grid[3, y]), float.Parse(grid[4, y])));
			EarthquakeGameObjects.Add(GameObject.Instantiate(EarthquakeGameObject, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), this.transform));

			EarthquakeGameObjects[y - 1].transform.localPosition = new Vector3(float.Parse(grid[1, y]), float.Parse(grid[2, y]), float.Parse(grid[3, y]) / -2);
			EarthquakeGameObjects[y - 1].transform.localScale = new Vector3(1, 1, float.Parse(grid[3, y]));

			EarthquakeGameObjects[y - 1].SetActive(false);
		}

		//foreach (EarthquakeInfo i in EarthquakeInfoList) Debug.Log(i.time + " " + i.latitude + " " + i.longitude + " " + i.depth + " " + i.magnitude);
	}

	bool compressEnabled = false;
	public void SetCompress(bool v)
	{
		compressEnabled = v;
		SetDepthScale();
	}

	float compressionAmount = 1f;
	public void UpdateCompress(float v)
	{
		compressionAmount = v;
		SetDepthScale();
	}

	private float curM = 0;
	public void SetMagnitudeFilter(float m)
	{
		curM = m;
		DisplayEarthquakeData(curT);
	}
	
	public void SetDepthScale()
	{
		if(compressEnabled == false)
		{ 
			for (int i = 0; i < EarthquakeGameObjects.Count; i++)
			{
				EarthquakeGameObjects[i].transform.localPosition = new Vector3(EarthquakeInfoList[i].latitude, EarthquakeInfoList[i].longitude, (EarthquakeInfoList[i].depth)/-2);
				EarthquakeGameObjects[i].transform.localScale = new Vector3(1, 1, EarthquakeInfoList[i].depth);
			}
		}
		else
		{
			for (int i = 0; i < EarthquakeGameObjects.Count; i++)
			{
				EarthquakeGameObjects[i].transform.localPosition = new Vector3(EarthquakeInfoList[i].latitude, EarthquakeInfoList[i].longitude, compressionAmount / -2);
				EarthquakeGameObjects[i].transform.localScale = new Vector3(1, 1, compressionAmount);
			}
		}
	}

	DateTime curT;
	public void DisplayEarthquakeData(DateTime startTime)
	{
		curT = startTime;
		// Clear the old list
		for (int i = 0; i < EarthquakeGameObjects.Count; i++)
		{
			//EarthquakeGameObjects[i].transform.Find("Render").transform.position = new Vector3(0, 0, )
			if (EarthquakeInfoList[i].time >= startTime && EarthquakeInfoList[i].magnitude >= curM) EarthquakeGameObjects[i].SetActive(true);
			else EarthquakeGameObjects[i].SetActive(false);
		}
	}

	// outputs the content of a 2D array, useful for checking the importer
	static public void DebugOutputGrid(string[,] grid)
	{
		string textOutput = "";
		for (int y = 0; y < grid.GetUpperBound(1); y++)
		{
			for (int x = 0; x < grid.GetUpperBound(0); x++)
			{

				textOutput += grid[x, y];
				textOutput += "|";
			}
			textOutput += "\n";
		}
		//Debug.Log(textOutput);
	}

	// splits a CSV file into a 2D string array
	static public string[,] SplitCsvGrid(string csvText)
	{

		string[] lines = csvText.Split("\n"[0]);

		// finds the max width of row
		int width = 0;
		for (int i = 0; i < lines.Length; i++)
		{
			string[] row = SplitCsvLine(lines[i]);
			string todisplay = "";

			for (int j = 0; j < row.Length; j++)
				todisplay = String.Concat(todisplay, row[j]);

			//Debug.Log(todisplay);
			width = Mathf.Max(width, row.Length);
		}

		// creates new 2D string grid to output to
		string[,] outputGrid = new string[width + 1, lines.Length + 1];
		for (int y = 0; y < lines.Length; y++)
		{
			string[] row = SplitCsvLine(lines[y]);
			for (int x = 0; x < row.Length; x++)
			{
				outputGrid[x, y] = row[x];
				// This line was to replace "" with " in my output. 
				// Include or edit it as you wish.
				outputGrid[x, y] = outputGrid[x, y].Replace("\"\"", "\"");
			}
		}

		return outputGrid;
	}

	// splits a CSV row 
	static public string[] SplitCsvLine(string line)
	{
		return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
		@"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
		System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
				select m.Groups[1].Value).ToArray();
	}
}
