using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject selectLevelCanvas;
    public GameObject tutorialCanvas;



    void Start()
    {
        if (FindFirstObjectByType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem", typeof(EventSystem));
            eventSystem.AddComponent<InputSystemUIInputModule>(); // if using the New Input System
        }

        MainMenuCanvas.SetActive(true);
        selectLevelCanvas.SetActive(false);
    }


    public void OnStartPressed()
    {
        SceneManager.LoadScene("GameScene"); // exact name of your game scene
    
    }

    public void selectLevelPressed()
    {
        MainMenuCanvas.SetActive(false);
        selectLevelCanvas.SetActive(true);
        tutorialCanvas.SetActive(false);
    }

    public void onBackPresseed()
    {
        MainMenuCanvas.SetActive(true);
        selectLevelCanvas.SetActive(false);
        tutorialCanvas.SetActive(false);

    }

    public void onTutorialPressed()
    {
        MainMenuCanvas.SetActive(false);
        selectLevelCanvas.SetActive(false);
        tutorialCanvas.SetActive(true);

    }

}
