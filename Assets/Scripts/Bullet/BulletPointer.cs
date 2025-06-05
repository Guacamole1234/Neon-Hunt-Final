using UnityEngine;

public class BulletPointer : MonoBehaviour
{
    public GameObject target;
    Vector3 directionWanted;

    private void FixedUpdate()
    {
        if (target != null)
        {
            directionWanted = target.transform.position;
            directionWanted.y += 3f;
            transform.LookAt(directionWanted);
        }
    }
}
