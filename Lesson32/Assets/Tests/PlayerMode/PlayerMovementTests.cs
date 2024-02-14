using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTests
{
    [UnityTest]
    public IEnumerator PlayerMovementTestsWithEnumeratorPasses()
    {
        Player player = Object.Instantiate(Resources.Load<Player>("Player"));
        //player.Setup(new TestInputAxis);
        float startPositionByX = player.transform.position.x;
        

        yield return null;
    }
}
