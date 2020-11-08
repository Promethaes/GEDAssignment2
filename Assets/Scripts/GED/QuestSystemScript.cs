using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystemScript : MonoBehaviour
{
    public List<Quest> editorList = new List<Quest>();
    public Dictionary<string, Quest> Quests = new Dictionary<string, Quest>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var q in editorList)
            Quests.Add(q.gameObject.name, q);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendCompleteEvent(string questName)
    {
        foreach (var quest in Quests)
            if (quest.Key == questName)
                quest.Value.completeQuest();
    }
}
