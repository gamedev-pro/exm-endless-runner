using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour_Magnet : PowerUpBehaviour
{
    [SerializeField] private float attractSpeed = 8;
    [SerializeField] private float scaleSpeed = 2;

    [SerializeField] private float finalScaleMultipler = 0.3f;
    [SerializeField] private Vector3 attractionBox = Vector3.one * 10;

    private List<Pickup> pickupsToAttract = new List<Pickup>();
    private Collider[] overlapResults = new Collider[20];

    public void Activate(float duration)
    {
        ActivateForDuration(duration);
    }

    protected override void EndBehaviour()
    {

    }

    protected override void StartBehaviour()
    {
        pickupsToAttract.Clear();
    }

    protected override void UpdateBehaviour()
    {
        GatherPickupsInRange();
        foreach (Pickup pickup in pickupsToAttract)
        {
            if (pickup != null)
            {
                Vector3 startPos = pickup.transform.position;
                Vector3 endPos = transform.position;
                pickup.transform.position = Vector3.MoveTowards(startPos, endPos, Time.deltaTime * attractSpeed);

                Vector3 startScale = pickup.transform.localScale;
                Vector3 endScale = Vector3.one * finalScaleMultipler;
                pickup.transform.localScale = Vector3.MoveTowards(startScale, endScale, Time.deltaTime * scaleSpeed);
            }
        }
    }


    private void GatherPickupsInRange()
    {
        int overlapCount = Physics.OverlapBoxNonAlloc(transform.position, attractionBox, overlapResults);
        for (int i = 0; i < overlapCount; i++)
        {
            Pickup pickup = overlapResults[i].GetComponent<Pickup>();
            if (pickup != null &&
                pickup != this &&
                !(pickup is PowerUp) &&
                !pickupsToAttract.Contains(pickup))
            {
                pickupsToAttract.Add(pickup);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, attractionBox);
    }
}