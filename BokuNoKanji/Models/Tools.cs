using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokuNoKanji.Models
{
    public static class Tools
    {
        public static string ToHiraGana(string str)
        {
            str = str.ToLower();

            #region Main

            // K line
            str = str.Replace("ka", "か")
                     .Replace("ki", "き")
                     .Replace("ku", "く")
                     .Replace("ke", "け")
                     .Replace("ko", "こ");

            // S line
            str = str.Replace("sa", "さ")
                     .Replace("shi", "し")
                     .Replace("su", "す")
                     .Replace("se", "せ")
                     .Replace("so", "そ");

            // T line
            str = str.Replace("ta", "た")
                     .Replace("chi", "ち")
                     .Replace("tsu", "つ")
                     .Replace("te", "て")
                     .Replace("to", "と");

            // N line
            str = str.Replace("na", "な")
                     .Replace("ni", "に")
                     .Replace("nu", "ぬ")
                     .Replace("ne", "ね")
                     .Replace("no", "の");

            // H line
            str = str.Replace("ha", "は")
                     .Replace("hi", "ひ")
                     .Replace("fu", "ふ")
                     .Replace("he", "へ")
                     .Replace("ho", "ほ");

            // M line
            str = str.Replace("ma", "ま")
                     .Replace("mi", "み")
                     .Replace("mu", "む")
                     .Replace("me", "め")
                     .Replace("mo", "も");

            // Y line
            str = str.Replace("ya", "や")
                     .Replace("yu", "ゆ")
                     .Replace("yo", "よ");

            // R line
            str = str.Replace("ra", "ら")
                     .Replace("ri", "り")
                     .Replace("ru", "る")
                     .Replace("re", "れ")
                     .Replace("ro", "ろ");

            // W line
            str = str.Replace("wa", "わ")
                     .Replace("wo", "を");

            // Special
            str = str.Replace("n", "ん");

            #endregion

            #region Dakuten
            // Dakuten
            str = str.Replace("ga", "が")
                     .Replace("gi", "ぎ")
                     .Replace("gu", "ぐ")
                     .Replace("ge", "げ")
                     .Replace("go", "ご");

            str = str.Replace("za", "ざ")
                     .Replace("ji", "じ")
                     .Replace("zu", "ず")
                     .Replace("ze", "ぜ")
                     .Replace("zo", "ぞ");

            str = str.Replace("da", "だ")
                     .Replace("de", "で")
                     .Replace("do", "ど")
                     .Replace("dji", "ぢ") // rare
                     .Replace("dzu", "づ"); // rare

            str = str.Replace("ba", "ば")
                     .Replace("bi", "び")
                     .Replace("bu", "ぶ")
                     .Replace("be", "べ")
                     .Replace("bo", "ぼ");

            // Handakuten
            str = str.Replace("pa", "ぱ")
                     .Replace("pi", "ぴ")
                     .Replace("pu", "ぷ")
                     .Replace("pe", "ぺ")
                     .Replace("po", "ぽ");

            #endregion

            #region Yoon
            // Yōon combos (small ya/yu/yo)
            str = str.Replace("kya", "きゃ")
                     .Replace("kyu", "きゅ")
                     .Replace("kyo", "きょ");

            str = str.Replace("sha", "しゃ")
                     .Replace("shu", "しゅ")
                     .Replace("sho", "しょ");

            str = str.Replace("cha", "ちゃ")
                     .Replace("chu", "ちゅ")
                     .Replace("cho", "ちょ");

            str = str.Replace("nya", "にゃ")
                     .Replace("nyu", "にゅ")
                     .Replace("nyo", "にょ");

            str = str.Replace("hya", "ひゃ")
                     .Replace("hyu", "ひゅ")
                     .Replace("hyo", "ひょ");

            str = str.Replace("mya", "みゃ")
                     .Replace("myu", "みゅ")
                     .Replace("myo", "みょ");

            str = str.Replace("rya", "りゃ")
                     .Replace("ryu", "りゅ")
                     .Replace("ryo", "りょ");

            str = str.Replace("gya", "ぎゃ")
                     .Replace("gyu", "ぎゅ")
                     .Replace("gyo", "ぎょ");

            str = str.Replace("ja", "じゃ")
                     .Replace("ju", "じゅ")
                     .Replace("jo", "じょ");

            str = str.Replace("bya", "びゃ")
                     .Replace("byu", "びゅ")
                     .Replace("byo", "びょ");

            str = str.Replace("pya", "ぴゃ")
                     .Replace("pyu", "ぴゅ")
                     .Replace("pyo", "ぴょ");

            #endregion

            #region Vowels
            // Vowels
            str = str.Replace("a", "あ")
                     .Replace("i", "い")
                     .Replace("u", "う")
                     .Replace("e", "え")
                     .Replace("o", "お");

#endregion

            return str;
        }

        public static string ToKataKana(string str)
        {
            str = str.ToLower();

            #region Main

            // K line
            str = str.Replace("ka", "カ")
                     .Replace("ki", "キ")
                     .Replace("ku", "ク")
                     .Replace("ke", "ケ")
                     .Replace("ko", "コ");

            // S line
            str = str.Replace("sa", "サ")
                     .Replace("shi", "シ")
                     .Replace("su", "ス")
                     .Replace("se", "セ")
                     .Replace("so", "ソ");

            // T line
            str = str.Replace("ta", "タ")
                     .Replace("chi", "チ")
                     .Replace("tsu", "ツ")
                     .Replace("te", "テ")
                     .Replace("to", "ト");

            // N line
            str = str.Replace("na", "ナ")
                     .Replace("ni", "ニ")
                     .Replace("nu", "ヌ")
                     .Replace("ne", "ネ")
                     .Replace("no", "ノ");

            // H line
            str = str.Replace("ha", "ハ")
                     .Replace("hi", "ヒ")
                     .Replace("fu", "フ")
                     .Replace("he", "ヘ")
                     .Replace("ho", "ホ");

            // M line
            str = str.Replace("ma", "マ")
                     .Replace("mi", "ミ")
                     .Replace("mu", "ム")
                     .Replace("me", "メ")
                     .Replace("mo", "モ");

            // Y line
            str = str.Replace("ya", "ヤ")
                     .Replace("yu", "ユ")
                     .Replace("yo", "ヨ");

            // R line
            str = str.Replace("ra", "ラ")
                     .Replace("ri", "リ")
                     .Replace("ru", "ル")
                     .Replace("re", "レ")
                     .Replace("ro", "ロ");

            // W line
            str = str.Replace("wa", "ワ")
                     .Replace("wo", "ヲ");

            // Special
            str = str.Replace("n", "ン");

            #endregion

            #region Dakuten
            // Dakuten
            str = str.Replace("ga", "ガ")
                     .Replace("gi", "ギ")
                     .Replace("gu", "グ")
                     .Replace("ge", "ゲ")
                     .Replace("go", "ゴ");

            str = str.Replace("za", "ザ")
                     .Replace("ji", "ジ")
                     .Replace("zu", "ズ")
                     .Replace("ze", "ゼ")
                     .Replace("zo", "ゾ");

            str = str.Replace("da", "ダ")
                     .Replace("de", "デ")
                     .Replace("do", "ド")
                     .Replace("dji", "ヂ") // rare
                     .Replace("dzu", "ヅ"); // rare

            str = str.Replace("ba", "バ")
                     .Replace("bi", "ビ")
                     .Replace("bu", "ブ")
                     .Replace("be", "ベ")
                     .Replace("bo", "ボ");

            // Handakuten
            str = str.Replace("pa", "パ")
                     .Replace("pi", "ピ")
                     .Replace("pu", "プ")
                     .Replace("pe", "ペ")
                     .Replace("po", "ポ");

            #endregion

            #region Yoon
            // Yōon combos (small ya/yu/yo)
            str = str.Replace("kya", "キャ")
                     .Replace("kyu", "キュ")
                     .Replace("kyo", "キョ");

            str = str.Replace("sha", "シャ")
                     .Replace("shu", "シュ")
                     .Replace("sho", "ショ");

            str = str.Replace("cha", "チャ")
                     .Replace("chu", "チュ")
                     .Replace("cho", "チョ");

            str = str.Replace("nya", "ニャ")
                     .Replace("nyu", "ニュ")
                     .Replace("nyo", "ニョ");

            str = str.Replace("hya", "ヒャ")
                     .Replace("hyu", "ヒュ")
                     .Replace("hyo", "ヒョ");

            str = str.Replace("mya", "ミャ")
                     .Replace("myu", "ミュ")
                     .Replace("myo", "ミョ");

            str = str.Replace("rya", "リャ")
                     .Replace("ryu", "リュ")
                     .Replace("ryo", "リョ");

            str = str.Replace("gya", "ギャ")
                     .Replace("gyu", "ギュ")
                     .Replace("gyo", "ギョ");

            str = str.Replace("ja", "ジャ")
                     .Replace("ju", "ジュ")
                     .Replace("jo", "ジョ");

            str = str.Replace("bya", "ビャ")
                     .Replace("byu", "ビュ")
                     .Replace("byo", "ビョ");

            str = str.Replace("pya", "ピャ")
                     .Replace("pyu", "ピュ")
                     .Replace("pyo", "ピョ");

            #endregion

            #region Vowels
            // Vowels
            str = str.Replace("a", "ア")
                     .Replace("i", "イ")
                     .Replace("u", "ウ")
                     .Replace("e", "エ")
                     .Replace("o", "オ");

            #endregion

            return str;
        }

    }
}
