using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModeTests
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator SafeZoneShrinkWorks()
    {
        var safeZone = MonoBehaviour.
            Instantiate(Resources.Load<GameObject>("RedSafeZone"), 
            new Vector3(0, 0, 0), Quaternion.identity);

        

        float safeZoneSize = safeZone.GetComponent<SizeChange>().scale;
        safeZone.GetComponent<SizeChange>().shrink();
        yield return null;

        Assert.AreEqual(false, 
            safeZoneSize.Equals(safeZone.GetComponent<SizeChange>().scale));

    }

    [UnityTest]
    public IEnumerator SafeZoneSwellWorks()
    {
        var safeZone = MonoBehaviour.
            Instantiate(Resources.Load<GameObject>("RedSafeZone"),
            new Vector3(0, 0, 0), Quaternion.identity);



        float safeZoneSize = safeZone.GetComponent<SizeChange>().scale;
        safeZone.GetComponent<SizeChange>().swell();
        yield return null;

        Assert.AreEqual(false,
            safeZoneSize.Equals(safeZone.GetComponent<SizeChange>().scale));

    }

    [UnityTest]
    public IEnumerator SafeZoneMoves()
    {
        // Use the Assert class to test conditions
        var gameObject = MonoBehaviour.
            Instantiate(Resources.Load<GameObject>("RedSafeZone"));

        Vector3 startPosition = gameObject.transform.position;

        gameObject.GetComponent<SafeZoneMovement>().maxSpeed = 5f; 

        yield return new WaitForSeconds(1f);

        Vector3 endPosition = gameObject.transform.position;

        Assert.AreEqual(false, startPosition.Equals(endPosition));
    }


    [UnityTest]
    public IEnumerator BulletMoves()
    {
        // Use the Assert class to test conditions
        var gameObject = MonoBehaviour.
            Instantiate(Resources.Load<GameObject>("Bullet"));

        Vector3 startPosition = gameObject.transform.position;

        yield return new WaitForSeconds(1f);

        Vector3 endPosition = gameObject.transform.position;

        Assert.AreEqual(false, startPosition.Equals(endPosition));
    }


}
