using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using FMODUnity;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // The player's score.


        Text text;                      // Reference to the Text component.


        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the score.
            score = 0;

            // Initialise the FMOD "Score" global parameter to 0.
            RuntimeManager.StudioSystem.setParameterByName("Score", 0);
        }


        void Update ()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            text.text = "Score: " + score;

            // Send the current score to the FMOD global parameter "Score".
            RuntimeManager.StudioSystem.setParameterByName("Score", score);
        }
    }
}