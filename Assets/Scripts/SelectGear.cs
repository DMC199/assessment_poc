using UnityEngine;
using System.Collections;

public class SelectGear : MonoBehaviour {

	public int CurrentRingState;
	public int CurrentSunState;
	public string StateText;

	// Use this for initialization
	void Start () {
		CurrentRingState = 0;
		CurrentSunState = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100)){
				if (hit.transform.tag == "Ring") {
					if (CurrentRingState == 0) {
						Renderer rend = hit.transform.GetComponent<Renderer> ();
						rend.material.SetColor ("_Color", Color.green);
						// display text "Fixed"
						CurrentRingState++;
					} else if (CurrentRingState == 1) {
						Renderer rend = hit.transform.GetComponent<Renderer> ();
						rend.material.SetColor ("_Color", Color.red);
						// display text "Forward"
						CurrentRingState++;
					} else if (CurrentRingState == 2) {
						Renderer rend = hit.transform.GetComponent<Renderer> ();
						rend.material.SetColor ("_Color", Color.blue);
						// display text "Forward Fast"
						CurrentRingState = 0;
					}
				} // if "Ring"

				if (hit.transform.tag == "Sun") {
					if (CurrentSunState == 0) {
						Renderer rend = hit.transform.GetComponent<Renderer> ();
						rend.material.SetColor ("_Color", Color.cyan);
						// display text "Reverse"
						CurrentSunState++;
					} else if (CurrentSunState == 1) {
						Renderer rend = hit.transform.GetComponent<Renderer> ();
						rend.material.SetColor ("_Color", Color.magenta);
						// display text "Forward"
						CurrentSunState = 0;
					}
				} // if "Sun"

				if (hit.transform.tag == "Planet") {
					//Do Nothing
				} // if "Planet"

			} // Raycast
		} // if ButtonDown
	} // Update()

	void ResetColor(string tag){
		var gear = GameObject.FindGameObjectsWithTag (tag);
		foreach (var obj in gear) {
			Renderer rendObj = obj.GetComponent<Renderer>();
			rendObj.material.SetColor ("_Color", Color.gray);
		}
	}

}
