using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerParametersInGame
{
    public static bool IsFaceRight = true;
    public static Transform PlayerTransform;
    public static PlayerControl_v2 PlayerControlV2;
    public static Weapon Weapon;
    public static GameObject RespawnArrow;

    public static void SetParameters(Transform playerTransform, PlayerControl_v2 playerControlV2)
    {
        IsFaceRight = true;
        PlayerTransform = playerTransform;
        PlayerControlV2 = playerControlV2;
        Weapon = null;
        RespawnArrow = null;
    }
}
