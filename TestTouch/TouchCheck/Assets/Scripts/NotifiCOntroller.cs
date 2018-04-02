using UnityEngine;
using System.Collections;
using System;

using UnityEngine.iOS.NotificationServices;
using UnityEngine.iOS.NotificationType;

public class NotifiCOntroller : MonoBehaviour {

	public tk2dUIItem btnContinute;


	public void btnContinute_OnClick()
	{
		ScheduleNotificationForiOSWithMessage ("Xem The Nao");
	}

	void ScheduleNotificationForiOSWithMessage (string text)
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			UnityEngine.iOS.LocalNotification notification = new UnityEngine.iOS.LocalNotification ();
			notification.fireDate =DateTime.Now.AddSeconds(5); 
			notification.alertAction = "Alert";
			notification.alertBody = text;
			notification.hasAction = false;
			UnityEngine.iOS.NotificationServices.ScheduleLocalNotification (notification);

			#if UNITY_IOS
			NotificationServices.RegisterForLocalNotificationTypes (LocalNotificationType.Alert | LocalNotificationType.Badge);
			#endif
		}   


	}

	// Use this for initialization
	void Start () {
		btnContinute.OnClick += btnContinute_OnClick;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
