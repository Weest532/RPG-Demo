using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;

// This class represents the NPC that the player can talk to
public class QuestGiverText : MonoBehaviour
{
    // A reference to the player object
    private GameObject player;

    // A reference to the GUI text component that will display the dialogue
    private TextMeshPro dialogueText;

    public Transform target;

    public float within_interact_range;

    bool hasPlayed = false;

    public AudioClip clip1;

    public AudioClip clip2;

    public AudioClip clip3;

    public AudioSource audioSource;

    public Text questBox;

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
        int scrollCount = player.GetComponent<Player>().menuCanvas.GetComponent<Inventory>().getNumberOfGivenItem("Scroll");

        if(dist <= within_interact_range){
            if (hasPlayed == false)
            {
                hasPlayed = true;
                audioSource.PlayOneShot(clip1, 0.5f);
            }
            if(scrollCount == 1)
            {
                StartCoroutine("finishedDialogue", 5.0f);
            } 
            else
            {
                StartCoroutine("startingDialogue", 5.0f);
            }
        }
    }

    void dialogueStart()
    {
        // Set the initial dialogue text to be the first dialogue option
        dialogueText.text = "I have a quest for you, traveller          N) what is the quest?                               M) who are you??";
    }

    IEnumerator startingDialogue(float delay)
    {
       if (Input.GetKeyDown(KeyCode.N))
            {
                // Update the dialogue text to the next dialogue option
                dialogueText.text = "Head to the castle and kill the skeletons, retrieve their scroll and bring it back to me!";
                questBox.text = "Fetch the scroll from the castle";
                audioSource.PlayOneShot(clip2, 0.5f);
                yield return new WaitForSeconds (5.0f);
                dialogueStart();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                // Update the dialogue text to the next dialogue option
                audioSource.PlayOneShot(clip3, 0.5f);
                dialogueText.text = "I am the captain of the guard, I protect this town from all the creatures of the dark woods";
                yield return new WaitForSeconds (5.0f);;
                dialogueStart();
            } 
    }
    IEnumerator finishedDialogue()
    {
        questBox.text = "Scroll removed from inventory";
        dialogueText.text = "You did it! With this scroll, our village can close the nearby oblivion gate!";
        yield return new WaitForSeconds (5.0f);
        player.GetComponent<Player>().menuCanvas.GetComponent<Inventory>().removeItemfromInventory("Scroll");
        questBox.text = "";
    }
}
