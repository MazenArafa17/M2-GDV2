using UnityEngine;

public class Target : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Target Hit!");
}
}
