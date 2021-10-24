using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCherry : Pickup
{
    protected override void ExecutePickupBehaviour(in PlayerCollisionInfo collisionInfo)
    {
        collisionInfo.GameMode.OnCherryPickedUp();
    }
}
