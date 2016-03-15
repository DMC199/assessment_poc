using UnityEngine;
using System.Collections;

public class CheckBox : MonoBehaviour {

	bool test = true;

	Animator anim;

	// Use this for initialization
	void Start () 
	{
		Qcorrect(test);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void Qcorrect(bool Win)
	{

		if (Win == true) 
		{
			anim.SetBool ("IsCorrect", true);
		}
	}



}
