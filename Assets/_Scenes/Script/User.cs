using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LoginUser
{
    public int id;
    public string password;

    public LoginUser()
    {
        password = "";
    }
}
