using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CustomerActions : MonoBehaviour
{
    private enum CustomerState
    {
        WaitingToBeSeated,
        Seated,
        WaitingToOrder,
        ReadyToOrder,
        Eating,
        Done
    }

    private CustomerState currentState;

    [SerializeField] ClickMovement clickMovement;
    [SerializeField] private GameObject ExclamationPoint;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Customer;

    public UnityEvent orderPlaced;

    //IEnumerator OrderWaitTime()
    //{
    //    yield return new WaitForSeconds(5);
    //    ExclamationPoint.SetActive(true);
    //    Debug.Log("I'm ready to order");
    //    orderPlaced.Invoke();
    //}

    public void SeatAtTable(Table table)
    {
        if (currentState != CustomerState.WaitingToBeSeated) return;
        currentState = CustomerState.Seated;
        Customer.transform.position = table.seatPosition.position;
    }
}
