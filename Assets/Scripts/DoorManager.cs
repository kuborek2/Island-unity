using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    bool doorIsOpen = false;
    float doorTimer = 0.0f;
    public float doorOpenTime = 3.0f;
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doorIsOpen){
            doorTimer += Time.deltaTime;
        }
        if(doorTimer > doorOpenTime){
            Door(doorShutSound, true, "doorshut");
            doorTimer = 0.0f;
        }
    }

    void DoorCheck(){
        if(!doorIsOpen){
            Door(doorOpenSound, false, "dooropen");
        }
    }

    void Door(AudioClip aClip, bool openCheck, string animName){ //, GameObject thisDoor
        if ( openCheck == doorIsOpen ){
            doorIsOpen = !doorIsOpen;
            this.GetComponent<AudioSource>().PlayOneShot(aClip);
            this.transform.parent.GetComponent<Animation>().Play(animName);
        }
    }
}


    // ----------------------------------------------------------------- Legacy Player door collision and dooropen and doorshut functions

    // void OnControllerColliderHit(ControllerColliderHit hit){
    //     if(hit.gameObject.tag == "playerDoor" && doorIsOpen == false){
    //         currentDoor = hit.gameObject;
    //         Door(doorOpenSound, false, "dooropen", currentDoor);   
    //     }
    // }

    // void OpenDoor(GameObject door){   
    //     doorIsOpen = true;
    //     door.GetComponent<AudioSource>().PlayOneShot(doorOpenSound);
    //     door.transform.parent.GetComponent<Animation>().Play("dooropen");
    // }

    // void ShutDoor(GameObject door){
    //     doorIsOpen = false;
    //     door.GetComponent<AudioSource>().PlayOneShot(doorShutSound);
    //     door.transform.parent.GetComponent<Animation>().Play("doorshut");
    // }
