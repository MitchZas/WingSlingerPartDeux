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
    [SerializeField] Player player;
    [SerializeField] private GameObject ExclamationPoint;
    [SerializeField] GameObject PlayerChar;
    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] GameObject Customer;

    public UnityEvent orderPlaced;

    IEnumerator OrderWaitTime()
    {
        currentState = CustomerState.WaitingToOrder;
        yield return new WaitForSeconds(5);
        ExclamationPoint.SetActive(true);
        currentState = CustomerState.ReadyToOrder;
        //Debug.Log("I'm ready to order");
        //orderPlaced.Invoke();
    }

    public void SeatAtTable(Table table)
    {
        if (currentState != CustomerState.WaitingToBeSeated) return;
        currentState = CustomerState.Seated;
        Customer.transform.position = table.seatPosition.position;
        StartCoroutine(OrderWaitTime());
    }
    public void TakeOrder(Table table)
    {
        Debug.Log($"State: {currentState}, Busy: {player.IsBusy()}");
        if (currentState != CustomerState.ReadyToOrder) return;
        if (player.IsBusy()) return;
        PlayerChar.transform.position = table.orderPosition.position;
        if (table.playerFacesLeft) playerSpriteRenderer.flipX = true;
        ExclamationPoint.SetActive(false);
        player.SetBusy(true);
        
        // Put Order above Player's Head
        // Bring to counter & drop off order
        //player.isBusy = false;
    }
}
