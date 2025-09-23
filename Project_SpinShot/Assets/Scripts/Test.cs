using UnityEngine;

public class Test : MonoBehaviour
{
    public int frameCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        Debug.Log(frameCount);
    }
}
