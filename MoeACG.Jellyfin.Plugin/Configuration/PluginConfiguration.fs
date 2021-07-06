namespace MoeACG.Jellyfin.Plugin.Configuration

open System.Text.RegularExpressions
open MediaBrowser.Model.Plugins

type SomeOptions =
    | OneOption = 0
    | AnotherOption = 1

type PluginConfiguration() =
    inherit BasePluginConfiguration()
    member _.Version = typeof<PluginConfiguration>.Assembly.GetName().Version.ToString()
    // store configurable settings your plugin might need
    // member val TrueFalseSetting = true                      with get, set
    // member val AnInteger        = 2                         with get, set
    // member val AString          = "string"                  with get, set
    // member val Options          = SomeOptions.AnotherOption with get, set

    member val DefaultRegexOptions =  RegexOptions.IgnoreCase ||| RegexOptions.Compiled

    member val SeriesNameGroupName = "seriesname"
    member val SeasonNumberGroupName = "seasonnumber"
    member val EpisodeNumberGroupName = "epnumber"
    member val SpecialSeasonGroupName = "specialSeason"
    member val EpisodeNameGroupName = "episodename"

    member val SeriesPattern = 
        [| 
            @"(?:��[^��]*��)? ?(?<seriesname>.*?) ?(?:[��ȫ��].��.*|\[[^\]]*].*|(?<=[ \p{IsCJKUnifiedIdeographs}])[1-9]$|SP.*|[��-��]|OAD|$)" 
        |] with get, set
    member val SeasonPattern = 
        [| 
            @"(?:\[Nekomoe kissaten])\[(?<seriesname>.*?) S(?<seasonnumber>[1-9])].*|(?:��[^��]*��)? ?(?<seriesname>.*?) ?(?:��(?<seasonnumber>[һ�����������߰˾�ʮ1-9])��[ ]?|(?<=[ \-\p{IsCJKUnifiedIdeographs}]|^)(?<seasonnumber>[1-9])$|(?<seasonnumber>[��-��]))?(?:(?<specialSeason>SPs?|OAD|OVA|�糡��|\[��[���e]ƪ]|Extras)|��(?<seasonnumber>һ)��1998|\[[^\]]*].*|[TM]V|(?:1080|720)P|$)" 
        |] with get, set
    member val EpisodePattern = 
        [| 
            @"^(?:(?:EP|(?<specialSeason>OVA|SP))?(?<epnumber>[0-9.]+)?Y?(?:\[baha])?(?:[\. ](?<episodename>.*?))?\.[A-z1-9]+$"
            @"^(?:[[��](?<header>Nekomoe kissaten|LKSUB|UHA-WINGS|YG&Neo.sub|KTXP|�Ӯ���|HYSUB|UHA-WINGS|Nekomoe kissaten&VCB-Studio|BDRIP)[\]��]\[?\ ?(?:�͹� )?(?<seriesname>.+?)[\ \]]?(?:��(?<seasonnumber>[һ�����������߰˾�ʮ1-9])��[ ]?|[Ss](?<seasonnumber>[1-9]))?(?<specialSeason>\[�؄eƪ])?(?:\[���g���ư�])?(?:\ (?<epnumber>[0-9.]+)\ |]?\[(?<epnumber>[0-9.]+)])?(?:\[[^\]]*])*\.[A-z1-9]+$"
            @"^(?<seriesname>.+?)_(?<epnumber>[0-9.]+) \(480P\)_baofeng\.mp4$"
            @"^(?<seriesname>.+?)(?: S(?<seasonnumber>[1-9]))?(?: (?<epnumber>[0-9.]+))?(?: (?<specialSeason>OVA))?(?: END)? \[BD 1920x1080 HEVC-10bit OPUS ASSx2]\.mkv$"
            @"^\[(?<seriesname>.+?)]\[(?<specialSeason>OVA)]\[����]\[720P]\.mp4$"
            @"^����������(?<seriesname>.+?) ����\.mp4$"
            @"^(?<episodename>.+?)\.[A-z1-9]+$"
        |] with get, set

    member val VideoExtensions = 
        [|
            ".m4v";
            ".3gp";
            ".nsv";
            ".ts";
            ".ty";
            ".strm";
            ".rm";
            ".rmvb";
            ".ifo";
            ".mov";
            ".qt";
            ".divx";
            ".xvid";
            ".bivx";
            ".vob";
            ".nrg";
            ".img";
            ".iso";
            ".pva";
            ".wmv";
            ".asf";
            ".asx";
            ".ogm";
            ".m2v";
            ".avi";
            ".bin";
            ".dvr-ms";
            ".mpg";
            ".mpeg";
            ".mp4";
            ".mkv";
            ".avc";
            ".vp3";
            ".svq3";
            ".nuv";
            ".viv";
            ".dv";
            ".fli";
            ".flv";
            ".001";
            ".tp"
        |] with get, set
