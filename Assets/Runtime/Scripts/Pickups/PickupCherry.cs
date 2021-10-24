public class PickupCherry : Pickup
{
    protected override void ExecutePickupBehaviour(in PlayerCollisionInfo collisionInfo)
    {
        collisionInfo.GameMode.CherriesPicked++;
    }
}
