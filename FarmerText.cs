using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;

// This class represents the NPC that the player can talk to
public class FarmerText : MonoBehaviour
{
    // A reference to the player object
    private GameObject player;

    // A reference to the GUI text component that will display the dialogue
    private TextMeshPro dialogueText;

    public Transform target;

    public float within_interact_range;

    public AudioClip clip1;

    public AudioClip clip2;

    public AudioSource audioSource;

    void Start()
    {
        // Find the player object in the scene
        player = GameObject.FindWithTag("Player");

        // Find the GUI text component on this NPC
        dialogueText = GetComponent<TextMeshPro>();

        dialogueStart();
    }

    void Update()
    {
        //get the distance between the player and the NPC
        float dist = Vector3.Distance(target.position, transform.position);

        if(dist <= within_interact_range)
        {
            StartCoroutine("updateDialogue");
        }            
    }
    

    void dialogueStart()
    {
        // Set the initial dialogue text to be the first dialogue option
        dialogueText.text = "N) what do you do around here?         M) what do you think of the castle?";
    }

    IEnumerator updateDialogue()
    {
       if (Input.GetKeyDown(KeyCode.N))
            {
                Debug.Log("1 pressed");
                // Update the dialogue text to the next dialogue option
                dialogueText.text = "I am but a simple farmer";
                audioSource.PlayOneShot(clip1, 0.5f);
                yield return new WaitForSeconds (5.0f);
                dialogueStart();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("2 pressed");
                // Update the dialogue text to the next dialogue option
                audioSource.PlayOneShot(clip2, 0.5f);
                dialogueText.text = "it scares me it does!";
                yield return new WaitForSeconds (5.0f);
                 Debug.Log("delay over");
                 dialogueStart();
            } 
    }
}
