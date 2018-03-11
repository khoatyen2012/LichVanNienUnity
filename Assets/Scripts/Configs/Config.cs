using UnityEngine;
using System.Collections;

public class Config  {

#if UNITY_IPHONE
       public static string adsID = "ca-app-pub-2127327600096597/8097963269";
    public static string adsInID = "ca-app-pub-2127327600096597/2550957266";


#endif

#if UNITY_ANDROID

    public static string adsID = "ca-app-pub-3940256099942544/630097811";
    public static string adsInID = "ca-app-pub-3940256099942544/1033173712";


#endif

}
