using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI highScoreText;
    void Start()
    {
        GameState.LoadHighScore();
        string topScorer = GameState.topScorer;
        int topScore = GameState.topScore;
        highScoreText.text = "HighScore:" + topScorer + " " + topScore;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
    public void SetScorerName()
    {
        TMP_InputField text = GameObject.Find("EnterName").GetComponent<TMP_InputField>();
        GameState.Scorer = text.text.ToString();
    }
}
