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

    public static List<string> level13 = new List<string> {
    "``", "~~", "!!", "@@", "##", "$$", "%%", "^^", "&&", "**", "((", "))", "__", "==", "++",
    "[[", "{{", "]]", "}}", "\\", "||", "::", "\"\"", "<<", ">>", "//", "??", "`~", "!@", 
    "#$", "%^", "&*", "()", "_=", "++", "[{", "]}", "\\|", "\":", "<>", "/?", "?/", "><", 
    "\":", "|\\", "}]", "{[", "++", "=_", ")(", "*&", "^%", "$#", "@!", "~`", "~})?", "}++%", 
    "+:_:", "|)|{", "\\>^[", "@/(>", "+?%%", "++<:)", "[]]%", "#$)+", "^<+`", "++#%", 
    "utn9", "ae\\y", "@r\"t", "$*&~", "/t*=", "/>b5", "uqla", "&\"#}", "u#y", "sg=|", "@^^=", 
    "o=@k", "ude'", "+&)e", "i|o5", "w@jf", "mt#]", "jb?$", ".aad", ";*(>", "ejoa", ")d>{", 
    "rz^v", "r!&c", "jya&", "`o+o", "ciab", "!oig", "xzer", "yb{%", "1mu`", "*aqw", "++=d", 
    "ju<a", "(h8l", "f+xo", "g!sj", "8oxz", "59eo", "o\\cb", "{w/\"", "rh8p", "k&u.", "\\`)|"};
    public static List<string> level14 = new List<string>
        {"A", "S", "D", "F", "G", "H", "J", "K", "L", ";", "'", "Z", "X", "C", "V", "B", "N", "M",
        ",", ".", "/", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "[", "]", "\\", "{", "}",
        "|", "<", ">", "?", "\"", ":", "`", "~", "1", "!", "@", "2", "#", "3", "4", "$", "%", "5",
        "6", "^", "&", "7", "*", "8", "9", "(", "0", ")", "-", "_", "+", "=", "Act", "America", "Amusement", "April", "August", "Australia", "Bakery", "Banana", "Bangkok", "Bank", "Bat", "Beard", "Beetroot", "Behind", "Bhudda", "Big", "Blond", "Boring", "Bridge", "Brinjal", "Britain", "By", "Camel", "Cap", "Carrot", "Carry", "Cashier", "Chocolate", "Church", "Claw", "Climb", "Cloudy", "Coat", "Cold", "Cool", "Corner", "Crocodile", "Curly", "Cute", "Dance", "December", "Do", "Doctor", "Dolphin", "Draw", "Drive", "Ears", "Elephant", "England", "English", "Enokitake", "Excited", "Exciting", "Eyes", "Factory", "Farm", "Farmer", "Feather", "February", "Fin", "Fly", "Foggy", "Freezing", "Friday", "Fun", "Fur", "Giraffe", "Gloves", "Hair", "Handsome", "Have", "Hippo", "Hop", "Horse", "Hospital", "Hot", "Hungry", "IT", "In", "Jacket", "January", "Japan", "Japanese", "Jeans", "July", "Jump", "June", "Kangaroo", "Lantern", "Last", "Lavender", "Lion", "Listen", "Logan", "Long", "Lotus", "Lychee", "Make", "Malaysia", "Mall", "March", "Marigold", "Mask", "May", "Monday", "Monkey", "Mouth", "Movie", "Museum", "Mustache", "Near", "Next", "No", "Nose", "November", "October", "Office", "Old", "On", "Onion", "Opposite", "Paint", "Pancakes", "Panda", "Paper", "Pasta", "Peas", "Penguin", "Play", "Playground", "Poppy", "Potato", "Pretty", "Pumpkin", "Raincoat", "Rainy", "Relaxing", "Restaurant", "Rhino", "Ride", "Salad", "Saturday", "Scared", "September", "Shark", "Short", "Sing", "Singapore", "Slim", "Snake", "Snowy", "Soup", "Spring", "Stop", "Store", "Stormy", "Straight", "Strong", "Sunday", "Sunglasses", "Sunny", "Supermarket", "Surprised", "Swim", "Sydney", "T-shirt", "Tail", "Tall", "Thailand", "Theatre", "Thirsty", "Thursday", "Tiger", "Tired", "Tiring", "Tokyo", "Tomato", "Traffic", "Tuesday", "Tuplip", "Turn", "Umbrella", "Video", "Vietnam", "Vietnamese", "Waiter", "Warm", "Weak", "Wednesday", "Weekend", "Windy", "Wing", "Yesterday", "Young", "Zebra", "actor", "after", "afternoon", "ago", "and", "ant", "apple", "around", "arts", "badmintion", "bags", "bakery", "bay", "beach", "bear", "beautifully", "because", "bee", "before", "between", "bike", "bird", "birthday", "bookcase", "brave", "breakfast", "bus", "busy", "but", "butter", "buy", "campfire", "campsite", "can", "capital", "car", "card", "careful", "cashew", "centre", "cheap", "cheese", "chef", "cherry", "chess", "chicken", "chips", "christmas", "cinema", "city", "clothes", "coffee", "collecting", "color", "comic", "company", "computer", "conjunction", "cook", "country", "countryside", "cow", "crafts", "crawl", "cucumber", "dance", "dancing", "dangerous", "date", "day", "decorate", "dinner", "dishes", "district", "dog", "dragon", "driver", "drums", "duck", "education", "email", "engineer", "enjoy", "enormous", "enter", "erase", "evening", "exercise", "eyes", "face", "factory", "festival", "field", "fifteen", "films", "finish", "fireworks", "fishing", "fit", "flag", "flax", "flower", "food", "foot", "footbal", "forty-five", "friendly", "front", "games", "garden", "get", "gift", "global", "glue", "go", "goat", "grape", "guitar", "gymnastics", "hair", "hamster", "happy", "have", "hightlight", "hobby", "holiday", "homework", "hotel", "housewife", "hug", "hungry", "information", "jackfruit", "jam", "join", "juice", "jumper", "karate", "keyboard", "king", "kite", "kiwi", "lab", "laundry", "leaf", "learn", "left", "lemonade", "library", "live", "long", "loudly", "lovely", "lunch", "maker", "mango", "market", "maths", "merrily", "milk", "morning", "motorbike", "mountain", "mushroom", "musician", "nationality", "near", "noisy", "noodles", "noon", "noun", "nurse", "o'clock", "of", "over", "pagoda", "paint", "parents", "park", "parking", "party", "peach", "peacock", "pecan", "people", "photographs", "phrase", "physical", "piano", "picnic", "pig", "pillow", "pilot", "plane", "plant", "playground", "playing", "policeman", "pork", "prepare", "preposition", "present", "puppet", "pyjamas", "quick", "quiet", "rabbit", "raidish", "reading", "rice", "right", "road", "roar", "rolls", "room", "rope", "rose", "round", "rug", "run", "sad", "sailor", "sandal", "sandcastle", "scary", "scenery", "science", "sea", "seafood", "shamppo", "shark", "ship", "shoe", "shop", "shopping", "sick", "skiing", "skip", "skirt", "sniff", "snowman", "soap", "soccer", "sports", "stall", "stamp", "start", "story", "straight", "street", "study", "subject", "subway", "summer", "sunflower", "sunny", "swan", "swimming", "taxi", "tea", "teacher", "technology", "telling", "temple", "tennis", "tent", "text", "the", "theater", "thirty", "thousand", "time", "to", "toothbursh", "toothpaste", "towel", "town", "toy", "train", "travel", "trip", "trousers", "tug", "turtle", "up", "vase", "verb", "vet", "village", "visit", "walnut", "war", "watch", "water", "watermelon", "weather", "why", "wice", "wish", "wonderful", "worker", "write", "writer", "yoga", "zoo"
    };


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
            case 13:
                currLevel = new List<string>(level13);
                break;
            case 14:
                currLevel = new List<string>(level14);
                break;
            default:
                currLevel.Clear();
                break;
        }
    }
    public static string GetRandomWord(int level)
    {
        if(level == 14)
        {
            int ramdom = Random.Range(0, currLevel.Count + 1);
            string randomWord = currLevel[ramdom];
            currLevel.RemoveAt(ramdom);
            return randomWord;
        }
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
