using NUnit.Framework;

public class PersonHitTest
{
    [Test]
    public void CreatePersonTest()
    {
        Person player = new Person();
        Person enemy = new Person();
        Assert.AreEqual(player.EnemyPerson, enemy);
    }
}
