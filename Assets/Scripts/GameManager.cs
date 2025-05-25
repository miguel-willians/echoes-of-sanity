using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreHUD;

    [SerializeField]
    private TMP_Text _timeHUD;

    [SerializeField]
    private string _nextSceneName = "EndingScene";

    [SerializeField]
    private float _startTime = 3f;

    private int _score;
    private float _currentTime;
    private bool _isGameOver;

    private void Start()
    {
        _currentTime = _startTime;
    }

    private void Update()
    {
        if (_isGameOver)
        {
            return;
        }

        if (_currentTime < 0)
        {
            SetGameOver();
        }

        _currentTime -= Time.deltaTime;
        _timeHUD.text = $"Time: {_currentTime:0.00}";
    }

    public void AddPoints(int amount)
    {
        _score += amount;
        _scoreHUD.text = $"Score: {_score}";
    }

    public void DepletePoints(int amount)
    {
        _score -= amount;
        _scoreHUD.text = $"Score: {_score}";
    }

    private void SetGameOver()
    {
        _isGameOver = true;
        SceneManager.LoadScene(_nextSceneName);
    }
}
