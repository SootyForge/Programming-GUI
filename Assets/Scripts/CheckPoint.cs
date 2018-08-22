using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CheckPoint
[AddComponentMenu("FirstPerson/Checkpoint")]

public class CheckPoint : MonoBehaviour
{
    #region Variables
    [Header("Check Point Elements")]
    //GameObject for our currentCheck
    public GameObject curCheckpoint;
    [Header("Character Handler")]
    //character handler script that holds the players health
    public CharacterController charH;
    #endregion
    // Start is called just before any of the Update methods is called the first time
    void Start()
    {
        //the character handler is the component attached to our player
        #region Check if we have Key
        //if we have a save key called SpawnPoint
            //then our checkpoint is equal to the game object that is named after our save file
            //our transform.position is equal to that of the checkpoint
        #endregion
    }



    // Update is called every frame, if the MonoBehaviour is enabled
    void Update()
    {
        //if our characters health is less than or equal to 0
        //our transform.position is equal to that of the checkpoint
        //our characters health is equal to full health
        //character is alive
        //characters controller is active		
    }



    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        //Collider other
        //if our other objects tag when compared is CheckPoint
        //our checkpoint is equal to the other object
        //save our SpawnPoint as the name of that object
    }
}
