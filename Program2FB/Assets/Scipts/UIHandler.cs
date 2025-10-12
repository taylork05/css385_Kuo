using UnityEngine;
using TMPro;


public class UIHandler : MonoBehaviour
{

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private Vector3 _playerStartPosition = Vector3.zero;

    [SerializeField]
    private GameObject _menuUI;

    [SerializeField]
    private TextMeshProUGUI _scoreText, _highScoreText;

    private PlayerController _playerController;
    private int _highScore = 0;

    private void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        _scoreText.text = _playerController.getScore.ToString();

        if(_playerController.getScore > _highScore)
        {
            _highScore = _playerController.getScore;
            _highScoreText.text = _highScore.ToString();
        }
    }

    public void OnStartPress()
    {
        _player.SetActive(true);
        _player.transform.position = _playerStartPosition;
        _menuUI.SetActive(false);
    }

}
