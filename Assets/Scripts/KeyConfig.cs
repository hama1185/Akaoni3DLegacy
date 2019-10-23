using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConfig {
    static string moveH = "StickL_H";
    static string moveV = "StickL_V";
    static string viewH = "StickR_H";
    static string viewV = "StickR_V";

    public static (string moveH, string moveV, string viewH, string viewV) SetKeyConfig() {
        return (moveH : moveH, moveV : moveV, viewH : viewH, viewV : viewV);
    }
}