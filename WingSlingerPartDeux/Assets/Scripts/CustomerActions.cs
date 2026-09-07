using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CustomerActions : MonoBehaviour
{
    private enum CustomerState
    {
        WaitingToBeSeated,
        WalkingToTable,
        Seated,
        WaitingToOrder,
        ReadyToOrder,
        Eating,
        Done
    }

    private CustomerState currentState;

    [SerializeField] ClickMovement clickMovement;
    [SerializeField] private GameObject ExclamationPoint;

    public UnityEvent orderPlaced;

    public void CustomerOrders()
    {
        Debug.Log(clickMovement.customerIsSitting);
        if (clickMovement.customerIsSitting)
        {
            StartCoroutine(OrderWaitTime());
        }
    }
    IEnumerator OrderWaitTime()
    {
        yield return new WaitForSeconds(5);
        ExclamationPoint.SetActive(true);
        Debug.Log("I'm ready to order");
        orderPlaced.Invoke();
    }

    private void SeatAtTable()
    {
        currentState = CustomerState.WaitingToBeSeated;
    }
}
