using UnityEngine;
using System.Collections;

public enum gearSpeed
{
    fast, // Overdrive when used for output
    normal, // Direct drive when used for output
    slow, // Low gear when used for output
    stationary, // Is not used for output
    reverse // same name when used as output
}

public class WinCondition : MonoBehaviour {
    public Animator gearAnimation;

    public bool ConditionMet(gearSpeed desiredOutput, gearSpeed sunInput, gearSpeed ringInput)
    {
        gearSpeed desiredSunInput = gearSpeed.stationary; // Initialized because unity complains
        gearSpeed desiredRingInput = gearSpeed.stationary;// when they aren't

        switch(desiredOutput)
        {
        case gearSpeed.fast:
            desiredSunInput = gearSpeed.normal;
            desiredRingInput = gearSpeed.fast;
            break;
        case gearSpeed.normal:
            desiredSunInput = gearSpeed.normal;
            desiredRingInput = gearSpeed.normal;
            break;
        case gearSpeed.slow:
            desiredSunInput = gearSpeed.normal;
            desiredRingInput = gearSpeed.stationary;
            break;
        case gearSpeed.reverse:
            desiredSunInput = gearSpeed.reverse;
            desiredRingInput = gearSpeed.stationary;
            break;
        };

        if (desiredSunInput == sunInput && desiredRingInput == ringInput)
        {
            //gearAnimation.Play() put animation state cooresponding to desiredOutput in arguments list
            // Additionally, make the checkbox do it's animation
            return true;
        }
        return false;
    }
}
