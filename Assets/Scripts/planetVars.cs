using UnityEngine;
using System.Collections;

public class planetVars : MonoBehaviour {
	public bool planetSelected;

	// Use this for initialization
	void Start () {
		planetSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (planetSelected == true) {
			var ring = GameObject.FindGameObjectsWithTag ("Ring");
			var sun = GameObject.FindGameObjectsWithTag ("Sun");

			foreach (var obj in ring) {
				Renderer rendObj = obj.GetComponent<Renderer>();
				rendObj.material.SetColor ("_Color", Color.gray);
			}
			foreach (var obj in sun) {
				Renderer rendObj = obj.GetComponent<Renderer> ();
				rendObj.material.SetColor ("_Color", Color.gray);
			}

			var planets = GameObject.FindGameObjectsWithTag ("Planet");

			foreach (var obj in planets) {
				Renderer rendObj = obj.GetComponent<Renderer>();
				rendObj.material.SetColor ("_Color", Color.green);
			}
		}
	}
}
