/*Brendan Dickinson
 * 4.21.14
 * Triggers Info Script
 * 
 * Triggers happen when a collider enters a trigger,
 * this is a collider that has been marked as a trigger.
 * This script is very similar to the Collisions script.
 * 
 * If this script is placed on the player then these
 * functions will effect all the objects with triggers
 * that the player interacts with.
 * 
 * For More Info Go To:
 * Collider-
 * https://docs.unity3d.com/Documentation/ScriptReference/Collider.html
 */

using UnityEngine;
using System.Collections;

public class Triggers : MonoBehaviour {
    /*There are three different functions that we can use when it
     * comes to triggers OnTriggerEnter(), OnTriggerStay(),
     * and OnTriggerExit().  They all take one argument of type
     * Collider.  The Collider objecct being passed in is whatever
     * entered the trigger.
     */
    void OnTriggerEnter(Collider trigger){  //Called when this collider/rigidbody touches a Trigger
        //Destroy(trigger.gameObject); //Destroys every trigger it touches
        Debug.Log("Entered Trigger"); //Prints when touches any trigger
        if(trigger.tag == "environmentObject"){ //Enters only when touching a trigger on objects tagged "environmentObject"
            Debug.Log("Entered environment object Trigger.");
            //Destroy(trigger.gameObject);
        }
    }

    void OnTriggerStay(Collider trigger){ //Called when every frame this collider/rigidbody is touching another
        //Debug.Log("Inside a Trigger"); //Prints every frame that it is colliding with something
        if (trigger.gameObject.tag == "environmentObject")
        { 
            Debug.Log("Inside an environment object Trigger");  //Prints every frame that it is colliding with an env. obj.
            //Destroy(trigger.gameObject);
        }
    }

    void OnTriggerExit(Collider trigger){ //Called when a collision stops happening
        //Destroy(trigger.gameObject);
        Debug.Log("Exited Trigger"); //Prints after it stops colliding with anything
        if(trigger.gameObject.tag == "environmentObject"){ //Prints after it stops colliding with an environment object
            Debug.Log("Exited Trigger of Environment Object");
            //Destroy(trigger.gameObject);
        }
    }
}
