using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{
    public static int score = 0;
    public Text scoreText;
    public GameObject player;
    public float posX, posY, posZ;

    // Start is called before the first frame update
    void Start()
    {
        posX = (float)-10.681;
        posY = (float)2.065;
        posZ = (float)15.278;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            score++;
            scoreText.text = "Score: " + score;

            UnityEngine.Vector3 newPos = new UnityEngine.Vector3(posX, posY, posZ);
            player.transform.localPosition = newPos;
        }
    }

}
