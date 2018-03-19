using UnityEngine;
using System.Collections;

public class Config  {

#if UNITY_IPHONE
     public static string adsID = "ca-app-pub-2127327600096597/2080016787";
	public static string adsInID = "ca-app-pub-2127327600096597/6252509167";


#endif

#if UNITY_ANDROID

                         public static string adsID = "ca-app-pub-3940256099942544/6300978111";
	public static string adsInID = "ca-app-pub-3940256099942544/1033173712";


#endif

}
