using UnityEngine;
using UnityEngine.Events;

public class ClickMovement : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Customer;

    private bool customerClicked;

    void Start()
    {
        customerClicked = false;
    }

    public void MoveTowardsCustomer()
    {
        Player.transform.position = new Vector3(-0.6f, 1.22f, 0);
        customerClicked = true;
    }

    public void CustomerToTable()
    {
        if (customerClicked)
        {
            Debug.Log("Bring me to a table!");
        }
    }
}
