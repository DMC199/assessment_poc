using UnityEngine;
using System.Collections;

public class GearVars : MonoBehaviour {
	public bool selected;

	// Use this for initialization
	void Start () {
		selected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (selected == true) {
			Renderer rend = GetComponent<Renderer> ();
			rend.material.SetColor ("_Color", Color.green);
		}
	}
}
