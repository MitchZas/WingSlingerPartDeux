using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class ClickMovement : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Customer;
    [SerializeField] GameObject Table;
    [SerializeField] GameObject Table1Position;

    private bool customerClicked;

    void Start()
    {
        customerClicked = false;
    }

    public void MoveTowardsCustomer(GameObject clickedObject)
    {
        if (!clickedObject.CompareTag("Customer")) return;

        Player.transform.position = new Vector3(-0.6f, 1.22f, 0);
        customerClicked = true;
        Debug.Log(customerClicked);
    }

    public void CustomerToTable(GameObject clickedObject)
    {
        if (!clickedObject.CompareTag("Table")) return;

        if (customerClicked = true && clickedObject == Table)
        {
            Customer.transform.position = Table1Position.transform.position;
        }
    }

    //public List<GameObject> tableList = new List<GameObject>();
}
