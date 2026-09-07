using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] public Transform seatPosition;
    [SerializeField] public Transform orderPosition;
    [SerializeField] public bool playerFacesLeft;
    public bool isOccupied;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isOccupied = false;
    }
}
