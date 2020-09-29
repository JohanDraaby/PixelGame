using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;
    public bool isAccessory;
    public bool isHead;
    public bool isBoots;

    [Header("Item Details")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Item Detail For Potion")]
    public int amountToChange;
    public bool affectHp, affectMP;

    [Header("Item Details")]
    public bool affectMaxHP;
    public bool affectMaxMP;
    public bool affectStr;
    public bool affectAp;
    public bool affectDef;
    public bool affectMr;
    public bool affectCrt;
    public bool affectCrtP;
    public bool affectSpeed;
    public int strAmount, defAmount, hpAmount, mpAmount, apAmount, mrAmount, crtAmount, crtpAmount, speedAmount;

    //[Header("Weapon/Armor Details")]
    //public int weaponStrength;
    //public int armorStrength;



    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {






    }

    public void Use(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (BattleManager.instance.battleActive)
        {
            charToUseOn = BattleManager.instance.currentTurn;
        }

        CharStats selectedPlayer = GameManager.instance.playerStats[charToUseOn];

        if (isItem)
        {
            if (affectHp)
            {
                selectedChar.currentHP += amountToChange;

                if (selectedChar.currentHP > selectedChar.maxHP)
                {
                    selectedChar.currentHP = selectedChar.maxHP;
                }

                if (BattleManager.instance.battleActive)
                {
                    charToUseOn = BattleManager.instance.currentTurn;
                    BattleManager.instance.activeBattlers[charToUseOn].currentHP += amountToChange;
                    if (BattleManager.instance.activeBattlers[charToUseOn].currentHP > selectedChar.maxHP)
                    {
                        BattleManager.instance.activeBattlers[charToUseOn].currentHP = selectedChar.maxHP;
                    }
                }
            }

            if (affectMP)
            {
                selectedChar.currentMP += amountToChange;

                if (selectedChar.currentMP > selectedChar.maxMP)
                {
                    selectedChar.currentMP = selectedChar.maxMP;
                }

                if (BattleManager.instance.battleActive)
                {
                    charToUseOn = BattleManager.instance.currentTurn;
                    BattleManager.instance.activeBattlers[charToUseOn].currentMP += amountToChange;
                    if (BattleManager.instance.activeBattlers[charToUseOn].currentMP > selectedChar.maxMP)
                    {
                        BattleManager.instance.activeBattlers[charToUseOn].currentMP = selectedChar.maxMP;
                    }
                }
            }

        }

        if (isWeapon)
        {
            if (selectedChar.equippedWpn != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWpn);

                selectedChar.strenght -= GameManager.instance.GetItemDetail(selectedChar.equippedWpn).strAmount;
                selectedChar.abilityPower -= GameManager.instance.GetItemDetail(selectedChar.equippedWpn).apAmount;
                selectedChar.critChance -= GameManager.instance.GetItemDetail(selectedChar.equippedWpn).crtAmount;
                selectedChar.critPower -= GameManager.instance.GetItemDetail(selectedChar.equippedWpn).crtpAmount;

            }

            selectedChar.equippedWpn = itemName;

            if (affectStr)
            {
                selectedChar.strenght += strAmount;
            }
            if (affectAp)
            {
                selectedChar.abilityPower += apAmount;
            }
            if (affectCrt)
            {
                selectedChar.critChance += crtAmount;
                if (selectedChar.critChance > 100)
                {
                    selectedChar.critChance = 100;
                }
            }
            if (affectCrtP)
            {
                selectedChar.critPower += crtpAmount;
                if (selectedChar.critPower > 100)
                {
                    selectedChar.critPower = 100;
                }
            }
        }

        if (isArmor)
        {
            if (selectedChar.equippedArmr != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedArmr);

                selectedChar.strenght -= GameManager.instance.GetItemDetail(selectedChar.equippedArmr).strAmount;
                selectedChar.abilityPower -= GameManager.instance.GetItemDetail(selectedChar.equippedArmr).apAmount;
                selectedChar.defence -= GameManager.instance.GetItemDetail(selectedChar.equippedArmr).defAmount;
                selectedChar.magicDefence -= GameManager.instance.GetItemDetail(selectedChar.equippedArmr).mrAmount;
                selectedChar.maxHP -= GameManager.instance.GetItemDetail(selectedChar.equippedArmr).hpAmount;
                selectedChar.maxMP -= GameManager.instance.GetItemDetail(selectedChar.equippedArmr).mpAmount;

            }

            selectedChar.equippedArmr = itemName;

            if (affectMaxHP)
            {
                selectedChar.maxHP += hpAmount;
            }
            if (affectMaxMP)
            {
                selectedChar.maxMP += mpAmount;
            }
            if (affectStr)
            {
                selectedChar.strenght += strAmount;
            }
            if (affectAp)
            {
                selectedChar.abilityPower += apAmount;
            }
            if (affectDef)
            {
                selectedChar.defence += defAmount;
            }
            if (affectMr)
            {
                selectedChar.magicDefence += mrAmount;
            }
        }

        if (isHead)
        {
            if (selectedChar.equippedHead != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedHead);

                selectedChar.strenght -= GameManager.instance.GetItemDetail(selectedChar.equippedHead).strAmount;
                selectedChar.abilityPower -= GameManager.instance.GetItemDetail(selectedChar.equippedHead).apAmount;
                selectedChar.defence -= GameManager.instance.GetItemDetail(selectedChar.equippedHead).defAmount;
                selectedChar.magicDefence -= GameManager.instance.GetItemDetail(selectedChar.equippedHead).mrAmount;
                selectedChar.maxHP -= GameManager.instance.GetItemDetail(selectedChar.equippedHead).hpAmount;
                selectedChar.maxMP -= GameManager.instance.GetItemDetail(selectedChar.equippedHead).mpAmount;

            }

            selectedChar.equippedHead = itemName;

            if (affectMaxHP)
            {
                selectedChar.maxHP += hpAmount;
            }
            if (affectMaxMP)
            {
                selectedChar.maxMP += mpAmount;
            }
            if (affectStr)
            {
                selectedChar.strenght += strAmount;
            }
            if (affectAp)
            {
                selectedChar.abilityPower += apAmount;
            }
            if (affectDef)
            {
                selectedChar.defence += defAmount;
            }
            if (affectMr)
            {
                selectedChar.magicDefence += mrAmount;
            }
        }

        if (isBoots)
        {
            if (selectedChar.equippedBoots != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedBoots);

                selectedChar.strenght -= GameManager.instance.GetItemDetail(selectedChar.equippedBoots).strAmount;
                selectedChar.abilityPower -= GameManager.instance.GetItemDetail(selectedChar.equippedBoots).apAmount;
                selectedChar.defence -= GameManager.instance.GetItemDetail(selectedChar.equippedBoots).defAmount;
                selectedChar.magicDefence -= GameManager.instance.GetItemDetail(selectedChar.equippedBoots).mrAmount;
                selectedChar.maxHP -= GameManager.instance.GetItemDetail(selectedChar.equippedBoots).hpAmount;
                selectedChar.maxMP -= GameManager.instance.GetItemDetail(selectedChar.equippedBoots).mpAmount;
                selectedChar.speed -= GameManager.instance.GetItemDetail(selectedChar.equippedBoots).speedAmount;
                PlayerController.instance.moveSpeed -= speedAmount / 10;

            }

            selectedChar.equippedBoots = itemName;

            if (affectMaxHP)
            {
                selectedChar.maxHP += hpAmount;
            }
            if (affectMaxMP)
            {
                selectedChar.maxMP += mpAmount;
            }
            if (affectStr)
            {
                selectedChar.strenght += strAmount;
            }
            if (affectAp)
            {
                selectedChar.abilityPower += apAmount;
            }
            if (affectDef)
            {
                selectedChar.defence += defAmount;
            }
            if (affectMr)
            {
                selectedChar.magicDefence += mrAmount;
            }
            if (affectSpeed)
            {
                selectedChar.speed += speedAmount;
                PlayerController.instance.moveSpeed += speedAmount / 10;
            }
        }



        GameManager.instance.RemoveItem(itemName);
    }

    public void UseAccessory1(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (selectedChar.equippedAccess1 != "")
        {
            GameManager.instance.AddItem(selectedChar.equippedAccess1);

            selectedChar.strenght -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess1).strAmount;
            selectedChar.abilityPower -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess1).apAmount;
            selectedChar.defence -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess1).defAmount;
            selectedChar.magicDefence -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess1).mrAmount;
            selectedChar.maxHP -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess1).hpAmount;
            selectedChar.maxMP -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess1).mpAmount;
            selectedChar.critChance -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess1).crtAmount;
            selectedChar.critPower -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess1).crtpAmount;
            selectedChar.speed -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess1).speedAmount;

        }

        selectedChar.equippedAccess1 = itemName;

        if (affectMaxHP)
        {
            selectedChar.maxHP += hpAmount;
        }
        if (affectMaxMP)
        {
            selectedChar.maxMP += mpAmount;
        }
        if (affectStr)
        {
            selectedChar.strenght += strAmount;
        }
        if (affectAp)
        {
            selectedChar.abilityPower += apAmount;
        }
        if (affectDef)
        {
            selectedChar.defence += defAmount;
        }
        if (affectMr)
        {
            selectedChar.magicDefence += mrAmount;
        }
        if (affectCrt)
        {
            selectedChar.critChance += crtAmount;
            if (selectedChar.critChance > 100)
            {
                selectedChar.critChance = 100;
            }
        }
        if (affectCrtP)
        {
            selectedChar.critPower += crtpAmount;
            if (selectedChar.critPower > 100)
            {
                selectedChar.critPower = 100;
            }
        }
        if (affectSpeed)
        {
            selectedChar.speed += speedAmount;
            PlayerController.instance.moveSpeed += speedAmount / 10;

        }


        GameManager.instance.RemoveItem(itemName);
    }

    public void UseAccessory2(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (selectedChar.equippedAccess2 != "")
        {
            GameManager.instance.AddItem(selectedChar.equippedAccess2);

            selectedChar.strenght -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess2).strAmount;
            selectedChar.abilityPower -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess2).apAmount;
            selectedChar.defence -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess2).defAmount;
            selectedChar.magicDefence -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess2).mrAmount;
            selectedChar.maxHP -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess2).hpAmount;
            selectedChar.maxMP -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess2).mpAmount;
            selectedChar.critChance -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess2).crtAmount;
            selectedChar.critPower -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess2).crtpAmount;
            selectedChar.speed -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess2).speedAmount;

        }

        selectedChar.equippedAccess2 = itemName;

        if (affectMaxHP)
        {
            selectedChar.maxHP += hpAmount;
        }
        if (affectMaxMP)
        {
            selectedChar.maxMP += mpAmount;
        }
        if (affectStr)
        {
            selectedChar.strenght += strAmount;
        }
        if (affectAp)
        {
            selectedChar.abilityPower += apAmount;
        }
        if (affectDef)
        {
            selectedChar.defence += defAmount;
        }
        if (affectMr)
        {
            selectedChar.magicDefence += mrAmount;
        }
        if (affectCrt)
        {
            selectedChar.critChance += crtAmount;
            if (selectedChar.critChance > 100)
            {
                selectedChar.critChance = 100;
            }
        }
        if (affectCrtP)
        {
            selectedChar.critPower += crtpAmount;
            if (selectedChar.critPower > 100)
            {
                selectedChar.critPower = 100;
            }
        }
        if (affectSpeed)
        {
            selectedChar.speed += speedAmount;
            PlayerController.instance.moveSpeed += speedAmount / 10;

        }

        GameMenu.instance.activeItem = null;

        GameManager.instance.RemoveItem(itemName);
    }

    public void UseAccessory3(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (selectedChar.equippedAccess3 != "")
        {
            GameManager.instance.AddItem(selectedChar.equippedAccess3);

            selectedChar.strenght -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess3).strAmount;
            selectedChar.abilityPower -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess3).apAmount;
            selectedChar.defence -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess3).defAmount;
            selectedChar.magicDefence -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess3).mrAmount;
            selectedChar.maxHP -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess3).hpAmount;
            selectedChar.maxMP -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess3).mpAmount;
            selectedChar.critChance -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess3).crtAmount;
            selectedChar.critPower -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess3).crtpAmount;
            selectedChar.speed -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess3).speedAmount;

        }

        selectedChar.equippedAccess3 = itemName;

        if (affectMaxHP)
        {
            selectedChar.maxHP += hpAmount;
        }
        if (affectMaxMP)
        {
            selectedChar.maxMP += mpAmount;
        }
        if (affectStr)
        {
            selectedChar.strenght += strAmount;
        }
        if (affectAp)
        {
            selectedChar.abilityPower += apAmount;
        }
        if (affectDef)
        {
            selectedChar.defence += defAmount;
        }
        if (affectMr)
        {
            selectedChar.magicDefence += mrAmount;
        }
        if (affectCrt)
        {
            selectedChar.critChance += crtAmount;
            if (selectedChar.critChance > 100)
            {
                selectedChar.critChance = 100;
            }
        }
        if (affectCrtP)
        {
            selectedChar.critPower += crtpAmount;
            if (selectedChar.critPower > 100)
            {
                selectedChar.critPower = 100;
            }
        }
        if (affectSpeed)
        {
            selectedChar.speed += speedAmount;
            PlayerController.instance.moveSpeed += speedAmount / 10;

        }

        GameMenu.instance.activeItem = null;

        GameManager.instance.RemoveItem(itemName);
    }

    public void UseAccessory4(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (selectedChar.equippedAccess4 != "")
        {
            GameManager.instance.AddItem(selectedChar.equippedAccess4);

            selectedChar.strenght -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess4).strAmount;
            selectedChar.abilityPower -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess4).apAmount;
            selectedChar.defence -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess4).defAmount;
            selectedChar.magicDefence -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess4).mrAmount;
            selectedChar.maxHP -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess4).hpAmount;
            selectedChar.maxMP -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess4).mpAmount;
            selectedChar.critChance -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess4).crtAmount;
            selectedChar.critPower -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess4).crtpAmount;
            selectedChar.speed -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess4).speedAmount;

        }

        selectedChar.equippedAccess4 = itemName;

        if (affectMaxHP)
        {
            selectedChar.maxHP += hpAmount;
        }
        if (affectMaxMP)
        {
            selectedChar.maxMP += mpAmount;
        }
        if (affectStr)
        {
            selectedChar.strenght += strAmount;
        }
        if (affectAp)
        {
            selectedChar.abilityPower += apAmount;
        }
        if (affectDef)
        {
            selectedChar.defence += defAmount;
        }
        if (affectMr)
        {
            selectedChar.magicDefence += mrAmount;
        }
        if (affectCrt)
        {
            selectedChar.critChance += crtAmount;
            if (selectedChar.critChance > 100)
            {
                selectedChar.critChance = 100;
            }
        }
        if (affectCrtP)
        {
            selectedChar.critPower += crtpAmount;
            if (selectedChar.critPower > 100)
            {
                selectedChar.critPower = 100;
            }
        }
        if (affectSpeed)
        {
            selectedChar.speed += speedAmount;
            PlayerController.instance.moveSpeed += speedAmount / 10;

        }

        GameMenu.instance.activeItem = null;

        GameManager.instance.RemoveItem(itemName);
    }

    public void UseAccessory5(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (selectedChar.equippedAccess5 != "")
        {
            GameManager.instance.AddItem(selectedChar.equippedAccess5);

            selectedChar.strenght -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess5).strAmount;
            selectedChar.abilityPower -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess5).apAmount;
            selectedChar.defence -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess5).defAmount;
            selectedChar.magicDefence -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess5).mrAmount;
            selectedChar.maxHP -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess5).hpAmount;
            selectedChar.maxMP -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess5).mpAmount;
            selectedChar.critChance -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess5).crtAmount;
            selectedChar.critPower -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess5).crtpAmount;
            selectedChar.speed -= GameManager.instance.GetItemDetail(selectedChar.equippedAccess5).speedAmount;

        }

        selectedChar.equippedAccess5 = itemName;

        if (affectMaxHP)
        {
            selectedChar.maxHP += hpAmount;
        }
        if (affectMaxMP)
        {
            selectedChar.maxMP += mpAmount;
        }
        if (affectStr)
        {
            selectedChar.strenght += strAmount;
        }
        if (affectAp)
        {
            selectedChar.abilityPower += apAmount;
        }
        if (affectDef)
        {
            selectedChar.defence += defAmount;
        }
        if (affectMr)
        {
            selectedChar.magicDefence += mrAmount;
        }
        if (affectCrt)
        {
            selectedChar.critChance += crtAmount;
            if (selectedChar.critChance > 100)
            {
                selectedChar.critChance = 100;
            }
        }
        if (affectCrtP)
        {
            selectedChar.critPower += crtpAmount;
            if (selectedChar.critPower > 100)
            {
                selectedChar.critPower = 100;
            }
        }
        if (affectSpeed)
        {
            selectedChar.speed += speedAmount;
            PlayerController.instance.moveSpeed += speedAmount / 10;

        }

        GameMenu.instance.activeItem = null;

        GameManager.instance.RemoveItem(itemName);
    }


}
