using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isBusy;

    public bool IsBusy() { return isBusy; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isBusy = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBusy (bool value)
    {
        isBusy = value;
    }
}
