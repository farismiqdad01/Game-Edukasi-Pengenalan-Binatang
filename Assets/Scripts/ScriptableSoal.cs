using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableSoal", menuName = "GameEdukasi/ScriptableSoal")]
public class ScriptableSoal : ScriptableObject
{
    [TextArea(3, 10)]
    public string soal1, soal2, soal3, soal4;
    // public Sprite soal1_gambar, soal2_gambar, soal3_gambar, soal4_gambar;
    // public Sprite hewan1, hewan2, hewan3, hewan4, hewan5;
    // public Sprite makanan1, makanan2, makanan3, makanan4, makanan5;
}

