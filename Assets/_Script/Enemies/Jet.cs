using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : Enemy {
    public override string GetName()
    {
        return "Jet";
    }

    public override Sprite GetSprite()
    {
        return Resources.Load("_Sprites/Ships/shpsall_2") as Sprite;
        
    }

    public override int GetHealthPoints()
    {
        return 50;
    }
}
