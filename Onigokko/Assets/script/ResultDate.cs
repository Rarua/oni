using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public readonly static Data Instance = new Data();

    public List<bool> score = new List<bool>();
}