using System;
using Codice.CM.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace WeatherService.Runtime.Utils
{
    public static class UserLocation
    {
        public static async UniTask<(float _latitude, float _longitude)> Get()
        {
#if UNITY_ANDROID
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.CoarseLocation)) {
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.CoarseLocation);
        }

        if (!UnityEngine.Input.location.isEnabledByUser) {
            throw new Exception("Location services it not enabled, please enable");
        }

#elif UNITY_IOS
        if (!UnityEngine.Input.location.isEnabledByUser) {
throw new Exception("Location services it not enabled, please enable");
        }
#endif
           
            Input.location.Start(500f, 500f);
            
            int maxWait = 15;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                await UniTask.WaitForSeconds(1);
                maxWait--;
            }
            
#if UNITY_EDITOR
            return (Random.Range(1f, 35f), Random.Range(1f, 35f));
#endif
            
            if (maxWait < 1)
            {
                throw new Exception("Timieout");
            }

            if (Input.location.status != LocationServiceStatus.Running)
            {
                throw new Exception($"Unable to determine device location. Failed with status {Input.location.status}");
            }

            var _latitude = Input.location.lastData.latitude;
            var _longitude = Input.location.lastData.longitude;


            Input.location.Stop();

            return (_latitude, _longitude);
        }
    }
}