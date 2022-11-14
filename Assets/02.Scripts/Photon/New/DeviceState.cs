using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum PhoneControlMode
{
    PhoneSwipe,
    PhoneGyro,
    GlassesGyro
}

enum Furniture
{
    Chair,
    Table,
    SmallSofa,
    BigSofa
}

enum InteractionSpace
{
    Phone,
    NearHand,
    World
}

struct DeviceState
{
    public static PhoneControlMode phoneControlMode;
    public static bool isGazeOnObject;
    public static bool isGenerateObjectButtonPressed;
    public static Vector3 swipeDelta;
    public static Vector3 gyroDelta;
    public static Furniture furniture;
    public static InteractionSpace interactionSpace;
}