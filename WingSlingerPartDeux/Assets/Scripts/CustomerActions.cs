using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

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
    [SerializeField] private GameObject OrderPic;
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
        if (currentState != CustomerState.ReadyToOrder) return;
        if (player.IsBusy()) return;
        PlayerChar.transform.position = table.orderPosition.position;
        FlipPlayerSprite(table);
        ExclamationPoint.SetActive(false);
        player.SetBusy(true);
        StartCoroutine(ShowOrderPic());
        player.SetBusy(false);
        // Bring to counter & drop off order
    }

    IEnumerator ShowOrderPic()
    {
        yield return new WaitForSeconds(2f);
        OrderPic.SetActive(true);
    }

    private void FlipPlayerSprite(Table table)
    {
        if (table.playerFacesLeft)
        {
            playerSpriteRenderer.flipX = true;
        }
        else
        {
            playerSpriteRenderer.flipX = false;
        }
    }
}
