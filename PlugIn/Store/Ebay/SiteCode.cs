using System.Collections.Generic;

namespace Auu.PlugIn.Store.EbayApi
{
    public static class SiteCode
    {
        private static Dictionary<int, string> sites;
        private static Dictionary<string, string> countryCode;
        private static List<CountryShortName> countries;

        public static Dictionary<string, string> CountryCode()
        {
            if (countryCode == null)
            {
                countryCode=new Dictionary<string, string>();
                countryCode.Add("Andorra","AD");
                countryCode.Add("United Arab Emirates","AE");
                countryCode.Add("Afghanistan","AF");
                countryCode.Add("Antigua and Barbuda","AG");
                countryCode.Add("Anguilla","AI");
                countryCode.Add("Albania","AL");
                countryCode.Add("Armenia","AM");
                countryCode.Add("Netherlands Antilles","AN");
                countryCode.Add("Angola","AO");
                countryCode.Add("Antarctica","AQ");
                countryCode.Add("Argentina","AR");
                countryCode.Add("American Samoa","AS");
                countryCode.Add("Austria","AT");
                countryCode.Add("Australia","AU");
                countryCode.Add("Aruba","AW");
                countryCode.Add("Aland Islands","AX");
                countryCode.Add("Azerbaijan","AZ");
                countryCode.Add("Bosnia and Herzegovina","BA");
                countryCode.Add("Barbados","BB");
                countryCode.Add("Bangladesh","BD");
                countryCode.Add("Belgium","BE");
                countryCode.Add("Burkina Faso","BF");
                countryCode.Add("Bulgaria","BG");
                countryCode.Add("Bahrain","BH");
                countryCode.Add("Burundi","BI");
                countryCode.Add("Benin","BJ");
                countryCode.Add("Saint Barthelemy","BL");
                countryCode.Add("Bermuda","BM");
                countryCode.Add("Brunei Darussalam","BN");
                countryCode.Add("Bolivia","BO");
                countryCode.Add("Bonaire, Sint Eustatius, and Saba","BQ");
                countryCode.Add("Brazil","BR");
                countryCode.Add("Bahamas","BS");
                countryCode.Add("Bhutan","BT");
                countryCode.Add("Bouvet Island","BV");
                countryCode.Add("Botswana","BW");
                countryCode.Add("Belarus","BY");
                countryCode.Add("Belize","BZ");
                countryCode.Add("Canada","CA");
                countryCode.Add("Cocos (Keeling) Islands","CC");
                countryCode.Add("The Democratic Republic of the Congo","CD");
                countryCode.Add("Central African Republic","CF");
                countryCode.Add("Congo","CG");
                countryCode.Add("Switzerland","CH");
                countryCode.Add("Cote d'Ivoire","CI");
                countryCode.Add("Cook Islands","CK");
                countryCode.Add("Chile","CL");
                countryCode.Add("Cameroon","CM");
                countryCode.Add("China","CN");
                countryCode.Add("Colombia","CO");
                countryCode.Add("Costa Rica","CR");
                countryCode.Add("Cuba","CU");
                countryCode.Add("Cape Verde","CV");
                countryCode.Add("Curacao","CW");
                countryCode.Add("Christmas Island","CX");
                countryCode.Add("Cyprus","CY");
                countryCode.Add("Czech Republic","CZ");
                countryCode.Add("Germany","DE");
                countryCode.Add("Djibouti","DJ");
                countryCode.Add("Denmark","DK");
                countryCode.Add("Dominica","DM");
                countryCode.Add("Dominican Republic","DO");
                countryCode.Add("Algeria","DZ");
                countryCode.Add("Ecuador","EC");
                countryCode.Add("Estonia","EE");
                countryCode.Add("Egypt","EG");
                countryCode.Add("Western Sahara","EH");
                countryCode.Add("Eritrea","ER");
                countryCode.Add("Spain","ES");
                countryCode.Add("Ethiopia","ET");
                countryCode.Add("Finland","FI");
                countryCode.Add("Fiji","FJ");
                countryCode.Add("Falkland Islands (Malvinas)","FK");
                countryCode.Add("Federated States of Micronesia","FM");
                countryCode.Add("Faroe Islands","FO");
                countryCode.Add("France","FR");
                countryCode.Add("Gabon","GA");
                countryCode.Add("United Kingdom","GB");
                countryCode.Add("Grenada","GD");
                countryCode.Add("Georgia","GE");
                countryCode.Add("French Guiana","GF");
                countryCode.Add("Guernsey","GG");
                countryCode.Add("Ghana","GH");
                countryCode.Add("Gibraltar","GI");
                countryCode.Add("Greenland","GL");
                countryCode.Add("Gambia","GM");
                countryCode.Add("Guinea","GN");
                countryCode.Add("Guadeloupe","GP");
                countryCode.Add("Equatorial Guinea","GQ");
                countryCode.Add("Greece","GR");
                countryCode.Add("South Georgia and the South Sandwich Islands","GS");
                countryCode.Add("Guatemala","GT");
                countryCode.Add("Guam","GU");
                countryCode.Add("Guinea-Bissau","GW");
                countryCode.Add("Guyana","GY");
                countryCode.Add("Hong Kong","HK");
                countryCode.Add("Heard Island and McDonald Islands","HM");
                countryCode.Add("Honduras","HN");
                countryCode.Add("Croatia","HR");
                countryCode.Add("Haiti","HT");
                countryCode.Add("Hungary","HU");
                countryCode.Add("Indonesia","ID");
                countryCode.Add("Ireland","IE");
                countryCode.Add("Israel","IL");
                countryCode.Add("Isle of Man","IM");
                countryCode.Add("India","IN");
                countryCode.Add("British Indian Ocean Territory","IO");
                countryCode.Add("Iraq","IQ");
                countryCode.Add("Islamic Republic of Iran","IR");
                countryCode.Add("Iceland","IS");
                countryCode.Add("Italy","IT");
                countryCode.Add("Jersey","JE");
                countryCode.Add("Jamaica","JM");
                countryCode.Add("Jordan","JO");
                countryCode.Add("Japan","JP");
                countryCode.Add("Kenya","KE");
                countryCode.Add("Kyrgyzstan","KG");
                countryCode.Add("Cambodia","KH");
                countryCode.Add("Kiribati","KI");
                countryCode.Add("Comoros","KM");
                countryCode.Add("Saint Kitts and Nevis","KN");
                countryCode.Add("Democratic People's Republic of Korea","KP");
                countryCode.Add("Republic of Korea","KR");
                countryCode.Add("Kuwait","KW");
                countryCode.Add("Cayman Islands","KY");
                countryCode.Add("Kazakhstan","KZ");
                countryCode.Add("Lao People's Democratic Republic","LA");
                countryCode.Add("Lebanon","LB");
                countryCode.Add("Saint Lucia","LC");
                countryCode.Add("Liechtenstein","LI");
                countryCode.Add("Sri Lanka","LK");
                countryCode.Add("Liberia","LR");
                countryCode.Add("Lesotho","LS");
                countryCode.Add("Lithuania","LT");
                countryCode.Add("Luxembourg","LU");
                countryCode.Add("Latvia","LV");
                countryCode.Add("Libyan Arab Jamahiriya","LY");
                countryCode.Add("Morocco","MA");
                countryCode.Add("Monaco","MC");
                countryCode.Add("Republic of Moldova","MD");
                countryCode.Add("Montenegro","ME");
                countryCode.Add("Saint Martin (French part)","MF");
                countryCode.Add("Madagascar","MG");
                countryCode.Add("Marshall Islands","MH");
                countryCode.Add("The Former Yugoslav Republic of Macedonia","MK");
                countryCode.Add("Mali","ML");
                countryCode.Add("Myanmar","MM");
                countryCode.Add("Mongolia","MN");
                countryCode.Add("Macao","MO");
                countryCode.Add("Northern Mariana Islands","MP");
                countryCode.Add("Martinique","MQ");
                countryCode.Add("Mauritania","MR");
                countryCode.Add("Montserrat","MS");
                countryCode.Add("Malta","MT");
                countryCode.Add("Mauritius","MU");
                countryCode.Add("Maldives","MV");
                countryCode.Add("Malawi","MW");
                countryCode.Add("Mexico","MX");
                countryCode.Add("Malaysia","MY");
                countryCode.Add("Mozambique","MZ");
                countryCode.Add("Namibia","NA");
                countryCode.Add("New Caledonia","NC");
                countryCode.Add("Niger","NE");
                countryCode.Add("Norfolk Island","NF");
                countryCode.Add("Nigeria","NG");
                countryCode.Add("Nicaragua","NI");
                countryCode.Add("Netherlands","NL");
                countryCode.Add("Norway","NO");
                countryCode.Add("Nepal","NP");
                countryCode.Add("Nauru","NR");
                countryCode.Add("Niue","NU");
                countryCode.Add("New Zealand","NZ");
                countryCode.Add("Oman","OM");
                countryCode.Add("Panama","PA");
                countryCode.Add("Peru","PE");
                countryCode.Add("French Polynesia. Includes Tahiti","PF");
                countryCode.Add("Papua New Guinea","PG");
                countryCode.Add("Philippines","PH");
                countryCode.Add("Pakistan","PK");
                countryCode.Add("Poland","PL");
                countryCode.Add("Saint Pierre and Miquelon","PM");
                countryCode.Add("Pitcairn","PN");
                countryCode.Add("Puerto Rico","PR");
                countryCode.Add("Palestinian territory Occupied","PS");
                countryCode.Add("Portugal","PT");
                countryCode.Add("Palau","PW");
                countryCode.Add("Paraguay","PY");
                countryCode.Add("Qatar","QA");
                countryCode.Add("Reunion","RE");
                countryCode.Add("Romania","RO");
                countryCode.Add("Serbia","RS");
                countryCode.Add("Russian Federation","RU");
                countryCode.Add("Rwanda","RW");
                countryCode.Add("Saudi Arabia","SA");
                countryCode.Add("Solomon Islands","SB");
                countryCode.Add("Seychelles","SC");
                countryCode.Add("Sudan","SD");
                countryCode.Add("Sweden","SE");
                countryCode.Add("Singapore","SG");
                countryCode.Add("Saint Helena","SH");
                countryCode.Add("Slovenia","SI");
                countryCode.Add("Svalbard and Jan Mayen","SJ");
                countryCode.Add("Slovakia","SK");
                countryCode.Add("Sierra Leone","SL");
                countryCode.Add("San Marino","SM");
                countryCode.Add("Senegal","SN");
                countryCode.Add("Somalia","SO");
                countryCode.Add("Suriname","SR");
                countryCode.Add("Sao Tome and Principe","ST");
                countryCode.Add("El Salvador","SV");
                countryCode.Add("Sint Maarten (Dutch part)","SX");
                countryCode.Add("Syrian Arab Republic","SY");
                countryCode.Add("Swaziland","SZ");
                countryCode.Add("Turks and Caicos Islands","TC");
                countryCode.Add("Chad","TD");
                countryCode.Add("French Southern Territories","TF");
                countryCode.Add("Togo","TG");
                countryCode.Add("Thailand","TH");
                countryCode.Add("Tajikistan","TJ");
                countryCode.Add("Tokelau","TK");
                countryCode.Add("Timor-Leste","TL");
                countryCode.Add("Turkmenistan","TM");
                countryCode.Add("Tunisia","TN");
                countryCode.Add("Tonga","TO");
                countryCode.Add("Turkey","TR");
                countryCode.Add("Trinidad and Tobago","TT");
                countryCode.Add("Tuvalu","TV");
                countryCode.Add("Taiwan","TW");
                countryCode.Add("Tanzania","TZ");
                countryCode.Add("Ukraine","UA");
                countryCode.Add("Uganda","UG");
                countryCode.Add("United States Minor Outlying Islands","UM");
                countryCode.Add("United States","US");
                countryCode.Add("Uruguay","UY");
                countryCode.Add("Uzbekistan","UZ");
                countryCode.Add("Holy See (Vatican City state)","VA");
                countryCode.Add("Saint Vincent and the Grenadines","VC");
                countryCode.Add("Venezuela","VE");
                countryCode.Add("British Virgin Islands","VG");
                countryCode.Add("The U.S. Virgin Islands","VI");
                countryCode.Add("Vietnam","VN");
                countryCode.Add("Vanuatu","VU");
                countryCode.Add("Wallis and Futuna","WF");
                countryCode.Add("Samoa","WS");
                countryCode.Add("Yemen","YE");
                countryCode.Add("Mayotte","YT");
                countryCode.Add("South Africa","ZA");
                countryCode.Add("Zambia","ZM");
                countryCode.Add("Zimbabwe","ZW");
            }
            
            
            return countryCode;
        }

        public static List<CountryShortName> Counties()
        {
            if (countries == null)
            {
                countries=new List<CountryShortName>();
                var dist = CountryCode();
                foreach (var kv in dist)
                {
                    CountryShortName csn=new CountryShortName();
                    csn.Name = kv.Key;
                    csn.ShortName = kv.Value;
                    countries.Add(csn);
                }
            }

            return countries;
        }
        public static Dictionary<int, string> Sites()
        {
            if (sites == null)
            {
                sites=new Dictionary<int, string>();
                sites.Add(15,"Australia");
                sites.Add(16,"Austria");
                sites.Add(123,"Belgium_Dutch");
                sites.Add(23,"Belgium_French");
                sites.Add(2,"Canada");
                sites.Add(210,"CanadaFrench");
                sites.Add(100,"eBayMotors");
                sites.Add(71,"France");
                sites.Add(77,"Germany");
                sites.Add(201,"HongKong");
                sites.Add(203,"India");
                sites.Add(205,"Ireland");
                sites.Add(101,"Italy");
                sites.Add(207,"Malaysia");
                sites.Add(146,"Netherlands");
                sites.Add(211,"Philippines");
                sites.Add(212,"Poland");
                sites.Add(215,"Russia");
                sites.Add(216,"Singapore");
                sites.Add(186,"Spain");
                sites.Add(193,"Switzerland");
                sites.Add(3,"UK");
                sites.Add(0,"US");
            }
            return sites;
        }
    }
    public class CountryShortName
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}