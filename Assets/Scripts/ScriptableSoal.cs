using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableSoal", menuName = "GameEdukasi/ScriptableSoal")]
public class ScriptableSoal : ScriptableObject
{
    [TextArea(3, 10)]
    public string soal1, soal2, soal3, soal4;
    public Sprite soal1_gambar, soal2_gambar, soal3_gambar, soal4_gambar;
}

