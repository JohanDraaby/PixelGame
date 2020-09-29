using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{

    private bool canHeal;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canHeal && Input.GetButtonDown("Fire1"))
        {
            GameManager.instance.playerStats[0].currentHP = GameManager.instance.playerStats[0].maxHP;
            GameManager.instance.playerStats[0].currentMP = GameManager.instance.playerStats[0].maxMP;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canHeal = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canHeal = false;
        }
    }
}
