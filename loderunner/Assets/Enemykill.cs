using UnityEngine;

public class Enemykill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.CompareTag("Enemy"))
        {
            
            Destroy(this.gameObject);
        }
    }
}
