using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;  // custom editor programming

public class MiniMapIconBuilder : EditorWindow {
	// デフォルト
	string theTag = "enemy";
	float x,y,z;

	public GameObject go;
	GameObject[] gos;


	// tabs attributes
	public int toolbarInt = 0;
	public string[] toolbarStrings = new string[] {"Object", "Scene", "Lightmap"};

	// ツールパーに表示
	[MenuItem("MiniMapIconBuilder/Builer")]
	static void Init()
	{
		// get exiting open window or if none, make a new one:
		MiniMapIconBuilder window = (MiniMapIconBuilder)EditorWindow.GetWindow(typeof(MiniMapIconBuilder));
		window.Show ();
	}

	void OnGUI()
	{	GUILayout.BeginHorizontal ();
		GUILayout.Label ("GameobjectTag", EditorStyles.boldLabel);		

		theTag = GUILayout.TextField (theTag, 15);			//tag

		GUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label ("IconObject", EditorStyles.boldLabel);

		//移動量
		go = (GameObject)EditorGUILayout.ObjectField (go, typeof(Object), true);
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		GUILayout.Label ("x", EditorStyles.boldLabel);
		x = EditorGUILayout.FloatField (x);	
		GUILayout.Label ("y", EditorStyles.boldLabel);
		y = EditorGUILayout.FloatField (y);	
		GUILayout.Label ("z", EditorStyles.boldLabel);
		z = EditorGUILayout.FloatField (z);	
		EditorGUILayout.EndHorizontal();

		//ゲームオブジェクトを作成
		if (GUILayout.Button ("Create")) {
			Debug.Log (theTag);
			gos= null;
			if (gos == null)
				gos = GameObject.FindGameObjectsWithTag(theTag);
			int i = 0;
	
			GameObject icon;
			foreach (GameObject tagedObject in gos)
			{
				 icon = Instantiate(go, go.transform.position, go.transform.rotation);
					icon.transform.parent = gos [i].transform;
					i++;

				icon.transform.localPosition = new Vector3 (x, y, z);
			}


		}
	}


}
