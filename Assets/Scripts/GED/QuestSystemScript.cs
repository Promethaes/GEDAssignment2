using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystemScript : MonoBehaviour
{
    public GameObject tutorialCompleteText;
    public Dictionary<string, Quest> Quests = new Dictionary<string, Quest>();
    // Start is called before the first frame update
    void Start()
    {
    }

    bool switchToGameScene = false;
    float timer = 1.0f;
    // Update is called once per frame
    void Update()
    {
        if (switchToGameScene)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game Scene");
                FindObjectOfType<CharMenuInput>().gameObject.transform.position = new Vector3(361.0f, 25.0f, 246.0f);
                switchToGameScene = false;
            }
        }
    }

    public void SendCompleteEvent(string questName)
    {
        foreach (var quest in Quests)
        {
            if (quest.Key == questName)
                quest.Value.completeQuest();
        }

        bool allComplete = true;
        foreach (var q in Quests)
        {
            if (!q.Value.questComplete)
                allComplete = false;
        }
        if (allComplete)
        {
            tutorialCompleteText.SetActive(true);
            switchToGameScene = true;
        }
    }
}
