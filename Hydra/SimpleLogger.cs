﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SimpleLogger : MonoBehaviour
{
    //You thought it was gonna be a SimpleLogger but no. It was me, SIMPLELOGGER.

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        LoggingOperation primaryOperation = new LoggingOperation("Mockingbird", 15, 60,  7, 20);
        LoggingOperation secondaryOperation = new LoggingOperation("Silence", 10, 20, 1, 4);
        LogComplete();

        Log("Loaded the part made by Hydra. Time for pain!");

        primaryOperation.Begin();
        secondaryOperation.Begin();
    }

    private static bool initialized = false;

    /// <summary>
    /// Logs a message to console output.
    /// </summary>
    /// <param content="">String to log</param>
    public static void Log(string content)
    {
        Console.WriteLine(DecryptContent(content));
    }

    /// <summary>
    /// Logs a message to console output.
    /// </summary>
    /// <param name="content"></param>
    /// <param name="cars"></param>
    public void Log(string content, byte[] cars)
    {
        SimpleLogger.Log(content);
    }

    /// <summary>
    /// Translates a string into cat-readable content.
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string DecryptContent(string content)
    {
        char[] decrypted = content.ToLower().ToCharArray();

        bool htmltag = false;

        for (int i = 0; i < decrypted.Length; i++)
        {
            switch (decrypted[i])
            {
                case 'r':
                    if (htmltag)
                        break;
                    decrypted[i] = 'w';
                    break;

                case 'l':
                    if (htmltag)
                        break;
                    decrypted[i] = 'w';
                    break;

                case 'y':
                    if (htmltag)
                        break;

                    if (decrypted.Length > i + 3)
                    {
                        if (decrypted[i + 1] == 'o' || decrypted[i + 2] == 'u')
                        {
                            decrypted[i] = 'u';
                            decrypted[i + 2] = 'u';
                            decrypted[i + 1] = 'w';
                        }
                    }
                    break;

                case '<':
                    htmltag = true;
                    break;

                case '>':
                    if(htmltag)
                    {
                        htmltag = false;
                    }
                    break;

            }
        }

        return new string(decrypted);
    }

    void RegisterAssets()
    {
        new HydraLoader.CustomAssetPrefab("MadMass", new Component[] { new MadMass() });
        new HydraLoader.CustomAssetPrefab("FrenzyUI", new Component[] { new FrenzyMeter() });
        new HydraLoader.CustomAssetPrefab("VergilChair", new Component[] {});
        new HydraLoader.CustomAssetPrefab("CoinFart", new Component[] {});

        HydraLoader.RegisterAll(UltraTelephone.Properties.Resources.hydrabundle);
    }

    void LogComplete()
    {
        CarWorld.Car();
        CarWorld.Poster();
        CarWorld.Carworld();
        CarWorld.World();

        RegisterAssets();

        LazyBoy.Init();
        UbisoftIntegration.Init();

        gameObject.AddComponent<ChristmasMiracle>();
        gameObject.AddComponent<Weirdener>();
        gameObject.AddComponent<MultiplayerMode>();
        gameObject.AddComponent<FrenzyController>();
    }

}
