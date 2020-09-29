using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{

    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;




    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] mpLvlBonus;
    public int strenght;
    public int abilityPower;
    public int defence;
    public int magicDefence;
    public int critChance;
    public int critPower;
    public int speed;




    public string equippedHead;
    public string equippedWpn;
    public string equippedArmr;
    public string equippedBoots;
    public string equippedAccess1;
    public string equippedAccess2;
    public string equippedAccess3;
    public string equippedAccess4;
    public string equippedAccess5;
    public Sprite charImage;



    // Start is called before the first frame update
    void Start()
    {

        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;
        for (int i = 2; i < expToNextLevel.Length; i++)
        {

            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Cheat Tool
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    AddExp(500);
        //}


    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
        if (playerLevel < maxLevel)
        {

            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];

                playerLevel++;

                //determin wheter to add to str or def based on odd or even.
                if (playerLevel % 2 == 0)
                {
                    strenght += 3;
                    abilityPower += 3;
                    speed += 10;
                }
                else
                {
                    defence += 3;
                    magicDefence += 3;
                }

                maxHP += 15;
                currentHP = maxHP;

                maxMP += mpLvlBonus[playerLevel];
                currentMP = maxMP;
            }
        }

        if (playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }


}
