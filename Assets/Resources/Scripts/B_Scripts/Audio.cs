/*Brendan Dickinson
 * 4.21.14
 * Audio Info Script
 * 
 * In order to use this script you must have a gameobject or camera in the scene
 * that the audio will be coming from and put this script on it. It will not need
 * and AudioSource on it as we address that in the code.  You will need an Audio
 * Listener on the camera in order to recieve any of the audio.  Most of the time
 * they have it on them already.
 * 
 * To demonstrate the audio is coming from the object change the position of the
 * camera and listen to the audio.
 * 
 * For More Info Go To:
 * AudioSource-
 * https://docs.unity3d.com/Documentation/ScriptReference/AudioSource.html
 * AudioClip-
 * https://docs.unity3d.com/Documentation/ScriptReference/AudioClip.html 
 */

using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
    public AudioClip loopingAudio;  //public variable allows for user to drag and drop in Unity on script the audio they want

    void Start(){ //you could use Awake() as well if you wish to play when the object is instantiated
        AudioSource source = gameObject.AddComponent<AudioSource>();    //creates an audioSource component and places it on the gameobject
                                                                        //that this script is attached to, this is needed for audio to play

        //OPTION 1 LOOP AUDIO AND PLAY
		source.loop = false;	//loops audio, if set to false the audio will only play once on source.Play();
		source.clip = loopingAudio;	//sets audio to the audioclip you dragged onto the script
            //if you want to set the audio through code you could use this instead, you would not need loopingAudio anymore
        //source.clip = Resources.Load(PathFromResourcesFolderToAudioclipAsString) as AudioClip;
		source.Play();	//plays the audio
        
        /*OPTION 2 PLAY ONE SHOT
         * using PlayOneShot just plays the audioclip once
         * even if your source is set to loop it will only play once
         * it recieves an audioclip and a volume level
         */
        //source.PlayOneShot(loopingAudio, 0.7f);

        /*OPTION 3 PLAY AFTER DELAY
         * using PlayDelayed will play the clip with a specified delay
         */
        //source.PlayDelayed(4.0f);

        /*Other interesting AudioSource variables/functions
         * source.Stop();   //stop audio
         * source.Pause();  //pause audio
         * source.pitch = 4.0f; //set pitch to float
         * source.mute = true; //set to boolean
         * source.isPlaying; //returns a boolean
         * source.volume; //set volume to float
         * source.time; //returns the playback time as a float
         * 
         * look into static function, says can't play with instance-
         * source.PlayClipAtPoint(loopingAudio, new Vector3(0, 0, 0));	//Stays at point doesn't follow object
         */


    }
}
