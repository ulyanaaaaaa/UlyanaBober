using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

public class PlayerHealthTest
{
    [Test]
    public void PlayerHealthTestSimplePasses()
    {
        Player player = new Player();
        Assert.AreEqual(player.Health, 10);
    }
}
