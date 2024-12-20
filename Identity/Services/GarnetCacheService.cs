﻿using Application.Contracts.Identity;
using Garnet.client;
using Identity.Models.DTO;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Identity.Services
{
    public class GarnetCacheService : IGarnetCacheService
    {
        private readonly GarnetConfiguration _g;

        private readonly ConfigurationOptions co;

        public GarnetCacheService(IOptions<GarnetConfiguration> garnetConfiguration)
        {

            _g = garnetConfiguration.Value;

            co = new ConfigurationOptions()
            {
                SyncTimeout = 500000,
                EndPoints =
                {
                    {_g.Address, _g.Port }
                },
                AbortOnConnectFail = false 
            };
        }

        public async Task Clear(string key)
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());

            await db.ConnectAsync();

            if (await Contains(db, key))
            {
                await db.KeyDeleteAsync(key);
            }
        }

        public async void ClearAll()
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());

            await db.ConnectAsync();
            
            await db.ExecuteForStringResultAsync("FLUSHDB");
        }

        public async Task<string> GetValueAsync(string key)
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());

            await db.ConnectAsync();

            return await db.StringGetAsync(key);
        }

        public async Task<bool> SetValueAsync(string key, string value)
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());

            await db.ConnectAsync();

            await db.StringSetAsync(key, value);



            string check = await db.StringGetAsync(key);

            if (check == value)
            {
                return true;
            }
            return false;
        }

        public async Task<List<string>> GetList(string key)
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());

            await db.ConnectAsync();

            var list = await db.ListRangeAsync(key, 0, -1);

            return list.ToList();
        }

        public async Task AppendListAsync(string key, string element)
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());

            await db.ConnectAsync();

            await db.ListRightPushAsync(key, element);
        }

        public async Task<bool> RemoveFromList(string key, string element)
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());

            await db.ConnectAsync();

            bool isRemove = int.Parse(await db.ExecuteForStringResultAsync("LREM", new string[] { key, "0", element })) == 1 ? true : false;

            return isRemove;
        }

        public async Task AddHashSet(string key, string field, string value)
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());

            await db.ConnectAsync();

            await db.ExecuteForStringResultAsync("HSET", new string[] { key, field, value });
        }

        public async Task<string> GetHashSet(string key, string field)
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());

            await db.ConnectAsync();

            string value = await db.ExecuteForStringResultAsync("HGET", new string[] { key, field });

            return value;
        }


        public async Task RemoveFieldHashSet(string key, string field)
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());
            await db.ConnectAsync();
            await db.ExecuteForStringResultAsync("HDEL", new string[] { key, field });
        }

        public async Task<Dictionary<string, string>?> GetAllHashSet (string key)
        {

            try
            {
                using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());
                await db.ConnectAsync();

                string[] hashArray = await db.ExecuteForStringArrayResultAsync("HGETALL", new string[] { key });

                if (hashArray.Length > 0)
                {
                    Dictionary<string, string> hash = new Dictionary<string, string>();
                    for (int i = 0; i < hashArray.Length; i += 2)
                    {
                        hash.Add(hashArray[i], hashArray[(i + 1)]);
                    }

                    return hash;
                }

            }
            catch(Exception ex)
            {
                var test = ex.Message.ToString();
            }
            return null;
            
        }

        public async Task<HashScanResult> HashScan(string key, string[] matchPatterns, int count)
        {
            using var redis = ConnectionMultiplexer.Connect(co);
            var db = redis.GetDatabase(0);

            HashScanResult hsResult = new HashScanResult
            {
                Length = 0,
                Hash = new Dictionary<string, string>(),
                IsSuccess = false,
            };

            foreach (var pattern in matchPatterns)
            {
                var result = await db.ExecuteAsync("HSCAN", key, "0", "MATCH", pattern, "COUNT", count.ToString());
                
                if (!result.IsNull && result.Length > 0)
                {
                    hsResult.Length += result.Length;

                    string?[]? hashArray = ((string?[]?)result[1]);

                    if (hashArray is not null && hashArray.Length > 0 && hashArray.Length % 2 == 0)
                    {
                        for (int i = 0; i < hashArray.Length; i += 2)
                        {
                            hsResult.Hash.Add(hashArray[i]!, hashArray[(i + 1)]!);
                        }

                        hsResult.IsSuccess = true;
                    }
                }

            }

            return hsResult;

        }

        public async Task Scan(string matchPattern, int count)
        {
            using var db = new GarnetClient(_g.Address, _g.Port, GetSslOpts());
            await db.ConnectAsync();


            string[] hashArray =  await db.ExecuteForStringArrayResultAsync("SSCAN", new string[] { 0.ToString(), "MATCH", matchPattern, "COUNT", count.ToString()});

            var test2 = 0;
        }

        private async Task<bool> Contains(GarnetClient db, string key)
        {
            bool exist = int.Parse(await db.ExecuteForStringResultAsync("EXISTS", new string[] { key })) == 1 ? true : false;
            return exist;
        }
        SslClientAuthenticationOptions GetSslOpts() => _g.UseTLS ? new()
        {
            ClientCertificates = [new X509Certificate2("testcert.pfx", "placeholder")],
            TargetHost = "GarnetTest",
            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
        } : null;

        
    }
}
