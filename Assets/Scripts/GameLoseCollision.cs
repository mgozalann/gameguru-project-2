using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoseCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameLose();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
