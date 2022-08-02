using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FoxPetAI : MonoBehaviour
{
    public NavMeshAgent Pet;
    public Animator PetAnim;
    public ARSpawner arp;

    //audio
    public AudioSource walking;
    public AudioSource talking;
    public AudioSource angry;
    bool isCoroutineReady = true;

    // Update is called once per frame
    void Update()
    {
        //makes the Pet walk over to the selected position by using bool and referencing to ARSpawner
       if(arp.didHit == true)
       {
            Pet.SetDestination(arp.PlacementPose.position);
       }

       if(Pet.velocity != Vector3.zero)
       {
            PetAnim.SetBool("isWalking", true);
            walking.Play();
       }
       else if (Pet.velocity == Vector3.zero)
       {
            PetAnim.SetBool("isWalking", false);
            walking.Stop();
            arp.didHit = false;
       }
       // Makes the pet turn 
       if (Input.touchCount == 2)
       {
            PetAnim.SetBool("isFall",true);
            if (isCoroutineReady)
            {
                isCoroutineReady = false;
                StartCoroutine(Playangry());
            }
        }

       // touch and hold detection for talking state

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Stationary)
            {
                PetAnim.SetBool("isTalking", true);
                talking.Play(); // audio play
            }
            if (touch.phase == TouchPhase.Ended)
            {
                PetAnim.SetBool("isTalking",false);
            }

        }
    }

    IEnumerator Playangry()
    {
        angry.Play();

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        angry.Stop();
        PetAnim.SetBool("isFall",false);
        isCoroutineReady = true;
    }

}
