using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using playerNameSpace;
using UnityEngine;

public class LifeBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    GameObject[] lifeBar;
    public static int lives = 2;
    public int effect;
    private bool canTrigger = true;
    public float triggerCooldown = 1f; // 1 second cooldown

    public GameObject fade;

    void Start()
    {
        lifeBar = new GameObject[] { one, two, three };
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject && canTrigger)
        {
            updateLives(effect);
            StartCoroutine(TriggerCooldown());
        }
    }

    private IEnumerator TriggerCooldown()
    {
        canTrigger = false;
        yield return new WaitForSeconds(triggerCooldown);
        canTrigger = true;
    }

    private void updateLives(int live)
    {
        if (live > 0)
        {
            if (lives < 2)
            {
                lives++;
                lifeBar[lives].SetActive(true);
                
            }
        }
        if (live < 0)
        {
            if (lives >= 0)
            {
                lifeBar[lives].SetActive(false);
                lives--;
            }
            if (lives < 0)
            {
                gameOver();
            }
        }
    }

    private void gameOver()
    {
        PlayerBehaviour.setCanMove(false);
        StartCoroutine(StartFade());
    }

    IEnumerator StartFade()
    {
        Animator a = fade.GetComponent<Animator>();
        a.SetInteger("isOver", 1);
        yield return new WaitForSeconds(4f);
    }
}