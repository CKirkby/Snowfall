using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 5.0f;

    private InputAction MoveAction;
    private Camera MainCamera;
    
    public ScoreManager ScoreManager;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainCamera = Camera.main;
        MoveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MoveValue = MoveAction.ReadValue<Vector2>();
        transform.Translate(new Vector2(MoveValue.x, 0) * (MovementSpeed * Time.deltaTime), Space.World);
    }

    private void LateUpdate()
    {
        // Convert the object's position into viewport space (0–1)
        Vector3 pos = MainCamera.WorldToViewportPoint(transform.position);

        // Clamp values so object stays in the screen
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);

        // Convert back to world space
        transform.position = MainCamera.ViewportToWorldPoint(pos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        int CurrentHighScore = PlayerPrefs.GetInt("Highscore");
        int TotalScore = ScoreManager.GetScore();

        if (TotalScore > CurrentHighScore)
        {
             PlayerPrefs.SetInt("Highscore", TotalScore);
        }
        
        yield return new WaitForSeconds(0.2f);
        
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
