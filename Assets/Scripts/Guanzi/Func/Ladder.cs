using System.Collections;
using GrayCity.Control.Movement._Scripts;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed = 5f; // 爬梯子的速度
    private PlayerMovement playerMovement;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (playerMovement == null)
        {
            playerMovement = other.GetComponent<PlayerMovement>();
        }
        if (other.CompareTag("Player"))
        {
            playerMovement.IsClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (playerMovement == null)
        {
            playerMovement = other.GetComponent<PlayerMovement>();
        }
        if (other.CompareTag("Player"))
        {
            playerMovement.IsClimbing = false;
            other.transform.position += new Vector3(0,0.1f,0);
        }
    }
}