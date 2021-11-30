using UnityEngine;

public class Target : MonoBehaviour
{
    void OnMouseDown() 
    {
        RecapEvents.current.TargetHit();
        Destroy(this.gameObject);
    }
}
