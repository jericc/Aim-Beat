using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private GameManager gameManager; 

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        CompareScores();
    }

    private void CompareScores()
    {
        if (gameObject.CompareTag("Blue"))
        {
            gameManager.IncreaseScore(1);
        }

        if (gameObject.CompareTag("Green"))
        {
            gameManager.IncreaseScore(3);
        }
    }
}
