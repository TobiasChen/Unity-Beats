using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy
{
    public abstract string GetName();
    public abstract Sprite GetSprite();
    public abstract int GetHealthPoints();
}
