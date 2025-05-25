using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _titleText;

    [SerializeField]
    private string _nextSceneName = "GameplayScene";


    public void StartGameAction()
    {
        SceneManager.LoadScene(_nextSceneName);
    }

}
