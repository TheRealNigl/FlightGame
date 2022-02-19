///// Title of class:
/////     Person
///// Description:
/////     AWS user registeration
/////
///// Author: Alex Nigl


//using UnityEngine;
//using System;

//[Obsolete]
//public class Person : MonoBehaviour
//{
//    public static Person Instance;

//    private string Name
//    {
//        get;
//        set;
//    }

//    private string Username
//    {
//        get;
//        set;
//    }

//    private string Password
//    {
//        get;
//        set;
//    }

//    private bool NewUser
//    {
//        get;
//        set;
//    }

//    private void Start()
//    {

//    }

//    public Person(string name, string username, string password, bool newUser)
//    {

//        if(NewUser)
//        {
//            PromptNewUser(name, username, password, newUser);
//        }
//        else
//        {
//            Login(name, username, password, newUser);
//        }
//    }

//    private void PromptNewUser(string name, string username, string password, bool newUser)
//    {

//    }

//    private void Login(string name, string username, string password, bool newUser)
//    {
//        NewUser = newUser;
//        Name = name;
//        Username = username;
//        Password = password;
//    }
//}