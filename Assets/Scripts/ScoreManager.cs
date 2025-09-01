using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int Score;
    public TextMeshProUGUI ScoreText;
    public GameObject MainMenu;
    public GameObject MainUI;
    public TextMeshProUGUI HighscoreText;
    
    private void Awake()
    {
        MainUI.SetActive(false);
        
        HighscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
    }
    
    public void AddScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
        
        ScoreText.text = Score.ToString();
    }
    
    public int GetScore()
    {
        return Score;
    }

    public void ActivateUI()
    {
        MainMenu.SetActive(false);
        MainUI.SetActive(true);
    }
}
