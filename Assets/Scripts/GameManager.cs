using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public List<Character> Characters = new List<Character>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[System.Serializable]
public class Character
{
	public string Name;
	public Texture2D Icon;
	public GameObject PlayerPrefab;
}