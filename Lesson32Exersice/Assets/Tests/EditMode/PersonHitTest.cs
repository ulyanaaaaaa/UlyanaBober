using NUnit.Framework;
using UnityEngine;


public class PersonHitTest
{
    [Test]
    public void PersonHitTestSimplePasses()
    {
        Person person = new Person();
        person.Hit(50);
        Assert.AreEqual(50, person.Health);
    }
    
    [Test]
    public void CreatePersonTest()
    {
        Person player = new Person();
        Person enemy = new Person();
        Assert.AreEqual(player.EnemyPerson, enemy);
    }
    
    [Test]
    public void DiePersonTest()
    {
        Person person = new Person();
        person.Hit(100);
        //Assert.AreEqual(person.EnemyPerson.Die(), );
    }
}
