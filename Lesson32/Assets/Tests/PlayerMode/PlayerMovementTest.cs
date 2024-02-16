using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest
{
    [UnityTest]
    public IEnumerator PlayerMovementTestWithEnumeratorPasses()
    {
        Player player = Object.Instantiate(Resources.Load<Player>("Player"));
        player.Setup(new TestInputAxis());
        float startPositionByX = player.transform.position.x;
        yield return new WaitForSeconds(5);
        Assert.IsTrue(player.transform.position.x > startPositionByX);
    }

    public class TestInputAxis : IInput
    {
        public Vector3 Direction => new Vector3(1, 0, 0);
    }
}
