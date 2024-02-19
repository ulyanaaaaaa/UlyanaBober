using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PersonHitTests
{
    [UnityTest]
    public IEnumerator PersonHitTestsWithEnumeratorPasses()
    {
        Person person = Object.Instantiate(Resources.Load<Person>("RedPerson"));
        Person enemyPerson = Object.Instantiate(Resources.Load<Person>("RedPerson"));
        person.EnemyPerson = enemyPerson;
        person.Hit(50);
        Assert.AreEqual(50f,person.EnemyPerson.Health);
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator PersonDieTestsWithEnumeratorPasses()
    {
        Person person = Object.Instantiate(Resources.Load<Person>("RedPerson"));
        Person enemyPerson = Object.Instantiate(Resources.Load<Person>("RedPerson"));
        person.EnemyPerson = enemyPerson;
        int a = 0;
        while (a < 5)
        {
            yield return new WaitForSeconds(2);
            person.Hit(50);
            a++;
        }
        Assert.IsTrue(person.EnemyPerson.Health <= 0);
    }
}
