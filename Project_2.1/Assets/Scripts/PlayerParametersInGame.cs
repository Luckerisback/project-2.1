using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerParametersInGame
{
    public static bool IsFaceRight = true;
    public static Transform PlayerTransform;

    public static void SetParameters(Transform playerTransform)
    {
        IsFaceRight = true;
        PlayerTransform = playerTransform;
    }
}
