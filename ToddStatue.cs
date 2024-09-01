using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToddStatue : MonoBehaviour
{
    public AudioClip clip;

    private Vector3 pos;

    public Transform target;

    public float within_interact_range;

    private GameObject player;

    bool hasPlayed = false;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        pos.Set(706, 11, 183);

    }

    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if (hasPlayed == false){
            if(dist <= within_interact_range)
            {
                hasPlayed = true;
                audioSource.PlayOneShot(clip, 0.5f);
            }
        }
    }
}
