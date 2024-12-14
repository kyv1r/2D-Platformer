using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    private void Update()
    {
        transform.parent.localScale = transform.parent.localScale.x == -1 ? transform.localScale = new Vector3(-1, 1, 1) : transform.localScale = new Vector3(1, 1, 1);
    }
}
