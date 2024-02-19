using UnityEngine;

public class FastEnemy : Enemy
{
    public override void Hit()
    {
        SmallBall ball = Instantiate(Resources.Load<SmallBall>("SmallBall"), transform.position, Quaternion.identity);
        ball.Fly(transform.forward, _force);
    }
}
