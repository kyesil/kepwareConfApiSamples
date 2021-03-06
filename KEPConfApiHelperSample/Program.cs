﻿using RestSharp;
using RestSharp.Authenticators;
using System;
using KEPConfApiHelper;
using System.Collections.Generic;

namespace MyKEPConfApiSample
{
    class Program
    {
 

        static void Main(string[] args)
        {
            KepConfApiH.kepConfApiUrl = "http://192.168.1.22:57412";
            KepConfApiH.kepAuth = new HttpBasicAuthenticator("Administrator", "");

            Console.WriteLine("Ch:" + KepConfApiH.getChListJson());Console.ReadLine();
            Console.WriteLine("Devs:" + KepConfApiH.getDevListJson("13006")); Console.ReadLine();
            Console.WriteLine("Tags:" + KepConfApiH.getTagListJson("13006","1")); Console.ReadLine();

            var template = new KepModbusTemplate();

            var x = KepConfApiH.createCh(template,"mych");//results:  201:created //400:err //200:ok/deleted

            KepConfApiH.createDev(template,"mych", "mydev", "<5.26.130.81>.1", "35001");

            KepConfApiH.createTags(template,"mych", "mydev", new List<Tuple<string, string, int>>() {
                new Tuple<string, string, int>("mytag1", "404031", 5),
                new Tuple<string, string, int>("mytag2", "404032", 5)
            });

            Console.ReadLine();

            KepConfApiH.deleteTag("mych", "mydev", "mytag1");
            KepConfApiH.deleteDev("mych", "mydev");
            KepConfApiH.deleteCh("mych");
            Console.ReadLine();

        }


       

    }
}
