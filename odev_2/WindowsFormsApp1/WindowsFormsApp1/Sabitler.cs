using FireSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
///////////////////////////////////
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using WindowsFormsApp1;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.VisualBasic.ApplicationServices;

public class Sabitler
{
    public static List<string> sehirler = new List<string>();
    // Color modeIsDark = Color.Black;
    public static bool modeIsDark;

    /// <summary>
    /// ///////////////////////////////////////////////////////////////////
    /// </summary>
    public static async void veriYazmaAsync()
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "pvvzhzxSTE9XFCcHuA0iHUNvDiO9o8zTiFF9c5cU",
            BasePath = "https://csharpproje-933d0-default-rtdb.firebaseio.com/"
        };
        FirebaseClient firebaseClient = new FirebaseClient(config);
        Console.WriteLine("******************************" + config);
        var data1 = new Data
        {
            modeIsDark = modeIsDark,
            Cities = sehirler,
        };
        SetResponse response = await firebaseClient.SetAsync("myData/1", data1);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            Console.WriteLine("Veri başarıyla yazıldı.");
        }
        else
        {
            Console.WriteLine("Veri yazma hatası: " + response.Body);
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////
    /// </summary>
    public static async void veriOkumaAsync()
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "pvvzhzxSTE9XFCcHuA0iHUNvDiO9o8zTiFF9c5cU",
            BasePath = "https://csharpproje-933d0-default-rtdb.firebaseio.com/"
        };
        FirebaseClient firebaseClient = new FirebaseClient(config);
        FirebaseResponse response = await firebaseClient.GetAsync("myData/1");

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var data = response.ResultAs<dynamic>();
            string city = data.city;
            string mode = data.modeIsDark;
            var s = data.Cities;
            Console.WriteLine($"City: {city}");
            Console.WriteLine($"Mode: {mode}");
            Console.WriteLine($"Cities: {s[0]}");

        }
        else
        {
            Console.WriteLine("Veri okuma hatası: " + response.Body);
        }
    }


    public static async void yazSehirler(List<string> c)
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "pvvzhzxSTE9XFCcHuA0iHUNvDiO9o8zTiFF9c5cU",
            BasePath = "https://csharpproje-933d0-default-rtdb.firebaseio.com/"
        };
        FirebaseClient firebaseClient = new FirebaseClient(config);
        //Console.WriteLine("******************************" + config);
        var data1 = new Data
        {
            //modeIsDark = modeIsDark,
            //city = "kastamonu",
            Cities = c,
        };
        SetResponse response = await firebaseClient.SetAsync("myData/1", data1);

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            Console.WriteLine("Veri başarıyla yazıldı.");
        }
        else
        {
            Console.WriteLine("Veri yazma hatası: " + response.Body);
        }
    }
    public static async void okuSehirler()
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "pvvzhzxSTE9XFCcHuA0iHUNvDiO9o8zTiFF9c5cU",
            BasePath = "https://csharpproje-933d0-default-rtdb.firebaseio.com/"
        };
        FirebaseClient firebaseClient = new FirebaseClient(config);
        FirebaseResponse response = await firebaseClient.GetAsync("myData/1");

        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var data = response.ResultAs<dynamic>();

            if (data.Cities != null)
            {
                JArray citiesArray = data.Cities;
                List<string> cityList = citiesArray.ToObject<List<string>>();
                sehirler = cityList;
            }

        }
        else
        {
            Console.WriteLine("Veri okuma hatası: " + response.Body);
        }


    }
    /// görevler /// 
    /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 

    public static async void guncelleGorev(string key, string yeniGorev, string yeniDetay, string yeniTarih, string yeniSaat, bool isChecked)
    {
        var config = new FirebaseConfig
        {
            AuthSecret = "pvvzhzxSTE9XFCcHuA0iHUNvDiO9o8zTiFF9c5cU",
            BasePath = "https://csharpproje-933d0-default-rtdb.firebaseio.com/"
        };

        using (var firebaseClient = new FirebaseClient(config))
        {
            var data = new gorevData
            {
                gorev = yeniGorev,
                detay = yeniDetay,
                date = yeniTarih,
                time = yeniSaat,
                Checked = isChecked
            };
            SetResponse response = await firebaseClient.SetAsync("myData/" + key, data);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Veri başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Veri güncelleme hatası: " + response.Body);
            }
        }
    }


    public static async void ekleGorev(string g, string d, string tarih, string saat, string myId)
    {
        var config = new FirebaseConfig
        {
            AuthSecret = "pvvzhzxSTE9XFCcHuA0iHUNvDiO9o8zTiFF9c5cU",
            BasePath = "https://csharpproje-933d0-default-rtdb.firebaseio.com/"
        };

        using (var firebaseClient = new FirebaseClient(config))
        {
            var data2 = new gorevData
            {
                gorev = g,
                detay = d,
                date = tarih,
                time = saat,
            };
            var my_user = new userData
            {
                my_user = myId,
            };
            FirebaseResponse response2 = await firebaseClient.PushAsync("myUsers/", my_user);
            FirebaseResponse response = await firebaseClient.SetAsync("myData/" + myId, data2);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Veri başarıyla yazıldı.");
            }
            else
            {
                Console.WriteLine("Veri yazma hatası: " + response.Body);
            }
        }
    }
  
    public static async Task<List<string>> getIds()
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "pvvzhzxSTE9XFCcHuA0iHUNvDiO9o8zTiFF9c5cU",
            BasePath = "https://csharpproje-933d0-default-rtdb.firebaseio.com/"
        };
        FirebaseClient firebaseClient = new FirebaseClient(config);
        FirebaseResponse firebaseResponse = await firebaseClient.GetAsync("myUsers");
        if (firebaseResponse.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var u = firebaseResponse.ResultAs<Dictionary<string, dynamic>>();
            List<string> userList = new List<string>();

            if (u != null)
            {
                foreach (var childNode in u)
                {
                    if (childNode.Value.my_user != null)
                    {
                        string x1 = childNode.Value.my_user;
                        if (!userList.Contains(x1))
                        {
                            userList.Add(x1);
                        }
                    }
                }
            }

            return userList;
        }
        else
        {
            Console.WriteLine("Veri okuma hatası: " + firebaseResponse.Body);
            return null;
        }
    }

    // Console.WriteLine("users is: " + childNode.Key);

    public static async Task<(string, string, string, string, bool)> okuGorev(string item)
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "pvvzhzxSTE9XFCcHuA0iHUNvDiO9o8zTiFF9c5cU",
            BasePath = "https://csharpproje-933d0-default-rtdb.firebaseio.com/"
        };
        FirebaseClient firebaseClient = new FirebaseClient(config);
        FirebaseResponse response = await firebaseClient.GetAsync("myData/" + item);
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var data = response.ResultAs<dynamic>();
            string x1 = data.gorev;
            string x2 = data.detay;
            string x3 = data.date;
            string x4 = data.time;
            bool x5 = data.Checked;


            return (x1, x2, x3, x4, x5);
        }
        else
        {

            Console.WriteLine("Veri okuma hatası: " + response.Body);
            return (null, null, null, null, false);
        }
    }
    public static async Task<int> ElemanSayisiniGetir()
    {
        var config = new FirebaseConfig
        {
            AuthSecret = "pvvzhzxSTE9XFCcHuA0iHUNvDiO9o8zTiFF9c5cU",
            BasePath = "https://csharpproje-933d0-default-rtdb.firebaseio.com/"
        };

        using (var firebaseClient = new FirebaseClient(config))
        {
            FirebaseResponse response = await firebaseClient.GetAsync("myData");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = JsonConvert.DeserializeObject<List<gorevData>>(response.Body);
                int elemanSayisi = data.Count;
                return elemanSayisi;
            }
            else
            {
                Console.WriteLine("Eleman sayısı alınamadı. Hata: " + response.Body);
                return -1; // Hata durumunda -1 döndürebilirsiniz veya hata durumunu uygun şekilde işleyebilirsiniz.
            }
        }
    }



    public static async void silGorev(string deleteId)
    {
        var config = new FirebaseConfig
        {
            AuthSecret = "pvvzhzxSTE9XFCcHuA0iHUNvDiO9o8zTiFF9c5cU",
            BasePath = "https://csharpproje-933d0-default-rtdb.firebaseio.com/"
        };

        using (var firebaseClient = new FirebaseClient(config))
        {
            string deleteId2;
            FirebaseResponse response = await firebaseClient.DeleteAsync("myData/" + deleteId);
          

            FirebaseResponse getDataResponse = await firebaseClient.GetAsync("myUsers");
            if (getDataResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = getDataResponse.ResultAs<Dictionary<string, dynamic>>();

                if (data != null)
                {
                    foreach (var childNode in data)
                    {
                        if (childNode.Value.my_user != null)
                        {
                            string x1 = childNode.Value.my_user;
                            string x2 = childNode.Key;
                            if (x1== deleteId)
                            {
                                Console.WriteLine(x1);
                                Console.WriteLine(x2);
                                deleteId2 = childNode.Key;
                                 FirebaseResponse response2 = await firebaseClient.DeleteAsync("myUsers/" + deleteId2);
                                break;
                            }
                        }
                    }
                }

            }
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Veri başarıyla silindi");
            }
            else
            {
                Console.WriteLine("Veri silme hatası: " + response.Body);
            }
       
        }
    }
}

