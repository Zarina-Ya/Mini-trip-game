using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct LocalisationData
{
    public string _id;
    public string EN;
    public string FR;
    public string RU;
  
    public string CheckLenq(string val)
    {
        if (val.Equals("EN"))
            return this.EN;
        else if (val.Equals("FR"))
            return this.FR;
        else
            return this.RU;
    }
  
}
