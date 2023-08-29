using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EditModeTest
{
    [Test]
    public void PlayerHasRB2D()
    {
        // Use the Assert class to test conditions
        var gameObject = MonoBehaviour.
            Instantiate(Resources.Load<GameObject>("Player"));

        bool doesExist = false;

        if (gameObject.GetComponent<Rigidbody2D>() != null)
        {
            doesExist= true;
        }

        Assert.AreEqual(true, doesExist);
    }


    [Test]
    public void PlayerHasMoveSpeed()
    {
        var gameObject = MonoBehaviour.
            Instantiate(Resources.Load<GameObject>("Player"));

        float moveSpeed = gameObject.GetComponent<Move>().speed;

        Assert.AreEqual(true, moveSpeed > 0);

    }
}
