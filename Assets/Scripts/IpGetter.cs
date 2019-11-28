using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpGetter {
    public string ip = "";

    public string GetIp() {

        try {
            string host = System.Net.Dns.GetHostName();

            System.Net.IPAddress[] addr_arr = System.Net.Dns.GetHostAddresses(host);

            foreach (System.Net.IPAddress addr in addr_arr) {
                string addr_str = addr.ToString();

                if (addr_str.IndexOf(".") > 0 && !addr_str.StartsWith("127.")) {
                    ip = addr_str;
                    break;
                }
            }
        }
        catch {
            ip = "";
        }

        return ip;
    }
}