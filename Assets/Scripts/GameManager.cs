using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public CharStats[] playerStats;

    public bool gameMenuOpen, dialogActive, fadingBetweenAreas, shopActive, battleActive;


    public string[] itemsHeld;
    public int[] numberOfItems;
    public Item[] referenceItems;

    public int currentGold;

    [Header("Game Events")]
    public bool guidetalkedTo;




    // Start is called before the first frame update
    void Start()
    {

        instance = this;

        DontDestroyOnLoad(gameObject);

        SortItems();
    }

    // Update is called once per frame
    void Update()
    {



        if (NPCController.instance.npcName == "Guide")
        {
            if (guidetalkedTo)
            {
                NPCController.instance.gameObject.SetActive(false);
            }
        }


        if (gameMenuOpen || dialogActive || fadingBetweenAreas || shopActive || battleActive)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }


        //Uncomment for debyg items

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    AddItem("Iron Armor");

        //    AddItem("Iron Sword");

        //    AddItem("Wooden Sword");

        //    AddItem("Red Ring");

        //    AddItem("Blue Ring");

        //    AddItem("Iron Boots");

        //    AddItem("Iron Head");

        //    AddItem("Iron Shield");

        //    AddItem("God Power");

        //    currentGold += 5;


        //    //    RemoveItem("Health Potion");
        //}





        // Save Game Buttons
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    SaveData();
        //}

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    LoadData();
        //}

    }

    public Item GetItemDetail(string itemToGrab)
    {
        for (int i = 0; i < referenceItems.Length; i++)
        {
            if (referenceItems[i].itemName == itemToGrab)
            {
                return referenceItems[i];
            }
        }



        return null;
    }

    public void SortItems()
    {
        bool itemAfterSpace = true;

        while (itemAfterSpace)
        {
            itemAfterSpace = false;

            for (int i = 0; i < itemsHeld.Length - 1; i++)
            {
                if (itemsHeld[i] == "")
                {
                    // fjern item data når der ikke er flere af det item.
                    Shop.instance.selectedItem = null;

                    itemsHeld[i] = itemsHeld[i + 1];
                    itemsHeld[i + 1] = "";

                    numberOfItems[i] = numberOfItems[i + 1];
                    numberOfItems[i + 1] = 0;

                    if (itemsHeld[i] != "")
                    {
                        itemAfterSpace = true;
                    }
                }
            }
        }
    }

    public void AddItem(string itemToAdd)
    {
        int newItemPosition = 0;
        bool foundSpace = false;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if (itemsHeld[i] == "" || itemsHeld[i] == itemToAdd)
            {
                newItemPosition = i;
                i = itemsHeld.Length;
                foundSpace = true;
            }
        }

        if (foundSpace)
        {
            bool itemExist = false;
            for (int i = 0; i < referenceItems.Length; i++)
            {
                if (referenceItems[i].itemName == itemToAdd)
                {
                    itemExist = true;
                    i = referenceItems.Length;
                }
            }

            if (itemExist)
            {
                itemsHeld[newItemPosition] = itemToAdd;
                numberOfItems[newItemPosition]++;
            }
            else
            {
                Debug.LogError(itemToAdd + " Does Not Exist!!");
            }
        }

        GameMenu.instance.ShowItems();
    }

    public void RemoveItem(string itemToRemove)
    {
        bool foundItem = false;
        int itemPosition = 0;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if (itemsHeld[i] == itemToRemove)
            {
                foundItem = true;
                itemPosition = i;

                i = itemsHeld.Length;

            }
        }

        if (foundItem)
        {
            numberOfItems[itemPosition]--;

            if (numberOfItems[itemPosition] <= 0)
            {
                itemsHeld[itemPosition] = "";
            }
            GameMenu.instance.ShowItems();
        }
        else
        {
            Debug.LogError("Couldn't Find " + itemToRemove);
        }

    }

    public void SaveData()
    {
        PlayerPrefs.SetString("Current_Scene", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetFloat("Player_Position_x", PlayerController.instance.transform.position.x);
        PlayerPrefs.SetFloat("Player_Position_y", PlayerController.instance.transform.position.y);
        PlayerPrefs.SetFloat("Player_Position_z", PlayerController.instance.transform.position.z);

        //save character info
        for (int i = 0; i < playerStats.Length; i++)
        {
            if (playerStats[i].gameObject.activeInHierarchy)
            {
                PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_active", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_active", 0);
            }

            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_Level", playerStats[i].playerLevel);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_CurrentExp", playerStats[i].currentEXP);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_CurrentHP", playerStats[i].currentHP);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_MaxHP", playerStats[i].maxHP);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_CurrentMP", playerStats[i].currentMP);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_MaxMP", playerStats[i].maxMP);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_Strength", playerStats[i].strenght);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_AbilityPower", playerStats[i].abilityPower);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_Defence", playerStats[i].defence);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_MagicResist", playerStats[i].magicDefence);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_CritChance", playerStats[i].critChance);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_CritPower", playerStats[i].critPower);
            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_Speed", playerStats[i].speed);

            PlayerPrefs.SetInt("Player_" + playerStats[i].charName + "_Gold", currentGold);

            PlayerPrefs.SetString("Player_" + playerStats[i].charName + "_EquippedWpn", playerStats[i].equippedWpn);
            PlayerPrefs.SetString("Player_" + playerStats[i].charName + "_EquippedArmr", playerStats[i].equippedArmr);
            PlayerPrefs.SetString("Player_" + playerStats[i].charName + "_EquippedHead", playerStats[i].equippedHead);
            PlayerPrefs.SetString("Player_" + playerStats[i].charName + "_EquippedBoots", playerStats[i].equippedBoots);
            PlayerPrefs.SetString("Player_" + playerStats[i].charName + "_EquippedAccess1", playerStats[i].equippedAccess1);
            PlayerPrefs.SetString("Player_" + playerStats[i].charName + "_EquippedAccess2", playerStats[i].equippedAccess2);
            PlayerPrefs.SetString("Player_" + playerStats[i].charName + "_EquippedAccess3", playerStats[i].equippedAccess3);
            PlayerPrefs.SetString("Player_" + playerStats[i].charName + "_EquippedAccess4", playerStats[i].equippedAccess4);
            PlayerPrefs.SetString("Player_" + playerStats[i].charName + "_EquippedAccess5", playerStats[i].equippedAccess5);

        }

        // store inventory data
        for (int i = 0; i < itemsHeld.Length; i++)
        {
            PlayerPrefs.SetString("ItemInInventory_" + i, itemsHeld[i]);
            PlayerPrefs.SetInt("ItemAmount_" + i, numberOfItems[i]);
        }
    }

    public void LoadData()
    {
        PlayerController.instance.transform.position = new Vector3(PlayerPrefs.GetFloat("Player_Position_x"), PlayerPrefs.GetFloat("Player_Position_y"), PlayerPrefs.GetFloat("Player_Position_z"));

        for (int i = 0; i < playerStats.Length; i++)
        {
            if (PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_active") == 0)
            {
                playerStats[i].gameObject.SetActive(false);
            }
            else
            {
                playerStats[i].gameObject.SetActive(true);
            }

            playerStats[i].playerLevel = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_Level");
            playerStats[i].currentEXP = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_CurrentExp");
            playerStats[i].currentHP = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_CurrentHP");
            playerStats[i].maxHP = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_MaxHP");
            playerStats[i].currentMP = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_CurrentMP");
            playerStats[i].maxMP = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_MaxMP");
            playerStats[i].strenght = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_Strength");
            playerStats[i].abilityPower = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_AbilityPower");
            playerStats[i].defence = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_Defence");
            playerStats[i].magicDefence = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_MagicResist");
            playerStats[i].critChance = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_CritChance");
            playerStats[i].critPower = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_CritPower");
            playerStats[i].speed = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_Speed");

            currentGold = PlayerPrefs.GetInt("Player_" + playerStats[i].charName + "_Gold");

            playerStats[i].equippedWpn = PlayerPrefs.GetString("Player_" + playerStats[i].charName + "_EquippedWpn");
            playerStats[i].equippedArmr = PlayerPrefs.GetString("Player_" + playerStats[i].charName + "_EquippedArmr");
            playerStats[i].equippedHead = PlayerPrefs.GetString("Player_" + playerStats[i].charName + "_EquippedHead");
            playerStats[i].equippedBoots = PlayerPrefs.GetString("Player_" + playerStats[i].charName + "_EquippedBoots");
            playerStats[i].equippedAccess1 = PlayerPrefs.GetString("Player_" + playerStats[i].charName + "_EquippedAccess1");
            playerStats[i].equippedAccess2 = PlayerPrefs.GetString("Player_" + playerStats[i].charName + "_EquippedAccess2");
            playerStats[i].equippedAccess3 = PlayerPrefs.GetString("Player_" + playerStats[i].charName + "_EquippedAccess3");
            playerStats[i].equippedAccess4 = PlayerPrefs.GetString("Player_" + playerStats[i].charName + "_EquippedAccess4");
            playerStats[i].equippedAccess5 = PlayerPrefs.GetString("Player_" + playerStats[i].charName + "_EquippedAccess5");

        }

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            itemsHeld[i] = PlayerPrefs.GetString("ItemInInventory_" + i);
            numberOfItems[i] = PlayerPrefs.GetInt("ItemAmount_" + i);
        }
    }

}
