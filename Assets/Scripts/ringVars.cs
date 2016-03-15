using UnityEngine;
using System.Collections;

public class ringVars : MonoBehaviour {
	public bool ringSelected;

	// Use this for initialization
	void Start () {
		ringSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ringSelected == true) {
			var sun = GameObject.FindGameObjectsWithTag ("Sun");
			var planets = GameObject.FindGameObjectsWithTag ("Planet");

			foreach (var obj in sun) {
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
