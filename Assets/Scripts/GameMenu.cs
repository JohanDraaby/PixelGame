using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public GameObject theMenu;
    public GameObject[] windows;

    public CharStats[] playerStats;


    public Text[] nameText, hpText, mpText, levelText, expText;
    public Slider[] expSlider;
    public Image[] charImage;
    public GameObject[] charStatHolder;
    public ItemButton headSlot, outfitSlot, weaponSlot, bootsSlot, accessory1, accessory2, accessory3, accessory4, accessory5;


    public GameObject[] statusButtons;


    public Text statusName, statusHP, statusMP, statusStr, statusAP, statusDef, statusMr, statusCrit, statusCritP, statusSpeed, statusExp;
    public Image statusImage;


    public ItemButton[] itemButtons;

    public string selectedItem;
    public Item activeItem;
    public Text itemName, itemDescription, useButtonText;

    public static GameMenu instance;

    public GameObject itemCharChoiseMenu;
    public GameObject itemAccChoiseMenu;
    public Text[] itemCharChoiseNames;

    public Text goldText;

    public string mainMenuName;

    public GameObject accChoiseItemBlock;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;



    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.battleActive)
        {
            if (!GameManager.instance.shopActive)
            {

                if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
                {
                    if (theMenu.activeInHierarchy)
                    {
                        //theMenu.SetActive(false);
                        //GameManager.instance.gameMenuOpen = false;
                        CloseMenu();
                    }
                    else
                    {
                        theMenu.SetActive(true);
                        UpdateMainStats();
                        GameManager.instance.gameMenuOpen = true;
                    }
                    AudioManager.instance.PlaySFX(5);
                }
            }
        }


    }

    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i].gameObject.activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);

                nameText[i].text = playerStats[i].charName;
                hpText[i].text = "HP; " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
                mpText[i].text = "MP; " + playerStats[i].currentMP + "/" + playerStats[i].maxMP;
                levelText[i].text = "Lvl: " + playerStats[i].playerLevel;
                expText[i].text = "" + playerStats[i].currentEXP + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                expSlider[i].value = playerStats[i].currentEXP;
                charImage[i].sprite = playerStats[i].charImage;
            }
            else
            {
                charStatHolder[i].SetActive(false);
            }
        }

        goldText.text = GameManager.instance.currentGold.ToString() + "g";

    }

    public void ToggleWindow(int windowNumber)
    {
        UpdateMainStats();

        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }

        itemCharChoiseMenu.SetActive(false);
    }

    public void CloseMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }

        theMenu.SetActive(false);

        GameManager.instance.gameMenuOpen = false;

        itemCharChoiseMenu.SetActive(false);
    }

    public void OpenStatus()
    {
        UpdateMainStats();

        // update information shown
        StatusCharTest(0);


        for (int i = 0; i < statusButtons.Length; i++)
        {
            statusButtons[i].SetActive(playerStats[i].gameObject.activeInHierarchy);
            statusButtons[i].GetComponentInChildren<Text>().text = playerStats[i].charName;
        }

    }


    public void StatusCharTest(int selected)
    {
        statusName.text = playerStats[selected].charName;
        //kunne også bruge ".ToString" istedet for at starte med en string ""
        statusHP.text = "" + playerStats[selected].currentHP + "/" + playerStats[selected].maxHP;
        statusMP.text = "" + playerStats[selected].currentMP + "/" + playerStats[selected].maxMP;
        statusStr.text = "" + playerStats[selected].strenght;
        statusAP.text = "" + playerStats[selected].abilityPower;
        statusDef.text = "" + playerStats[selected].defence;
        statusMr.text = "" + playerStats[selected].magicDefence;
        statusCrit.text = "" + playerStats[selected].critChance + "%";
        statusCritP.text = "" + playerStats[selected].critPower + "%";
        statusSpeed.text = "" + playerStats[selected].speed;

        if (playerStats[selected].equippedWpn != "")
        {
            weaponSlot.buttonImage.sprite = GameManager.instance.GetItemDetail(playerStats[selected].equippedWpn).itemSprite;
        }
        if (playerStats[selected].equippedArmr != "")
        {
            outfitSlot.buttonImage.sprite = GameManager.instance.GetItemDetail(playerStats[selected].equippedArmr).itemSprite;
        }
        if (playerStats[selected].equippedHead != "")
        {
            headSlot.buttonImage.sprite = GameManager.instance.GetItemDetail(playerStats[selected].equippedHead).itemSprite;
        }
        if (playerStats[selected].equippedBoots != "")
        {
            bootsSlot.buttonImage.sprite = GameManager.instance.GetItemDetail(playerStats[selected].equippedBoots).itemSprite;
        }
        if (playerStats[selected].equippedAccess1 != "")
        {
            accessory1.buttonImage.sprite = GameManager.instance.GetItemDetail(playerStats[selected].equippedAccess1).itemSprite;
        }
        if (playerStats[selected].equippedAccess2 != "")
        {
            accessory2.buttonImage.sprite = GameManager.instance.GetItemDetail(playerStats[selected].equippedAccess2).itemSprite;
        }
        if (playerStats[selected].equippedAccess3 != "")
        {
            accessory3.buttonImage.sprite = GameManager.instance.GetItemDetail(playerStats[selected].equippedAccess3).itemSprite;
        }
        if (playerStats[selected].equippedAccess4 != "")
        {
            accessory4.buttonImage.sprite = GameManager.instance.GetItemDetail(playerStats[selected].equippedAccess4).itemSprite;
        }
        if (playerStats[selected].equippedAccess5 != "")
        {
            accessory5.buttonImage.sprite = GameManager.instance.GetItemDetail(playerStats[selected].equippedAccess5).itemSprite;
        }

        statusExp.text = (playerStats[selected].expToNextLevel[playerStats[selected].playerLevel] - playerStats[selected].currentEXP).ToString();
        statusImage.sprite = playerStats[selected].charImage;

    }

    public void ShowItems()
    {
        GameManager.instance.SortItems();
        for (int i = 0; i < itemButtons.Length; i++)
        {
            itemButtons[i].buttonValue = i;

            if (GameManager.instance.itemsHeld[i] != "")
            {
                itemButtons[i].buttonImage.gameObject.SetActive(true);
                itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetail(GameManager.instance.itemsHeld[i]).itemSprite;
                itemButtons[i].amountText.text = GameManager.instance.numberOfItems[i].ToString();
            }
            else
            {
                itemButtons[i].buttonImage.gameObject.SetActive(false);
                itemButtons[i].amountText.text = "";
            }
        }
    }

    public void SelectItem(Item newItem)
    {
        activeItem = newItem;

        if (activeItem.isItem)
        {
            useButtonText.text = "Use";
        }

        if (activeItem.isWeapon)
        {
            useButtonText.text = "Equip";
        }

        itemName.text = activeItem.itemName;
        itemDescription.text = activeItem.description;
    }

    public void DiscardItem()
    {
        if (activeItem != null)
        {
            GameManager.instance.RemoveItem(activeItem.itemName);
        }
    }

    public void OpenItemCharChoise()
    {

        UseItem(0);
        //itemCharChoiseMenu.SetActive(true);

        //for (int i = 0; i < itemCharChoiseNames.Length; i++)
        //{
        //    itemCharChoiseNames[i].text = GameManager.instance.playerStats[i].charName;
        //    itemCharChoiseNames[i].transform.parent.gameObject.SetActive(GameManager.instance.playerStats[i].gameObject.activeInHierarchy);
        //}
    }

    public void OpenItemAccChoise()
    {
        itemAccChoiseMenu.SetActive(true);
        accChoiseItemBlock.SetActive(true);
    }

    public void CloseItemCharChoise()
    {
        itemCharChoiseMenu.SetActive(false);

    }
    public void CloseItemAccChoise()
    {
        itemAccChoiseMenu.SetActive(false);
        accChoiseItemBlock.SetActive(false);
    }

    public void UseItem(int selectChar)
    {
        if (activeItem.isAccessory)
        {
            OpenItemAccChoise();
        }
        else
        {
            activeItem.Use(selectChar);
            CloseItemCharChoise();
        }
    }

    public void UseAcc1()
    {
        activeItem.UseAccessory1(0);
    }

    public void UseAcc2()
    {
        activeItem.UseAccessory2(0);
    }

    public void UseAcc3()
    {
        activeItem.UseAccessory3(0);
    }

    public void UseAcc4()
    {
        activeItem.UseAccessory4(0);
    }

    public void UseAcc5()
    {
        activeItem.UseAccessory5(0);

    }



    //public void UseAcc(int selectSlot)
    //{
    //    activeItem.Use(selectSlot);
    //    CloseItemAccChoise();
    //}

    public void SaveGame()
    {
        GameManager.instance.SaveData();
        QuestManager.instance.SaveQuestData();
    }

    public void PlayerButtonSound()
    {
        AudioManager.instance.PlaySFX(4);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(mainMenuName);

        Destroy(GameManager.instance.gameObject);
        Destroy(PlayerController.instance.gameObject);
        Destroy(AudioManager.instance.gameObject);
        Destroy(gameObject);
    }
}
