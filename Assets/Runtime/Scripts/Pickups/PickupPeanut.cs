public class PickupPeanut : Pickup
{
    protected override void ExecutePickupBehaviour(in PlayerCollisionInfo collisionInfo)
    {
        // collisionInfo.GameMode.OnCherryPickedUp();
    }
}
