﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FietsLibrary.JSONObjecten
{
    [Serializable]
    public class User
    {

        public string id { get; private set; }
        public string password { get; private set; }
        public List<Session> tests { get; private set; }
        public int age { get; private set; }
        public bool gender { get; private set; }
        public int weight { get; private set; }

        public bool isDoctor { get; private set; }

        public User()
        {

        }

        //Create Patient
        public User(string id, string password, int age, bool gender, int weight)
        {
            this.id = id;
            this.password = password;
            this.tests = new List<Session>();
            this.age = age;
            this.gender = gender;
            this.weight = weight;
            this.isDoctor = false;
        }

        //Create Patient or Doctor
        public User(string id, string password, int age, bool gender, int weight, bool isDoctor)
        {
            this.id = id;
            this.password = password;
            this.tests = new List<Session>();
            this.age = age;
            this.gender = gender;
            this.weight = weight;
            this.isDoctor = isDoctor;
        }

        public void AddSession(Session session)
        {
            tests.Add(session);
        }

        public List<Session> GetSessions()
        {
            return tests;
        }
    }
}
