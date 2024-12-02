using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    public static List<string> level1 = new List<string> { "aa", "ss", "dd", "ff", "jj", "kk", "ll", ";;", "as", "df", "jk", "l;", ";l", "kj", "fd", "sa", "alka", "jjsa", "kfsd", "slks", "k;js", "al;a", "djkk", "jjsf", "jdad", "sd;k", "faad", "jflj", "fkld", "addf", "f;dl", "dlfj" };

    public static List<string> level2 = new List<string> { "ee", "ii", "ee", "ii", "ei", "ei", "ei", "ei", "ie", "ie", "ie", "ie", "ie", "eiei", "eiie", "iiei", "ieii", "eiei", "ieie", "eeie", "iiee", "ieie", "ieei", "ieie", "eeie", "faei", "didi", "eaei", "eiie", "jeae", "i;ks", "elj;", "jiek", "lili", "eife", "ieei", "saie", "jias", "eikk", "sikk", "esfj", "eife", "eeje", "eeei", "deel" };

    public static List<string> level3 = new List<string> { "rr", "uu", "rr", "uu", "ru", "ru", "ru", "ru", "ur", "ur", "ur", "ur", "ruur", "urur", "ruru", "uurr", "urur", "rurr", "uuru", "urru", "uurr", "uurr", "urur", "ruru", "reuu", "efj;", "ueru", ";uii", "uuje", "uare", "jrij", "urur", "ruur", "jrur", "ursr", "jrur", "fker", "s;rr", "ruar", "erur", "eeuu", "akrr", "fiuk", "rdui", "diuj", "ddaa", "uurk", "uffs", "jjiu", "id;r", "dlui", "ruur", "rdrl", "fsrr", "drsk", "aa;f", "arja", "uiku", "uufe", "ejkr", "euul", "risd", "ijis", "jrru", ";dsl", ";drj", "lurk", "jre;", "ud;s", "rseu", "fdjk", "ell;" };

    public static List<string> level4 = new List<string> { "tt", "yy", "tt", "yy", "ty", "ty", "ty", "ty", "yt", "yt", "yt", "ytyt", "ytty", "tytt", "ytty", "yyty", "yyty", "yyty", "tyyt", "ytty", "ttyt", "yyty", "tsts", "iest", "uts;", "rttj", "tyjt", "tlyy", "test", "ttue", "yrii", "tsi;", "rkd", "aslt", "raty", "tuty", "tikf", "ttlk", "ytsr", "tlas", "sily", "yift", "kyyk", "i;tf", "juty", "tlyy", "eyde", "rjkt", "dsys", "aref", "kyja", "trrt", "ryyr", "ylse", "frae", "eklt", "uur;", "efyk", "tjjd", "sssj", "ijyy", "atrl", "fjky", "tslr", "u;tj", "yyfu", "tsuy", "elyt", "rifs", "tdyk" };

    public static List<string> level5 = new List<string> { "gg", "hh", ",,", "..", "gg", "hh", ",,", "..", "gh", ",.", "gh", ",.", ".,", "hg", ".,", "hg", "gh,g", "ghh,", ".h,g", "hghh", "gh,g", ",g.h", "g,h.", "gh,h", "h.gg", ",hg,", ".hhg", "hgg.", "gụje", "ad;,", "sax,j", "ashdd", ",fr,", "h,;i", "hiri,", ".egix", "gi,.", "hgiy", "hgh,", "..kef", "igysf", ".h,d", "rlejs", "eh,g", "hurih", "gtj;", "kgj.", "ryj.a", ".l,t", "ex.,y", ",afif", ";sga", "hj,.", ";kuej", "ffgs", "kesj.", "tgiar", "ru,.", "g,ir;", ";r.e", "gexht", "huik", ";hyl", "egajk", "srfyx", "g,yt", "jdhg", "skil", "rufyj", "gafd", "lka;", "rht,", "ed.yx", "shjf", "hida", "uxlsj" };

    public static List<string> level6 = new List<string> { "EE", "RR", "TT", "YY", "UU", "II", "AA", "SS", "DD", "FF", "GG", "HH", "JJ", "KK", "LL", "ER", "TY", "UI", "AS", "DF", "GH", "JKL", "LK", "JH", "GF", "DS", "AI", "UY", "TRE", "KTTA", "FJYD", "UFIK", "IEYL", "RHIG", "IDLE", "IDJA", "GRAJ", "LTRE", "GSII", "HGYK", "KJSJ", "uysE", "E;HL", "E,GY", "AEKi", "ldad", ".l;i", "IYAL", "hIj.", "DUjk", "yiga", "KH;;", "fkHT", "uedi", "TGLJ", "fKHG", "K,;H", "ugkY", "gIRG", "hLeR", "HK;D", "Jysh", "kjfY", "ISKI", "EKUG", "eLhY", "AUUr", "GK;u", "lYJu", "JDKU", ".uFr", "LGRh", "e,Fd", "yeYs", ".Y,K", "d;ji", "TUYF", "ajID", "FsA;", "fJda", "kl,h", ";ygk", "g.hJ", "Ry.;", "ILGI" };
    
    public static List<string> level7 = new List<string> { "ww", "oo", "ww", "oo", "wo", "wo", "ow", "ow", "ooow", "wwoo", "wowo", "wooo", "owow", "ooow", "owow", "t.oy", "wjoy", "eode", "ewwi", "aodo", "owoo", "jgwo", "w,ed", "loha", "howh", "otef", ",owy", "whkw", "hooo", "oaoh", "goof", "jhoo", "ogg,", "o;ok", "iskw", "oywo", "wogt", "hwot", "wotd", "rook", "ejwo", "gowy", "saoj", "soho", "dh.o", "jows", "ouro", "joku", "uohi", "wgou", "wapo", "wkwo", "wa;o", "gorf", "wouo", "uihf", "iweh", "osio", "eeol", "juii", "jorh", "wwe.", "sow;" };
    
    public static List<string> level8 = new List<string> { "cc", "nn", "mm", "cc", "nn", "mm", "cnm", "cnm", "cnm", "cnm", "mnc", "mnc", "mnc", "mnc", "mcnm", "mcnm", "cmcc", "nncc", "nmmn", "mmcn", "mcnn", "nncc", "mnmc", "cmcc", "mmcn", "cnnm", ".mig", "iecm", "crtn", "snmw", "krsi", "haae", "ecmm", "intl", "wg;s", "mstm", "sadc", "cnoa", "rcid", "nnlt", "cuco", "utmy", "omcm", "u,nos", "mnhd", "cmrn", "kgdm", "fomo", "fknu", "dcmi", "mmjf", "nmnn", "cfori", "ulj,", "rwcu", "deuc", "fmfd", "oemr", "inja", "acirj", "dyhi", "nscn", "tnru", "keo;", "au.t", "jmmh", "wrol", ";fro", "mnyn", "lsnn", "ssai", "cisif", "exc.d", "cciu" };
   
    public static List<string> level9 = new List<string> { "pp", "qq", "vv", "qq", "vv", "pqv", "qvp", "qpv", "pqv", "vqq", "vpq", "vpq", "vpq", "pppv", "pvqv", "pvqp", "pvvp", "qpqv", "qqvq", "pvvq", "vqvp", "pvvq", "pqpp", "qvqv", "qvvp", "vvhn", "vnhp", "nuvv", "qvq.", "gfjq", "vpdq", "mhhp", "epvl", "qdqv", "vqee", "ppqq", "tqdv", "opov", "eqqv", "rtqv", "llpq", "qspk", "voop", "upqk", "pcep", "qevk", "snej", "jyvy", "mptp", "hlpp", "nvpg", "uqcp", "gpdv", "yvdj", "kalf", "plap", "vqep", ".fuq", "ldup", "qwvu", "vdph", "empe", "eqfc", ",pjq", "prqi", "gqqp", "epcj", "tikq", "lltq", "ocph", "cpmq", "v;ou", "apeu", "tduq", "tvtp", "lso;", "qvvu", "plof", "do.n", "psmv", "pu;,", "atev", "vwpv", "wu.q" };
    
    public static List<string> level10 = new List<string> { "bb", "''", "bb", "''", "'b", "'b", "b'", "b'", "'bb", "b''''", "'bbb", "b''b'", "'bb''", "bd'a", "db''a", "ebda", "k'lb", "b'ad", "'bba", "w'br", "ejob", "anbw", "m'fb", "''bbd", "pa''j", "or'v", "abqr", "a''rb", "dlay", "jkbb", "ok'n", "h'je", "i'uv", "bcb,", "e''''h", "ad'k", "urwb", "'uag", "abwy", ",cbd", "bbgs", "'e'y", "bn'a", "adtb", "aq''j", "kyao", "abad", "dpbo", "d''li", "bvub", "plmo", "k,e''", "fwba", "at''q", "pbb'", "uubd", "qdm''", "vsab", ",h''b", "''vda", "u'da", "aenm", "bscb", "d'ag", "dbb'", "pggp", "'hpq" };

    public static List<string> level11 = new List<string> { "zz", "xx", "--", "zz", "xx", "--", "-z", "zx", "-x", "zx", "xz", "z-", "xz", "x-", "x-zz", "xz-z", "xx-z", "-zxx", "zz-z", "x-xz", "xzzz", "zxxz", "xz-x", "x-zx", "xzz-", "zxx-", "xnzx", "axvo", "izg-", "xzx-", "daoi", "cazy", ";vex", "ecwy", "zgxb", "ioaw", "ozdx", "-wcx", "rxty", "ufzi", "mtfz", "xnzx", "o-xs", "zozw", "zalv", "txtx", "qle-", "zaxk", "fzpr", "mn;z", "aiyx", "vozz", "lzxx", "ez-b", "wkex", "vxsm", "wegm", "is-h", "b.vw", "e,'.", "xkxy", "znpu", ".d;d", "xirz", ",zkk", "-bba", "zaxa", ",dhz", "fcxx", "zaza", "tvxd", "zkkx", "ooxf-", "-y.b" };

    public static List<string> level12 = new List<string> { "11", "22", "33", "44", "55", "66", "77", "88", "99", "00", "12", "34", "56", "78", "90", "09", "87", "65", "43", "21", "8664", "8878", "9239", "5901", "3172", "0014", "5468", "8901", "7159", "1650", "4765", "8452", "uz0d", "g9a3", "67dw", "vj10", "p24o", "d34o", "5u53", "e406", "'4ry", "g2'1", "141h", "ko7f", "ul98", "x688", "hz30", "n7sy", "uiag", "u9;4", "f0đ7", "a93;", "f7ks", ",8m1", "f458", "v7v6", "t71r", "vp-a", "yueo", "n6xa", "r4eh", "wax1", "ko5g", "zs0b", "7io4", "76ge", "927l", "60d8", "336i", "o.uu", "5vag", "oo.a", "76hy", "btad", "eotb", "h1r5" };

    //public static List<string> level13 = new List<string> {"``", "~~", "!!", "@@", "##", "$$", "%%", "^^", "&&", "**", "((", "))", "__", "==", "++", "++", "[[", "{{", "]]", "}}", "\\", "||", "::", @"""", "<<", ">>", "//", "??", "`~", "!@", "#$", "%^", "&*", "()", "_=", "++", "[{", "]}", @"\|", @":"", @"<>", @"/?", "?/", "><", "":", "|\", "}]", "{[", "++", "=_", ")(", "*&", "^%", "$#", "@!", "~`", "~})?", "}++%", "+:_:", "|)|{", "\>^[", "@/(>", "+?%%", "++<:)", "[]]%", "#$)+", "^<+`", "++#%", "utn9", "ae\y", "@r"t", "$*&~", "/t*=", "/>b5", "uqla", "&"#}", "u#y", "sg=|", "@^^=", "o=@k", "ude'", "+&)e", "i|o5", "w@jf", "mt#]", "jb?$", ".aad", ";*(>", "ejoa", ")d>{", "rz^v", "r!&c", "jya&", "`o+o", "ciab", "!oig", "xzer", "yb{%", "1mu`", "*aqw", "++=d", "ju<a", "(h8l", "f+xo", "g!sj", "8oxz", "59eo", "o\cb", "{w/"", "rh8p", "k&u.", "\`)|"};

    public static List<string> currLevel;

    public static void setValueCurrLevel(int level)
    {
        switch (level)
        {
            case 1:
                currLevel = new List<string>(level1);
                break;
            case 2:
                currLevel = new List<string>(level2);
                break;
            case 3:
                currLevel = new List<string>(level3);
                break;
            case 4:
                currLevel = new List<string>(level4);
                break;
            case 5:
                currLevel = new List<string>(level5);
                break;
            case 6:
                currLevel = new List<string>(level6);
                break;
            case 7:
                currLevel = new List<string>(level7);
                break;
            case 8:
                currLevel = new List<string>(level8);
                break;
            case 9:
                currLevel = new List<string>(level9);
                break;
            case 10:
                currLevel = new List<string>(level10);
                break;
            case 11:
                currLevel = new List<string>(level11);
                break;
            case 12:
                currLevel = new List<string>(level12);
                break;
            default:
                currLevel.Clear();
                break;
        }
    }
    public static string GetRandomWord(int level)
    {
        if(currLevel.Count > 0)
        {
            string randomWord = currLevel[0];
            currLevel.RemoveAt(0);
            return randomWord;
        }
        return "";
    }

    public static int getLengthCurrLevel()
    {
        return currLevel.Count;
    }
}
