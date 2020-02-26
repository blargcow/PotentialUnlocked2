
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemPickUpMiniGame : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        loadScene();
        
    }

    void loadScene()
    {
        Debug.Log("Pick up item " + item.name + " to load scene");
        SceneManager.LoadScene("Test_project");

    }
}
