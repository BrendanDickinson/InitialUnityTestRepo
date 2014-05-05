/*Brendan Dickinson
 * 4.21.14
 * Collisions Info Script
 * 
 * Collisions happen when one collider hits another
 * colliders have the option to make them triggers
 * if either collider is a trigger then there will
 * not be a collision and you will need to use one
 * of the trigger methods to handle the interaction.
 * 
 * If this script is placed on the player then these
 * functions will effect all the objects with colliders
 * that the player hits.
 * 
 * For More Info Go To:
 * Collision-
 * https://docs.unity3d.com/Documentation/ScriptReference/Collision.html
 * Collider-
 * https://docs.unity3d.com/Documentation/ScriptReference/Collider.html 
 */

using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {
    /*There are three different functions that we can use when it
     * comes to collisions OnCollisionEnter(), OnCollisionStay(),
     * and OnCollisionExit().  They all take one argument of type
     * Collision.  The Collision objecct being passed in is whatever
     * collided with the object this script is on.
     */
    void OnCollisionEnter(Collision collider){  //Called when this collider/rigidbody touches another collider/rigidbody
        //Destroy(collider.gameObject); //Destroys everything that it touches
        Debug.Log("Touched something"); //Prints when it collides with anything
        if(collider.gameObject.tag == "environmentObject"){ //Enters only whent colliding with objects tagged "environmentObject"
            Debug.Log("Touched an environment object.");
            //Destroy(collider.gameObject);
        }
    }

    void OnCollisionStay(Collision collider){ //Called when every frame this collider/rigidbody is touching another
        //Debug.Log("Touching something"); //Prints every frame that it is colliding with something
        if (collider.gameObject.tag == "environmentObject")
        { 
            Debug.Log("Touching an environmentObject");  //Prints every frame that it is colliding with an env. obj.
            //Destroy(collider.gameObject);
        }
    }

    void OnCollisionExit(Collision collider){ //Called when a collision stops happening
        Debug.Log("Exited Collision"); //Prints after it stops colliding with anything
        if(collider.gameObject.tag == "environmentObject"){ //Prints after it stops colliding with an environment object
            Debug.Log("Exited Collision with Environment Object");
            //Destroy(collider.gameObject);
        }
    }
}
