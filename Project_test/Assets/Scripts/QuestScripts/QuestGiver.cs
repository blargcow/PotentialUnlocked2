using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : Interactable
{
    public DialogueParts dialoguepart;
    public Text chat;
    public bool questAssigned;
    public bool questCompleted;
    public GameObject quests;
    public string questType;
    public Quest quest { get; set; }

    public GameObject questUI;
    public Text questTitle;
    public Text questDescription;


    void Start()
    {
        ID = 1;
    }
    public override void Interact()
    {
        
        if (!questAssigned && !questCompleted)
        {
            base.Interact();
            AssignQuest();
        }
        else if(questAssigned && !questCompleted)
        {
            FindObjectOfType<DialogueManager>().setPart(3);
            TriggerDialogue();
            checkQuest();
            
        }

        else
        {
            FindObjectOfType<DialogueManager>().setPart(4);
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        
        FindObjectOfType<DialogueManager>().StartDialogue(dialoguepart); 
        

    }

    public void AssignQuest()
    {
        hasInteracted = true;
        questAssigned = true;
        quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
        FindObjectOfType<DialogueManager>().setPart(1);

        TriggerDialogue(); 
        
        Debug.Log(quest.reward);
        //createUI();
    }

    public void createUI()
    {
        questUI.SetActive(true);
        questTitle.text = quest.QuestName;
        questDescription.text = quest.Description;
        
    }

    public void checkQuest()
    {
        questTitle.text = quest.QuestName;
        questDescription.text = quest.Description;
        if (quest.completed)
        {
            FindObjectOfType<DialogueManager>().setPart(2);
            TriggerDialogue();
            questUI.SetActive(false);
            quest.GiveReward();
            questCompleted = true;
            questAssigned = false;
            Debug.Log("Quest Finished");
            hasInteracted = false;
        }
    }

    private void Update()
    {
        if (isFocus && !hasInteracted && !questCompleted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;

            }
            else
            {
                hasInteracted = true;
            }
        }
        if (hasInteracted && !questCompleted)
        {
            createUI();
        }
        else
        {
            questUI.SetActive(false);
        }
    }

}
