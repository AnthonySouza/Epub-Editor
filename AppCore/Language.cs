using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epub_Editor.AppCore
{
    public enum Language
    {
        // English
        EN_US = 0, // United States
        EN_GB = 1, // United Kingdom
        EN_AU = 2, // Australia
        EN_CA = 3, // Canada
        EN_IN = 4, // India

        // Spanish
        ES_ES = 10, // Spain
        ES_MX = 11, // Mexico
        ES_AR = 12, // Argentina
        ES_CO = 13, // Colombia
        ES_US = 14, // United States

        // French
        FR_FR = 20, // France
        FR_CA = 21, // Canada
        FR_BE = 22, // Belgium

        // Portuguese
        PT_PT = 30, // Portugal
        PT_BR = 31, // Brazil

        // German
        DE_DE = 40, // Germany
        DE_AT = 41, // Austria
        DE_CH = 42, // Switzerland

        // Chinese
        ZH_CN = 50, // Simplified Chinese (China)
        ZH_TW = 51, // Traditional Chinese (Taiwan)
        ZH_HK = 52, // Traditional Chinese (Hong Kong)

        // Japanese
        JA_JP = 60, // Japan

        // Korean
        KO_KR = 70, // South Korea

        // Russian
        RU_RU = 80, // Russia

        // Italian
        IT_IT = 90, // Italy

        // Arabic
        AR_SA = 100, // Saudi Arabia
        AR_AE = 101, // United Arab Emirates

        // Hindi
        HI_IN = 110, // India

        // Others
        NL_NL = 120, // Dutch (Netherlands)
        SV_SE = 121, // Swedish (Sweden)
        DA_DK = 122, // Danish (Denmark)
        NO_NO = 123, // Norwegian (Norway)
        FI_FI = 124, // Finnish (Finland)
        TR_TR = 125, // Turkish (Turkey)
        PL_PL = 126, // Polish (Poland)
        HE_IL = 127, // Hebrew (Israel)
        TH_TH = 128, // Thai (Thailand)
    }
}
