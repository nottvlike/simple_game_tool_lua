using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	public List<Character> Characters = new List<Character>();
	bool ShowCharWheel;
	public int SelectedCharacter;
	int LastCharacter;
	public static GameManager Instance;
	public bool CanShowSelected = true;

	void Awake()
	{
		Instance = this;
		foreach (Character c in Characters) 
		{
			c.Instance = Instantiate( c.PlayerPrefab , c.HomeSpawn.position , c.HomeSpawn.rotation) as GameObject;
			c.Instance.GetComponent<PlayerController>().LocalCharacter = c;
		}
		ChangeCharacterStart( Characters[PlayerPrefs.GetInt ("SelectedChar")]);
	}
	// Use this for initialization
	void Start () {
		ShowCharWheel = true;
//		foreach (Character c in Characters) {
//			names.Add ( c.Name );			
//		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) 
		{
			ShowCharWheel = !ShowCharWheel;		
		} 

//		Camera.main.GetComponent<Smoo>
	}

	void ChangeCharacterStart( Character c)
	{
//		SequenceManager.Instance.StartCoroutine ( "DoCharSwitch" ,c);
		LastCharacter = SelectedCharacter;
		SelectedCharacter = Characters.IndexOf (c);
		Characters [LastCharacter].Instance.GetComponent<PlayerController> ().CanPlay = false;
		Characters [SelectedCharacter].Instance.GetComponent<PlayerController> ().CanPlay = true;
		SmoothFollow flow = Camera.main.GetComponent ("SmoothFollow") as SmoothFollow;
		flow.target = c.Instance.transform;
		PlayerPrefs.SetInt ("SelectedChar" , SelectedCharacter);
	}

	void ChangeCharacter( Character c)
	{
//		Debug.Log ( Vector3.Distance (Characters [SelectedCharacter].Instance.transform.position, c.Instance.transform.position));
		c.Instance.GetComponent<AI> ().DoneHome = false;
//		c.Instance.GetComponent<PlayerController> ().Go ();
		if (Mathf.Round (Vector3.Distance (Characters [SelectedCharacter].Instance.transform.position, c.Instance.transform.position)) > 10) {
			SequenceManager.Instance.StartCoroutine ("DoCharSwitch", c);
			CanShowSelected = false;

//			SequenceManager.Instance.StartCoroutine ( "DoCharSwitch" ,c);
			LastCharacter = SelectedCharacter;
			SelectedCharacter = Characters.IndexOf (c);
			Characters [LastCharacter].Instance.GetComponent<PlayerController> ().CanPlay = false;
//			Characters [LastCharacter].Instance.GetComponent<PlayerController> ().Go();
			Characters [LastCharacter].Instance.GetComponent<AI> ().goBack();
			Characters [SelectedCharacter].Instance.GetComponent<PlayerController> ().CanPlay = true;
//			Characters [SelectedCharacter].Instance.GetComponent<PlayerController> ().Go();
			Characters [SelectedCharacter].Instance.GetComponent<AI> ().goHead();
			PlayerPrefs.SetInt ("SelectedChar" , SelectedCharacter);
		}
		else {
//			SequenceManager.Instance.StartCoroutine ( "DoCharSwitch" ,c);
			LastCharacter = SelectedCharacter;
			SelectedCharacter = Characters.IndexOf (c);
			Characters [LastCharacter].Instance.GetComponent<PlayerController> ().CanPlay = false;
			Characters [LastCharacter].Instance.GetComponent<PlayerController> ().Go();
			Characters [LastCharacter].Instance.GetComponent<AI> ().goBack();
			Characters [SelectedCharacter].Instance.GetComponent<PlayerController> ().CanPlay = true;
			Characters [SelectedCharacter].Instance.GetComponent<PlayerController> ().Go();
			Characters [SelectedCharacter].Instance.GetComponent<AI> ().goHead();
			PlayerPrefs.SetInt ("SelectedChar" , SelectedCharacter);
			SmoothFollow flow = Camera.main.GetComponent ("SmoothFollow") as SmoothFollow;
			flow.target = c.Instance.transform;
		}

//		SequenceManager.Instance.StartCoroutine ( "DoCharSwitch" ,c);
//		LastCharacter = SelectedCharacter;
//		SelectedCharacter = Characters.IndexOf (c);
//		Characters [LastCharacter].Instance.GetComponent<PlayerController> ().CanPlay = false;
//		Characters [SelectedCharacter].Instance.GetComponent<PlayerController> ().CanPlay = true;
//		PlayerPrefs.SetInt ("SelectedChar" , SelectedCharacter);
	}

	void OnGUI()
	{
		if (ShowCharWheel && CanShowSelected) 
		{
			GUILayout.BeginArea( new Rect( Screen.width - 64 , Screen.height - 192 , 64 , 192 ) , "box");
			foreach( Character c in Characters )
			{
				if( GUILayout.Button( c.Icon , GUILayout.Width(64) , GUILayout.Height(64)))
				{
//					SelectedCharacter = Characters.IndexOf(c);
					ChangeCharacter( c );
				}
			}
			GUILayout.EndArea();
//			SelectedCharacter = GUI.SelectionGrid( new Rect(Screen.width - 256 , Screen.height - 256 , 512 , 512 ) , SelectedCharacter , names.ToArray() , 2 );		
		}
	}
}

[System.Serializable]
public class Character
{
	public string Name;
	public Texture2D Icon;
	public GameObject PlayerPrefab;
	public GameObject Instance;
	public Transform HomeSpawn;
}