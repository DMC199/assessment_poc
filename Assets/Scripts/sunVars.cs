using UnityEngine;
using System.Collections;

public class sunVars : MonoBehaviour {
	public bool sunSelected;

	// Use this for initialization
	void Start () {
		sunSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (sunSelected == true) {
			var ring = GameObject.FindGameObjectsWithTag ("Ring");
			var planets = GameObject.FindGameObjectsWithTag ("Planet");

			foreach (var obj in ring) {
				Renderer rendObj = obj.GetComponent<Renderer>();
				rendObj.material.SetColor ("_Color", Color.gray);
			}
			foreach (var obj in planets) {
				Renderer rendObj = obj.GetComponent<Renderer> ();
				rendObj.material.SetColor ("_Color", Color.gray);
			}

			Renderer rend = GetComponent<Renderer> ();
			rend.material.SetColor ("_Color", Color.green);
		}
	}
}
