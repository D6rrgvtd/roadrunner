using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Point : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        GameObject otherObj = collision.gameObject;

        
        Pointgetplayer playerScript = otherObj.GetComponent<Pointgetplayer>();

        if (playerScript != null)
        {
           
            playerScript.AddPointAndLog();

           
            Destroy(gameObject);
        }
       
    }

}
