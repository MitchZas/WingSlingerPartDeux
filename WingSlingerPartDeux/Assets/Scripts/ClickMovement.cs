using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class ClickMovement : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] CustomerActions CustomerActions;

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
        Table table = clickedObject.GetComponent<Table>();
        CustomerActions.SeatAtTable(table);
    }
    public void ServerToTable(GameObject clickedObject)
    {
        if (!clickedObject.CompareTag("Table")) return;
        Table table = clickedObject.GetComponent<Table>();
        CustomerActions.TakeOrder(table);
    }
}
