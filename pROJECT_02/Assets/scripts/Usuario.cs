using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Root
{
    //public int count { get; set; }
    //public object next { get; set; }
    //public object previous { get; set; }
    public List<Result> results { get; set; }
}

[Serializable]
public class Result
{
    public int id { get; set; }
    public string order { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public bool active { get; set; }
    public string password { get; set; }
    public DateTime created_date { get; set; }
}