using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using playerNameSpace;
using System;
using System.Numerics;

public class SurpisesBehaviour : MonoBehaviour
{
    public GameObject keys;
    //public static int numKeys = 0;
    //public Text keysText;
    public GameObject player;
    public bool exists = true;
    public float minX, maxX, minZ, maxZ; // Boundaries of the table
    public float yPosition = (float)-9.187248;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        if (!exists)
            gameObject.SetActive(false); // checks if key is visible.

        minX = -5;
        maxX = 16;
        minZ = -14;
        maxZ = 27;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            //numKeys++;
            //keysText.text = "Keys: " + numKeys + "/4";
            exists = false;
            //PersistentObjectManager.Instance.setHasCoin(false);
            playerNameSpace.PlayerBehaviour player1 = player.GetComponent<playerNameSpace.PlayerBehaviour>();
            player1.UpdateSpeed(speed);
            RandomizePosition();
            //AudioSource sound = keys.GetComponent<AudioSource>();
            //sound.Play();
        }
    }

    private void RandomizePosition()
    {
        float randomX = UnityEngine.Random.Range(minX, maxX);
        float randomZ = UnityEngine.Random.Range(minZ, maxZ);

        UnityEngine.Debug.Log("x,y,z: " + randomX + ", " + yPosition + ", " + randomZ);
        UnityEngine.Vector3 newPos = new UnityEngine.Vector3(randomX, yPosition, randomZ);
        transform.localPosition = newPos;
    }

    public static int getNumOfKeys()
    {
        return 0;
        //return numKeys;
    }

    public static void setNumOfKeys(int newNum)
    {
        //numKeys = newNum;
    }
}
