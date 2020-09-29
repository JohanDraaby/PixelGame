using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleReward : MonoBehaviour
{

    public static BattleReward instance;

    public Text xpText, itemText, goldText;
    public GameObject rewardScreen;

    public string[] rewardItems;
    public int xpEarned;
    public int goldEarned;

    public bool markQuestComplete;
    public string questToMark;

    // Start is called before the first frame update
    void Start()
    {

        instance = this;



    }

    // Update is called once per frame
    void Update()
    {
        // uncomment for debbing of reward system
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    OpenRewardScreen(54, new string[] { "Iron Sword", "Iron Armor" }, 2);
        //}



    }

    public void OpenRewardScreen(int xp, string[] rewards, int gold)
    {
        xpEarned = xp;
        rewardItems = rewards;
        goldEarned = gold;

        xpText.text = "You Earned " + xpEarned + " xp!";
        goldText.text = "You Earned " + goldEarned + " Gold!";
        itemText.text = "";

        for (int i = 0; i < rewardItems.Length; i++)
        {
            itemText.text += rewards[i] + "\n";
        }

        rewardScreen.SetActive(true);
    }

    public void CloseRewardScreen()
    {
        for (int i = 0; i < GameManager.instance.playerStats.Length; i++)
        {
            if (GameManager.instance.playerStats[i].gameObject.activeInHierarchy)
            {
                GameManager.instance.playerStats[i].AddExp(xpEarned);
            }
        }

        for (int i = 0; i < rewardItems.Length; i++)
        {
            GameManager.instance.AddItem(rewardItems[i]);
        }

        rewardScreen.SetActive(false);
        GameManager.instance.battleActive = false;
        GameManager.instance.currentGold += goldEarned;

        if (QuestManager.instance.questActive[QuestManager.instance.GetQuestNumber(questToMark)])
        {
            QuestManager.instance.MarkQuestComplete(questToMark);
            //QuestManager.instance.MarkQuestClaimedReward(questToMark);
        }
    }


}
