using UnityEngine;

public class Clear : MonoBehaviour
{
    public float clearpoint = 3;
    public GameObject targetobject;
    public Pointgetplayer pointgetplayer;
    void Update()
    {
        if (pointgetplayer.pointnow == clearpoint)
        {
            targetobject.SetActive(true);
        }
    }
}
