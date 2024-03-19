using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoDmgCDScript : MonoBehaviour
{
    private static Boolean hasDamaged = false;
    private static float cooldownTimer = 0f;

    public static Boolean IsOnCooldown()
    {
        if (cooldownTimer != 0 && Time.time - cooldownTimer > 3)
        {
            hasDamaged = false;
        }

        if (!hasDamaged)
        {
            cooldownTimer = Time.time;
            Debug.Log(cooldownTimer);
            hasDamaged = true;
            return false;
        }
        return true;
    }
}
