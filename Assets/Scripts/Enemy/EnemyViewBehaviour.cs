using UnityEngine;

public class EnemyViewBehaviour : MonoBehaviour
{
    bool caught = false;

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.CompareTag("Player") && !caught)
            {
                caught = true;
                GeneralController.instance.playerWon = false;
                GeneralController.instance.StartRestart();
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}
