using UnityEngine;

public class AwakeTest : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log($"[Awake] {gameObject.name}");
    }
    private void Start()
    {
        Debug.Log($"[Start] {gameObject.name}");
    }
}
