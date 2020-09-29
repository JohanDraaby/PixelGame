using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public string[] questMarkerNames;
    public bool[] questActive;
    public bool[] questMarkersComplete;
    public bool[] collectedRewards;

    public static QuestManager instance;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        questMarkersComplete = new bool[questMarkerNames.Length];
        questActive = new bool[questMarkerNames.Length];
        collectedRewards = new bool[questMarkerNames.Length];

    }

    // Update is called once per frame
    void Update()
    {


        // Quest Debugging
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Debug.Log(CheckIfComplete("Quest Test"));
        //    MarkQuestComplete("Quest Test");
        //    //MarkQuestIncomplete("Fight The Demon");
        //}

        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    SaveQuestData();
        //}

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    LoadQuestData();
        //}

    }

    public int GetQuestNumber(string questToFind)
    {
        for (int i = 0; i < questMarkerNames.Length; i++)
        {
            if (questMarkerNames[i] == questToFind)
            {
                return i;
            }
        }

        Debug.LogError("Quest " + questToFind + " Does Not Exist");
        return 0;

    }

    public bool CheckIfComplete(string questToCheck)
    {
        if (GetQuestNumber(questToCheck) != 0)
        {
            return questMarkersComplete[GetQuestNumber(questToCheck)];
        }


        return false;
    }


    public void MarkQuestComplete(string questToMark)
    {
        questMarkersComplete[GetQuestNumber(questToMark)] = true;
        questActive[GetQuestNumber(questToMark)] = false;
        //collectedRewards[GetQuestNumber(questToMark)] = true;

        UpdateLocalQuestObjects();
    }

    public void MarkQuestActive(string questToMark)
    {
        questActive[GetQuestNumber(questToMark)] = true;

        UpdateLocalQuestObjects();
    }

    public void MarkQuestClaimedReward(string questToMark)
    {
        collectedRewards[GetQuestNumber(questToMark)] = true;

        UpdateLocalQuestObjects();
    }

    //public void MarkQuestIncomplete(string questToMark)
    //{
    //    questMarkersComplete[GetQuestNumber(questToMark)] = false;


    //    UpdateLocalQuestObjects();
    //}

    public void UpdateLocalQuestObjects()
    {
        QuestObjectActivator[] questObjects = FindObjectsOfType<QuestObjectActivator>();

        if (questObjects.Length > 0)
        {
            for (int i = 0; i < questObjects.Length; i++)
            {
                questObjects[i].CheckCompletion();
            }
        }
    }

    public void SaveQuestData()
    {
        for (int i = 0; i < questMarkerNames.Length; i++)
        {
            if (questMarkersComplete[i])
            {
                PlayerPrefs.SetInt("QuestMarker_" + questMarkerNames[i], 1);
            }
            else
            {
                PlayerPrefs.SetInt("QuestMarker_" + questMarkerNames[i], 0);
            }
        }
    }

    public void LoadQuestData()
    {
        for (int i = 0; i < questMarkerNames.Length; i++)
        {
            int valueToSet = 0;

            if (PlayerPrefs.HasKey("QuestMarker_" + questMarkerNames[i]))
            {
                valueToSet = PlayerPrefs.GetInt("QuestMarker_" + questMarkerNames[i]);
            }

            if (valueToSet == 0)
            {
                questMarkersComplete[i] = false;
            }
            else
            {
                questMarkersComplete[i] = true;
            }
        }
    }

}
