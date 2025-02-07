using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private GameObject _ball;
    [SerializeField] private float _ballAcceleration;
    [SerializeField] private float _waitTime;

    private TextMeshPro _textMeshPro;
    private int[] _score = {0, 0};
    
    public int StartingPlayer { get; private set; } = 1;
    public float BallAcceleration { get => _ballAcceleration; }


    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        Debug.Log("Welcome to Pong !\nKeys:  Up  -  Down");
        Debug.Log("Left:  w   |   s\nRight:  ^   |   v");
        StartCoroutine(CreateNewBall());
    }


    public void Scored(int playerNumber)
    {
        string winningPlayer;

        if (playerNumber == 1) {
            StartingPlayer = 2;
            winningPlayer = "Left";
        }
        else if (playerNumber == 2) {
            StartingPlayer = 1;
            winningPlayer = "Right";
        }
        else {
            StartCoroutine(CreateNewBall());
            return;
        }

        _score[playerNumber - 1]++;
        _textMeshPro.text = $"Score : {_score[0]} - {_score[1]}";
        Debug.Log($"{winningPlayer} Player Scored !\nScore : {_score[0]} - {_score[1]}");

        if (_score[playerNumber - 1] > 10) {
            Debug.Log($"Game Over !\n{winningPlayer} Player Wins !");
            Debug.Log("Game Starts Again in 3 seconds !\nScore : 0 - 0");
            _textMeshPro.text = $"Score : 0 - 0";
            _score[0] = 0;
            _score[1] = 0;
        }

        StartCoroutine(CreateNewBall());
    }


    public IEnumerator CreateNewBall()
    {
        Debug.Log($"New Ball spaws in {_waitTime} seconds.");
        yield return new WaitForSeconds(_waitTime);
        Instantiate(_ball);
    }
}
