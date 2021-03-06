﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using TV_App.DataTransferObjects;
using TV_App.Models;
using WebPush;


namespace TV_App.Services
{
    public class PushService
    {
        private const string PUBLIC_KEY = @"BJmJ27fKmbkzBH7XkeJWzmEdqtRM8S4SpV6btWP6IlwUwmNgiLCg63az0JYWbL7HR4ah6BVVhiyniAMAAaPfu3w";
        private const string PRIVATE_KEY = @"2dU0c_kb2Dk2Xn96JsaxVkvQyxSz_Ckxg9pQ9XtWOzA";
        private const string SUBJECT = @"https://www.lookingglass.gq";
        private readonly TvAppContext db = new TvAppContext();

        public void Notify(User user, string title, string body)
        {
            

            foreach (Subscription s in user.Subscriptions)
            {
                var subscription = new PushSubscription(s.PushEndpoint, s.PushP256dh, s.PushAuth);
                var vapidDetails = new VapidDetails(SUBJECT, PUBLIC_KEY, PRIVATE_KEY);
                var payload = new MessageDTO(title, body);
                var webPushClient = new WebPushClient();
                LogService.Log($"Notification to {user.Login}: {title} - {body}");
                try
                {
                    webPushClient.SendNotification(subscription, JsonConvert.SerializeObject(payload), vapidDetails);
                }
                catch(WebPushException e)
                {
                    LogService.Log($"Error - {e.Message}");
                }
            }
        }
    }
}
