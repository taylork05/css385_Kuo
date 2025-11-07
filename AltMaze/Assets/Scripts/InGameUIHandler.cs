using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InGameUIHandler : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public GameObject WinMenuCanvas;
    public GameObject InGameCanvas;

    [SerializeField]
    private TextMeshProUGUI _collectInt;
    [SerializeField]
    private TextMeshProUGUI _collectInt2;

    private PlayerHandler _playerHandler;


    private void Start()
    {
        _playerHandler = FindFirstObjectByType<PlayerHandler>();

    }

    public void onPausePressed()
    {
        PauseMenuCanvas.SetActive(true);
        WinMenuCanvas.SetActive(false);
        InGameCanvas.SetActive(false);

        _playerHandler.OnDisable();
    }

    public void onContinuePressed()
    {
        WinMenuCanvas.SetActive(false);
        PauseMenuCanvas.SetActive(false);
        InGameCanvas.SetActive(true);

        _playerHandler.OnEnable();
    }

    public void gameOver()
    {
        PauseMenuCanvas.SetActive(false);
        WinMenuCanvas.SetActive(true);
        InGameCanvas.SetActive(false);

    }

    public void selectLevelPressed()
    {
        PauseMenuCanvas.SetActive(false);
        WinMenuCanvas.SetActive(false);
        InGameCanvas.SetActive(false);

    }

    public void onBackPresseed()
    {
        PauseMenuCanvas.SetActive(false);
        WinMenuCanvas.SetActive(true);
        InGameCanvas.SetActive(false);

    }


    public void mainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }


    private void Update()
    {
        _collectInt.text = _playerHandler.getCollected().ToString();
        _collectInt2.text = _playerHandler.getCollected().ToString();
    }

}
