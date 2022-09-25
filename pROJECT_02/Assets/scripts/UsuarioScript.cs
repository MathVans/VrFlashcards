using Assets.scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsuarioScript : MonoBehaviour
{
    public class Root
    {

        public int user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool active { get; set; }
        public string password { get; set; }
        public DateTime created_date { get; set; }
        public List<Cheap.Result> cheaps { get; set; }
   
  
    }



}
