using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    public Animator npcAnim;
    public GameObject npc;
    public static NPCController instance;

    public string npcName;

    public bool activateOtherNPC;
    public GameObject npcToActivate;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;


    }

    // Update is called once per frame
    void Update()
    {



    }

    //public void JiraiyaSmokeScreenEvent()
    //{
    //    npcAnim.SetBool("ActivateSmokeScreen", true);

    //    npcAnim.SetBool("SetInactive", true);

    //}

    public IEnumerator JiraiyaSmokeScreenEventCo()
    {
        npcAnim.SetBool("ActivateSmokeScreen", true);

        GameManager.instance.dialogActive = true;

        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);

        GameManager.instance.dialogActive = false;

        if (activateOtherNPC)
        {
            npcToActivate.SetActive(true);
        }

        GameManager.instance.guidetalkedTo = true;
    }


}
