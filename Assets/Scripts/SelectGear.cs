using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

// All possible gear states
public enum gearSpeed
{
	Fast,
	Normal,
	Stationary,
	Reverse
}

// All possible states that the user can be asked for
public enum prompt
{
	Overdrive,
	DirectDrive,
	LowDrive,
	Reverse
}

public class SelectGear : MonoBehaviour {
	private gearSpeed _ringSpeed;
	private gearSpeed _sunSpeed;
	private prompt _currentPrompt;
	public Text RingStateText;
	public Text SunStateText;
	public Text PromptText;

	// Use this for initialization
	void Start () {
		_ringSpeed = gearSpeed.Stationary;
		_sunSpeed = gearSpeed.Reverse;
		_currentPrompt = RandomEnumValue<prompt>();
		RingStateText.text = "";
		SunStateText.text = "";
		PromptText.text = "Put the gears in: " + _currentPrompt.ToString ();
	}
		
	// Update is called once per frame
	void Update () {
		// On mouse click cast a ray
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100)){
				//if ray hits ring gear:
				if (hit.transform.tag == "Ring") {
					// alternate between gear states
					switch (_ringSpeed) 
					{
						case gearSpeed.Stationary:
							SetColor (Color.green, hit); // change gear color
							_ringSpeed = gearSpeed.Normal; // set gear state
							RingStateText.text = _ringSpeed.ToString(); // set text for gear state
							FadeText (RingStateText); // fade animation for text in and out
							break;
						case gearSpeed.Normal:
							SetColor (Color.red, hit);
							_ringSpeed = gearSpeed.Fast;
							RingStateText.text = _ringSpeed.ToString();
							FadeText (RingStateText);
							break;
						case gearSpeed.Fast:
							SetColor (Color.blue, hit);
							_ringSpeed = gearSpeed.Stationary;
							RingStateText.text = _ringSpeed.ToString();
							FadeText (RingStateText);
							break;
					}
				} // if "Ring"

				// if ray hits sun gear:
				if (hit.transform.tag == "Sun") {
					// alternate between gear states
					switch (_sunSpeed) 
					{
						case gearSpeed.Reverse:
							SetColor (Color.cyan, hit);
							_sunSpeed = gearSpeed.Normal;
							SunStateText.text = _sunSpeed.ToString();
							FadeText (SunStateText);
							break;
						case gearSpeed.Normal:
							SetColor (Color.magenta, hit);
							_sunSpeed = gearSpeed.Reverse;
							SunStateText.text = _sunSpeed.ToString();
							FadeText (SunStateText);
							break;
					}
				} // if "Sun"

			} // Raycast
		} // if ButtonDown
	} // Update()

	// Run when "Try Selection" button is pressed
	public void onClick(){
		switch (_currentPrompt) // Assess what the user has been prompted to do
		{
		case prompt.DirectDrive:
			if (_sunSpeed == gearSpeed.Normal && _ringSpeed == gearSpeed.Normal) { // assess if the user has chosen the right states
				Win("DirectDrive");
				break;	
			} else {
				// TODO: insert fail animations
				break;
			}
		case prompt.LowDrive:
			if (_sunSpeed == gearSpeed.Normal && _ringSpeed == gearSpeed.Stationary) {
				Win ("LowGear");
				break;	
			} else {
				// TODO: insert fail animations
				break;
			}
		case prompt.Overdrive:
			if (_sunSpeed == gearSpeed.Normal && _ringSpeed == gearSpeed.Fast) {
				Win ("OverDrive");
				break;	
			} else {
				// TODO: insert fail animations
				break;
			}
		case prompt.Reverse:
			if (_sunSpeed == gearSpeed.Reverse && _ringSpeed == gearSpeed.Stationary) {
				Win ("ReverseGear");
				break;	
			} else {
				// TODO: insert fail animations
				break;
			}
		}
	}

	void Win(string condition)
	{
		PlayAnimation (condition); // play the win animation
		//yield return new WaitForSeconds (2);
		//StopAnimation (condition);
		//Start ();
	}

	// Animate the fading of text
	private void FadeText(Text text)
	{
		text.CrossFadeAlpha (1.0f, 0.0f, false);
		text.CrossFadeAlpha (0.0f, 0.75f, false);
	}

	// start|stop the appropriate animation
	private void PlayAnimation(string name)
	{
		var gear = GameObject.FindGameObjectWithTag ("Gears");
		var animator = gear.GetComponent<Animator> ();
		animator.Play (name);
	}
	private void StopAnimation(string name)
	{
		var gear = GameObject.FindGameObjectWithTag ("Gears");
		var animator = gear.GetComponent<Animator> ();
		animator.Stop ();
	}

	// Set the color of a game object
	private void SetColor(Color color, RaycastHit hit) {
		Renderer rend = hit.transform.GetComponent<Renderer> ();
		rend.material.SetColor ("_Color", color);
	}

	// pick a random item from an Enum list
	private static T RandomEnumValue<T> ()
	{
		var v = Enum.GetValues (typeof (T));
		return (T) v.GetValue (new System.Random ().Next(v.Length));
	}

}
