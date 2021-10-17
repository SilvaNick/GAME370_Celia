using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    //THIS IS A WORK IN PROGRESS AND IS NOT WORKING CORRECTLY 


    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnLocation;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You are in the death goo.");
        Player.transform.position = respawnLocation.transform.position;
    }



}
