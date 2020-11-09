using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    void Start()
    {
        FindObjectOfType<QuestSystemScript>().Quests.Add(gameObject.name,this);
    }

    public bool questComplete = false;
    public void completeQuest()
    {
        if (questComplete)
            return;
        questComplete = true;
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().color = Color.green;

    }
}
