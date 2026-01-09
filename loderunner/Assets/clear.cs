using UnityEngine;

public class clear : MonoBehaviour
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
