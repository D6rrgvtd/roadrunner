using UnityEngine;
using UnityEngine.SceneManagement;

public class clearseen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Result"))
        {
            SceneManager.LoadScene("Result");
        }
    }
}
