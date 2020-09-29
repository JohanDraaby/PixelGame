using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{

    public string[] mainDialog;
    public string[] startQuestDialog;
    public string[] activeQuestDialog;
    public string[] questCompleteDialog;
    public string[] afterQuestDialog;

    public bool hasQuest, questActive, questComplete;

    public bool firstTalkAfterQuest;


    public bool shouldActivateQuest;
    public string questToActivate;
    public string questToUnlockThisQuest;
    public int goldToGive;
    public string[] itemsToGive;
    public int expToGive;

    private bool canActivate;

    public bool isPerson = true;





    //public bool markComplete;




    public bool shouldTriggerEvent;



    // Start is called before the first frame update
    void Start()
    {


    }






    // Update is called once per frame
    void Update()
    {

        if (questToActivate != null)
        {
            if (QuestManager.instance.questActive[QuestManager.instance.GetQuestNumber(questToActivate)] == true)
            {
                hasQuest = false;
                questActive = true;
            }
            else if (QuestManager.instance.questMarkersComplete[QuestManager.instance.GetQuestNumber(questToActivate)] == true)
            {
                questActive = false;
                hasQuest = false;
                questComplete = true;

            }

            if (QuestManager.instance.collectedRewards[QuestManager.instance.GetQuestNumber(questToActivate)])
            {
                firstTalkAfterQuest = true;
            }
        }





        if (!GameManager.instance.dialogActive)
        {
            if (canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogBox.activeInHierarchy)
            {

                if (QuestManager.instance.questMarkersComplete[QuestManager.instance.GetQuestNumber(questToUnlockThisQuest)] == false && questToUnlockThisQuest != "")
                {
                    DialogManager.instance.ShowDialog(mainDialog, isPerson);
                }
                else if (hasQuest)
                {
                    DialogManager.instance.ShowDialog(startQuestDialog, isPerson);
                    hasQuest = false;
                    questActive = true;
                }
                else if (questActive)
                {
                    DialogManager.instance.ShowDialog(activeQuestDialog, isPerson);
                }
                else if (questComplete && firstTalkAfterQuest == false)
                {
                    DialogManager.instance.ShowDialog(questCompleteDialog, isPerson);
                    QuestManager.instance.MarkQuestClaimedReward(questToActivate);


                    // reward here
                    BattleReward.instance.OpenRewardScreen(expToGive, itemsToGive, goldToGive);


                    firstTalkAfterQuest = true;
                }
                else if (questComplete && firstTalkAfterQuest)
                {
                    DialogManager.instance.ShowDialog(afterQuestDialog, isPerson);
                }






                //if (hasQuest)
                //{
                //    DialogManager.instance.ShowDialog(startQuestDialog, isPerson);
                //    hasQuest = false;
                //    questActive = true;
                //}
                //else if (questActive)
                //{
                //    DialogManager.instance.ShowDialog(activeQuestDialog, isPerson);
                //}
                //else if (questComplete && firstTalkAfterQuest == false)
                //{
                //    DialogManager.instance.ShowDialog(questCompleteDialog, isPerson);
                //    QuestManager.instance.MarkQuestClaimedReward(questToActivate);


                //    // reward here
                //    BattleReward.instance.OpenRewardScreen(expToGive, itemsToGive, goldToGive);


                //    firstTalkAfterQuest = true;
                //}
                //else if (questComplete && firstTalkAfterQuest)
                //{
                //    DialogManager.instance.ShowDialog(afterQuestDialog, isPerson);
                //}
                //else
                //{
                //    DialogManager.instance.ShowDialog(mainDialog, isPerson);
                //}





                if (shouldActivateQuest)
                {
                    DialogManager.instance.ShouldActivateQuestAtEnd(questToActivate, questActive, firstTalkAfterQuest);
                }




                if (shouldTriggerEvent)
                {
                    DialogManager.instance.ShouldActivateEventAtEnd();
                }
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canActivate = false;
        }
    }
}
