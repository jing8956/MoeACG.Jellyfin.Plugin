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

    member val SeriesPattern = @"(?:��[^��]*��)? ?(?<seriesname>.*?) ?(?:[��ȫ��].��.*|\[[^\]]*].*|(?<=[ \p{IsCJKUnifiedIdeographs}])[1-9]$|SP.*|[��-��]|OAD|$)" with get, set
    member val SeasonPattern = @"(?:\[Nekomoe kissaten])\[(?<seriesname>.*?) S(?<seasonnumber>[1-9])].*|(?:��[^��]*��)? ?(?<seriesname>.*?) ?(?:��(?<seasonnumber>[һ�����������߰˾�ʮ1-9])��[ ]?|(?<=[ \-\p{IsCJKUnifiedIdeographs}]|^)(?<seasonnumber>[1-9])$|(?<seasonnumber>[��-��]))?(?:(?<specialSeason>SPs?|OAD|OVA|�糡��|\[��[���e]ƪ]|Extras)|��(?<seasonnumber>һ)��1998|\[[^\]]*].*|[TM]V|(?:1080|720)P|$)" with get, set
    member val EpisodePattern = "" with get, set
